using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
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

        /// <inheritdoc />
        public CuttingToolLifeCycle() : base() { }

        /// <inheritdoc />
        public CuttingToolLifeCycle(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE) { }

        public bool TrySetReconditionCount(XmlNode xNode, XmlNamespaceManager nsmgr, out ReconditionCount reconditionCount)
        {
            Logger.Verbose($"Reading CuttingTool ReconditionCount...");
            reconditionCount = new ReconditionCount(xNode, nsmgr);
            if (!reconditionCount.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Asset] ReconditionCount of Asset:\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            ReconditionCount = reconditionCount;
            return true;
        }

        public bool TrySetToolLife(XmlNode xNode, XmlNamespaceManager nsmgr, out ToolLife toolLife)
        {
            Logger.Verbose($"Reading CuttingTool ToolLife...");
            toolLife = new ToolLife(xNode, nsmgr);
            if (!toolLife.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Asset] ToolLife of Asset:\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            ToolLife = toolLife;
            return true;
        }

        public bool TrySetCutterStatus(XmlNode xNode, XmlNamespaceManager nsmgr, out CutterStatus cutterStatus)
        {
            Logger.Verbose($"Reading CutterStatus...");
            cutterStatus = new CutterStatus(xNode, nsmgr);
            if (!cutterStatus.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Asset] Cutter Status of Asset:\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            CutterStatus = cutterStatus;
            return true;
        }

        public bool TrySetLocation(XmlNode xNode, XmlNamespaceManager nsmgr, out Location location)
        {
            Logger.Verbose($"Reading CuttingTool Location...");
            location = new Location(xNode, nsmgr);
            if (!location.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Asset] Location of Asset:\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            Location = location;
            return true;
        }

        public bool TrySetProcessSpindleSpeed(XmlNode xNode, XmlNamespaceManager nsmgr, out ProcessSpindleSpeed processSpindleSpeed)
        {
            Logger.Verbose($"Reading CuttingTool ProcessSpindleSpeed...");
            processSpindleSpeed = new ProcessSpindleSpeed(xNode, nsmgr);
            if (!processSpindleSpeed.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Asset] ProcessSpindleSpeed of Asset:\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            ProcessSpindleSpeed = processSpindleSpeed;
            return true;
        }

        public bool TrySetProcessFeedRate(XmlNode xNode, XmlNamespaceManager nsmgr, out ProcessFeedRate processFeedRate)
        {
            Logger.Verbose($"Reading CuttingTool ProcessFeedRate...");
            processFeedRate = new ProcessFeedRate(xNode, nsmgr);
            if (!processFeedRate.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Asset] ProcessFeedRate of Asset:\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            ProcessFeedRate = processFeedRate;
            return true;
        }

        public bool TryAddMeasurement(XmlNode xNode, XmlNamespaceManager nsmgr, out CuttingToolMeasurement measurement)
        {
            Logger.Verbose($"Reading CuttingTool Measurements...");
            measurement = new CuttingToolMeasurement(xNode, nsmgr);
            if (!measurement.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Asset] CuttingToolMeasurements of Asset:\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            _measurements.Add(measurement);
            return true;
        }

        public bool TrySetCuttingItems(XmlNode xNode, XmlNamespaceManager nsmgr, out CuttingItems cuttingItems)
        {
            Logger.Verbose($"Reading CuttingTool CuttingItems...");
            cuttingItems = new CuttingItems(xNode, nsmgr);
            if (!cuttingItems.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Asset] CuttingItems of Asset:\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            CuttingItems = cuttingItems;
            return true;
        }

        /// <inheritdoc />
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            var allErrors = new List<MtconnectValidationException>();

            if (CutterStatus == null)
            {
                allErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"CuttingToolLifeCycle missing 'CutterStatus'."));
            } else if (!CutterStatus.TryValidate(out ICollection<MtconnectValidationException> cutterStatusErrors)) {
                allErrors.AddRange(cutterStatusErrors);
            }

            if (ReconditionCount != null && !ReconditionCount.TryValidate(out ICollection<MtconnectValidationException> reconditionCountErrors))
            {
                allErrors.AddRange(reconditionCountErrors);
            }

            if (ToolLife != null && !ToolLife.TryValidate(out ICollection<MtconnectValidationException> toolLifeErrors))
            {
                allErrors.AddRange(toolLifeErrors);
            }

            if (Location != null && !Location.TryValidate(out ICollection<MtconnectValidationException> locationErrors))
            {
                allErrors.AddRange(locationErrors);
            }

            if (ProcessSpindleSpeed != null && !ProcessSpindleSpeed.TryValidate(out ICollection<MtconnectValidationException> processSpindleSpeedErrors))
            {
                allErrors.AddRange(processSpindleSpeedErrors);
            }

            if (ProcessFeedRate != null && !ProcessFeedRate.TryValidate(out ICollection<MtconnectValidationException> processFeedRateErrors))
            {
                allErrors.AddRange(processFeedRateErrors);
            }

            if (Measurements?.Any() == true)
            {
                foreach (var measurement in Measurements)
                {
                    if (!measurement.TryValidate(out ICollection<MtconnectValidationException> measurementErrors))
                    {
                        allErrors.AddRange(measurementErrors);
                    }
                }
            }

            if (CuttingItems != null && !CuttingItems.TryValidate(out ICollection<MtconnectValidationException> cuttingItemsErrors))
            {
                allErrors.AddRange(cuttingItemsErrors);
            }

            validationErrors = allErrors;
            if (validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR)) {
                return false;
            }
            return true;
        }
    }
}
