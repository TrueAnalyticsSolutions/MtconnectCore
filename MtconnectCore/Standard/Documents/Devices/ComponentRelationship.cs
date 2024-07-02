using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    public class ComponentRelationship : Relationship
    {
        /// <inheritdoc cref="ComponentRelationshipAttributes.ID"/>
        [MtconnectNodeAttribute(ComponentRelationshipAttributes.ID)]
        public override string Id { get; set; }

        /// <inheritdoc cref="ComponentRelationshipAttributes.NAME"/>
        [MtconnectNodeAttribute(ComponentRelationshipAttributes.NAME)]
        public override string Name { get; set; }

        /// <inheritdoc cref="ComponentRelationshipAttributes.TYPE"/>
        [MtconnectNodeAttribute(ComponentRelationshipAttributes.TYPE)]
        public override string Type { get; set; }

        /// <inheritdoc cref="ComponentRelationshipAttributes.CRITICALITY"/>
        [MtconnectNodeAttribute(ComponentRelationshipAttributes.CRITICALITY)]
        public override string Criticality { get; set; }

        /// <inheritdoc cref="ComponentRelationshipAttributes.ID_REF"/>
        [MtconnectNodeAttribute(ComponentRelationshipAttributes.ID_REF)]
        public string IdRef { get; set; }

        /// <inheritdoc />
        public ComponentRelationship() : base() { }

        /// <inheritdoc />
        public ComponentRelationship(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 4.10.2")]
        private bool validateId(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Id))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"ComponentRelationship MUST include a 'id' attribute."));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 4.10.2")]
        private bool validateIdRef(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(IdRef))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"ComponentRelationship MUST include a 'idRef' attribute."));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 4.10.2")]
        private bool validateType(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Type))
            {
                validationErrors.Add(new MtconnectValidationException(ValidationSeverity.ERROR, $"ComponentRelationship MUST include a 'type' attribute."));
            }
            else if (!EnumHelper.Contains<RelationshipTypes>(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.WARNING,
                    $"ComponentRelationship type of '{Type}' is not defined in the MTConnect Standard in version '{MtconnectVersion}'."));
            }
            else if (!EnumHelper.IsImplemented<RelationshipTypes>(Type, MtconnectVersion.GetValueOrDefault()))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.WARNING,
                    $"ComponentRelationship type of '{Type}' is not supported in version '{MtconnectVersion}' of the MTConnect Standard."));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
