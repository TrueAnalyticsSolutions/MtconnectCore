using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Assets.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Assets
{
    /// <inheritdoc />
    public class CuttingToolLifeCycle : MtconnectNode
    {
        /// <inheritdoc cref="CuttingToolLifeCycleElements.CUTTER_STATUS"/>
        [MtconnectNodeElements(nameof(CuttingToolLifeCycleElements.CUTTER_STATUS), nameof(TrySetCutterStatus), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public CutterStatus CutterStatus { get; set; }

        /// <inheritdoc cref="CuttingToolLifeCycleElements.LOCATION"/>
        [MtconnectNodeElement(nameof(CuttingToolLifeCycleElements.LOCATION))]
        [MtconnectNodeElements(nameof(CuttingToolLifeCycleElements.LOCATION), nameof(TrySetLocation), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public Location Location { get; set; }

        /// <inheritdoc cref="CuttingToolLifeCycleElements.RECONDITION_COUNT"/>
        [MtconnectNodeElements(nameof(CuttingToolLifeCycleElements.RECONDITION_COUNT), nameof(TrySetReconditionCount), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public ReconditionCount ReconditionCount { get; set; }

        /// <inheritdoc cref="CuttingToolLifeCycleElements.TOOL_LIFE"/>
        [MtconnectNodeElements(nameof(CuttingToolLifeCycleElements.TOOL_LIFE), nameof(TrySetToolLife), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public ToolLife ToolLife { get; set; }

        /// <inheritdoc cref="CuttingToolLifeCycleElements.PROGRAM_TOOL_GROUP"/>
        [MtconnectNodeElement(nameof(CuttingToolLifeCycleElements.PROGRAM_TOOL_GROUP))]
        public string ProgramToolGroup { get; set; }

        /// <inheritdoc cref="CuttingToolLifeCycleElements.PROGRAM_TOOL_NUMBER"/>
        [MtconnectNodeElement(nameof(CuttingToolLifeCycleElements.PROGRAM_TOOL_NUMBER))]
        public string ProgramToolNumber { get; set; }

        /// <inheritdoc cref="CuttingToolLifeCycleElements.PROCESS_SPINDLE_SPEED"/>
        [MtconnectNodeElements(nameof(CuttingToolLifeCycleElements.PROCESS_SPINDLE_SPEED), nameof(TrySetProcessSpindleSpeed), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public ProcessSpindleSpeed ProcessSpindleSpeed { get; set; }

        /// <inheritdoc cref="CuttingToolLifeCycleElements.PROCESS_FEED_RATE"/>
        [MtconnectNodeElements(nameof(CuttingToolLifeCycleElements.PROCESS_FEED_RATE), nameof(TrySetProcessFeedRate), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public ProcessFeedRate ProcessFeedRate { get; set; }

        /// <inheritdoc cref="CuttingToolLifeCycleElements.CONNECTION_CODE_MACHINE_SIDE"/>
        [MtconnectNodeElement(nameof(CuttingToolLifeCycleElements.CONNECTION_CODE_MACHINE_SIDE))]
        public string ConnectionCodeMachineSide { get; set; }

        private List<CuttingToolMeasurement> _measurements = new List<CuttingToolMeasurement>();
        [MtconnectNodeElements("Measurements/m:*", nameof(TryAddMeasurement), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public ICollection<CuttingToolMeasurement> Measurements => _measurements;

        [MtconnectNodeElements(nameof(CuttingToolLifeCycleElements.CUTTING_ITEMS), nameof(TrySetCuttingItems), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public CuttingItems CuttingItems { get; set; }

        private List<ExtensibleLifeCycleElement> _extensibleElements = new List<ExtensibleLifeCycleElement>();
        public ICollection<ExtensibleLifeCycleElement> ExtensibleElements => _extensibleElements;

        /// <inheritdoc />
        public CuttingToolLifeCycle() : base() { }

        /// <inheritdoc />
        public CuttingToolLifeCycle(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE, version)
        {
            foreach (XmlNode child in xNode.ChildNodes)
            {
                if (!EnumHelper.Contains<CuttingToolLifeCycleElements>(child.LocalName))
                {
                    _extensibleElements.Add(new ExtensibleLifeCycleElement(child, nsmgr, version));
                }
            }
        }

        public bool TrySetReconditionCount(XmlNode xNode, XmlNamespaceManager nsmgr, out ReconditionCount reconditionCount)
            => base.TrySet<ReconditionCount>(xNode, nsmgr, nameof(ReconditionCount), out reconditionCount);

        public bool TrySetToolLife(XmlNode xNode, XmlNamespaceManager nsmgr, out ToolLife toolLife)
            => base.TrySet<ToolLife>(xNode, nsmgr, nameof(ToolLife), out toolLife);

        public bool TrySetCutterStatus(XmlNode xNode, XmlNamespaceManager nsmgr, out CutterStatus cutterStatus)
            => base.TrySet<CutterStatus>(xNode, nsmgr, nameof(CutterStatus), out cutterStatus);

        public bool TrySetLocation(XmlNode xNode, XmlNamespaceManager nsmgr, out Location location)
            => base.TrySet<Location>(xNode, nsmgr, nameof(Location), out location);

        public bool TrySetProcessSpindleSpeed(XmlNode xNode, XmlNamespaceManager nsmgr, out ProcessSpindleSpeed processSpindleSpeed)
            => base.TrySet<ProcessSpindleSpeed>(xNode, nsmgr, nameof(ProcessSpindleSpeed), out processSpindleSpeed);

        public bool TrySetProcessFeedRate(XmlNode xNode, XmlNamespaceManager nsmgr, out ProcessFeedRate processFeedRate)
            => base.TrySet<ProcessFeedRate>(xNode, nsmgr, nameof(ProcessFeedRate), out processFeedRate);

        public bool TryAddMeasurement(XmlNode xNode, XmlNamespaceManager nsmgr, out CuttingToolMeasurement measurement)
            => base.TryAdd<CuttingToolMeasurement>(xNode, nsmgr, ref _measurements, out measurement);

        public bool TrySetCuttingItems(XmlNode xNode, XmlNamespaceManager nsmgr, out CuttingItems cuttingItems)
            => base.TrySet<CuttingItems>(xNode, nsmgr, nameof(CuttingItems), out cuttingItems);

        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.8")]
        private bool validateCutterStatus(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (CutterStatus == null)
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"CuttingToolLifeCycle missing 'CutterStatus'."));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.8")]
        public bool validateProgramToolNumber(out ICollection<MtconnectValidationException> validationErrors) {
            validationErrors = new List<MtconnectValidationException>();
            if (!string.IsNullOrEmpty(ProgramToolNumber) && int.TryParse(ProgramToolNumber, out int toolNumber))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"CuttingToolLifeCycle ProgramToolNumber MUST be an integer."));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
