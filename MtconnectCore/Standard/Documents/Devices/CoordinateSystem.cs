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
        [MtconnectNodeElements(CoordinateSystemElements.TRANSFORMATION, nameof(TryAddTransformation), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public Transformation Transformation { get; set; }

        /// <inheritdoc cref="MtconnectNode.MtconnectNode()"/>
        public CoordinateSystem() : base() { }

        /// <inheritdoc cref="MtconnectNode.MtconnectNode(XmlNode, XmlNamespaceManager, string)"/>
        public CoordinateSystem(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE) { }

        public bool TryAddTransformation(XmlNode xNode, XmlNamespaceManager nsmgr, out Transformation transformation)
        {
            Logger.Verbose("Reading Transformation for CoordinateSystem {XnodeKey}", xNode.TryGetAttribute(CoordinateSystemAttributes.ID));
            transformation = new Transformation(xNode, nsmgr);
            if (!transformation.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Probe] Transformation:\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            Transformation = transformation;
            return true;
        }

        /// <remarks>See Part 2 Section 9.4.1.1 of MTConnect Standard</remarks>
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            const string documentationAttributes = "See Part 2 Section 9.4.1.1 of the MTConnect standard.";
            validationErrors = new List<MtconnectValidationException>();

            if (string.IsNullOrEmpty(Id))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"CoordinateSystem MUST include a unique 'id' attribute. {documentationAttributes}"));
            }

            if (string.IsNullOrEmpty(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"CoordinateSystem MUST include a 'type' attribute. {documentationAttributes}"));
            }
            else if (!EnumHelper.Contains<CoordinateSystemTypes>(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.WARNING,
                    $"CoordinateSystem 'type' should be one of: [{EnumHelper.ToListString<CoordinateSystemTypes>(", ", string.Empty, string.Empty)}]. {documentationAttributes}"));
            }

            return !validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR);
        }
    }
}
