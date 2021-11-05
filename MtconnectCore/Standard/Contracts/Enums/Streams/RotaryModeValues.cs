using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="EventElements.ROTARY_MODE"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
    public enum RotaryModeValues
    {
        /// <summary>
        /// The axis is operating like a spindle and spinning.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
        SPINDLE,
        /// <summary>
        /// The axis is indexing to a position.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
        INDEX,
        /// <summary>
        /// The axes is indexing and rotating at a programmed velocity.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 3 Section 3.10.1")]
        CONTOUR
    }
}
