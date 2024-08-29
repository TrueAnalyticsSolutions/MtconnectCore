using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    public class DeviceRelationship : ConfigurationRelationship
    {
        /// <inheritdoc cref="ConfigurationRelationshipAttributes.ID"/>
        [MtconnectNodeAttribute(ConfigurationRelationshipAttributes.ID)]
        public override string Id { get; set; }

        /// <inheritdoc cref="ConfigurationRelationshipAttributes.NAME"/>
        [MtconnectNodeAttribute(ConfigurationRelationshipAttributes.NAME)]
        public override string Name { get; set; }

        /// <inheritdoc cref="ConfigurationRelationshipAttributes.TYPE"/>
        [MtconnectNodeAttribute(ConfigurationRelationshipAttributes.TYPE)]
        public override ParsedValue<RelationshipTypeEnum> Type { get; set; }

        /// <inheritdoc cref="ConfigurationRelationshipAttributes.CRITICALITY"/>
        [MtconnectNodeAttribute(ConfigurationRelationshipAttributes.CRITICALITY)]
        public override ParsedValue<CriticalityTypeEnum> Criticality { get; set; }

        /// <inheritdoc cref="DeviceRelationshipAttributes.DEVICE_UUID_REF"/>
        [MtconnectNodeAttribute(DeviceRelationshipAttributes.DEVICE_UUID_REF)]
        public string DeviceUuidRef { get; set; }

        /// <inheritdoc cref="DeviceRelationshipAttributes.ROLE"/>
        [MtconnectNodeAttribute(DeviceRelationshipAttributes.ROLE)]
        public ParsedValue<DeviceRelationshipRoleTypes> Role { get; set; }

        /// <inheritdoc cref="DeviceRelationshipAttributes.HREF"/>
        [MtconnectNodeAttribute(DeviceRelationshipAttributes.HREF)]
        public string Href { get; set; }

        /// <summary>
        /// Type of <see cref="Href"/> fixed value locator.
        /// </summary>
        [MtconnectNodeAttribute("type")]
        public string XlinkType { get; set; }

        /// <inheritdoc/>
        public DeviceRelationship() : base() { }

        /// <inheritdoc/>
        public DeviceRelationship(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 4.10.1")]
        private bool ValidateProperties(out ICollection<MtconnectValidationException> validationErrors)
        {
            return new NodeValidationContext(this)
                // Validate deviceUuidRef
                .ValidateValueProperty(
                    DeviceRelationshipAttributes.DEVICE_UUID_REF,
                    (o) =>
                        o.IsImplemented(DeviceUuidRef)
                        ?.WhileIntroduced((i) =>
                            i.IsRequired(DeviceUuidRef)
                        )
                )
                // Validate role
                .ValidateValueProperty(
                    DeviceRelationshipAttributes.ROLE,
                    (o) =>
                        o.IsImplemented(Role)
                        ?.IsEnumValueType(Role, out _)
                )
                // TODO: Add href
                // TODO: Add xlink:type
                // Return validation errors
                .HasError(out validationErrors);
        }

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 4.10.1")]
        //private bool validateId(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (string.IsNullOrEmpty(Id))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"ComponentRelationship MUST include a 'id' attribute."));
        //    }
        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}


        //[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 4.10.1")]
        //private bool validateDeviceUuidRef(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (string.IsNullOrEmpty(DeviceUuidRef))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"DeviceRelationship MUST include a 'deviceUuidRef' attribute."));
        //    }
        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 4.10.1")]
        //private bool validateRole(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (!string.IsNullOrEmpty(Role) && !EnumHelper.Contains<DeviceRelationshipRoleTypes>(Role))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"DeviceRelationship 'role' MUST be one of the following types: [{EnumHelper.ToListString<DeviceRelationshipRoleTypes>(", ", string.Empty, string.Empty)}]."));
        //    }
        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 4.10.1")]
        //private bool validateType(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (string.IsNullOrEmpty(Type))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, $"DeviceRelationship MUST include a 'type' attribute."));
        //    }
        //    else if (!EnumHelper.Contains<RelationshipTypeEnum>(Type))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.WARNING,
        //            $"DeviceRelationship type of '{Type}' is not defined in the MTConnect Standard in version '{MtconnectVersion}'."));
        //    }
        //    else if (!EnumHelper.IsImplemented<RelationshipTypeEnum>(Type, MtconnectVersion.GetValueOrDefault()))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.WARNING,
        //            $"DeviceRelationship type of '{Type}' is not supported in version '{MtconnectVersion}' of the MTConnect Standard."));
        //    }
        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 4.10.1")]
        //private bool validateCriticality(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (!string.IsNullOrEmpty(Criticality))
        //    {
        //        if (!EnumHelper.Contains<RelationshipTypeEnum>(Type))
        //        {
        //            validationErrors.Add(new MtconnectValidationException(
        //                ValidationSeverity.WARNING,
        //                $"DeviceRelationship criticality of '{Criticality}' is not defined in the MTConnect Standard in version '{MtconnectVersion}'."));
        //        }
        //        else if (!EnumHelper.IsImplemented<RelationshipTypeEnum>(Type, MtconnectVersion.GetValueOrDefault()))
        //        {
        //            validationErrors.Add(new MtconnectValidationException(
        //                ValidationSeverity.WARNING,
        //                $"DeviceRelationship criticality of '{Criticality}' is not supported in version '{MtconnectVersion}' of the MTConnect Standard."));
        //        }
        //    }
        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}
    }
}
