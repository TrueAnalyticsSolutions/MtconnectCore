using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System.Collections.Generic;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    public class CellDefinition : MtconnectNode
    {
        /// <inheritdoc cref="CellDefinitionAttributes.UNITS"/>
        [MtconnectNodeAttribute(CellDefinitionAttributes.UNITS)]
        public string Units { get; set; }

        /// <inheritdoc cref="CellDefinitionAttributes.KEY"/>
        [MtconnectNodeAttribute(CellDefinitionAttributes.KEY)]
        public string Key { get; set; }

        /// <inheritdoc cref="CellDefinitionAttributes.TYPE"/>
        [MtconnectNodeAttribute(CellDefinitionAttributes.TYPE)]
        public string Type { get; set; }

        /// <inheritdoc cref="CellDefinitionAttributes.SUB_TYPE"/>
        [MtconnectNodeAttribute(CellDefinitionAttributes.SUB_TYPE)]
        public string SubType { get; set; }

        /// <inheritdoc cref="CellDefinitionAttributes.KEY_TYPE"/>
        [MtconnectNodeAttribute(CellDefinitionAttributes.KEY_TYPE)]
        public string KeyType { get; set; }

        [MtconnectNodeElement(CellDefinitionElements.DESCRIPTION)]
        public string Description { get; set; }

        /// <inheritdoc/>
        public CellDefinition() : base() { }

        /// <inheritdoc/>
        public CellDefinition(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DeviceModel.CELL_DEFINITION)]
        private bool validateValueProperties(out ICollection<MtconnectValidationException> validationErrors)
            => new NodeValidationContext(this)
                // units
                .ValidateValueProperty<CellDefinitionAttributes>(nameof(CellDefinitionAttributes.UNITS), (o) =>
                    o.IsImplemented(Units)
                    ?.IsEnumValueType<UnitEnum>(Units, out _)
                )
                // key
                .ValidateValueProperty<CellDefinitionAttributes>(nameof(CellDefinitionAttributes.KEY), (o) =>
                    o.IsImplemented(Key)
                )
                // type/subType
                .ValidateValueProperty<CellDefinitionAttributes>(nameof(CellDefinitionAttributes.TYPE), (o) =>
                    o.IsImplemented(Type)
                    ?.ValidateType(Type, SubType)
                )
                // keyType
                .ValidateValueProperty<CellDefinitionAttributes>(nameof(CellDefinitionAttributes.KEY_TYPE), (o) =>
                    o.IsImplemented(KeyType)
                    ?.ValidateType(KeyType, string.Empty)
                )
                .HasError(out validationErrors);
    }
}
