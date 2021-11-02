using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Xml;

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
        /// Initializes a blank <see cref="IMtconnectNode"/> entity.
        /// </summary>
        public MtconnectNode() { }

        /// <summary>
        /// Initializes a <see cref="IMtconnectNode"/> entity from a MTConnect Response Document.
        /// </summary>
        /// <param name="xNode">Reference to a <see cref="XmlNode"/> as part of a larger MTConnect Response Document.</param>
        /// <param name="nsmgr">Reference to the </param>
        /// <param name="defaultNamespace"></param>
        public MtconnectNode(XmlNode xNode, XmlNamespaceManager nsmgr, string defaultNamespace)
        {
            SourceNode = xNode;

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

        /// <inheritdoc/>
        public virtual bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            return true;
        }
    }
}
