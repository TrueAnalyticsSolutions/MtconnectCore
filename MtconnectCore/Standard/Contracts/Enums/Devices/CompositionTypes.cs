using System.Collections.Generic;
using System.Text;

namespace MtconnectCore.Standard.Contracts.Enums.Devices
{
    /// <summary>
    /// Available types of sub-parts of a <see cref="MtconnectCore.Standard.Documents.Devices.Component"/>.
    /// </summary>
    /// <remarks>See Part 2 Section 6 of the MTConnect specification.</remarks>
    public enum CompositionTypes
    {
        ACTUATOR,
        AMPLIFIER,
        BALLSCREW,
        BELT,
        BRAKE,
        CHAIN,
        CHOPPER,
        CHUCK,
        CHUTE,
        CIRCUIT_BREAKER,
        CLAMP,
        COMPRESSOR,
        DOOR,
        DRAIN,
        ENCODER,
        EXPOSURE_UNIT,
        EXTRUSION_UNIT,
        FAN,
        FILTER,
        GALVANOMOTOR,
        GRIPPER,
        HOPPER,
        LINEAR_POSITION_FEEDBACK,
        MOTOR,
        OIL,
        POWER_SUPPLY,
        PULLEY,
        PUMP,
        REEL,
        SENSING_ELEMENT,
        SPREADER,
        STORAGE_BATTERY,
        SWITCH,
        TABLE,
        TANK,
        TENSIONER,
        TRANSFORMER,
        VALVE,
        VAT,
        WATER,
        WIRE,
        WORKPIECE
    }
}
