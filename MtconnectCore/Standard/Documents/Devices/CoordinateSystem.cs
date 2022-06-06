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

        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 9.4.1.1.1")]
        private bool validateId(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Id))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"CoordinateSystem MUST include a unique 'id' attribute.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 9.4.1.1.1")]
        private bool validateType(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"CoordinateSystem MUST include a 'type' attribute.",
                    SourceNode));
            }
            else if (!EnumHelper.Contains<CoordinateSystemTypes>(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.WARNING,
                    $"CoordinateSystem 'type' should be one of: [{EnumHelper.ToListString<CoordinateSystemTypes>(", ", string.Empty, string.Empty)}].",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
