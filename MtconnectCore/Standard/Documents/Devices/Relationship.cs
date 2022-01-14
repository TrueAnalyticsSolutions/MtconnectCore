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
    public abstract class Relationship : MtconnectNode
    {
        /// <inheritdoc cref="RelationshipAttributes.ID"/>
        [MtconnectNodeAttribute(RelationshipAttributes.ID)]
        public abstract string Id { get; set; }

        /// <inheritdoc cref="RelationshipAttributes.NAME"/>
        [MtconnectNodeAttribute(RelationshipAttributes.NAME)]
        public abstract string Name { get; set; }

        /// <inheritdoc cref="RelationshipAttributes.TYPE"/>
        [MtconnectNodeAttribute(RelationshipAttributes.TYPE)]
        public abstract string Type { get; set; }

        /// <inheritdoc cref="RelationshipAttributes.CRITICALITY"/>
        [MtconnectNodeAttribute(RelationshipAttributes.CRITICALITY)]
        public abstract string Criticality { get; set; }


        /// <inheritdoc />
        public Relationship() : base() { }

        /// <inheritdoc />
        public Relationship(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE, version) { }


        private bool validateId(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Id))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Relationship MUST include a unique 'id' attribute."));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        private bool validateType(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Relationship MUST include a 'type' attribute."));
            }

            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
