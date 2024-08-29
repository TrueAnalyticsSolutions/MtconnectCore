using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices;
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

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.1")]
        //private bool validateId(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (string.IsNullOrEmpty(Id))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Motion MUST include a unique 'id' attribute.",
        //            SourceNode));
        //    }
        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.1")]
        //private bool validateCoordinateSystemIdRef(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (string.IsNullOrEmpty(CoordinateSystemIdRef))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Motion MUST include a unique 'coordinateSystemIdRef' attribute.",
        //            SourceNode));
        //    }
        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.1")]
        //private bool validateType(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();

        //    var version = MtconnectVersion.GetValueOrDefault();

        //    if (string.IsNullOrEmpty(Type))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Motion MUST include a unique 'type' attribute.",
        //            SourceNode));
        //    } else if (!EnumHelper.Contains<MotionTypeEnum>(Type))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Motion 'type' {Type} is not defined in version {version}.",
        //            SourceNode));
        //    } else if (!EnumHelper.IsImplemented<MotionTypeEnum>(Type, version))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Motion 'type' {Type} is not valid in version {version}.",
        //            SourceNode));
        //    }
        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.1")]
        //private bool validateActuation(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();

        //    var version = MtconnectVersion.GetValueOrDefault();

        //    if (string.IsNullOrEmpty(Actuation))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Motion MUST include a unique 'actuation' attribute.",
        //            SourceNode));
        //    }
        //    else if (!EnumHelper.Contains<MotionActuationTypeEnum>(Actuation))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Motion 'actuation' {Actuation} is not defined in version {version}.",
        //            SourceNode));
        //    }
        //    else if (!EnumHelper.IsImplemented<MotionActuationTypeEnum>(Actuation, version))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Motion 'actuation' {Actuation} is not valid in version {version}.",
        //            SourceNode));
        //    }
        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.2")]
        //private bool validateAxis(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (string.IsNullOrEmpty(Axis))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Motion MUST include a reference to an 'Axis'.",
        //            SourceNode));
        //    }
        //    // TODO: Validate value is UNIT_VECTOR_3D
        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}

        //// TODO: Validate Origin, if supplied, is MILLIMETER_3D

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.5.2")]
        //private bool validateTransformation(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();

        //    if (Transformation != null && Transformation.Translation == null && Transformation.Rotation == null)
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Motion Transformation MUST provide either Translation or Rotation at a minimum.",
        //            SourceNode));
        //    }

        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}
    }
}
