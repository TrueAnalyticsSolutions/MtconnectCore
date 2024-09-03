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
using MtconnectCore.Validation;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;

namespace MtconnectCore.Standard.Documents.Streams
{
    /// <summary>
    /// Observation that is a discrete piece of information from a piece of equipment.
    /// </summary>
    public class Event : Value
    {
        private const string MODEL_BROWSER_URL = "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531115_47447_25730";

        /// <inheritdoc />
        public override CategoryEnum Category => CategoryEnum.EVENT;

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
        [Obsolete("Use Result instead")]
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


        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.ObservationModel.EVENT)]
        private bool validateValueProperties(out ICollection<MtconnectValidationException> validationErrors)
            => new NodeValidationContext(this)
            // resetTriggered
            .ValidateValueProperty(
                MtcStreams.EventAttributes.RESET_TRIGGERED,
                (o) =>
                    o.IsImplemented(ResetTriggered)
                    ?.IsEnumValueType<ResetTriggeredEnum>(ResetTriggered, out _)
            )
            // result
            .Validate((o) =>
                o.ValidateEventObservationResult(Type, Result)
            )
            .UpdateHelpLinks(MODEL_BROWSER_URL)
            .HasError(out validationErrors);
        //{
        //    validationErrors = new List<MtconnectValidationException>();

        //    if (string.IsNullOrEmpty(Result))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Observation '{DataItemId}' MUST include a result.",
        //            SourceNode));
        //    } else if (Enum.TryParse<MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.EventTypes>(EnumHelper.FromPascalCase(Type), out MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.EventTypes type))
        //    {
        //        var eventFieldType = typeof(MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.EventTypes).GetField(EnumHelper.FromPascalCase(Type));
        //        var observationalValue = eventFieldType.GetCustomAttribute<ObservationalValueAttribute>();
        //        if (observationalValue != null)
        //        {
        //            if (!EnumHelper.Contains(observationalValue.ValueEnum, Result) && Result != Constants.UNAVAILABLE)
        //            {
        //                validationErrors.Add(new MtconnectValidationException(
        //                    ValidationSeverity.ERROR,
        //                    $"Observation '{DataItemId}' result does not match expected values for EVENT type '{Type}'",
        //                    SourceNode));
        //            }
        //        }
        //    }

        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "See model.mtconnect.org/Observation Information Model/Event")]
        //protected bool validateResetTriggered(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (!string.IsNullOrEmpty(ResetTriggered))
        //    {
        //        if (!EnumHelper.Contains<ResetTriggeredValues>(ResetTriggered))
        //        {
        //            validationErrors.Add(new MtconnectValidationException(
        //                ValidationSeverity.ERROR,
        //                $"Observation 'resetTriggered' of '{ResetTriggered}' is not defined in the MTConnect Standard in version '{MtconnectVersion}'.",
        //                    SourceNode));
        //        }
        //    }
        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}

    }
}
