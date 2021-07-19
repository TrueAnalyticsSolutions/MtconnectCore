using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
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
        public Device(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE) { }

        public bool TryAddComponent(XmlNode xNode, XmlNamespaceManager nsmgr, out Component component)
        {
            Logger.Verbose("Reading Component {XnodeKey}", xNode.TryGetAttribute(ComponentAttributes.COMPONENT_ID));
            component = new Component(xNode, nsmgr);
            if (!component.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Stream] Component {component.ComponentId} of Device '{Name}':\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            _components.Add(component);
            return true;
        }

        /// <inheritdoc/>
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            const string documentationAttributes = "See Part 1 Section 4.2.1 of the MTConnect standard.";
            validationErrors = new List<MtconnectValidationException>();

            if (string.IsNullOrEmpty(Name))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Device MUST include a 'name' attribute. {documentationAttributes}"));
            }

            if (string.IsNullOrEmpty(Uuid))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Device MUST include a 'uuid' attribute. {documentationAttributes}"));
            }

            return !validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR);
        }
    }
}
