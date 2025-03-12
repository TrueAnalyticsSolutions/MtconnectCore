using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.InterfaceTypes;
using MtconnectCore.Validation;
using System;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    public class InterfaceState : DataItem
    {
        public InterfaceState() : base() { }

        public InterfaceState(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) :base(xNode, nsmgr, version) { }

        /// <summary>
        /// Validates the <see cref="Type"/> and <see cref="SubType"/> fields according to the standard DataItemEnum
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        protected override NodeValidationContext.NodeValidator ValidateTypeSubType(NodeValidationContext.NodeValueValidator<DataItemAttributes> o)
        => o.IsImplemented(Type)
            ?.IsImplemented(SubType)
            ?.IsRequired(Type)
            ?.IsEnumValueType<InterfaceTypes>(Type, out _);
    }
}
