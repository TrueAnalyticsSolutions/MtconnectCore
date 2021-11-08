using MtconnectCore.Standard.Contracts.Attributes;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.3")]
    public enum ConditionTypes {
        /// <summary>
        /// Rate of Change of Velocity 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        ACCELERATION,
        /// <summary>
        /// The measurement of accumulated time associated with a Component
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        ACCUMULATED_TIME,
        /// <summary>
        /// An actuator related condition.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.3")]
        ACTUATOR,
        /// <summary>
        /// A high or low condition for the electrical current. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.3")]
        AMPERAGE,
        /// <summary>
        /// The angular position of a Component. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        ANGLE,
        /// <summary>
        /// Rate of change of angular velocity.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        ANGULAR_ACCELERATION,
        /// <summary>
        /// Rate of change of angular position
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        ANGULAR_VELOCITY,
        /// <summary>
        /// A communications failure indicator.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.3")]
        COMMUNICATIONS,
        /// <summary>
        /// Percentage of one ingredient within a mixture of ingredients 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        CONCENTRATION,
        /// <summary>
        /// The ability of a material to conduct electricity
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        CONDUCTIVITY,
        /// <summary>
        /// Information provided is outside of expected value range 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        DATA_RANGE,
        /// <summary>
        /// The direction of motion of a Component
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        DIRECTION,
        /// <summary>
        /// The change in position of an object
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        DISPLACEMENT,
        /// <summary>
        /// The measurement of electrical energy consumption by a Component
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        ELECTRICAL_ENERGY,
        /// <summary>
        /// An indication that the end of a piece of bar stock has been reached.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.3")]
        END_OF_BAR,
        /// <summary>
        /// Represents the amount of a substance remaining compared to the planned  maximum amount of that substance
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        FILL_LEVEL,
        /// <summary>
        /// The rate of flow of a fluid
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        FLOW,
        /// <summary>
        /// The number of occurrences of a repeating event per unit time
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        FREQUENCY,
        /// <summary>
        /// The hardware subsystem of the Component’s operation condition. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.3")]
        HARDWARE,
        /// <summary>
        /// An indication of the operation condition of an Interface component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.3")]
        INTERFACE_STATE,
        [Obsolete("Deprecated in Rel. 1.2. See FILL_LEVEL")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.3", MtconnectVersions.V_1_1_0)]
        LEVEL,
        /// <summary>
        /// The measure of the push or pull introduced by an actuator or exerted by an object
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        LINEAR_FORCE,
        /// <summary>
        /// The measure of the percentage of the standard rating of a device
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.3")]
        LOAD,
        /// <summary>
        /// An error occurred in the logic program or PLC (programmable logic controller).
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.3")]
        LOGIC_PROGRAM,
        /// <summary>
        /// The measurement of the mass of an object(s) or an amount of material
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        MASS,
        /// <summary>
        /// An error occurred in the motion program.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.3")]
        MOTION_PROGRAM,
        /// <summary>
        /// The federate of the tool path
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        PATH_FEEDRATE,
        /// <summary>
        /// The current control point of the path 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        PATH_POSITION,
        /// <summary>
        /// The measure of acidity or alkalinity 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        PH,
        /// <summary>
        /// The position of a Component. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.3")]
        POSITION,
        /// <summary>
        /// The ratio of real power flowing to a load to the apparent power in that AC circuit.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        POWER_FACTOR,
        /// <summary>
        /// The measurement of the force per unit area exerted by a gas or liquid. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.3")]
        PRESSURE,
        /// <summary>
        /// The measurement of the degree to which an object opposes an electric curren through it
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        RESISTANCE,
        /// <summary>
        /// The rotational speed of a rotary axis 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        ROTARY_VELOCITY,
        /// <summary>
        /// The measurement of sound pressure level
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        SOUND_LEVEL,
        [Obsolete("Deprecated in Rel. 1.2. See ROTARY_VELOCITY.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12", MtconnectVersions.V_1_2_0)]
        SPINDLE_SPEED,
        /// <summary>
        /// Indicates the amount of deformation per unit length of an object when a load i applied
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        STRAIN,
        /// <summary>
        /// A condition representing something that is not the operator, program, or  hardware. This is often used for operating system issues.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.3")]
        SYSTEM,
        /// <summary>
        /// Indicates the temperature of a Component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.3")]
        TEMPERATURE,
        /// <summary>
        /// The measure of angular displacement 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        TILT,
        /// <summary>
        /// The measured of the turning force exerted on an object or by an object 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        TORQUE,
        /// <summary>
        /// The measure of the apparent power in an electrical circuit (commonly referred  as VA)
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        VOLT_AMPERAGE,
        /// <summary>
        /// The measure of reactive power in an AC electrical power circuit (commonly  referred to as var).
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        VOLT_AMPERAGE_REACTIVE,
        /// <summary>
        /// Indicated the velocity of a component. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.3")]
        VELOCITY,
        /// <summary>
        /// The measure of a fluid’s resistance to flow
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        VISCOSITY,
        /// <summary>
        /// The measurement of electrical potential between two points 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.3")]
        VOLTAGE,
        /// <summary>
        /// The measurement of power consumed or dissipated by an electrical circuit or device
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.12")]
        WATTAGE
    }
}
