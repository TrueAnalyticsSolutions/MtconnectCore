using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class Device : MtconnectNode
    {
        /// <summary>
        /// Collected from the name attribute. Refer to Part 3 Streams - 4.2.2
        /// 
        /// Occurance: 1
        /// </summary>
        [MtconnectNodeAttribute(DeviceAttributes.NAME)]
        public string Name { get; set; }

        /// <summary>
        /// Collected from the uuid attribute. Refer to Part 3 Streams - 4.2.2
        /// 
        /// Occurance: 1
        /// </summary>
        [MtconnectNodeAttribute(DeviceAttributes.UUID)]
        public string Uuid { get; set; }

        private List<Component> _components = new List<Component>();
        /// <summary>
        /// Collected from ComponentStream elements. Refer to Part 3 Streams - 4.2.3
        /// 
        /// Occurance: 0..*
        /// </summary>
        [MtconnectNodeElements(StreamsElements.COMPONENT_STREAM, nameof(TryAddComponent), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public ICollection<Component> Components => _components;

        /// <inheritdoc/>
        public Device() { }

        /// <inheritdoc/>
        public Device(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE, version) { }

        public bool TryAddComponent(XmlNode xNode, XmlNamespaceManager nsmgr, out Component component) => base.TryAdd<Component>(xNode, nsmgr, ref _components, out component);


        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 3.3.1")]
        private bool validateName(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Name))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Device MUST include a 'name' attribute.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.3.1")]
        private bool validateUuid(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Uuid))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Device MUST include a 'uuid' attribute.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
