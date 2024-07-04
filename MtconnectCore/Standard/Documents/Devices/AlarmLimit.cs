using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System.Collections.Generic;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <summary>
    /// A set of limits used to trigger warning or alarm indicators.
    /// </summary>
    public class AlarmLimit : MtconnectNode
    {
        // NOTE: Model browser has multiple instances of AlarmLimits

        /// <inheritdoc cref="AlarmLimitElements.UPPER_LIMIT"/>
        [MtconnectNodeElement(AlarmLimitElements.UPPER_LIMIT)]
        public double? UpperLimit { get; set; }

        /// <inheritdoc cref="AlarmLimitElements.UPPER_WARNING"/>
        [MtconnectNodeElement(AlarmLimitElements.UPPER_WARNING)]
        public double? UpperWarning { get; set; }

        /// <inheritdoc cref="AlarmLimitElements.LOWER_WARNING"/>
        [MtconnectNodeElement(AlarmLimitElements.LOWER_WARNING)]
        public double? LowerWarning { get; set; }

        /// <inheritdoc cref="AlarmLimitElements.LOWER_LIMIT"/>
        [MtconnectNodeElement(AlarmLimitElements.LOWER_LIMIT)]
        public double? LowerLimit { get; set; }

        /// <inheritdoc />
        public AlarmLimit() : base() { }

        /// <inheritdoc />
        public AlarmLimit(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE, version) { }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DeviceModel.ALARM_LIMIT)]
        private bool validateValueProperties(out ICollection<MtconnectValidationException> validationErrors)
            => new NodeValidationContext(this)
                .Validate((o) =>
                    o.If((x) => {
                        return UpperLimit == null && UpperWarning == null && LowerLimit == null && LowerWarning == null;
                    },
                        (x) => {
                            x.AddError("Missing constraints");
                            return x;
                        }
                    )
                )
                .HasError(out validationErrors);
    }
}
