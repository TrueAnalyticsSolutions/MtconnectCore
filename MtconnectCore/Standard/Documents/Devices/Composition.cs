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
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <summary>
    /// Composition XML elements are used to describe the lowest level physical building blocks of a piece of equipment contained within a Component.
    /// </summary>
    /// <remarks>See Part 2 Section 4.6 of the MTConnect specification.</remarks>
    public class Composition : MtconnectNode
    {
        /// <inheritdoc cref="CompositionAttributes.ID"/>
        [MtconnectNodeAttribute(CompositionAttributes.ID)]
        public string Id { get; set; }

        /// <inheritdoc cref="CompositionAttributes.UUID"/>
        [MtconnectNodeAttribute(CompositionAttributes.UUID)]
        public string Uuid { get; set; }

        /// <inheritdoc cref="CompositionAttributes.NAME"/>
        [MtconnectNodeAttribute(CompositionAttributes.NAME)]
        public string Name { get; set; }

        /// <inheritdoc cref="CompositionAttributes.TYPE"/>
        [MtconnectNodeAttribute(CompositionAttributes.TYPE)]
        public string Type { get; set; }

        /// <inheritdoc cref="CompositionElements.DESCRIPTION"/>
        [MtconnectNodeElements("Description", nameof(TrySetDescription))]
        public CompositionDescription Description { get; set; }

        /// <inheritdoc/>
        public Composition() : base() { }

        /// <inheritdoc/>
        public Composition(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE, version) { }

        public bool TrySetDescription(XmlNode xNode, XmlNamespaceManager nsmgr, out CompositionDescription compositionDescription)
            => base.TrySet<CompositionDescription>(xNode, nsmgr, nameof(Description), out compositionDescription);

        /// <inheritdoc />
        /// <remarks>See Part 2 Section 4.6.2 of the MTConnect specification.</remarks>
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            base.TryValidate(out validationErrors);

            const string documentationAttributes = "See Part 2 Section 4.6.2 of the MTConnect standard.";

            if (string.IsNullOrEmpty(Id))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Composition MUST include a 'id' attribute. {documentationAttributes}"));
            }

            if (string.IsNullOrEmpty(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Composition MUST include a 'type' attribute. {documentationAttributes}"));
            }
            else if (!EnumHelper.Contains<CompositionTypes>(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.WARNING,
                    $"Composition 'type' of '{Type}' is not currently defined in the MTConnect standard and may not be supported. {documentationAttributes}"));
            }

            return !validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR);
        }
    }
}
