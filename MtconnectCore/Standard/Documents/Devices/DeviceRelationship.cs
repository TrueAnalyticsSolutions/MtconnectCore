using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    public class DeviceRelationship : Relationship
    {
        /// <inheritdoc cref="DeviceRelationshipAttributes.ID"/>
        [MtconnectNodeAttribute(DeviceRelationshipAttributes.ID)]
        public override string Id { get; set; }

        /// <inheritdoc cref="DeviceRelationshipAttributes.NAME"/>
        [MtconnectNodeAttribute(DeviceRelationshipAttributes.NAME)]
        public override string Name { get; set; }

        /// <inheritdoc cref="DeviceRelationshipAttributes.TYPE"/>
        [MtconnectNodeAttribute(DeviceRelationshipAttributes.TYPE)]
        public override string Type { get; set; }

        /// <inheritdoc cref="DeviceRelationshipAttributes.CRITICALITY"/>
        [MtconnectNodeAttribute(DeviceRelationshipAttributes.CRITICALITY)]
        public override string Criticality { get; set; }

        /// <inheritdoc cref="DeviceRelationshipAttributes.DEVICE_UUID_REF"/>
        [MtconnectNodeAttribute(DeviceRelationshipAttributes.DEVICE_UUID_REF)]
        public string DeviceUuidRef { get; set; }

        /// <inheritdoc cref="DeviceRelationshipAttributes.ROLE"/>
        [MtconnectNodeAttribute(DeviceRelationshipAttributes.ROLE)]
        public string Role { get; set; }

        /// <inheritdoc cref="DeviceRelationshipAttributes.HREF"/>
        [MtconnectNodeAttribute(DeviceRelationshipAttributes.HREF)]
        public string Href { get; set; }

        /// <summary>
        /// Type of <see cref="Href"/> fixed value locator.
        /// </summary>
        [MtconnectNodeAttribute("type", XmlNamespace = "xlink")]
        public string XlinkType { get; set; }

        /// <inheritdoc/>
        public DeviceRelationship() : base() { }

        /// <inheritdoc/>
        public DeviceRelationship(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr) { }


        private string[] validRoles = { "SYSTEM", "AUXILIARY" };

        /// <inheritdoc/>
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            const string documentationAttributes = "See Part 2 Section 9.2.1.1 of the MTConnect standard.";
            validationErrors = new List<MtconnectValidationException>();

            if (!base.TryValidate(out validationErrors)) {
                return false;
            }

            if (string.IsNullOrEmpty(DeviceUuidRef))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"DeviceRelationship MUST include a 'deviceUuidRef' attribute. {documentationAttributes}"));
            }
            
            if (!string.IsNullOrEmpty(Role) && !EnumHelper.Contains<DeviceRelationshipRoleTypes>(Role))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"DeviceRelationship 'role' MUST be one of the following types: [{EnumHelper.ToListString<DeviceRelationshipRoleTypes>(", ", string.Empty, string.Empty)}]. {documentationAttributes}"));
            }

            return !validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR);
        }
    }
}
