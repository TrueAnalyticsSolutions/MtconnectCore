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
    public class ComponentRelationship : ConfigurationRelationship
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

        /// <inheritdoc cref="ComponentRelationshipAttributes.ID_REF"/>
        [MtconnectNodeAttribute(ComponentRelationshipAttributes.ID_REF)]
        public string IdRef { get; set; }

        /// <inheritdoc />
        public ComponentRelationship() : base() { }

        /// <inheritdoc />
        public ComponentRelationship(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DeviceModel.COMPONENT)]
        private bool validateValueProperties(out ICollection<MtconnectValidationException> validationErrors)
            => new NodeValidationContext(this)
                // Validate idRef
                .ValidateValueProperty(
                    ComponentRelationshipAttributes.ID_REF,
                    (o) =>
                        o.IsImplemented(IdRef)
                        ?.WhileIntroduced((i) =>
                            i.IsRequired(IdRef)
                        )
                        ?.IsIdValueType(IdRef)
                )
                // Return validation errors
                .HasError(out validationErrors);
    }
}
