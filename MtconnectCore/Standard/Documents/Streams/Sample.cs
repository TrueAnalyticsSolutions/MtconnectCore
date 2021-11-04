using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class Sample : DataItem
    {
        /// <summary>
        /// Collected from the subType attribute. Refer to Part 3 Streams - 5.3.2
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(SampleAttributes.SUB_TYPE)]
        public string SubType { get; set; }

        /// <summary>
        /// Collected from the name attribute. Refer to Part 3 Streams - 5.3.2
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(SampleAttributes.NAME)]
        public string Name { get; set; }

        /// <summary>
        /// Collected from the sampleRate attribute. Refer to Part 3 Streams - 5.3.2
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(SampleAttributes.SAMPLE_RATE)]
        public double SampleRate { get; set; }

        /// <summary>
        /// Collected from the statistic attribute. Refer to Part 3 Streams - 5.3.2
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(SampleAttributes.STATISTIC)]
        public string Statistic { get; set; }

        /// <summary>
        /// Collected from the duration attribute. Refer to Part 3 Streams - 5.3.2
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(SampleAttributes.DURATION)]
        public double Duration { get; set; }

        /// <summary>
        /// Collected from the resetTriggered attribute. Refer to Part 3 Streams - 5.3.2
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(SampleAttributes.RESET_TRIGGERED)]
        public ResetTriggers ResetTriggered { get; set; }

        /// <summary>
        /// Collected from the compositionId attribute. Refer to Part 3 Streams - 5.3.2
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(SampleAttributes.COMPOSITION_ID)]
        public string CompositionId { get; set; }

        /// <summary>
        /// Collected from the textcontent of the Sample element. Refer to Part 3 Streams - 5.3.3
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Reference to the name of the element. Refer to Part 3 Streams - 5.3
        /// </summary>
        public string TagName { get; set; }

        /// <inheritdoc/>
        public Sample() : base() { }

        /// <inheritdoc/>
        public Sample(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version)
        {
            Value = xNode.InnerText;
            TagName = xNode.LocalName;
        }
    }
}
