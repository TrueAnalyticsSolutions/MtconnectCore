using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <summary>
    /// SolidModel references a file with the three-dimensional geometry of the Component or Composition.
    /// </summary>
    public class SolidModel : MtconnectNode
    {
        /// <inheritdoc cref="SolidModelAttributes.ID"/>
        [MtconnectNodeAttribute(SolidModelAttributes.ID)]
        public string Id { get; set; }

        /// <inheritdoc cref="SolidModelAttributes.SOLID_MODEL_ID_REF"/>
        [MtconnectNodeAttribute(SolidModelAttributes.SOLID_MODEL_ID_REF)]
        public string SolidModelIdRef { get; set; }

        /// <inheritdoc cref="SolidModelAttributes.HREF"/>
        [MtconnectNodeAttribute(SolidModelAttributes.HREF)]
        public string Href { get; set; }

        /// <inheritdoc cref="SolidModelAttributes.ITEM_REF"/>
        [MtconnectNodeAttribute(SolidModelAttributes.ITEM_REF)]
        public string ItemRef { get; set; }

        /// <inheritdoc cref="SolidModelAttributes.MEDIA_TYPE"/>
        [MtconnectNodeAttribute(SolidModelAttributes.MEDIA_TYPE)]
        public ParsedValue<MediaTypeEnum> MediaType { get; set; }

        /// <inheritdoc cref="SolidModelAttributes.COORDINATE_SYSTEM_ID_REF"/>
        [MtconnectNodeAttribute(SolidModelAttributes.COORDINATE_SYSTEM_ID_REF)]
        public string CoordinateSystemIdRef { get; set; }

        /// <inheritdoc cref="SolidModelAttributes.NATIVE_UNITS"/>
        [MtconnectNodeAttribute(SolidModelAttributes.NATIVE_UNITS)]
        public ParsedValue<NativeUnitEnum> NativeUnits { get; set; }

        /// <inheritdoc cref="SolidModelAttributes.UNITS"/>
        [MtconnectNodeAttribute(SolidModelAttributes.UNITS)]
        public ParsedValue<UnitEnum> Units { get; set; }

        /// <inheritdoc cref="SolidModelElements.TRANSFORMATION"/>
        [MtconnectNodeElements(SolidModelElements.TRANSFORMATION, nameof(TrySetTransformation))]
        public Transformation Transformation { get; set; }

        /// <inheritdoc cref="SolidModelElements.SCALE"/>
        [MtconnectNodeElement(SolidModelElements.SCALE)]
        public string Scale { get; set; }

        /// <inheritdoc />
        public SolidModel() : base() { }

        /// <inheritdoc />
        public SolidModel(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        public bool TrySetTransformation(XmlNode xNode, XmlNamespaceManager nsmgr, out Transformation transformation)
            => base.TrySet<Transformation>(xNode, nsmgr, nameof(Transformation), out transformation);

        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.6.1")]
        private bool ValidateProperties(out ICollection<MtconnectValidationException> validationErrors)
        {
            var version = MtconnectVersion.GetValueOrDefault();

            return new NodeValidationContext(this)
                // Validate id
                .ValidateValueProperty(
                    SolidModelAttributes.ID,
                    (o) =>
                        o.IsImplemented(Id)
                        ?.WhileIntroduced((i) =>
                            i.IsRequired(Id)
                        )
                        ?.IsIdValueType(Id)
                )
                // Validate solidModelIdRef
                .ValidateValueProperty(
                    SolidModelAttributes.SOLID_MODEL_ID_REF,
                    (o) =>
                        o.IsImplemented(SolidModelIdRef)
                        ?.IsIdValueType(Id)
                )
                // Validate href
                .ValidateValueProperty(
                    SolidModelAttributes.HREF,
                    (o) =>
                        o.IsImplemented(Href)
                )
                // Validate itemRef
                .ValidateValueProperty(
                    SolidModelAttributes.ITEM_REF,
                    (o) =>
                        o.IsImplemented(ItemRef)
                )
                // Validate mediaType
                .ValidateValueProperty(
                    SolidModelAttributes.MEDIA_TYPE,
                    (o) =>
                        o.IsImplemented(MediaType)
                        ?.WhileIntroduced((i) =>
                            i.IsRequired(MediaType)
                        )
                        ?.IsEnumValueType(MediaType, out _)
                )
                // Validate coordinateSystemIdRef
                .ValidateValueProperty(
                    SolidModelAttributes.COORDINATE_SYSTEM_ID_REF,
                    (o) =>
                        o.IsImplemented(CoordinateSystemIdRef)
                        ?.IsIdValueType(CoordinateSystemIdRef)
                )
                // Validate nativeUnits
                .ValidateValueProperty(
                    SolidModelAttributes.NATIVE_UNITS,
                    (o) =>
                        o.IsImplemented(NativeUnits)
                        ?.IsEnumValueType(NativeUnits, out _)
                )
                // Validate units
                .ValidateValueProperty(
                    SolidModelAttributes.UNITS,
                    (o) =>
                        o.IsImplemented(Units)
                        ?.IsEnumValueType(Units, out _)
                )
                // Validate Transformation
                //.ValidateValueProperty<SolidModelElements>(nameof(Transformation), (o) =>
                //    o.IsImplemented(Transformation)
                //    ?.If(
                //        (v) => Transformation != null,
                //        (v) => v.Translation != null || v.Rotation != null ? v : throw new MtconnectValidationException(
                //            ValidationSeverity.ERROR,
                //            "SolidModel Transformation MUST provide either Translation or Rotation at a minimum.",
                //            SourceNode)
                //    )
                //)
                // Return validation errors
                .HasError(out validationErrors);
        }

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.6.1")]
        //private bool validateId(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();
        //    if (string.IsNullOrEmpty(Id))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"SolidModel MUST include a unique 'id' attribute.",
        //            SourceNode));
        //    }
        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.6.1.1")]
        //private bool validateMediaType(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();

        //    var version = MtconnectVersion.GetValueOrDefault();

        //    if (string.IsNullOrEmpty(MediaType))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"SolidModel MUST include a 'mediaType' attribute.",
        //            SourceNode));
        //    }
        //    else if (!EnumHelper.Contains<MediaTypeEnum>(MediaType))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"SolidModel mediaType '{MediaType}' is not defined in version {version}.",
        //            SourceNode));
        //    }
        //    else if (!EnumHelper.IsImplemented<MediaTypeEnum>(MediaType, version))
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"SolidModel mediaType '{MediaType}' is not valid in version {version}.",
        //            SourceNode));
        //    }
        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}

        //[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.6.2")]
        //private bool validateTransformation(out ICollection<MtconnectValidationException> validationErrors)
        //{
        //    validationErrors = new List<MtconnectValidationException>();

        //    if (Transformation != null && Transformation.Translation == null && Transformation.Rotation == null)
        //    {
        //        validationErrors.Add(new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"SolidModel Transformation MUST provide either Translation or Rotation at a minimum.",
        //            SourceNode));
        //    }

        //    return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        //}

        // TODO: Validate Scale for single multiplier (float) value or 3D multiplier (one float for X, Y, and Z)
    }
}
