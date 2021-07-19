using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
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

        /// <inheritdoc cref="MtconnectNode.MtconnectNode()"/>
        public ComponentRelationship() : base() { }

        /// <inheritdoc cref="MtconnectNode.MtconnectNode(XmlNode, XmlNamespaceManager, string)"/>
        public ComponentRelationship(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr) { }


        /// <inheritdoc/>
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            const string documentationAttributes = "See Part 2 Section 9.2.1.1 of the MTConnect standard.";
            validationErrors = new List<MtconnectValidationException>();

            if (!base.TryValidate(out validationErrors))
            {
                return false;
            }

            if (string.IsNullOrEmpty(IdRef))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"ComponentRelationship MUST include a 'idRef' attribute. {documentationAttributes}"));
            }

            return !validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR);
        }
    }
}
