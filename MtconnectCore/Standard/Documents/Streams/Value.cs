﻿using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System;
using System.Collections.Generic;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    /// <summary>
    /// Default representation type for all Observation Types where <c>result</c> of the Observation  Types is an MTConnect data type.
    /// </summary>
    public abstract class Value : Observation, IRepresentation
    {
        /// <summary>
        /// Description of a means to interpret data consisting of multiple data points or samples reported as a single value.
        /// </summary>
        [MtconnectNodeAttribute(DataItemAttributes.REPRESENTATION)]
        public virtual string Representation { get; set; } = RepresentationEnum.VALUE.ToString();

        public override bool IsUnavailable
            => string.IsNullOrEmpty(Result) || Result.Equals(Constants.UNAVAILABLE, StringComparison.OrdinalIgnoreCase);

        public Value() : base() { }

        public Value(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "See model.mtconnect.org/Observation Information Model/Representations/Value")]
        protected virtual bool ValidateProperties(out ICollection<MtconnectValidationException> validationErrors)
        {
            return new NodeValidationContext(this)
                // Validate Representation property
                .ValidateValueProperty<DataItemAttributes>(nameof(Representation), (o) =>
                    o.IsImplemented(Representation)
                    ?.IsEnumValueType<RepresentationEnum>(Representation, out _)
                )
                // Return validation errors
                .HasError(out validationErrors);
        }
    }
}
