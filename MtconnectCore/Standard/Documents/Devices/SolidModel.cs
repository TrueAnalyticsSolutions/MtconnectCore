using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
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
        public string MediaType { get; set; }

        /// <inheritdoc cref="SolidModelAttributes.COORDINATE_SYSTEM_ID_REF"/>
        [MtconnectNodeAttribute(SolidModelAttributes.COORDINATE_SYSTEM_ID_REF)]
        public string CoordinateSystemIdRef { get; set; }

        /// <inheritdoc cref="SolidModelElements.TRANSFORMATION"/>
        [MtconnectNodeElements(SolidModelElements.TRANSFORMATION, nameof(TrySetTransformation), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public Transformation Transformation { get; set; }

        /// <inheritdoc cref="SolidModelElements.SCALE"/>
        [MtconnectNodeElement(SolidModelElements.SCALE)]
        public string Scale { get; set; }

        /// <inheritdoc />
        public SolidModel() : base() { }

        /// <inheritdoc />
        public SolidModel(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE, version) { }

        public bool TrySetTransformation(XmlNode xNode, XmlNamespaceManager nsmgr, out Transformation transformation)
            => base.TrySet<Transformation>(xNode, nsmgr, nameof(Transformation), out transformation);

        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.6.1")]
        private bool validateId(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Id))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"SolidModel MUST include a unique 'id' attribute.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.6.1.1")]
        private bool validateMediaType(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();

            var version = MtconnectVersion.GetValueOrDefault();

            if (string.IsNullOrEmpty(MediaType))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"SolidModel MUST include a 'mediaType' attribute.",
                    SourceNode));
            }
            else if (!EnumHelper.Contains<MediaTypeEnum>(MediaType))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"SolidModel mediaType '{MediaType}' is not defined in version {version}.",
                    SourceNode));
            }
            else if (!EnumHelper.IsImplemented<MediaTypeEnum>(MediaType, version))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"SolidModel mediaType '{MediaType}' is not valid in version {version}.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.6.2")]
        private bool validateTransformation(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();

            if (Transformation != null && Transformation.Translation == null && Transformation.Rotation == null)
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"SolidModel Transformation MUST provide either Translation or Rotation at a minimum.",
                    SourceNode));
            }

            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        // TODO: Validate Scale for single multiplier (float) value or 3D multiplier (one float for X, Y, and Z)
    }
}
