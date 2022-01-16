using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
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
        [MtconnectNodeElements("Samples/*", nameof(TryAddSample), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public ICollection<Sample> Samples => _samples;

        private List<Event> _events = new List<Event>();
        /// <summary>
        /// Collected from Event elements. Refer to Part 3 Streams - 4.3.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeElements("Events/*", nameof(TryAddEvent), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public ICollection<Event> Events => _events;

        private List<Condition> _conditions = new List<Condition>();
        /// <summary>
        /// Collected from Sample elements. Refer to Part 3 Streams - 4.3.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeElements("Condition/*", nameof(TryAddCondition), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public ICollection<Condition> Conditions => _conditions;

        /// <inheritdoc/>
        public Component() { }

        /// <inheritdoc/>
        public Component(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE, version) { }

        public bool TryAddSample(XmlNode xNode, XmlNamespaceManager nsmgr, out Sample sample)
        {
            if (xNode.Name == "VariableDataSet")
            {
                var variableList = new List<SampleVariableDataSet>();
                var variableParseResult = base.TryAdd<SampleVariableDataSet>(xNode, nsmgr, ref variableList, out SampleVariableDataSet variableDataSet);
                _samples.Add(variableDataSet as Sample);
                sample = variableDataSet;
                return variableParseResult;
            }
            else
            {
                return base.TryAdd<Sample>(xNode, nsmgr, ref _samples, out sample);
            }
        }

        public bool TryAddEvent(XmlNode xNode, XmlNamespaceManager nsmgr, out Event @event)
        {
            if (xNode.Name == "VariableDataSet")
            {
                var variableList = new List<EventVariableDataSet>();
                var variableParseResult = base.TryAdd<EventVariableDataSet>(xNode, nsmgr, ref variableList, out EventVariableDataSet variableDataSet);
                _events.Add(variableDataSet);
                @event = variableDataSet;
                return variableParseResult;
            } else
            {
                return base.TryAdd<Event>(xNode, nsmgr, ref _events, out @event);
            }
        }

        public bool TryAddCondition(XmlNode xNode, XmlNamespaceManager nsmgr, out Condition condition) => base.TryAdd<Condition>(xNode, nsmgr, ref _conditions, out condition);


        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.4")]
        private bool validateComponentId(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(ComponentId))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Component MUST include a 'componentId' attribute.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.4")]
        private bool validateComponentReference(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(ComponentReference))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Component MUST include a 'component' attribute.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.4", MtconnectVersions.V_1_2_0)]
        private bool validateName(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(Name)) {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Component MUST include a 'name' attribute.",
                    SourceNode));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
