using System;
using System.Text;
using System.Xml;

namespace MtconnectCore.Standard.Contracts
{
    internal static partial class XmlHelper
    {
        internal static string TryGetAttribute(this XmlNode xNode, string attributeName, string defaultValue = null, string ns = null)
        {
            XmlAttribute attr;
            if (!string.IsNullOrEmpty(ns))
            {
                attr = xNode.Attributes[attributeName, ns];
            }
            else
            {
                attr = xNode.Attributes[attributeName];
            }
            if (attr != null)
            {
                return attr.Value ?? defaultValue;
            }
            return defaultValue;
        }

        internal static string TryGetAttribute<TEnum>(this XmlNode xNode, TEnum attributeName, string defaultValue = null, string ns = null) where TEnum : Enum => xNode.TryGetAttribute(attributeName.ToCamelCase(), defaultValue, ns);

        internal static XmlNodeList SelectNodes(this XmlNode xNode, string elementName, XmlNamespaceManager nsmgr, string ns) => xNode?.SelectNodes($"{ns}:{elementName}", nsmgr) ?? new EmptyNodeList();

        internal static XmlNodeList SelectNodes<TEnum>(this XmlNode xNode, TEnum elementName, XmlNamespaceManager nsmgr, string ns) where TEnum : Enum => xNode?.SelectNodes(elementName.ToPascalCase(), nsmgr, ns) ?? new EmptyNodeList();

        internal static XmlNodeList SelectNodes<TEnum>(this XmlNode xNode, TEnum elementName) where TEnum : Enum => xNode?.SelectNodes(elementName.ToPascalCase()) ?? new EmptyNodeList();

        internal static XmlNode SelectSingleNode(this XmlNode xNode, string elementName, XmlNamespaceManager nsmgr, string ns) => xNode.SelectSingleNode($"{ns}:{elementName}", nsmgr);

        internal static XmlNode SelectSingleNode<TEnum>(this XmlNode xNode, TEnum elementName, XmlNamespaceManager nsmgr, string ns) where TEnum : Enum => xNode.SelectSingleNode(elementName.ToPascalCase(), nsmgr, ns);

        internal static XmlNode SelectSingleNode<TEnum>(this XmlNode xNode, TEnum elementName) where TEnum : Enum => xNode.SelectSingleNode(elementName.ToPascalCase());
    }
}
