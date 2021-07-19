using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <summary>
    /// Specification elements define information describing the design characteristics for a piece of equipment.
    /// </summary>
    /// <remarks>See Part 2 Section 9.3.1 of the MTConnect specification</remarks>
    public class Specification : MtconnectNode
    {
        /// <inheritdoc cref="SpecificationAttributes.TYPE"/>
        [MtconnectNodeAttribute(SpecificationAttributes.TYPE)]
        public string Type { get; set; }

        /// <inheritdoc cref="SpecificationAttributes.SUB_TYPE"/>
        [MtconnectNodeAttribute(SpecificationAttributes.SUB_TYPE)]
        public string SubType { get; set; }

        /// <inheritdoc cref="SpecificationAttributes.DATA_ITEM_ID_REF"/>
        [MtconnectNodeAttribute(SpecificationAttributes.DATA_ITEM_ID_REF)]
        public string DataItemIdRef { get; set; }

        /// <inheritdoc cref="SpecificationAttributes.COMPOSITION_ID_REF"/>
        [MtconnectNodeAttribute(SpecificationAttributes.COMPOSITION_ID_REF)]
        public string CompositionIdRef { get; set; }

        /// <inheritdoc cref="SpecificationAttributes.NAME"/>
        [MtconnectNodeAttribute(SpecificationAttributes.NAME)]
        public string Name { get; set; }

        /// <inheritdoc cref="SpecificationAttributes.COORDINATE_SYSTEM_ID_REF"/>
        [MtconnectNodeAttribute(SpecificationAttributes.COORDINATE_SYSTEM_ID_REF)]
        public string CoordinateSystemIdRef { get; set; }

        /// <inheritdoc cref="SpecificationElements.MINIMUM"/>
        [MtconnectNodeElement(SpecificationElements.MINIMUM)]
        public double? Minimum { get; set; }

        /// <inheritdoc cref="SpecificationElements.NOMINAL"/>
        [MtconnectNodeElement(SpecificationElements.NOMINAL)]
        public double? Nominal { get; set; }

        /// <inheritdoc cref="SpecificationElements.MAXIMUM"/>
        [MtconnectNodeElement(SpecificationElements.MAXIMUM)]
        public double? Maximum { get; set; }

        /// <inheritdoc cref="MtconnectNode.MtconnectNode()"/>
        public Specification() : base() { }

        /// <inheritdoc cref="MtconnectNode.MtconnectNode(XmlNode, XmlNamespaceManager, string)"/>
        public Specification(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE) { }

        /// <inheritdoc/>
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            const string documentationAttributes = "See Part 2 Section 9.3.1.1 of the MTConnect standard.";
            validationErrors = new List<MtconnectValidationException>();

            if (string.IsNullOrEmpty(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Specification MUST include a unique 'type' attribute. {documentationAttributes}"));
            }

            return !validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR);
        }
    }
}
