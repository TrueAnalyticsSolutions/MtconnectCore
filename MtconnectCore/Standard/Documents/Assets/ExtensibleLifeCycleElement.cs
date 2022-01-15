using MtconnectCore.Standard.Contracts.Enums;
using System.Collections.Generic;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Assets
{
    /// <summary>
    /// An extensible XML element that utilizes the xs: namespace in a MTConnect Response Document.
    /// </summary>
    public class ExtensibleLifeCycleElement {
        /// <summary>
        /// Name of the extensible XML element.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Collection of attributes and their values.
        /// </summary>
        public Dictionary<string, string> Attributes = new Dictionary<string, string>();

        /// <summary>
        /// The value of the extensible XML element.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Constructs a blank ExtensibleLifeCycleElement
        /// </summary>
        public ExtensibleLifeCycleElement() : base() { }

        /// <summary>
        /// Constructs an ExtensibleLifeCycleElement from an XML node.
        /// </summary>
        /// <param name="xNode">Reference to the XML node.</param>
        /// <param name="nsmgr">Reference to the namespace manager.</param>
        /// <param name="version">Reference the version of the MTConnect Standard implemented on the Response Document.</param>
        public ExtensibleLifeCycleElement(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version)
        {
            Name = xNode.LocalName;
            for (int i = 0; i < xNode.Attributes.Count; i++)
            {
                Attributes.Add(xNode.Attributes[i].LocalName, xNode.Attributes[i].Value);
            }

            Value = xNode.InnerText;
        }
    }
}
