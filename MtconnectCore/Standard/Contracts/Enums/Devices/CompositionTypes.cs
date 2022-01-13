using MtconnectCore.Standard.Contracts.Attributes;
using System.Collections.Generic;
using System.Text;

namespace MtconnectCore.Standard.Contracts.Enums.Devices
{
    /// <summary>
    /// Available types of sub-parts of a <see cref="MtconnectCore.Standard.Documents.Devices.Component"/>.
    /// </summary>
    /// <remarks>See Part 2 Section 6 of the MTConnect specification.</remarks>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
    public enum CompositionTypes
    {
        /// <summary>
        /// A mechanism for moving or controlling a mechanical part of a piece of  equipment. It takes energy usually provided by air, electric current, or liquid and converts the energy into some kind of motion.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        ACTUATOR,
        /// <summary>
        /// An electronic component or circuit for amplifying power, electric  current, or voltage
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        AMPLIFIER,
        /// <summary>
        /// A mechanical structure for transforming rotary motion into linear  motion.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        BALLSCREW,
        /// <summary>
        /// An endless flexible band used to transmit motion for a piece of  equipment or to convey materials and objects.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        BELT,
        /// <summary>
        /// A mechanism for slowing or stopping a moving object by the  absorption or transfer of the energy of momentum, usually by means of friction, electrical force, or magnetic force.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        BRAKE,
        /// <summary>
        /// An interconnected series of objects that band together and are used to  transmit motion for a piece of equipment or to convey materials and objects.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        CHAIN,
        /// <summary>
        /// A mechanism used to break material into smaller pieces.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        CHOPPER,
        /// <summary>
        /// A mechanism that holds a part, stock material, or any other item in  place.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        CHUCK,
        /// <summary>
        /// An inclined channel for conveying material.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        CHUTE,
        /// <summary>
        /// A mechanism for interrupting an electric circuit.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        CIRCUIT_BREAKER,
        /// <summary>
        /// A mechanism used to strengthen, support, or fasten objects in place.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        CLAMP,
        /// <summary>
        /// A pump or other mechanism for reducing volume and increasing  pressure of gases in order to condense the gases to drive pneumatically powered pieces of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        COMPRESSOR,
        /// <summary>
        /// A mechanical mechanism or closure that can cover a physical access  portal into a piece of equipment allowing or restricting access to other parts of the equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        DOOR,
        /// <summary>
        /// A mechanism that allows material to flow for the purpose of drainage  from, for example, a vessel or tank.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        DRAIN,
        /// <summary>
        /// A mechanism used to measure rotary position.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        ENCODER,
        /// <summary>
        /// A mechanism for emitting a type of radiation
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 6")]
        EXPOSURE_UNIT,
        /// <summary>
        /// A mechanism for dispensing liquid or powered materials
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 6")]
        EXTRUSION_UNIT,
        /// <summary>
        /// Any mechanism for producing a current of air.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        FAN,
        /// <summary>
        /// Any substance or structure through which liquids or gases are passed to  remove suspended impurities or to recover solids.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        FILTER,
        /// <summary>
        /// An electromechanical actuator that produces deflection of a beam of light or energy in response to electric current through its coil in a magnetic field.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 6")]
        GALVANOMOTOR,
        /// <summary>
        /// A mechanism that holds a part, stock material, or any other item in  place.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        GRIPPER,
        /// <summary>
        /// A chamber or bin in which materials are stored temporarily, typically  being filled through the top and dispensed through the bottom.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        HOPPER,
        /// <summary>
        /// A mechanism that measures linear motion or position.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        LINEAR_POSITION_FEEDBACK,
        /// <summary>
        /// A mechanism that converts electrical, pneumatic, or hydraulic energy  into mechanical energy.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        MOTOR,
        /// <summary>
        /// A viscous liquid.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        OIL,
        /// <summary>
        /// A unit that provides power to electric mechanisms
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        POWER_SUPPLY,
        /// <summary>
        /// A mechanism or wheel that turns in a frame or block and serves to  change the direction of or to transmit force.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        PULLEY,
        /// <summary>
        /// An apparatus raising, driving, exhausting, or compressing fluids or  gases by means of a piston, plunger, or set of rotating vanes.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        PUMP,
        /// <summary>
        /// A rotary storage unit for material
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 6")]
        REEL,
        /// <summary>
        /// A mechanism that provides a signal or measured value.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        SENSING_ELEMENT,
        /// <summary>
        /// A mechanism for flattening or spreadin materials
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 6")]
        SPREADER,
        /// <summary>
        /// A component consisting of one or more cells, in which chemical energy  is converted into electricity and used as a source of power.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        STORAGE_BATTERY,
        /// <summary>
        /// A mechanism for turning on or off an electric current or for making or  breaking a circuit.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        SWITCH,
        /// <summary>
        /// A surface for holding an object or material
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 6")]
        TABLE,
        /// <summary>
        /// A receptacle or container for holding material.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        TANK,
        /// <summary>
        /// A mechanism that provides or applies a stretch or strain to another  mechanism.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        TENSIONER,
        /// <summary>
        /// A mechanism that transforms electric energy from a source to a  secondary circuit.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        TRANSFORMER,
        /// <summary>
        /// Any mechanism for halting or controlling the flow of a liquid, gas, or  other material through a passage, pipe, inlet, or outlet.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        VALVE,
        /// <summary>
        /// A container for liquid or powdered materials
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 6")]
        VAT,
        /// <summary>
        /// A fluid.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        WATER,
        /// <summary>
        /// A string like piece or filament of relatively rigid or flexible material  provided in a variety of diameters
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 6")]
        WIRE,
        WORKPIECE
    }
}
