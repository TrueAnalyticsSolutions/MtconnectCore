﻿using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <summary>
    /// Specification elements define information describing the design characteristics for a piece of equipment.
    /// </summary>
    /// <remarks>See Part 2 Section 9.3.1 of the MTConnect specification</remarks>
    public class Specification : MtconnectNode
    {
        /// <inheritdoc cref="SpecificationAttributes.TYPE"/>
        [MtconnectNodeAttribute(SpecificationAttributes.TYPE)]
        public string Type { get; set; }

        /// <inheritdoc cref="SpecificationAttributes.SUB_TYPE"/>
        [MtconnectNodeAttribute(SpecificationAttributes.SUB_TYPE)]
        public string SubType { get; set; }

        /// <inheritdoc cref="SpecificationAttributes.DATA_ITEM_ID_REF"/>
        [MtconnectNodeAttribute(SpecificationAttributes.DATA_ITEM_ID_REF)]
        public string DataItemIdRef { get; set; }

        /// <inheritdoc cref="SpecificationAttributes.UNITS"/>
        [MtconnectNodeAttribute(SpecificationAttributes.UNITS)]
        public string Units { get; set; }

        /// <inheritdoc cref="SpecificationAttributes.COMPOSITION_ID_REF"/>
        [MtconnectNodeAttribute(SpecificationAttributes.COMPOSITION_ID_REF)]
        public string CompositionIdRef { get; set; }

        /// <inheritdoc cref="SpecificationAttributes.NAME"/>
        [MtconnectNodeAttribute(SpecificationAttributes.NAME)]
        public string Name { get; set; }

        /// <inheritdoc cref="SpecificationAttributes.COORDINATE_SYSTEM_ID_REF"/>
        [MtconnectNodeAttribute(SpecificationAttributes.COORDINATE_SYSTEM_ID_REF)]
        public string CoordinateSystemIdRef { get; set; }

        /// <inheritdoc cref="SpecificationAttributes.ID"/>
        [MtconnectNodeAttribute(SpecificationAttributes.ID)]
        public string Id { get; set; }

        /// <inheritdoc cref="SpecificationAttributes.ORIGINATOR"/>
        [MtconnectNodeAttribute(SpecificationAttributes.ORIGINATOR)]
        public string Originator { get; set; }

        /// <inheritdoc cref="SpecificationElements.MINIMUM"/>
        [MtconnectNodeElement(SpecificationElements.MINIMUM)]
        public double? Minimum { get; set; }

        /// <inheritdoc cref="SpecificationElements.NOMINAL"/>
        [MtconnectNodeElement(SpecificationElements.NOMINAL)]
        public double? Nominal { get; set; }

        /// <inheritdoc cref="SpecificationElements.MAXIMUM"/>
        [MtconnectNodeElement(SpecificationElements.MAXIMUM)]
        public double? Maximum { get; set; }

        /// <inheritdoc />
        public Specification() : base() { }

        /// <inheritdoc />
        public Specification(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE, version) { }


        private bool validateType(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();

            var version = MtconnectVersion.GetValueOrDefault();

            if (string.IsNullOrEmpty(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Specification MUST include a 'type' attribute.",
                    SourceNode));
            }
            else if (!EnumHelper.Contains<SampleTypes>(Type) && !EnumHelper.Contains<EventTypes>(Type) && !EnumHelper.Contains<ConditionTypes>(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Specification type of '{Type}' is not defined in the MTConnect Standard for SAMPLE, EVENT, nor CONDITION in version '{version}'.",
                    SourceNode));
            }
            else if (!EnumHelper.ValidateToVersion<SampleTypes>(Type, version) && !EnumHelper.ValidateToVersion<EventTypes>(Type, version) && !EnumHelper.ValidateToVersion<ConditionTypes>(Type, version))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.WARNING,
                    $"Specification type of '{Type}' is not valid for SAMPLE, EVENT, nor CONDITION in version '{version}' of the MTConnect Standard.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        // TODO: Validate SubTypes

        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.1.1")]
        protected bool validateUnits(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();

            var version = MtconnectVersion.GetValueOrDefault();

            if (!string.IsNullOrEmpty(Units) && !EnumHelper.Contains<UnitsTypes>(Units))
            {
                if (!EnumHelper.Contains<UnitsTypes>(Units))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.ERROR,
                        $"Specification units of '{Units}' is not defined in the MTConnect Standard in version '{version}'.",
                        SourceNode));
                } else if (!EnumHelper.ValidateToVersion<UnitsTypes>(Units, version))
                {
                    validationErrors.Add(new MtconnectValidationException(
                        ValidationSeverity.ERROR,
                        $"Specification units '{Units}' not valid for version {version}.",
                        SourceNode));
                }
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.3.1.1")]
        protected bool validateOriginator(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(Originator) && !EnumHelper.Contains<Originators>(Originator))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Specification 'originator' attribute must be one of the following: [{EnumHelper.ToListString<Originators>(", ", string.Empty, string.Empty)}].",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
