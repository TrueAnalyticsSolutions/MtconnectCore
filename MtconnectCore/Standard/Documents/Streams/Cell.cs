using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using System;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class Cell : MtconnectNode
    {
        /// <summary>
        /// Collected from the key attribute. Refer to Part 3 Streams - 5.6.5.3.5
        /// </summary>
        [MtconnectNodeAttribute(CellAttributes.KEY)]
        public string Key { get; set; }

        [Obsolete("Use Cell.Result instead")]
        public string Value {
            get {
                return Result;
            }
            set { Result = value; }
        }

        /// <summary>
        /// Collected from the textcontent of the Cell element. Refer to Part 3 Streams - 5.6.5.3.6
        /// </summary>
        public string Result { get; set; }

        /// <inheritdoc/>
        public Cell() : base() { }

        /// <inheritdoc/>
        public Cell(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE, version)
        {
            Result = xNode.InnerText;
        }
    }
}
