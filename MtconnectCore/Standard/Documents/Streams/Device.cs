using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System.Collections.Generic;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class Device : MtconnectNode
    {
        private const string MODEL_BROWSER_URL = "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1620240839406_285612_1596";

        /// <inheritdoc cref="DeviceAttributes.NAME"/>
        [MtconnectNodeAttribute(DeviceAttributes.NAME)]
        public string Name { get; set; }

        /// <inheritdoc cref="DeviceAttributes.UUID"/>
        [MtconnectNodeAttribute(DeviceAttributes.UUID)]
        public string Uuid { get; set; }

        private List<Component> _components = new List<Component>();
        /// <summary>
        /// Collected from ComponentStream elements. Refer to Part 3 Streams - 4.2.3
        /// 
        /// Occurance: 0..*
        /// </summary>
        [MtconnectNodeElements(StreamsElements.COMPONENT_STREAM, nameof(TryAddComponent))]
        public ICollection<Component> Components => _components;

        /// <inheritdoc/>
        public Device() { }

        /// <inheritdoc/>
        public Device(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        public bool TryAddComponent(XmlNode xNode, XmlNamespaceManager nsmgr, out Component component) => base.TryAdd<Component>(xNode, nsmgr, ref _components, out component);

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, MODEL_BROWSER_URL)]
        private bool ValidateProperties(out ICollection<MtconnectValidationException> validationErrors)
        {
            return new NodeValidationContext(this)
                // Validate Name
                .ValidateValueProperty<DeviceAttributes>(nameof(Name), (o) =>
                    o.IsImplemented(Name)?.IsRequired(Name)
                )
                // Validate Uuid
                .ValidateValueProperty<DeviceAttributes>(nameof(Uuid), (o) =>
                    o.IsImplemented(Uuid)?.IsRequired(Uuid)
                )
                // Return validation errors
                .HasError(out validationErrors);
        }
    }
}
