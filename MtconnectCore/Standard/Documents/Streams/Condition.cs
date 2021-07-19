using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using System;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class Condition : DataItem
    {
        /// <summary>
        /// Collected from the name attribute. Refer to Part 3 Streams - 5.8.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(ConditionAttributes.NAME)]
        public string Name { get; set; }

        /// <summary>
        /// Collected from the type attribute. Refer to Part 3 Streams - 5.8.3
        /// 
        /// Occurance: 1
        /// </summary>
        [MtconnectNodeAttribute(ConditionAttributes.TYPE)]
        public string Type { get; set; }

        /// <summary>
        /// Collected from the nativeCode attribute. Refer to Part 3 Streams - 5.8.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(ConditionAttributes.NATIVE_CODE)]
        public string NativeCode { get; set; }

        /// <summary>
        /// Collected from the nativeSeverity attribute. Refer to Part 3 Streams - 5.8.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(ConditionAttributes.NATIVE_SEVERITY)]
        public string NativeSeverity { get; set; }

        /// <summary>
        /// Collected from the qualifier attribute. Refer to Part 3 Streams - 5.8.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(ConditionAttributes.QUALIFIER)]
        public string Qualifier { get; set; }

        /// <summary>
        /// Collected from the statistic attribute. Refer to Part 3 Streams - 5.8.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(ConditionAttributes.STATISTIC)]
        public string Statistic { get; set; }

        /// <summary>
        /// Collected from the subType attribute. Refer to Part 3 Streams - 5.8.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(ConditionAttributes.SUB_TYPE)]
        public string SubType { get; set; }

        /// <summary>
        /// Collected from the compositionId attribute. Refer to Part 3 Streams - 5.8.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(ConditionAttributes.COMPOSITION_ID)]
        public string CompositionId { get; set; }

        /// <summary>
        /// Collected from the xs:lang attribute. Refer to Part 3 Streams - 5.8.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute("lang", XmlNamespace = "xs")]
        public string Language { get; set; }

        /// <summary>
        /// Collected from the textcontent of the Event element. Refer to Part 3 Streams - 5.8.4
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Reference to the name of the element. Refer to Part 3 Streams - 5.8
        /// </summary>
        public ConditionElements TagName { get; set; }

        /// <inheritdoc/>
        public Condition() : base() { }

        /// <inheritdoc/>
        public Condition(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr)
        {
            Value = xNode.InnerText;
            if (Enum.TryParse<ConditionElements>(xNode.LocalName, out ConditionElements condition))
            {
                TagName = condition;
            }
        }
    }
}
