using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using System;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    /// <summary>
    /// Default representation type for all Observation Types where <c>result</c> of the Observation  Types is an MTConnect data type.
    /// </summary>
    public abstract class Value : Observation, IRepresentation
    {
        /// <summary>
        /// Description of a means to interpret data consisting of multiple data points or samples reported as a single value.
        /// </summary>
        [MtconnectNodeAttribute(DataItemAttributes.REPRESENTATION)]
        public virtual string Representation { get; set; } = RepresentationTypes.VALUE.ToString();

        /// <summary>
        /// Collected from the textcontent of the Event element. Refer to Part 3 Streams - 5.5.3
        /// </summary>
        public virtual string Result { get; set; } = Constants.UNAVAILABLE;

        public override bool IsUnavailable => !string.IsNullOrEmpty(Result) && !Result.Equals(Constants.UNAVAILABLE, StringComparison.OrdinalIgnoreCase);

        public Value() : base() { }

        public Value(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) {

            Result = xNode.InnerText;
        }
    }
}
