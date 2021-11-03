using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    public enum ConditionTypes {
        /// <summary>
        /// Rate of Change of Velocity 
        /// </summary>
        ACCELERATION,
        /// <summary>
        /// The measurement of accumulated time associated with a Component
        /// </summary>
        ACCUMULATED_TIME,
        /// <summary>
        /// An actuator related condition.
        /// </summary>
        ACTUATOR,
        /// <summary>
        /// A high or low condition for the electrical current. 
        /// </summary>
        AMPERAGE,
        /// <summary>
        /// The angular position of a Component. 
        /// </summary>
        ANGLE,
        /// <summary>
        /// Rate of change of angular velocity.
        /// </summary>
        ANGULAR_ACCELERATION,
        /// <summary>
        /// Rate of change of angular position
        /// </summary>
        ANGULAR_VELOCITY,
        /// <summary>
        /// A communications failure indicator.
        /// </summary>
        COMMUNICATIONS,
        /// <summary>
        /// Percentage of one ingredient within a mixture of ingredients 
        /// </summary>
        CONCENTRATION,
        /// <summary>
        /// The ability of a material to conduct electricity
        /// </summary>
        CONDUCTIVITY,
        /// <summary>
        /// Information provided is outside of expected value range 
        /// </summary>
        DATA_RANGE,
        /// <summary>
        /// The direction of motion of a Component
        /// </summary>
        DIRECTION,
        /// <summary>
        /// The change in position of an object
        /// </summary>
        DISPLACEMENT,
        /// <summary>
        /// The measurement of electrical energy consumption by a Component
        /// </summary>
        ELECTRICAL_ENERGY,
        /// <summary>
        /// Represents the amount of a substance remaining compared to the planned  maximum amount of that substance
        /// </summary>
        FILL_LEVEL,
        /// <summary>
        /// The rate of flow of a fluid
        /// </summary>
        FLOW,
        /// <summary>
        /// The number of occurrences of a repeating event per unit time
        /// </summary>
        FREQUENCY,
        /// <summary>
        /// The hardware subsystem of the Component’s operation condition. 
        /// </summary>
        HARDWARE,
        [Obsolete("Deprecated in Rel. 1.2. See FILL_LEVEL")]
        LEVEL,
        /// <summary>
        /// The measure of the push or pull introduced by an actuator or exerted by an object
        /// </summary>
        LINEAR_FORCE,
        /// <summary>
        /// The measure of the percentage of the standard rating of a device
        /// </summary>
        LOAD,
        /// <summary>
        /// An error occurred in the logic program or PLC (programmable logic controller).
        /// </summary>
        LOGIC_PROGRAM,
        /// <summary>
        /// The measurement of the mass of an object(s) or an amount of material
        /// </summary>
        MASS,
        /// <summary>
        /// An error occurred in the motion program.
        /// </summary>
        MOTION_PROGRAM,
        /// <summary>
        /// The federate of the tool path
        /// </summary>
        PATH_FEEDRATE,
        /// <summary>
        /// The current control point of the path 
        /// </summary>
        PATH_POSITION,
        /// <summary>
        /// The measure of acidity or alkalinity 
        /// </summary>
        PH,
        /// <summary>
        /// The position of a Component. 
        /// </summary>
        POSITION,
        /// <summary>
        /// The ratio of real power flowing to a load to the apparent power in that AC circuit.
        /// </summary>
        POWER_FACTOR,
        /// <summary>
        /// The measurement of the force per unit area exerted by a gas or liquid. 
        /// </summary>
        PRESSURE,
        /// <summary>
        /// The measurement of the degree to which an object opposes an electric curren through it
        /// </summary>
        RESISTANCE,
        /// <summary>
        /// The rotational speed of a rotary axis 
        /// </summary>
        ROTARY_VELOCITY,
        /// <summary>
        /// The measurement of sound pressure level
        /// </summary>
        SOUND_LEVEL,
        [Obsolete("Deprecated in Rel. 1.2. See ROTARY_VELOCITY.")]
        SPINDLE_SPEED,
        /// <summary>
        /// Indicates the amount of deformation per unit length of an object when a load i applied
        /// </summary>
        STRAIN,
        /// <summary>
        /// A condition representing something that is not the operator, program, or  hardware. This is often used for operating system issues.
        /// </summary>
        SYSTEM,
        /// <summary>
        /// Indicates the temperature of a Component.
        /// </summary>
        TEMPERATURE,
        /// <summary>
        /// The measure of angular displacement 
        /// </summary>
        TILT,
        /// <summary>
        /// The measured of the turning force exerted on an object or by an object 
        /// </summary>
        TORQUE,
        /// <summary>
        /// The measure of the apparent power in an electrical circuit (commonly referred  as VA)
        /// </summary>
        VOLT_AMPERAGE,
        /// <summary>
        /// The measure of reactive power in an AC electrical power circuit (commonly  referred to as var).
        /// </summary>
        VOLT_AMPERAGE_REACTIVE,
        /// <summary>
        /// Indicated the velocity of a component. 
        /// </summary>
        VELOCITY,
        /// <summary>
        /// The measure of a fluid’s resistance to flow
        /// </summary>
        VISCOSITY,
        /// <summary>
        /// The measurement of electrical potential between two points 
        /// </summary>
        VOLTAGE,
        /// <summary>
        /// The measurement of power consumed or dissipated by an electrical circuit or device
        /// </summary>
        WATTAGE
    }
}
