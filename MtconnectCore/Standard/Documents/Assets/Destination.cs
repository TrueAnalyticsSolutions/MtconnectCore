using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Assets
{
    public class Destination : MtconnectNode
    {
        /// <inheritdoc cref="DestinationAttributes.DEVICE_UUID"/>
        [MtconnectNodeAttribute(DestinationAttributes.DEVICE_UUID)]
        public string DeviceUuid { get; set; }

        /// <inheritdoc />
        public Destination() : base() { }

        /// <inheritdoc/>
        public Destination(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }
    }
}
