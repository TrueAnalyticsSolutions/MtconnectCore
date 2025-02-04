using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System.Collections.Generic;
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
    }
}
