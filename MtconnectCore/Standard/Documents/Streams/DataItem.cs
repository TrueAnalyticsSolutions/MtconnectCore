using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using System;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    public abstract class DataItem : MtconnectNode, IDataItem
    {
        /// <summary>
        /// Collected from the dataItemId attribute. Refer to Part 3 Streams - 5.3.2, 5.5.2, 5.8.3
        /// 
        /// Occurance: 1
        /// </summary>
        [MtconnectNodeAttribute(SampleAttributes.DATA_ITEM_ID)]
        public string DataItemId { get; set; }

        /// <summary>
        /// Collected from the timestamp attribute. Refer to Part 3 Streams - 5.3.2, 5.5.2, 5.8.3
        /// 
        /// Occurance: 1
        /// </summary>
        [MtconnectNodeAttribute(SampleAttributes.TIMESTAMP)]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Collected from the sequence attribute. Refer to Part 3 Streams - 5.3.2, 5.5.2, 5.8.3
        /// 
        /// Occurance: 1
        /// </summary>
        [MtconnectNodeAttribute(SampleAttributes.SEQUENCE)]
        public int Sequence { get; set; }

        public DataItem() { }

        public DataItem(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE) { }

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(DataItemId)
                && Timestamp != null
                && Sequence > 0;
        }
    }
}
