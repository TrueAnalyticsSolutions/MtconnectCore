using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Contracts
{
    public static class MtconnectNodeParser
    {
        private static ConcurrentDictionary<Type, XmlParser> TypeCache = new ConcurrentDictionary<Type, XmlParser>();

        public static XmlParser GetParser(Type type)
        {
            XmlParser parser;
            if (!TypeCache.TryGetValue(type, out parser))
            {
                parser = new XmlParser(type);
                TypeCache.TryAdd(parser.Type, parser);
            }
            return parser;
        }

        public static void UpdateFromXml<T>(this T item, XmlNode xmlNode, XmlNamespaceManager nsmgr, string defaultNamespace, MtconnectVersions version) where T : MtconnectNode
        {
            GetParser(item.GetType())?.Set(item, xmlNode, nsmgr, defaultNamespace, version);
        }

        public static XmlParser.XmlPropertyParser GetPropertyParser<T>(this T item, string propertyName) where T : MtconnectNode
        {
            if (!TypeCache.TryGetValue(item.GetType(), out XmlParser typeParser))
            {
                return null;
            }

            return typeParser[propertyName];
        }

        public static object ConstructItemFromXml(Type itemType, XmlNode xmlNode, XmlNamespaceManager nsmgr, MtconnectVersions version)
        {
            XmlParser xmlParser = GetParser(itemType);
            if (xmlParser?.Constructor == null || xmlParser?.ConstructorParameters?.Length != 3) return null;

            TypeCache.TryAdd(xmlParser.Type, xmlParser);

            if (xmlParser.ConstructorParameters?.Length != 3)
            {
                throw new NotSupportedException("Only constructors with (XmlNode, XmlNamespaceManager, MtconnectVersions) signatures are supported at this time.");
            }

            object[] parameters = new object[3] { xmlNode, nsmgr, version };
            Logger.Verbose("Reading {MtconnectNodeType}", itemType.Name);

            return xmlParser.Constructor.Invoke(parameters);
        }

        /// <summary>
        /// An in-memory class to maintain static references to the methods necessary for parsing the MTConnect XML into a <see cref="MtconnectNode"/>.
        /// </summary>
        public class XmlParser
        {
            /// <summary>
            /// Reference to the inherited <see cref="MtconnectNode"/> type.
            /// </summary>
            public Type Type { get; set; }

            public ConstructorInfo Constructor { get; set; }

            public ParameterInfo[] ConstructorParameters { get; set; }

            /// <summary>
            /// Collection of XML parsers for the <see cref="MtconnectNode"/> properties that can be parsed from XML.
            /// </summary>
            public IEnumerable<XmlPropertyParser> Properties { get; set; }

            private IEnumerable<MtconnectNodeValidator> ValidationMethods { get; set; }

            public XmlPropertyParser this[string propertyName] {
                get {
                    return Properties.FirstOrDefault(o => o.Property.Name == propertyName);
                }
                set {
                    var property = this[propertyName];
                    if (property != null)
                    {
                        property = value;
                    }
                }
            }

            /// <summary>
            /// Constructs a new XmlParser based on the provided type.
            /// </summary>
            /// <param name="type">Reference to the <see cref="MtconnectNode"/> type.</param>
            public XmlParser(Type type)
            {
                Type = type;

                Constructor = Type.GetConstructors()?.FirstOrDefault(o => o.GetParameters()?.Length > 0);
                ConstructorParameters = Constructor?.GetParameters();

                PropertyInfo[] properties = Type.GetProperties();
                List<XmlPropertyParser> xmlParsers = new List<XmlPropertyParser>();
                foreach (PropertyInfo property in properties)
                {
                    var parser = new XmlPropertyParser(Type, property);
                    if (parser.ParseMethodAttribute != null || parser.IsOfMtconnectNode || parser.IsCollectionOfMtconnectNode)
                    {
                        xmlParsers.Add(parser);
                    }
                }
                Properties = xmlParsers;

                List<MtconnectNodeValidator> validators = new List<MtconnectNodeValidator>();
                Type validationAttribute = typeof(MtconnectVersionApplicabilityAttribute);
                Type expectedOutType = typeof(ICollection<MtconnectValidationException>);
                MethodInfo[] methods = Type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
                    .Where(o => !o.IsSpecialName)
                    .Where(o => o.ReturnType == typeof(bool))
                    .Where(o => o.GetCustomAttributes(validationAttribute)?.Any() == true)
                    .ToArray();
                foreach (MethodInfo method in methods)
                {
                    if (method.ReturnType != typeof(bool))
                        throw new InvalidOperationException("Cannot execute MTConnect validation method that does not have a return type of boolean.");

                    ParameterInfo[] parameters = method.GetParameters();
                    if (parameters.Length > 1)
                        throw new NotSupportedException("MTConnect validation method does not support more than one parameter at this time.");

                    Type genericTypeDefinition = parameters.FirstOrDefault(o => o.IsOut)
                        ?.ParameterType
                        ?.GetElementType();
                    if (genericTypeDefinition == null || genericTypeDefinition != expectedOutType)
                        throw new InvalidOperationException("Cannot execute MTConnect validation method that does not have an output of ICollection<MtconnectValidationException>.");

                    var validator = new MtconnectNodeValidator(method);
                    if (validator.ApplicibilityAttributes?.Any() == true)
                    {
                        validators.Add(validator);
                    }
                }
                ValidationMethods = validators;
            }

            public void Set<T>(T obj, XmlNode node, XmlNamespaceManager nsmgr, string defaultNamespace, MtconnectVersions version) where T : MtconnectNode
            {
                foreach (var propertyParser in Properties)
                {
                    propertyParser.Set(obj, node, nsmgr, defaultNamespace, version);
                }
            }

            public bool TryValidate<T>(T item, ValidationReport report = null) where T : MtconnectNode
            {
                using (var validationContext = new ValidationContext(report, item))
                {
                    // Validate this type based on the local validation methods
                    foreach (var validationMethod in ValidationMethods)
                    {
                        bool validationResult = validationMethod.TryValidate(item, out ICollection<MtconnectValidationException> errors);
                        if (errors?.Any() == true)
                        {
                            validationContext.AddExceptions(errors.ToArray());
                        }
                    }

                    // Validate this type based on the child entities
                    foreach (var property in Properties)
                    {
                        object propertyValue = property.Property.GetValue(item);
                        if (propertyValue == null) continue;

                        if (property.IsCollectionOfMtconnectNode)
                        {
                            IEnumerable<MtconnectNode> typedPropertyValue = (IEnumerable<MtconnectNode>)propertyValue;
                            if (typedPropertyValue?.Any() == true)
                            {
                                foreach (var nodeItem in typedPropertyValue)
                                {
                                    nodeItem.TryValidate(report);
                                }
                            }
                        }
                        else if (property.IsOfMtconnectNode)
                        {
                            MtconnectNode typedPropertyValue = (MtconnectNode)propertyValue;
                            if (typedPropertyValue != null)
                            {
                                typedPropertyValue.TryValidate(report);
                            }
                        }
                    }

                    return !validationContext.HasErrors();
                }
            }

            /// <summary>
            /// An in-memory class to maintain static references to the methods necessary for parsing a MTConnect XML node into the property of a <see cref="MtconnectNode"/>.
            /// </summary>
            public class XmlPropertyParser
            {
                /// <summary>
                /// Reference to the inherited <see cref="MtconnectNode"/> type.
                /// </summary>
                public Type Type { get; set; }

                /// <summary>
                /// Reference to the source property for this Xml-based property.
                /// </summary>
                public PropertyInfo Property { get; set; }

                /// <summary>
                /// Method for which the MTConnect Response Document should be processed to fill this property.
                /// </summary>
                public Attribute ParseMethodAttribute { get; set; }

                public bool IsOfMtconnectNode { get; set; }

                public bool IsCollectionOfMtconnectNode { get; set; }

                /// <summary>
                /// Constructs a new <see cref="XmlPropertyParser" /> based on the provided <paramref name="property"/> in the provided <paramref name="sourceType"/>.
                /// </summary>
                /// <param name="sourceType">Reference to the inherited <see cref="MtconnectNode"/> type.</param>
                /// <param name="property">Reference to the source property for this Xml-based property.</param>
                public XmlPropertyParser(Type sourceType, PropertyInfo property)
                {
                    Type = sourceType;
                    Property = property;

                    Type mtconnectNodeType = typeof(MtconnectNode);
                    Func<PropertyInfo, bool> isCollectionOfMtconnectNode = (p) => p.PropertyType.IsGenericType && (
                            p.PropertyType.GetGenericArguments().Any(g => mtconnectNodeType.IsAssignableFrom(g))
                        )
                        || p.PropertyType.IsArray && (
                            mtconnectNodeType.IsAssignableFrom(p.PropertyType.GetElementType())
                        );
                    IsOfMtconnectNode = Property.PropertyType.IsSubclassOf(mtconnectNodeType);
                    IsCollectionOfMtconnectNode = isCollectionOfMtconnectNode(Property);

                    MtconnectNodeAttributeAttribute attrAttr = Property.GetCustomAttribute<MtconnectNodeAttributeAttribute>(true);
                    if (attrAttr != null)
                    {
                        ParseMethodAttribute = attrAttr;
                        propertyConverter = TypeDescriptor.GetConverter(Property.PropertyType);
                    }

                    MtconnectNodeElementAttribute elemAttr = property.GetCustomAttribute<MtconnectNodeElementAttribute>(true);
                    if (elemAttr != null)
                    {
                        ParseMethodAttribute = elemAttr;
                        propertyConverter = TypeDescriptor.GetConverter(Property.PropertyType);

                        targetConstructor = Property.PropertyType.GetConstructors().FirstOrDefault(o => o.GetParameters().Length > 0);
                        if (targetConstructor == null)
                        {
                            ParseMethodAttribute = null; // Make this invalid
                        }
                        targetConstructorParameters = targetConstructor.GetParameters();
                        if (targetConstructorParameters.Length != 3)
                        {
                            ParseMethodAttribute = null; // Make this invalid
                        }
                    }

                    MtconnectNodeElementsAttribute elemsAttr = property.GetCustomAttribute<MtconnectNodeElementsAttribute>(true);
                    if (elemsAttr != null)
                    {
                        ParseMethodAttribute = elemsAttr;
                        tryAddMethod = Type.GetMethod(elemsAttr.TryAddMethod);
                        tryAddParameters = tryAddMethod?.GetParameters();

                        var targetType = tryAddParameters?.FirstOrDefault(o => o.IsOut)?.ParameterType?.GetElementType();
                        var targetTypeConstructors = targetType?.GetConstructor(new Type[] { });
                        targetConstructor = targetType?.GetConstructor(new Type[] { typeof(XmlNode), typeof(XmlNamespaceManager), typeof(MtconnectVersions) });
                        if (targetConstructor == null)
                        {
                            ParseMethodAttribute = null; // Make this invalid
                        }
                        targetConstructorParameters = targetConstructor?.GetParameters();
                        if (targetConstructorParameters?.Length != 3)
                        {
                            ParseMethodAttribute = null; // Make this invalid
                        }

                    }
                }

                /// <summary>
                /// Sets the parsed value from the <paramref name="node"/> into the <see cref="Property"/> of the provided <paramref name="obj"/>.
                /// </summary>
                /// <param name="obj">Reference to the object to update.</param>
                /// <param name="node">Reference to the MTConnect XML node to parse.</param>
                /// <param name="nsmgr"></param>
                /// <param name="defaultNamespace"></param>
                /// <param name="version"></param>
                public void Set<T>(T obj, XmlNode node, XmlNamespaceManager nsmgr, string defaultNamespace, MtconnectVersions version) where T : MtconnectNode 
                {
                    if (ParseMethodAttribute is MtconnectNodeAttributeAttribute)
                    {
                        _setFromAttribute(obj, node, nsmgr, defaultNamespace, version);
                    } else if (ParseMethodAttribute is MtconnectNodeElementAttribute)
                    {
                        _setFromElement(obj, node, nsmgr, defaultNamespace, version);
                    } else if (ParseMethodAttribute is MtconnectNodeElementsAttribute)
                    {
                        _setFromElements(obj, node, nsmgr, defaultNamespace, version);
                    }
                }

                internal TypeConverter propertyConverter;
                private void _setFromAttribute<T>(T obj, XmlNode node, XmlNamespaceManager nsmgr, string defaultNamespace, MtconnectVersions version) where T : MtconnectNode
                {
                    if (propertyConverter == null)
                    {
                        throw new MissingMethodException($"Cannot find property converter.");
                    }

                    MtconnectNodeAttributeAttribute attr = (MtconnectNodeAttributeAttribute)ParseMethodAttribute;

                    string nodeValue;
                    if (!string.IsNullOrEmpty(attr.XmlNamespace))
                    {
                        nodeValue = node.TryGetAttribute(attr.GetName(MtconnectNodeNameProcessors.CamelCase), attr.XmlNamespace);
                    }
                    else
                    {
                        nodeValue = node.TryGetAttribute(attr.GetName(MtconnectNodeNameProcessors.CamelCase));
                    }
                    if (!string.IsNullOrEmpty(nodeValue))
                    {
                        Property.SetValue(obj, propertyConverter.ConvertFromString(nodeValue));
                    }
                }

                private void _setFromElement<T>(T obj, XmlNode node, XmlNamespaceManager nsmgr, string defaultNamespace, MtconnectVersions version) where T : MtconnectNode
                {
                    if (propertyConverter == null)
                    {
                        throw new MissingMethodException($"Cannot find property converter.");
                    }

                    MtconnectNodeElementAttribute attr = (MtconnectNodeElementAttribute)ParseMethodAttribute;

                    string nodeValue;
                    if (!string.IsNullOrEmpty(attr.XmlNamespace))
                    {
                        nodeValue = node.SelectSingleNode(attr.GetName(MtconnectNodeNameProcessors.PascalCase), nsmgr, attr.XmlNamespace)?.InnerText;
                    }
                    else
                    {
                        nodeValue = node.SelectSingleNode(attr.GetName(MtconnectNodeNameProcessors.PascalCase))?.InnerText;
                    }
                    if (!string.IsNullOrEmpty(nodeValue))
                    {
                        Property.SetValue(obj, propertyConverter.ConvertFromString(nodeValue));
                    }
                }

                internal MethodInfo tryAddMethod;
                internal ParameterInfo[] tryAddParameters;
                internal ConstructorInfo targetConstructor;
                internal ParameterInfo[] targetConstructorParameters;
                private void _setFromElements<T>(T obj, XmlNode node, XmlNamespaceManager nsmgr, string defaultNamespace, MtconnectVersions version) where T : MtconnectNode
                {
                    MtconnectNodeElementsAttribute attr = (MtconnectNodeElementsAttribute)ParseMethodAttribute;

                    if (tryAddMethod == null)
                    {
                        throw new MissingMethodException($"Cannot find method '{attr.TryAddMethod}'");
                    }

                    XmlNodeList xElems;// = xNode.HasChildNodes ? xNode.SelectNodes(elemsAttr.GetName(), nsmgr, "m") : null;
                    if (!string.IsNullOrEmpty(attr.XmlNamespace))
                    {
                        xElems = node.SelectNodes(attr.GetName(MtconnectNodeNameProcessors.PascalCase), nsmgr, attr.XmlNamespace);
                    }
                    else if (!string.IsNullOrEmpty(defaultNamespace))
                    {
                        xElems = node.SelectNodes(attr.GetName(MtconnectNodeNameProcessors.PascalCase), nsmgr, defaultNamespace);
                    }
                    else
                    {
                        xElems = node.SelectNodes(attr.GetName(MtconnectNodeNameProcessors.PascalCase));
                    }

                    if (xElems?.Count > 0)
                    {
                        bool hasOut = tryAddParameters.Any(o => o.IsOut);
                        foreach (XmlNode xElem in xElems)
                        {
                            List<object> @params = new List<object>();
                            foreach (ParameterInfo paramInfo in tryAddParameters)
                            {
                                if (paramInfo.ParameterType == typeof(XmlNode))
                                {
                                    @params.Add(xElem);
                                }
                                else if (paramInfo.ParameterType == typeof(XmlNamespaceManager))
                                {
                                    @params.Add(nsmgr);
                                }
                                else if (paramInfo.IsOut)
                                {
                                    @params.Add(null);
                                }
                                else
                                {
                                    @params.Add(null);
                                }
                            }
                            object result = tryAddMethod.Invoke(obj, @params.ToArray());
                            if (tryAddMethod.ReturnType == typeof(bool) && hasOut && bool.TryParse(result.ToString(), out bool blnResult))
                            {
                                if (blnResult)
                                {

                                }
                                else
                                {

                                }
                            }
                        }
                    }
                }
            }
        
            public class MtconnectNodeValidator
            {
                public MethodInfo ValidationMethod { get; set; }

                public MtconnectVersionApplicabilityAttribute[] ApplicibilityAttributes { get; set; }

                public MtconnectNodeValidator(MethodInfo method)
                {
                    ValidationMethod = method;
                    ApplicibilityAttributes = method.GetCustomAttributes<MtconnectVersionApplicabilityAttribute>(true).ToArray();
                }

                public bool TryValidate(MtconnectNode item, out ICollection<MtconnectValidationException> validationErrors)
                {
                    validationErrors = new List<MtconnectValidationException>();

                    // If none of the Applicibility attributes apply to the version associated with this node, then all should be good, right?
                    if (!ApplicibilityAttributes.Any(o => o.Compare(item.MtconnectVersion.GetValueOrDefault()))) return true;

                    object[] parameters = new object[] { null };
                    bool methodResult;
                    try
                    {
                        methodResult = (bool)ValidationMethod.Invoke(item, parameters);
                        if ((parameters[0] as ICollection<MtconnectValidationException>)?.Any() == true)
                        {
                            foreach (var methodError in (parameters[0] as ICollection<MtconnectValidationException>))
                            {
                                validationErrors.Add(methodError);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("MTConnect validation method failed to execute.", ex);
                    }

                    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
                }
            }
        }
    }
}
