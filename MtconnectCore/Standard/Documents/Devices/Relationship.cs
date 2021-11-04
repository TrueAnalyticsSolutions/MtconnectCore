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

        /// <inheritdoc />
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            base.TryValidate(out validationErrors);

            const string documentationAttributes = "See Part 2 Section 9.2.1 of the MTConnect standard.";

            if (string.IsNullOrEmpty(Id))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Relationship MUST include a unique 'id' attribute. {documentationAttributes}"));
            }

            if (string.IsNullOrEmpty(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Relationship MUST include a 'type' attribute. {documentationAttributes}"));
            } else if (!EnumHelper.Contains<RelationshipTypes>(Type)) {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Relationship 'type' MUST be one of the following types: [{EnumHelper.ToListString<RelationshipTypes>(", ", string.Empty, string.Empty)}]. {documentationAttributes}"));
            }

            if (!string.IsNullOrEmpty(Criticality) && !EnumHelper.Contains<RelationshipTypes>(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Relationship 'criticality' MUST be one of the following types: [{EnumHelper.ToListString<RelationshipCriticalityTypes>(", ", string.Empty, string.Empty)}]. {documentationAttributes}"));
            }

            return !validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR);
        }
    }
}
