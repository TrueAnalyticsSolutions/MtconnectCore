using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System.Collections.Generic;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    /// <summary>
    /// abstract entity that provides telemetry data for a  DataItem at a point in time.
    /// </summary>
    public abstract class Observation : MtconnectNode, IObservation
    {
        private const string MODEL_BROWSER_URL = "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579566531115_47734_25731";

        public abstract CategoryEnum Category { get; }

        /// <inheritdoc cref="ObservationAttributes.COMPOSITION_ID"/>
        [MtconnectNodeAttribute(ObservationAttributes.COMPOSITION_ID)]
        public string CompositionId { get; internal set; }

        /// <inheritdoc cref="ObservationAttributes.DATA_ITEM_ID"/>
        [MtconnectNodeAttribute(ObservationAttributes.DATA_ITEM_ID)]
        public string DataItemId { get; internal set; }

        /// <inheritdoc cref="ObservationAttributes.NAME"/>
        [MtconnectNodeAttribute(ObservationAttributes.NAME)]
        public string Name { get; internal set; }

        /// <inheritdoc cref="ObservationAttributes.SEQUENCE"/>
        [MtconnectNodeAttribute(ObservationAttributes.SEQUENCE)]
        public string Sequence { get; set; }

        /// <inheritdoc cref="ObservationAttributes.SUB_TYPE"/>
        [MtconnectNodeAttribute(ObservationAttributes.SUB_TYPE)]
        public string SubType { get; internal set; }

        /// <inheritdoc cref="ObservationAttributes.TIMESTAMP"/>
        [MtconnectNodeAttribute(ObservationAttributes.TIMESTAMP)]
        public string Timestamp { get; set; }

        /// <inheritdoc cref="ObservationAttributes.TYPE"/>
        [MtconnectNodeAttribute(ObservationAttributes.TYPE)]
        public string Type { get; internal set; }

        /// <inheritdoc cref="ObservationAttributes.UNITS"/>
        [MtconnectNodeAttribute(ObservationAttributes.UNITS)]
        public string Units { get; internal set; }

        /// <inheritdoc cref="ObservationAttributes.IS_UNAVAILABLE"/>
        [MtconnectNodeAttribute(ObservationAttributes.IS_UNAVAILABLE)]
        public virtual bool IsUnavailable { get; } = true;

        /// <inheritdoc cref="ObservationAttributes.RESULT"/>
        [MtconnectNodeAttribute(ObservationAttributes.RESULT)]
        public virtual string Result { get; set; }

        /// <summary>
        /// Reference to the name of the element. Refer to Part 3 Streams - 5.5
        /// </summary>
        public string TagName { get; set; }

        /// <inheritdoc/>
        public Observation() : base() { }

        /// <inheritdoc/>
        public Observation(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version)
        {
            Result = xNode.InnerText;
            TagName = xNode.LocalName;

            if (string.IsNullOrEmpty(Type) && Category != CategoryEnum.CONDITION)
            {
                if (TagName.EndsWith("DataSet"))
                {
                    Type = TagName.Substring(0, TagName.LastIndexOf("DataSet"));
                }
                else if (TagName.EndsWith("Table"))
                {
                    Type = TagName.Substring(0, TagName.LastIndexOf("Table"));
                }
                else if (TagName.EndsWith("TimeSeries"))
                {
                    Type = TagName.Substring(0, TagName.LastIndexOf("TimeSeries"));
                }
                else
                {
                    Type = TagName;
                }
            }
        }


        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL)]
        private bool validateValueProperties(out ICollection<MtconnectValidationException> validationErrors)
            => new NodeValidationContext(this)
            // compositionId
            .ValidateValueProperty<ObservationAttributes>(nameof(ObservationAttributes.COMPOSITION_ID), (o) =>
                o.IsImplemented(CompositionId)
                ?.IsIdValueType(CompositionId, false)
            )
            // dataItemId
            .ValidateValueProperty<ObservationAttributes>(nameof(ObservationAttributes.DATA_ITEM_ID), (o) =>
                o.WhileIntroduced((x) =>
                    x.IsIdValueType(DataItemId)
                )
                ?.WhileNotIntroduced((x) =>
                    x.IsIdValueType(DataItemId, false)
                )
            )
            // name
            .ValidateValueProperty<ObservationAttributes>(nameof(ObservationAttributes.NAME), (o) =>
                o.IsImplemented(Name)
            )
            // sequence
            .ValidateValueProperty<ObservationAttributes>(nameof(ObservationAttributes.SEQUENCE), (o) =>
                o.WhileIntroduced((x) =>
                    x.IsImplemented()
                    .IsRequired(Sequence)
                )
                ?.WhileNotIntroduced((x) =>
                    x.IsImplemented(Sequence)
                )
                ?.IsUIntValueType(Sequence, out _)
                ?.IsUIntWithinRange(Sequence, 1, (2^64) - 1)
            )
            // type/subType
            .ValidateValueProperty<ObservationAttributes>(nameof(ObservationAttributes.TYPE), (o) =>
                o.IsImplemented(Type)
                ?.IsRequired(Type)
                ?.ValidateType(Category.ToString(), Type, SubType)
            )
            // timestamp
            .ValidateValueProperty<ObservationAttributes>(nameof(ObservationAttributes.TIMESTAMP), (o) =>
                o.IsImplemented(Timestamp)
                ?.IsRequired(Timestamp)
                ?.IsDateTimeValueType(Timestamp, out _)
            )
            // units
            .ValidateValueProperty<ObservationAttributes>(nameof(ObservationAttributes.UNITS), (o) =>
                o.IsImplemented(Units)
                ?.IsEnumValueType<UnitEnum>(Units, out _)
            )
            .UpdateHelpLinks(MODEL_BROWSER_URL)
            .HasError(out validationErrors);
    }
}
