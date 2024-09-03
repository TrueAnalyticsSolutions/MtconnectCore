using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Xml;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Validation;

namespace MtconnectCore.Standard.Documents.Devices
{
    public class Motion : MtconnectNode
    {
        /// <inheritdoc cref="MotionAttributes.ID"/>
        [MtconnectNodeAttribute(MotionAttributes.ID)]
        public string Id { get; set; }

        /// <inheritdoc cref="MotionAttributes.PARENT_ID_REF"/>
        [MtconnectNodeAttribute(MotionAttributes.PARENT_ID_REF)]
        public string ParentIdRef { get; set; }

        /// <inheritdoc cref="MotionAttributes.COORDINATE_SYSTEM_ID_REF"/>
        [MtconnectNodeAttribute(MotionAttributes.COORDINATE_SYSTEM_ID_REF)]
        public string CoordinateSystemIdRef { get; set; }

        /// <inheritdoc cref="MotionAttributes.TYPE"/>
        [MtconnectNodeAttribute(MotionAttributes.TYPE)]
        public ParsedValue<MotionTypeEnum> Type { get; set; }

        /// <inheritdoc cref="MotionAttributes.ACTUATION"/>
        [MtconnectNodeAttribute(MotionAttributes.ACTUATION)]
        public ParsedValue<MotionActuationTypeEnum> Actuation { get; set; }

        /// <inheritdoc cref="MotionElements.DESCRIPTION"/>
        [MtconnectNodeElement(MotionElements.DESCRIPTION)]
        public string Description { get; set; }

        /// <inheritdoc cref="MotionElements.AXIS"/>
        [MtconnectNodeElement(MotionElements.AXIS)]
        public string Axis { get; set; }

        /// <inheritdoc cref="MotionElements.ORIGIN"/>
        [MtconnectNodeElement(MotionElements.ORIGIN)]
        public string Origin { get; set; }

        /// <inheritdoc cref="CoordinateSystemElements.TRANSFORMATION"/>
        [MtconnectNodeElements(CoordinateSystemElements.TRANSFORMATION, nameof(TrySetTransformation))]
        public Transformation Transformation { get; set; }

        /// <inheritdoc />
        public Motion() : base() { }

        /// <inheritdoc />
        public Motion(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        public bool TrySetTransformation(XmlNode xNode, XmlNamespaceManager nsmgr, out Transformation transformation)
            => base.TrySet<Transformation>(xNode, nsmgr, nameof(Transformation), out transformation);

        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.1")]
        private bool ValidateProperties(out ICollection<MtconnectValidationException> validationErrors)
        {
            var version = MtconnectVersion.GetValueOrDefault();

            return new NodeValidationContext(this)
                // Validate actuation
                .ValidateValueProperty(
                    MotionAttributes.ACTUATION,
                    (o) =>
                        o.IsImplemented(Actuation)
                        ?.WhileIntroduced((i) =>
                            i.IsRequired(Actuation)
                        )
                        ?.IsEnumValueType<MotionActuationTypeEnum>(Actuation, out _)
                )
                // Validate coordinateSystemIdRef
                .ValidateValueProperty(
                    MotionAttributes.COORDINATE_SYSTEM_ID_REF,
                    (o) =>
                        o.IsImplemented(CoordinateSystemIdRef)
                        ?.WhileIntroduced((i) =>
                            i.IsRequired(CoordinateSystemIdRef)
                        )
                        ?.IsIdValueType(CoordinateSystemIdRef)
                )
                // Validate id
                .ValidateValueProperty(
                    MotionAttributes.ID,
                    (o) =>
                        o.IsImplemented(Id)
                        ?.WhileIntroduced((i) =>
                            i.IsRequired(Id)
                        )
                        ?.IsIdValueType(Id)
                )
                .ValidateValueProperty(
                    MotionAttributes.PARENT_ID_REF,
                    (o) =>
                        o.IsImplemented(ParentIdRef)
                        ?.IsIdValueType(ParentIdRef)
                )
                // Validate type
                .ValidateValueProperty(
                    MotionAttributes.TYPE,
                    (o) =>
                        o.IsImplemented(Type)
                        ?.WhileIntroduced((i) =>
                            i.IsRequired(Type)
                        )
                        ?.IsIdValueType(Type)
                )
                // Validate Axis
                .ValidateValueProperty<MotionElements>(nameof(Axis), (o) =>
                    o.IsImplemented(Axis)
                )
                // Validate Transformation
                //.ValidateValueProperty<CoordinateSystemElements>(nameof(Transformation), (o) =>
                //    o.IsImplemented(Transformation)
                //    ?.If(
                //        (v) => Transformation != null,
                //        (v) => v.Translation != null || v.Rotation != null ? v : throw new MtconnectValidationException(
                //            ValidationSeverity.ERROR,
                //            "Motion Transformation MUST provide either Translation or Rotation at a minimum.",
                //            SourceNode)
                //    )
                //)
                // Return validation errors
                .HasError(out validationErrors);
        }
    }
}
