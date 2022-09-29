using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Assets;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Assets
{
    /// <inheritdoc />
    public class CutterStatus : MtconnectNode
    {
        public string[] Statuses { get; set; }

        /// <inheritdoc />
        public CutterStatus() : base() { }

        /// <inheritdoc />
        public CutterStatus(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE, version)
        {
            var statusValues = new List<string>();
            foreach (XmlNode childNode in xNode.SelectNodes("Status",nsmgr, Constants.DEFAULT_XML_NAMESPACE))
            {
                statusValues.Add(childNode.InnerText);
            }
            Statuses = statusValues.ToArray();
        }

        /// <inheritdoc />
        public override bool TryValidate(ValidationReport report)
        {
            using (var validationContext = report.CreateContext(this))
            {
                var baseResult = base.TryValidate(report);

                const string documentationAttributes = "See Part 4 Section 6.1.10 of the MTConnect standard.";
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
                if (Statuses.Any())
                {
                    foreach (string status in Statuses)
                    {
                        if (Enum.TryParse<CuttingToolStatusTypes>(status, out CuttingToolStatusTypes statusType))
                        {
                            if (invalidMappings.TryGetValue(statusType, out CuttingToolStatusTypes[] invalidMap))
                            {
                                if (invalidMap.Any(o => Statuses.Any(s => s == o.ToString())))
                                {
                                    validationContext.AddExceptions(new MtconnectValidationException(
                                        Contracts.Enums.ValidationSeverity.ERROR,
                                        $"CutterStatus '{status}' MUST NOT be used with the following CutterStatus types: [{string.Join(", ", invalidMap.Select(o => o.ToString()))}].\r\n {documentationAttributes}"));
                                }
                            }
                        }
                    }
                }

                return baseResult && !validationContext.HasErrors();
            }
        }
    }
}
