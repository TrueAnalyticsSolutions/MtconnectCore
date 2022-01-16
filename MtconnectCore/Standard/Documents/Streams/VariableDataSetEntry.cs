using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class VariableDataSetEntry : MtconnectNode
    {
        /// <summary>
        /// Collected from the key attribute. Refer to Part 3 Streams - 5.6.3.3
        /// 
        /// Occurance: 1
        /// </summary>
        [MtconnectNodeAttribute(VariableDataSetEntryAttributes.KEY)]
        public string Key { get; set; }

        /// <summary>
        /// Collected from the removed attribute. Refer to Part 3 Streams - 5.6.3.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(VariableDataSetEntryAttributes.REMOVED)]
        public bool Removed { get; set; }

        /// <summary>
        /// Collected from the textcontent of the Entry element. Refer to Part 3 Streams - 5.6.3.3
        /// </summary>
        public string Value { get; set; }

        /// <inheritdoc/>
        public VariableDataSetEntry() { }

        /// <inheritdoc/>
        public VariableDataSetEntry(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE, version)
        {
            Value = xNode.InnerText;
        }

    }
}
