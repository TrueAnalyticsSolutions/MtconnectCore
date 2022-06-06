using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Elements
{
    /// <summary>
    /// Elements within the Specification element in the MTConnect Response document.
    /// </summary>
    public enum SpecificationElements {
        /// <summary>
        /// A numeric upper limit constraint. 
        /// </summary>
        MAXIMUM,
        /// <summary>
        /// A numeric lower limit constraint.
        /// </summary>
        MINIMUM,
        /// <summary>
        /// The numeric target or expected value. 
        /// </summary>
        NOMINAL
    }
}
