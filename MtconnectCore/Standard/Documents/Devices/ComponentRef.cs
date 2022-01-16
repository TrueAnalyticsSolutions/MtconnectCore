using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <summary>
    /// ComponentRef XML element is a pointer to all of the information associated with another Structural Element defined elsewhere in the XML document for a piece of equipment. ComponentRef allows all of the information (Lower Level Components and all Data Entities) that is associated with the other Structural Element to be directly associated with this XML element.
    /// </summary>
    public class ComponentRef : Reference
    {
        /// <inheritdoc cref="ComponentRefAttributes.ID_REF"/>
        [MtconnectNodeAttribute(ComponentRefAttributes.ID_REF)]
        public override string IdRef { get; set; }

        /// <inheritdoc cref="ComponentRefAttributes.NAME"/>
        [MtconnectNodeAttribute(ComponentRefAttributes.NAME)]
        public override string Name { get; set; }

        /// <inheritdoc/>
        public ComponentRef() : base() { }

        /// <inheritdoc/>
        public ComponentRef(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        //protected override bool validateIdRef(out ICollection<MtconnectValidationException> validationErrors) => base.validateIdRef(out validationErrors);
    }
}
