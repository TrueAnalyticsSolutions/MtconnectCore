using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtcStreams = MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using MtconnectCore.Standard.Contracts.Enums.Devices;
using MtconnectCore.Standard.Contracts.Enums.Streams;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class Event : Value
    {
        public override CategoryTypes Category => CategoryTypes.EVENT;

        /// <summary>
        /// Collected from the resetTriggered attribute. Refer to Part 3 Streams - 5.5.2
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(MtcStreams.EventAttributes.RESET_TRIGGERED)]
        public string ResetTriggered { get; set; }

        /// <summary>
        /// Collected from the textcontent of the Event element. Refer to Part 3 Streams - 5.5.3
        /// </summary>
        [Obsolete]
        public virtual string Value {
            get {
                return Result;
            }
            set {
                Result = value;
            }
        }

        /// <inheritdoc/>
        public Event() : base() { }

        /// <inheritdoc/>
        public Event(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "See model.mtconnect.org/Observation Information Model/Event")]
        protected override bool validateNode(out ICollection<MtconnectValidationException> validationErrors)
            => base.validateNode(out validationErrors);

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "See model.mtconnect.org/Observation Information Model/Event")]
        protected override bool validateValue(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();

            if (string.IsNullOrEmpty(Result))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Observation '{DataItemId}' MUST include a result.",
                    SourceNode));
            } else if (Enum.TryParse<MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.EventTypes>(EnumHelper.FromPascalCase(Type), out MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.EventTypes type))
            {
                var eventFieldType = typeof(MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.EventTypes).GetField(EnumHelper.FromPascalCase(Type));
                var observationalValue = eventFieldType.GetCustomAttribute<ObservationalValueAttribute>();
                if (observationalValue != null)
                {
                    if (!EnumHelper.Contains(observationalValue.ValueEnum, Value))
                    {
                        validationErrors.Add(new MtconnectValidationException(
                            ValidationSeverity.ERROR,
                            $"Observation '{DataItemId}' result does not match expected values for EVENT type '{Type}'",
                            SourceNode));
                    }
                }
            }

            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "See model.mtconnect.org/Observation Information Model/Event")]
        protected bool validateResetTriggered(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(ResetTriggered))
            {
                if (!EnumHelper.Contains<ResetTriggeredValues>(ResetTriggered))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.ERROR,
                        $"Observation resetTriggered of '{ResetTriggered}' is not defined in the MTConnect Standard in version '{MtconnectVersion}'.",
                            SourceNode));
                }
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

    }
}
