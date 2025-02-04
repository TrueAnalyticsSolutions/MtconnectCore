using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System.Collections.Generic;
using System.Xml;

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
        public ParsedValue<CompositionTypeEnum> Type { get; set; }

        /// <inheritdoc cref="CompositionElements.DESCRIPTION"/>
        [MtconnectNodeElements("Description", nameof(TrySetDescription))]
        public Description Description { get; set; }

        /// <inheritdoc/>
        public Composition() : base() { }

        /// <inheritdoc/>
        public Composition(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        public bool TrySetDescription(XmlNode xNode, XmlNamespaceManager nsmgr, out Description compositionDescription)
            => base.TrySet<Description>(xNode, nsmgr, nameof(Description), out compositionDescription);

        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 4.6.2")]
        private bool ValidateProperties(out ICollection<MtconnectValidationException> validationErrors)
        {
            return new NodeValidationContext(this)
                // Validate id
                .ValidateValueProperty(
                    CompositionAttributes.ID,
                    (o) =>
                        o.IsImplemented(Id)
                        ?.WhileIntroduced((i) =>
                            i.IsRequired(Id)
                        )
                        ?.IsIdValueType(Id)
                )
                // Validate type
                .ValidateValueProperty(
                    CompositionAttributes.TYPE,
                    (o) =>
                        o.IsImplemented(Type)
                        ?.WhileIntroduced((i) =>
                            i.IsRequired(Type)
                        )
                        ?.IsEnumValueType(Type, out _)
                )
                // Validate Uuid
                .ValidateValueProperty<CompositionAttributes>(nameof(Uuid), (o) =>
                    o.IsImplemented(Uuid)
                    ?.IsIdValueType(Uuid, false)
                )
                // Return validation errors
                .HasError(out validationErrors);
        }
    }
}
