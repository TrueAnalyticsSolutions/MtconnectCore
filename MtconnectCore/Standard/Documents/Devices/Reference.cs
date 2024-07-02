using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <summary>
    /// Reference is a pointer to information that is associated with another Structural Element defined elsewhere in the XML document for a piece of equipment.That information may be data from the other element or the entire structure of that element.
    /// </summary>
    public abstract class Reference : MtconnectNode
    {
        /// <inheritdoc cref="ReferenceAttributes.ID_REF"/>
        [MtconnectNodeAttribute(ReferenceAttributes.ID_REF)]
        public abstract string IdRef { get; set; }

        /// <inheritdoc cref="ReferenceAttributes.NAME"/>
        [MtconnectNodeAttribute(ReferenceAttributes.NAME)]
        public abstract string Name { get; set; }

        /// <inheritdoc cref="ReferenceAttributes.DATA_ITEM_ID"/>
        [MtconnectNodeAttribute(ReferenceAttributes.DATA_ITEM_ID)]
        public string DataItemId { get; set; }

        /// <inheritdoc cref="ReferenceAttributes.REF_DATA_ITEM_ID"/>
        [MtconnectNodeAttribute(ReferenceAttributes.REF_DATA_ITEM_ID)]
        public string RefDataItemId { get; set; }

        /// <inheritdoc/>
        public Reference() : base() { }

        /// <inheritdoc/>
        public Reference(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE, version) { }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.COMPONENT)]
        protected virtual bool validateValueProperties(out ICollection<MtconnectValidationException> validationErrors)
            => new NodeValidationContext(this)
                // idRef
                .ValidateValueProperty<ReferenceAttributes>(nameof(ReferenceAttributes.ID_REF), (o) =>
                    o.WhileIntroduced((x) =>
                        x.IsImplemented()
                        .IsIdValueType(IdRef)
                    )
                    .WhileNotIntroduced((x) =>
                        x.IsImplemented(IdRef)
                        .IsIdValueType(IdRef, false)
                    )
                )
                // name
                .ValidateValueProperty<ReferenceAttributes>(nameof(ReferenceAttributes.NAME), (o) =>
                    o.IsImplemented(Name)
                )
                // dataItemId
                .ValidateValueProperty<ReferenceAttributes>(nameof(ReferenceAttributes.DATA_ITEM_ID), (o) =>
                    o.WhileIntroduced((x) =>
                        x.IsImplemented()
                        .IsIdValueType(DataItemId)
                    )
                    .WhileNotIntroduced((x) =>
                        x.IsImplemented(DataItemId)
                        .IsIdValueType(DataItemId, false)
                    )
                )
                // refDataItemId
                .ValidateValueProperty<ReferenceAttributes>(nameof(ReferenceAttributes.REF_DATA_ITEM_ID), (o) =>
                    o.WhileIntroduced((x) =>
                        x.IsImplemented()
                        .IsIdValueType(RefDataItemId)
                    )
                    .WhileNotIntroduced((x) =>
                        x.IsImplemented(RefDataItemId)
                        .IsIdValueType(RefDataItemId, false)
                    )
                )
                .HasError(out validationErrors);
    }
}
