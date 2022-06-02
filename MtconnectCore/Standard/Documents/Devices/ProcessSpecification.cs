using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using System.Collections.Generic;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <summary>
    /// ProcessSpecification provides information used to assess the conformance of a variable to process requirements.
    /// </summary>
    public class ProcessSpecification : Specification
    {
        private List<ControlLimit> _controlLimits = new List<ControlLimit>();
        /// <inheritdoc cref="ProcessSpecificationElements.CONTROL_LIMITS"/>
        [MtconnectNodeElements("ControlLimits/*", nameof(TryAddControlLimit), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ICollection<ControlLimit> ControlLimits => _controlLimits;

        private List<SpecificationLimit> _specificationLimits = new List<SpecificationLimit>();
        /// <inheritdoc cref="ProcessSpecificationElements.SPECIFICATION_LIMITS"/>
        [MtconnectNodeElements("SpecificationLimits/*", nameof(TryAddSpecificationLimit), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ICollection<SpecificationLimit> SpecificationLimits => _specificationLimits;

        private List<AlarmLimit> _alarmLimits = new List<AlarmLimit>();
        /// <inheritdoc cref="ProcessSpecificationElements.ALARM_LIMITS"/>
        [MtconnectNodeElements("AlarmLimits/*", nameof(TryAddAlarmLimit), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ICollection<AlarmLimit> AlarmLimits => _alarmLimits;

        /// <inheritdoc />
        public ProcessSpecification() : base() { }

        /// <inheritdoc />
        public ProcessSpecification(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        public bool TryAddControlLimit(XmlNode xNode, XmlNamespaceManager nsmgr, out ControlLimit controlLimit)
            => base.TryAdd<ControlLimit>(xNode, nsmgr, ref _controlLimits, out controlLimit);

        public bool TryAddSpecificationLimit(XmlNode xNode, XmlNamespaceManager nsmgr, out SpecificationLimit specificationLimit)
            => base.TryAdd<SpecificationLimit>(xNode, nsmgr, ref _specificationLimits, out specificationLimit);

        public bool TryAddAlarmLimit(XmlNode xNode, XmlNamespaceManager nsmgr, out AlarmLimit alarmLimit)
            => base.TryAdd<AlarmLimit>(xNode, nsmgr, ref _alarmLimits, out alarmLimit);
    }
}
