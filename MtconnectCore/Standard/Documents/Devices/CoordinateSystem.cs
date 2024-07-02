using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Validation;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <summary>
    /// A CoordinateSystem is a reference system that associates a unique set of n parameters with each point in an n-dimensional space. Ref: ISO 10303-218:2004
    /// </summary>
    /// <remarks>See Part 2 Section 9.4.1 of the MTConnect specification</remarks>
    public class CoordinateSystem : MtconnectNode
    {
        /// <inheritdoc cref="CoordinateSystemAttributes.ID"/>
        [MtconnectNodeAttribute(CoordinateSystemAttributes.ID)]
        public string Id { get; set; }

        /// <inheritdoc cref="CoordinateSystemAttributes.NAME"/>
        [MtconnectNodeAttribute(CoordinateSystemAttributes.NAME)]
        public string Name { get; set; }

        /// <inheritdoc cref="CoordinateSystemAttributes.NATIVE_NAME"/>
        [MtconnectNodeAttribute(CoordinateSystemAttributes.NATIVE_NAME)]
        public string NativeName { get; set; }

        /// <inheritdoc cref="CoordinateSystemAttributes.PARENT_ID_REF"/>
        [MtconnectNodeAttribute(CoordinateSystemAttributes.PARENT_ID_REF)]
        public string ParentIdRef { get; set; }

        /// <inheritdoc cref="CoordinateSystemAttributes.TYPE"/>
        [MtconnectNodeAttribute(CoordinateSystemAttributes.TYPE)]
        public string Type { get; set; }

        /// <inheritdoc cref="CoordinateSystemElements.ORIGIN"/>
        [MtconnectNodeElement(CoordinateSystemElements.ORIGIN)]
        public string Origin { get; set; }

        /// <inheritdoc cref="CoordinateSystemElements.TRANSFORMATION"/>
        [MtconnectNodeElements(CoordinateSystemElements.TRANSFORMATION, nameof(TrySetTransformation), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public Transformation Transformation { get; set; }

        /// <inheritdoc />
        public CoordinateSystem() : base() { }

        /// <inheritdoc />
        public CoordinateSystem(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE, version) { }

        public bool TrySetTransformation(XmlNode xNode, XmlNamespaceManager nsmgr, out Transformation transformation)
            => base.TrySet<Transformation>(xNode, nsmgr, nameof(Transformation), out transformation);

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.COORDINATE_SYSTEM)]
        private bool validateValueProperties(out ICollection<MtconnectValidationException> validationErrors)
            => new NodeValidationContext(this)
            // id
            .ValidateValueProperty<CoordinateSystemAttributes>(nameof(CoordinateSystemAttributes.ID), (o) =>
                o.ValidateIdValueType(nameof(Id), Id)
            )
            // name
            .ValidateValueProperty<CoordinateSystemAttributes>(nameof(CoordinateSystemAttributes.NAME), (o) =>
                o
            )
            // nativeName
            .ValidateValueProperty<CoordinateSystemAttributes>(nameof(CoordinateSystemAttributes.NATIVE_NAME), (o) =>
                o
            )
            // parentIdRef
            .ValidateValueProperty<CoordinateSystemAttributes>(nameof(CoordinateSystemAttributes.PARENT_ID_REF), (o) =>
                o
            )
            // type
            // TODO: Scope this validation to the context of a minimum version. See extra validation below
            .ValidateValueProperty<CoordinateSystemAttributes>(nameof(CoordinateSystemAttributes.TYPE), (o) =>
                o
            )
            // uuid
            .ValidateValueProperty<CoordinateSystemAttributes>(nameof(CoordinateSystemAttributes.UUID), (o) =>
                // scope to v2.2.0 introduction
                o
            )
            // Description
            .ValidateValueProperty<CoordinateSystemElements>(nameof(CoordinateSystemElements.DESCRIPTION), (o) =>
                o
            )
            .HasError(out validationErrors);

        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, Constants.ModelBrowserLinks.COORDINATE_SYSTEM)]
        private bool validateType(out ICollection<MtconnectValidationException> validationErrors)
            => new NodeValidationContext(this)
            .Validate((o) =>
                o.ValidateRequired(nameof(Type), Type)
                ?.ValidateEnumValue<CoordinateSystemTypes>(nameof(Type), Type)
            )
            .HasError(out validationErrors);

        // TODO: Validate parentIdRef

    }
}
