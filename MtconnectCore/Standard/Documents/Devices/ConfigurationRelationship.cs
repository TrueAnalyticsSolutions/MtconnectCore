using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    public abstract class ConfigurationRelationship : MtconnectNode
    {
        /// <inheritdoc cref="ConfigurationRelationshipAttributes.ID"/>
        [MtconnectNodeAttribute(ConfigurationRelationshipAttributes.ID)]
        public abstract string Id { get; set; }

        /// <inheritdoc cref="ConfigurationRelationshipAttributes.NAME"/>
        [MtconnectNodeAttribute(ConfigurationRelationshipAttributes.NAME)]
        public abstract string Name { get; set; }

        /// <inheritdoc cref="ConfigurationRelationshipAttributes.TYPE"/>
        [MtconnectNodeAttribute(ConfigurationRelationshipAttributes.TYPE)]
        public abstract ParsedValue<RelationshipTypeEnum> Type { get; set; }

        /// <inheritdoc cref="ConfigurationRelationshipAttributes.CRITICALITY"/>
        [MtconnectNodeAttribute(ConfigurationRelationshipAttributes.CRITICALITY)]
        public abstract ParsedValue<CriticalityTypeEnum> Criticality { get; set; }


        /// <inheritdoc />
        public ConfigurationRelationship() : base() { }

        /// <inheritdoc />
        public ConfigurationRelationship(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }


        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 4.6.2")]
        private bool ValidateProperties(out ICollection<MtconnectValidationException> validationErrors)
        {
            return new NodeValidationContext(this)
                // Validate name
                .ValidateValueProperty(
                    ConfigurationRelationshipAttributes.NAME,
                    (o) =>
                        o.IsImplemented(Name)
                )
                // Validate id
                .ValidateValueProperty(
                    ConfigurationRelationshipAttributes.ID,
                    (o) =>
                        o.IsImplemented(Id)
                        ?.WhileIntroduced((i) =>
                            i.IsRequired(Id)
                        )
                )
                // Validate type
                .ValidateValueProperty(
                    ConfigurationRelationshipAttributes.TYPE,
                    (o) =>
                        o.IsImplemented(Type)
                        ?.WhileIntroduced((i) =>
                            i.IsRequired(Type)
                        )
                        ?.IsEnumValueType(Type, out _)
                )
                // Validate criticality
                .ValidateValueProperty(
                    ConfigurationRelationshipAttributes.CRITICALITY,
                    (o) =>
                        o.IsImplemented(Criticality)
                        ?.IsEnumValueType(Criticality, out _)
                )
                // Return validation errors
                .HasError(out validationErrors);
        }

        //private bool validateId(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (string.IsNullOrEmpty(Id))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Relationship MUST include a unique 'id' attribute."));
        //    }
        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}

        //private bool validateType(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (string.IsNullOrEmpty(Type))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Relationship MUST include a 'type' attribute."));
        //    } else if (!EnumHelper.Contains<RelationshipTypeEnum>(Type)) {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Relationship 'type' MUST be one of the following types: [{EnumHelper.ToListString<RelationshipTypeEnum>(", ", string.Empty, string.Empty)}]."));
        //    }

        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}

        //private bool validateCriticality(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (!string.IsNullOrEmpty(Criticality) && !EnumHelper.Contains<RelationshipTypeEnum>(Type))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            Contracts.Enums.ValidationSeverity.ERROR,
        //            $"Relationship 'criticality' MUST be one of the following types: [{EnumHelper.ToListString<CriticalityTypeEnum>(", ", string.Empty, string.Empty)}]."));
        //    }
        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}
    }
}
