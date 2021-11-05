using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
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
    }
}
