using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Contracts
{
    /// <summary>
    /// Represents the most basic form of a MTConnect Response Document XML node. Used for parsing a MTConnect Response Document.
    /// </summary>
    public abstract class MtconnectNode : IMtconnectNode
    {
        /// <summary>
        /// Reference to the Source XmlNode.
        /// </summary>
        internal XmlNode SourceNode { get; set; }

        /// <summary>
        /// Reference to the version of the MTConnect Standard implemented on the MTConnect Response Document.
        /// </summary>
        internal MtconnectVersions? MtconnectVersion { get; set; }

        /// <summary>
        /// A collection of Validation exceptions that are raised during initialization of a MTConnect node.
        /// </summary>
        internal List<MtconnectValidationException> InitializationErrors { get; set; } = new List<MtconnectValidationException>();

        /// <summary>
        /// Initializes a blank <see cref="IMtconnectNode"/> entity.
        /// </summary>
        public MtconnectNode() { }

        /// <summary>
        /// Initializes a <see cref="IMtconnectNode"/> entity from a MTConnect Response Document.
        /// </summary>
        /// <param name="xNode">Reference to a <see cref="XmlNode"/> as part of a larger MTConnect Response Document.</param>
        /// <param name="nsmgr">Reference to the </param>
        /// <param name="defaultNamespace"></param>
        public MtconnectNode(XmlNode xNode, XmlNamespaceManager nsmgr, string defaultNamespace, MtconnectVersions version)
        {
            SourceNode = xNode;
            MtconnectVersion = version;

            Type thisType = this.GetType();
            PropertyInfo[] properties = thisType.GetProperties();
            Type nodeAttribute = typeof(MtconnectNodeAttributeAttribute);
            foreach (PropertyInfo property in properties)
            {
                MtconnectNodeAttributeAttribute attrAttr = property.GetCustomAttribute<MtconnectNodeAttributeAttribute>(true);
                if (attrAttr != null)
                {
                    string strAttributeValue;
                    if (!string.IsNullOrEmpty(attrAttr.XmlNamespace))
                    {
                        strAttributeValue = SourceNode.TryGetAttribute(attrAttr.GetName(MtconnectNodeNameProcessors.CamelCase), attrAttr.XmlNamespace);
                    }
                    else
                    {
                        strAttributeValue = SourceNode.TryGetAttribute(attrAttr.GetName(MtconnectNodeNameProcessors.CamelCase));
                    }
                    if (!string.IsNullOrEmpty(strAttributeValue))
                    {
                        var attributePropertyConverter = TypeDescriptor.GetConverter(property.PropertyType);
                        if (attributePropertyConverter != null)
                        {
                            property.SetValue(this, attributePropertyConverter.ConvertFromString(strAttributeValue));
                        }
                    }
                }

                MtconnectNodeElementAttribute elemAttr = property.GetCustomAttribute<MtconnectNodeElementAttribute>(true);
                if (elemAttr != null)
                {
                    string strElementValue;
                    if (!string.IsNullOrEmpty(elemAttr.XmlNamespace))
                    {
                        strElementValue = SourceNode.SelectSingleNode(elemAttr.GetName(MtconnectNodeNameProcessors.PascalCase), nsmgr, elemAttr.XmlNamespace)?.InnerText;
                    }
                    else
                    {
                        strElementValue = SourceNode.SelectSingleNode(elemAttr.GetName(MtconnectNodeNameProcessors.PascalCase))?.InnerText;
                    }
                    if (!string.IsNullOrEmpty(strElementValue))
                    {
                        var attributePropertyConverter = TypeDescriptor.GetConverter(property.PropertyType);
                        if (attributePropertyConverter != null)
                        {
                            property.SetValue(this, attributePropertyConverter.ConvertFromString(strElementValue));
                        }
                    }
                }

                MtconnectNodeElementsAttribute elemsAttr = property.GetCustomAttribute<MtconnectNodeElementsAttribute>(true);
                if (elemsAttr != null)
                {
                    MethodInfo tryAddMethod = thisType.GetMethod(elemsAttr.TryAddMethod);
                    if (tryAddMethod == null)
                    {
                        throw new MissingMethodException($"Cannot find method '{elemsAttr.TryAddMethod}'");
                    }

                    XmlNodeList xElems;// = xNode.HasChildNodes ? xNode.SelectNodes(elemsAttr.GetName(), nsmgr, "m") : null;
                    if (!string.IsNullOrEmpty(elemsAttr.XmlNamespace))
                    {
                        xElems = SourceNode.SelectNodes(elemsAttr.GetName(MtconnectNodeNameProcessors.PascalCase), nsmgr, elemsAttr.XmlNamespace);
                    }
                    else if (!string.IsNullOrEmpty(defaultNamespace))
                    {
                        xElems = SourceNode.SelectNodes(elemsAttr.GetName(MtconnectNodeNameProcessors.PascalCase), nsmgr, defaultNamespace);
                    }
                    else
                    {
                        xElems = SourceNode.SelectNodes(elemsAttr.GetName(MtconnectNodeNameProcessors.PascalCase));
                    }

                    if (xElems?.Count > 0)
                    {
                        ParameterInfo[] paramInfos = tryAddMethod.GetParameters();
                        bool hasOut = paramInfos.Any(o => o.IsOut);
                        foreach (XmlNode xElem in xElems)
                        {
                            List<object> @params = new List<object>();
                            foreach (ParameterInfo paramInfo in paramInfos)
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
                            object result = tryAddMethod.Invoke(this, @params.ToArray());
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
        }

        public bool TryAdd<T>(XmlNode xNode, XmlNamespaceManager nsmgr, ref List<T> array, out T item) where T : MtconnectNode {
            Type type = typeof(T);
            ConstructorInfo ctor = type.GetConstructors().FirstOrDefault(o => o.GetParameters().Length > 0);
            ParameterInfo[] ctorParameters = ctor?.GetParameters();
            if (ctorParameters?.Length == 3) {
                object[] parameters = new object[3] { xNode, nsmgr, MtconnectVersion.GetValueOrDefault() };
                Logger.Verbose("Reading {MtconnectNodeType}", type.Name);
                item = (T)ctor.Invoke(parameters);
                if (item != null) {
                    if (!item.TryValidate(out ICollection<MtconnectValidationException> validationExceptions)) {
                        Logger.Warn("[Invalid MtconnectNode] Parsing type '{MtconnectNodeType}' from XmlNode '{XnodeName}':\r\n{ValidationExceptions}", type.Name, xNode.LocalName, ExceptionHelper.ToString(validationExceptions));
                        InitializationErrors.AddRange(validationExceptions);
                        return false;
                    }
                    array.Add(item);
                    return true;
                } else {
                    throw new InvalidCastException($"Could not cast item to type '{type.Name}'");
                }
            } else {
                throw new NotSupportedException("Only constructors with (XmlNode, XmlNamespaceManager, MtconnectVersions) signatures are supported at this time.");
            }
            item = null;
            return false;
        }

        public bool TrySet<T>(XmlNode xNode, XmlNamespaceManager nsmgr, string propertyName, out T item) where T : MtconnectNode
        {
            PropertyInfo updateProperty = this.GetType().GetProperty(propertyName);
            if (updateProperty == null) {
                throw new ArgumentException($"Could not find property '{propertyName}' in '{this.GetType().Name}'.");
            }
            Type type = typeof(T);
            ConstructorInfo ctor = type.GetConstructors().FirstOrDefault(o => o.GetParameters().Length > 0);
            ParameterInfo[] ctorParameters = ctor?.GetParameters();
            if (ctorParameters?.Length == 3)
            {
                object[] parameters = new object[3] { xNode, nsmgr, MtconnectVersion.GetValueOrDefault() };
                Logger.Verbose("Reading {MtconnectNodeType}", type.Name);
                item = (T)ctor.Invoke(parameters);
                if (item != null)
                {
                    if (!item.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
                    {
                        Logger.Warn("[Invalid MtconnectNode] Parsing type '{MtconnectNodeType}' from XmlNode '{XnodeName}':\r\n{ValidationExceptions}", type.Name, xNode.LocalName, ExceptionHelper.ToString(validationExceptions));
                        InitializationErrors.AddRange(validationExceptions);
                        return false;
                    }
                    updateProperty.SetValue(this, item);
                    return true;
                }
                else
                {
                    throw new InvalidCastException($"Could not cast item to type '{type.Name}'");
                }
            }
            else
            {
                throw new NotSupportedException("Only constructors with (XmlNode, XmlNamespaceManager, MtconnectVersions) signatures are supported at this time.");
            }
            item = null;
            return false;
        }

        /// <inheritdoc/>
        public virtual bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = InitializationErrors;// new List<MtconnectValidationException>();

            Type thisType = this.GetType();

            // Execute validation methods on this object
            if (MtconnectVersion.HasValue)
            {
                MethodInfo[] methods = thisType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
                    .Where(o => !o.IsSpecialName)
                    .Where(o => o.ReturnType == typeof(bool))
                    //.Where(o => o.GetParameters().FirstOrDefault(p => p.IsOut && p.ParameterType == typeof(ICollection<MtconnectValidationException>)) != null)
                    .ToArray();
                Type validationAttribute = typeof(MtconnectValidationMethodAttribute);
                foreach (MethodInfo method in methods)
                {
                    var methodValidations = method.GetCustomAttributes<MtconnectValidationMethodAttribute>(true);
                    if (methodValidations.Any(o => o.Version == MtconnectVersion.Value))
                    {
                        // Verify correct signature
                        ParameterInfo outParam = method.GetParameters().FirstOrDefault(o => o.IsOut);
                        Type? genericTypeDefinition = outParam.ParameterType.GetElementType();
                        if (method.ReturnType != typeof(bool))
                        {
                            throw new InvalidOperationException("Cannot execute MTConnect validation method that does not have a return type of boolean.");
                        } else if (genericTypeDefinition != null && genericTypeDefinition != typeof(ICollection<MtconnectValidationException>)) {
                            throw new InvalidOperationException("Cannot execute MTConnect validation method that does not have an output of ICollection<MtconnectValidationException>.");
                        } else if (method.GetParameters().Length > 1) {
                            throw new NotSupportedException("MTConnect validation method does not support more than one parameter at this time.");
                        }

                        // Execute method
                        object[] parameters = new object[] { null };
                        bool methodResult;
                        try
                        {
                            methodResult = (bool)method.Invoke(this, parameters);
                            if ((parameters[0] as ICollection<MtconnectValidationException>)?.Any() == true) {
                                foreach (MtconnectValidationException methodError in (parameters[0] as ICollection<MtconnectValidationException>))
                                {
                                    validationErrors.Add(methodError);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("MTConnect validation method failed to execute.", ex);
                        }
                    } else {
                        // No applicable Validation Methods for the currently implemented version of the standard
                    }
                }
            }

            // Execute validation methods on MtconnectNode children
            PropertyInfo[] properties = thisType.GetProperties();
            Type mtconnectNodeType = typeof(MtconnectNode);
            Func<PropertyInfo, bool> isCollectionOfMtconnectNode = (p) => p.PropertyType.IsGenericType && (
                    p.PropertyType.GetGenericArguments().Any(g => mtconnectNodeType.IsAssignableFrom(g))
                )
                || p.PropertyType.IsArray && (
                    mtconnectNodeType.IsAssignableFrom(p.PropertyType.GetElementType())
                );
            PropertyInfo[] mtconnectNodeProperties = properties.Where(o =>
                    mtconnectNodeType.IsAssignableFrom(o.PropertyType)
                    || isCollectionOfMtconnectNode(o)
                ).ToArray();
            foreach (var property in mtconnectNodeProperties)
            {
                object? propertyValue = property.GetValue(this);
                if (propertyValue != null)
                {
                    if (isCollectionOfMtconnectNode(property))
                    {
                        IEnumerable<MtconnectNode> typedPropertyValue = (IEnumerable<MtconnectNode>)propertyValue;
                        if (typedPropertyValue != null)
                        {
                            foreach (MtconnectNode nodeItem in typedPropertyValue)
                            {
                                nodeItem.TryValidate(out ICollection<MtconnectValidationException> propertyErrors);
                                if (propertyErrors?.Any() == true)
                                {
                                    foreach (var propertyError in propertyErrors)
                                    {
                                        validationErrors.Add(propertyError);
                                    }
                                }
                            }
                        } else {
                            System.Diagnostics.Debug.WriteLine("Failed to case property value to IEnumerable<MtconnectNode>.");
                        }
                    }
                    else
                    {
                        MtconnectNode typedPropertyValue = (MtconnectNode)propertyValue;
                        if (typedPropertyValue != null)
                        {
                            typedPropertyValue.TryValidate(out ICollection<MtconnectValidationException> propertyErrors);
                            if (propertyErrors?.Any() == true)
                            {
                                foreach (var propertyError in propertyErrors)
                                {
                                    validationErrors.Add(propertyError);
                                }
                            }
                        } else {
                            System.Diagnostics.Debug.WriteLine("Failed to case property value to MtconnectNode.");
                        }
                    }
                }
            }

            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
