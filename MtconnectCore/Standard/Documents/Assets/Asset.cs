using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Assets;
using MtconnectCore.Standard.Contracts.Enums.Assets.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Assets.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Assets
{
    public abstract class Asset : MtconnectNode
    {
        /// <inheritdoc/>
        public Asset() : base() { }

        /// <inheritdoc/>
        public Asset(XmlNode xNode, XmlNamespaceManager nsmgr, string defaultNamespace) : base(xNode, nsmgr, defaultNamespace ?? Constants.DEFAULT_DEVICES_XML_NAMESPACE) { }

        /// <inheritdoc />
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors) => base.TryValidate(out validationErrors);
    }
    /// <summary>
    /// An element that can contain any descriptive content.
    /// </summary>
    /// <remarks>See Part 4 Section 6.1.3 of the MTConnect specification</remarks>
    public class CuttingToolDescription : MtconnectNode
    {
        /// <summary>
        /// The content of the description can be text or XML elements. This is the inner text of the XML element.
        /// </summary>
        public string Content { get; set; }

        /// <inheritdoc/>
        public CuttingToolDescription() : base() { }

        /// <inheritdoc/>
        public CuttingToolDescription(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE)
        {
            Content = xNode.Value;
        }
    }
    /// <inheritdoc />
    public class CuttingToolDefinition : MtconnectNode
    {
        /// <inheritdoc cref="CuttingToolDefinitionAttributes.FORMAT"/>
        [MtconnectNodeAttribute(CuttingToolDefinitionAttributes.FORMAT)]
        public string Format { get; set; }

        /// <summary>
        /// The content of the description can be text or XML elements. This is the outer XML of the XML element.
        /// </summary>
        public string Content { get; set; }

        /// <inheritdoc/>
        public CuttingToolDefinition() : base() { }

        /// <inheritdoc/>
        public CuttingToolDefinition(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE)
        {
            Content = xNode.OuterXml;
        }
    }
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

        // ReconditionCount
        // ToolLife

        /// <inheritdoc cref="CuttingToolLifeCycleElements.PROGRAM_TOOL_GROUP"/>
        [MtconnectNodeElement(nameof(CuttingToolLifeCycleElements.PROGRAM_TOOL_GROUP))]
        public string ProgramToolGroup { get; set; }

        /// <inheritdoc cref="CuttingToolLifeCycleElements.PROGRAM_TOOL_NUMBER"/>
        [MtconnectNodeElement(nameof(CuttingToolLifeCycleElements.PROGRAM_TOOL_NUMBER))]
        public string ProgramToolNumber { get; set; }

        // ProcessSpindleSpeed
        // ProcessFeedRate
        // ConnectionCodeMachineSide
        // Measurements
        // CuttingItems

        /// <inheritdoc />
        public CuttingToolLifeCycle() : base() { }

        /// <inheritdoc />
        public CuttingToolLifeCycle(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE)
        {

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

        /// <inheritdoc />
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();

            if (CutterStatus == null)
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"CuttingToolLifeCycle missing 'CutterStatus'."));
            } else if (!CutterStatus.TryValidate(out ICollection<MtconnectValidationException> cutterStatusErrors)) {
                foreach (var error in cutterStatusErrors)
                {
                    validationErrors.Add(error);
                }
            }

            if (Location != null && !Location.TryValidate(out ICollection<MtconnectValidationException> locationErrors))
            {
                foreach (var error in locationErrors)
                {
                    validationErrors.Add(error);
                }
            }

            if (validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR)) {
                return false;
            }
            return true;
        }
    }
    /// <inheritdoc />
    public class CutterStatus : MtconnectNode
    {
        public string[] Statuses { get; set; }

        /// <inheritdoc />
        public CutterStatus() : base() { }

        /// <inheritdoc />
        public CutterStatus(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE)
        {
            var statusValues = new List<string>();
            foreach (XmlNode childNode in xNode.SelectNodes("Status",nsmgr, Constants.DEFAULT_XML_NAMESPACE))
            {
                statusValues.Add(childNode.InnerText);
            }
            Statuses = statusValues.ToArray();
        }

        /// <inheritdoc />
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            const string documentationAttributes = "See Part 4 Section 6.1.10 of the MTConnect standard.";
            validationErrors = new List<MtconnectValidationException>();
            var invalidMappings = new Dictionary<CuttingToolStatusTypes, CuttingToolStatusTypes[]>() {
                {
                    CuttingToolStatusTypes.NEW,
                    new[] {
                        CuttingToolStatusTypes.USED,
                        CuttingToolStatusTypes.RECONDITIONED,
                        CuttingToolStatusTypes.EXPIRED
                    }
                },
                {
                    CuttingToolStatusTypes.UNKNOWN,
                    new[] {
                        CuttingToolStatusTypes.NEW,
                        CuttingToolStatusTypes.AVAILABLE,
                        CuttingToolStatusTypes.UNAVAILABLE,
                        CuttingToolStatusTypes.ALLOCATED,
                        CuttingToolStatusTypes.UNALLOCATED,
                        CuttingToolStatusTypes.MEASURED,
                        CuttingToolStatusTypes.RECONDITIONED,
                        CuttingToolStatusTypes.USED,
                        CuttingToolStatusTypes.EXPIRED,
                        CuttingToolStatusTypes.BROKEN,
                        CuttingToolStatusTypes.NOT_REGISTERED
                    }
                },
                {
                    CuttingToolStatusTypes.ALLOCATED,
                    new[] {
                        CuttingToolStatusTypes.UNALLOCATED
                    }
                },
                {
                    CuttingToolStatusTypes.AVAILABLE,
                    new[] {
                        CuttingToolStatusTypes.UNAVAILABLE,
                        CuttingToolStatusTypes.EXPIRED,
                        CuttingToolStatusTypes.BROKEN,
                        CuttingToolStatusTypes.NOT_REGISTERED
                    }
                }
            };
            if (Statuses.Any()) {
                foreach (string status in Statuses)
                {
                    if (Enum.TryParse<CuttingToolStatusTypes>(status, out CuttingToolStatusTypes statusType)) {
                        if (invalidMappings.TryGetValue(statusType, out CuttingToolStatusTypes[] invalidMap)) {
                            if (invalidMap.Any(o => Statuses.Any(s => s == o.ToString())))
                            {
                                validationErrors.Add(new MtconnectValidationException(
                                    Contracts.Enums.ValidationSeverity.ERROR,
                                    $"CutterStatus '{status}' MUST NOT be used with the following CutterStatus types: [{string.Join(", ", invalidMap.Select(o => o.ToString()))}].\r\n {documentationAttributes}"));
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }
    }
    /// <inheritdoc />
    public class Location : MtconnectNode
    {
        /// <inheritdoc cref="LocationAttributes.TYPE"/>
        [MtconnectNodeAttribute(LocationAttributes.TYPE)]
        public string Type { get; set; }

        /// <inheritdoc cref="LocationAttributes.POSITIVE_OVERLAP"/>
        [MtconnectNodeAttribute(LocationAttributes.POSITIVE_OVERLAP)]
        public int? PositiveOverlap { get; set; }

        /// <inheritdoc cref="LocationAttributes.NEGATIVE_OVERLAP"/>
        [MtconnectNodeAttribute(LocationAttributes.NEGATIVE_OVERLAP)]
        public int? NegativeOverlap { get; set; }

        public string Value { get; set; }

        /// <inheritdoc />
        public Location() : base() { }

        /// <inheritdoc />
        public Location(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE)
        {
            Value = xNode.InnerText;
        }

        /// <inheritdoc />
        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();

            if (string.IsNullOrEmpty(Type))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"CuttingTool Location missing 'type' attribute."));
            } else if (!Enum.TryParse<LocationTypes>(Type, out LocationTypes locationType))
            {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"Unrecognized CuttingTool Location 'type'."));
            }

            if (validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR)) {
                return false;
            }

            return true;
        }
    }
}
