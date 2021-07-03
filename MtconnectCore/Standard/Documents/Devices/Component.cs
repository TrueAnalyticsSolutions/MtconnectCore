using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Devices
{
    public class Component : MtconnectNode
    {
        [MtconnectNodeAttribute(ComponentAttributes.ID)]
        public string Id { get; set; }

        [MtconnectNodeAttribute(ComponentAttributes.NAME)]
        public string Name { get; set; }

        public string TagName { get; set; }

        [MtconnectNodeElements("Description", nameof(TrySetDescription), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ComponentDescription Description { get; set; }

        public int Size => _subComponents?.Sum(o => o.Size) ?? 1;

        private List<Component> _subComponents = new List<Component>();
        [MtconnectNodeElements("Components/*", nameof(TryAddComponent), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ICollection<Component> SubComponents => _subComponents;

        private List<DataItem> _dataItems = new List<DataItem>();
        [MtconnectNodeElements("DataItems/*", nameof(TryAddDataItem), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ICollection<DataItem> DataItems => _dataItems;

        public Component() : base() { }

        public Component(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE)
        {
            TagName = xNode.LocalName;
        }

        public bool TryAddComponent(XmlNode xNode, XmlNamespaceManager nsmgr, out Component component)
        {
            Logger.Verbose("Reading Component {XnodeKey}", xNode.TryGetAttribute(ComponentAttributes.ID));
            component = new Component(xNode, nsmgr);
            if (!component.IsValid())
            {
                Logger.Warn($"[Invalid Probe] Component {component.TagName} must have a valid id and name attribute.");
                return false;
            }
            _subComponents.Add(component);
            return true;
        }

        public bool TryAddDataItem(XmlNode xNode, XmlNamespaceManager nsmgr, out DataItem dataItem)
        {
            Logger.Verbose("Reading DataItem {XnodeKey}", xNode.TryGetAttribute(DataItemAttributes.ID));
            dataItem = new DataItem(xNode, nsmgr);
            if (!dataItem.IsValid())
            {
                Logger.Warn($"[Invalid Probe] DataItem not formatted properly, refer to Part 2 Section 6.2.1 of MTConnect Standard.");
                return false;
            }
            _dataItems.Add(dataItem);
            return true;
        }

        public bool TrySetDescription(XmlNode xNode, XmlNamespaceManager nsmgr, out ComponentDescription componentDescription)
        {
            Logger.Verbose($"Reading ComponentDescription...");
            componentDescription = new ComponentDescription(xNode, nsmgr);
            if (!componentDescription.IsValid())
            {
                Logger.Warn($"[Invalid Probe] Component Description not formatted properly, refer to Part 2 Section 4.4.3.1 of MTConnect Standard.");
                return false;
            }
            Description = componentDescription;
            return true;
        }

        public override bool IsValid() => Id != null && Name != null; // See Part 2 Section 4.4.1 of MTConnect Standard
    }
}
