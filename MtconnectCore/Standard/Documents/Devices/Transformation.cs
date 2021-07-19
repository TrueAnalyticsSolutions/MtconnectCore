using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
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

        /// <inheritdoc cref="MtconnectNode.MtconnectNode()"/>
        public Transformation() : base() { }

        /// <inheritdoc cref="MtconnectNode.MtconnectNode(XmlNode, XmlNamespaceManager, string)"/>
        public Transformation(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE) { }
    }
}
