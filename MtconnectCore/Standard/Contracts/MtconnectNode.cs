using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace MtconnectCore.Standard.Contracts
{
    public abstract class MtconnectNode : IMtconnectNode
    {
        public MtconnectNode() { }

        public MtconnectNode(XmlNode xNode, XmlNamespaceManager nsmgr, string defaultNamespace)
        {
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
                        strAttributeValue = xNode.TryGetAttribute(attrAttr.GetName(MtconnectNodeNameProcessors.CamelCase), attrAttr.XmlNamespace);
                    }
                    else
                    {
                        strAttributeValue = xNode.TryGetAttribute(attrAttr.GetName(MtconnectNodeNameProcessors.CamelCase));
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
                        strElementValue = xNode.SelectSingleNode(elemAttr.GetName(MtconnectNodeNameProcessors.PascalCase), nsmgr, elemAttr.XmlNamespace)?.InnerText;
                    }
                    else
                    {
                        strElementValue = xNode.SelectSingleNode(elemAttr.GetName(MtconnectNodeNameProcessors.PascalCase))?.InnerText;
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
                        continue;
                    }

                    XmlNodeList xElems;// = xNode.HasChildNodes ? xNode.SelectNodes(elemsAttr.GetName(), nsmgr, "m") : null;
                    if (!string.IsNullOrEmpty(elemsAttr.XmlNamespace))
                    {
                        xElems = xNode.SelectNodes(elemsAttr.GetName(MtconnectNodeNameProcessors.PascalCase), nsmgr, defaultNamespace);
                    }
                    else
                    {
                        xElems = xNode.SelectNodes(elemsAttr.GetName(MtconnectNodeNameProcessors.PascalCase));
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

        public virtual bool IsValid()
        {
            return true;
        }
    }
}
