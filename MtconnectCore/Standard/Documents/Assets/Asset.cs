using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Assets
{
    public abstract class Asset : MtconnectNode
    {
        /// <inheritdoc/>
        public Asset() : base() { }

        /// <inheritdoc/>
        public Asset(XmlNode xNode, XmlNamespaceManager nsmgr, string defaultNamespace) : base(xNode, nsmgr, defaultNamespace ?? Constants.DEFAULT_DEVICES_XML_NAMESPACE) { }

        /// <inheritdoc />
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors) => base.TryValidate(out validationErrors);
    }
}
