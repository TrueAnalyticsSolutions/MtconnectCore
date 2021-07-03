using System;
using System.Linq;
using System.Text;
using System.Xml;

namespace MtconnectCore.Standard.Contracts
{
    public static partial class XmlHelper
    {
        public static string ToCamelCase(this Enum enumValue) => enumValue.ToString().ToCamelCase('_');
        public static string ToPascalCase(this Enum enumValue) => enumValue.ToString().ToPascalCase('_');

        public static string ToCamelCase(this string input, char delimiter = '_')
        {
            string[] parts = input.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 1)
            {
                return parts[0].ToLower();
            }
            else if (parts.Length > 1)
            {
                return parts[0].ToLower() + string.Join("", parts.Skip(1).Select(o => WordToPascalCase(o)).ToArray());
            }
            return string.Empty;
        }

        public static string ToPascalCase(this string input, char delimiter = '_')
        {
            string[] parts = input.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 0)
            {
                return string.Join("", parts.Select(o => WordToPascalCase(o)).ToArray());
            }
            return string.Empty;
        }

        public static string WordToPascalCase(string input) => input.Length > 1 ? input.Substring(0, 1).ToUpper() + input.Substring(1).ToLower() : input.ToUpper();


        public static string TryGetAttribute(this XmlNode xNode, string attributeName, string defaultValue = null, string ns = null)
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

        public static string TryGetAttribute<TEnum>(this XmlNode xNode, TEnum attributeName, string defaultValue = null, string ns = null) where TEnum : Enum => xNode.TryGetAttribute(attributeName.ToCamelCase(), defaultValue, ns);

        public static XmlNodeList SelectNodes(this XmlNode xNode, string elementName, XmlNamespaceManager nsmgr, string ns) => xNode?.SelectNodes($"{ns}:{elementName}", nsmgr) ?? new EmptyNodeList();

        public static XmlNodeList SelectNodes<TEnum>(this XmlNode xNode, TEnum elementName, XmlNamespaceManager nsmgr, string ns) where TEnum : Enum => xNode?.SelectNodes(elementName.ToPascalCase(), nsmgr, ns) ?? new EmptyNodeList();

        public static XmlNodeList SelectNodes<TEnum>(this XmlNode xNode, TEnum elementName) where TEnum : Enum => xNode?.SelectNodes(elementName.ToPascalCase()) ?? new EmptyNodeList();

        public static XmlNode SelectSingleNode(this XmlNode xNode, string elementName, XmlNamespaceManager nsmgr, string ns) => xNode.SelectSingleNode($"{ns}:{elementName}", nsmgr);

        public static XmlNode SelectSingleNode<TEnum>(this XmlNode xNode, TEnum elementName, XmlNamespaceManager nsmgr, string ns) where TEnum : Enum => xNode.SelectSingleNode(elementName.ToPascalCase(), nsmgr, ns);

        public static XmlNode SelectSingleNode<TEnum>(this XmlNode xNode, TEnum elementName) where TEnum : Enum => xNode.SelectSingleNode(elementName.ToPascalCase());
    }
}
