using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <inheritdoc cref="TransformationElements"/>
    public class Transformation : MtconnectNode
    {
        /// <inheritdoc cref="TransformationElements.TRANSLATION"/>
        [MtconnectNodeElement(TransformationElements.TRANSLATION)]
        public string Translation { get; set; }

        /// <inheritdoc cref="TransformationElements.ROTATION"/>
        [MtconnectNodeElement(TransformationElements.ROTATION)]
        public string Rotation { get; set; }

        /// <inheritdoc />
        public Transformation() : base() { }

        /// <inheritdoc />
        public Transformation(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE, version) { }
    }
}
