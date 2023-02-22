using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class Event : DataItem
    {
        /// <summary>
        /// Collected from the name attribute. Refer to Part 3 Streams - 5.5.2
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(EventAttributes.NAME)]
        public string Name { get; set; }

        /// <summary>
        /// Collected from the resetTriggered attribute. Refer to Part 3 Streams - 5.5.2
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(EventAttributes.RESET_TRIGGERED)]
        public ResetTriggers? ResetTriggered { get; set; }

        /// <summary>
        /// Collected from the compositionId attribute. Refer to Part 3 Streams - 5.5.2
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(EventAttributes.COMPOSITION_ID)]
        public string CompositionId { get; set; }

        /// <summary>
        /// Collected from the textcontent of the Event element. Refer to Part 3 Streams - 5.5.3
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Reference to the name of the element. Refer to Part 3 Streams - 5.5
        /// </summary>
        public string TagName { get; set; }

        /// <inheritdoc/>
        public Event() : base() { }

        /// <inheritdoc/>
        public Event(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version)
        {
            Value = xNode.InnerText;
            TagName = xNode.LocalName;
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8", MtconnectVersions.V_1_1_0)]
        protected bool validateName_Required(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Name))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"DataItem MUST include a 'name' attribute.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.8")]
        protected override bool validateNode(out ICollection<MtconnectValidationException> validationErrors)
            => validateNode<MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.EventTypes>(Contracts.Enums.Devices.CategoryTypes.EVENT, out validationErrors);

        protected override bool validateValue(out ICollection<MtconnectValidationException> validationErrors) => throw new System.NotImplementedException();
    }
}
