using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using System.Xml;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class EventDiscrete : Event, IDiscrete
    {
        /// <summary>
        /// Description of a means to interpret data consisting of multiple data points or samples reported as a single value.
        /// </summary>
        [MtconnectNodeAttribute(DataItemAttributes.REPRESENTATION)]
        public override string Representation { get; set; } = RepresentationEnum.DISCRETE.ToString();

        /// <inheritdoc/>
        public EventDiscrete() : base() { }

        /// <inheritdoc/>
        public EventDiscrete(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }
    }
}
