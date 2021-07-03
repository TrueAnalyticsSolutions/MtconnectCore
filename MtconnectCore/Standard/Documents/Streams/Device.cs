using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using System.Collections.Generic;
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

        public Device() { }

        public Device(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE) { }

        public bool TryAddComponent(XmlNode xNode, XmlNamespaceManager nsmgr, out Component component)
        {
            Logger.Verbose("Reading Component {XnodeKey}", xNode.TryGetAttribute(ComponentAttributes.COMPONENT_ID));
            component = new Component(xNode, nsmgr);
            if (!component.IsValid())
            {
                Logger.Warn($"[Invalid Stream] Component {component.ComponentId} is not formatted properly, refer to Part 3 Section 4.3.2 of MTConnect Standard.");
                return false;
            }
            _components.Add(component);
            return true;
        }

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(Name)
                && !string.IsNullOrEmpty(Uuid);
        }
    }
}
