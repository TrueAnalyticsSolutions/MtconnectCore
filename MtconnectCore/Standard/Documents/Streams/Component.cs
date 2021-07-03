using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using System.Collections.Generic;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class Component : MtconnectNode
    {
        /// <summary>
        /// Collected from the componentId attribute. Refer to Part 3 Streams - 4.3.2
        /// 
        /// Occurance: 1
        /// </summary>
        [MtconnectNodeAttribute(ComponentAttributes.COMPONENT_ID)]
        public string ComponentId { get; set; }

        /// <summary>
        /// Collected from the name attribute. Refer to Part 3 Streams - 4.3.2
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(ComponentAttributes.NAME)]
        public string Name { get; set; }

        /// <summary>
        /// Collected from the nativeName attribute. Refer to Part 3 Streams - 4.3.2
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(ComponentAttributes.NATIVE_NAME)]
        public string NativeName { get; set; }

        /// <summary>
        /// Collected from the component attribute. Refer to Part 3 Streams - 4.3.2
        /// 
        /// Occurance: 1
        /// </summary>
        [MtconnectNodeAttribute(ComponentAttributes.COMPONENT)]
        public string ComponentReference { get; set; }

        /// <summary>
        /// Collected from the uuid attribute. Refer to Part 3 Streams - 4.3.2
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(ComponentAttributes.UUID)]
        public string Uuid { get; set; }

        private List<Sample> _samples = new List<Sample>();
        /// <summary>
        /// Collected from Sample elements. Refer to Part 3 Streams - 4.3.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeElements("Samples/*", nameof(TryAddSample), XmlNamespace = "m")]
        public ICollection<Sample> Samples => _samples;

        private List<Event> _events = new List<Event>();
        /// <summary>
        /// Collected from Event elements. Refer to Part 3 Streams - 4.3.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeElements("Events/*", nameof(TryAddEvent), XmlNamespace = "m")]
        public ICollection<Event> Events => _events;

        private List<Condition> _conditions = new List<Condition>();
        /// <summary>
        /// Collected from Sample elements. Refer to Part 3 Streams - 4.3.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeElements("Condition/*", nameof(TryAddCondition), XmlNamespace = "m")]
        public ICollection<Condition> Conditions => _conditions;

        public Component() { }

        public Component(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, "m") { }

        public bool TryAddSample(XmlNode xNode, XmlNamespaceManager nsmgr, out Sample sample)
        {
            Logger.Verbose("Reading Sample {XnodeKey}", xNode.TryGetAttribute(SampleAttributes.DATA_ITEM_ID));
            sample = new Sample(xNode, nsmgr);
            if (!sample.IsValid())
            {
                Logger.Warn($"[Invalid Stream] Sample {sample.DataItemId} is not formatted properly, refer to Part 3 Section 5.2 of MTConnect Standard.");
                return false;
            }
            _samples.Add(sample);
            return true;
        }

        public bool TryAddEvent(XmlNode xNode, XmlNamespaceManager nsmgr, out Event @event)
        {
            Logger.Verbose("Reading Event {XnodeKey}", xNode.TryGetAttribute(EventAttributes.DATA_ITEM_ID));
            @event = new Event(xNode, nsmgr);
            if (!@event.IsValid())
            {
                Logger.Warn($"[Invalid Stream] Event {@event.DataItemId} is not formatted properly, refer to Part 3 Section 5.3 of MTConnect Standard.");
                return false;
            }
            _events.Add(@event);
            return true;
        }

        public bool TryAddCondition(XmlNode xNode, XmlNamespaceManager nsmgr, out Condition condition)
        {
            Logger.Verbose("Reading Condition {XnodeKey}", xNode.TryGetAttribute(ConditionAttributes.DATA_ITEM_ID));
            condition = new Condition(xNode, nsmgr);
            if (!condition.IsValid())
            {
                Logger.Warn($"[Invalid Stream] Condition {condition.DataItemId} is not formatted properly, refer to Part 3 Section 5.8 of MTConnect Standard.");
                return false;
            }
            _conditions.Add(condition);
            return true;
        }

        public override bool IsValid()
        {
            return !string.IsNullOrEmpty(ComponentId) && !string.IsNullOrEmpty(ComponentReference);
        }
    }
}
