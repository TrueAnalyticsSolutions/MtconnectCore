using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <summary>
    /// DataItemRef XML element is a pointer to a Data Entity associated with another Structural Element defined elsewhere in the XML document for a piece of equipment. DataItemRef allows the data associated with a data item defined in another Structural Element to be directly associated with this XML element.
    /// </summary>
    public class DataItemRef : Reference
    {
        /// <inheritdoc cref="DataItemRefAttributes.ID_REF"/>
        [MtconnectNodeAttribute(DataItemRefAttributes.ID_REF)]
        public override string IdRef { get; set; }

        /// <inheritdoc cref="DataItemRefAttributes.NAME"/>
        [MtconnectNodeAttribute(DataItemRefAttributes.NAME)]
        public override string Name { get; set; }

        /// <inheritdoc />
        public DataItemRef() : base() { }

        /// <inheritdoc />
        public DataItemRef(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }
    }
}
