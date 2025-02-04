using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtcStreams = MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Xml;
using MtconnectCore.Validation;

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
    }
}
