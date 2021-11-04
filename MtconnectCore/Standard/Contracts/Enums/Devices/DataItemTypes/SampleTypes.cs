using System;
using System.Collections.Generic;
using System.Text;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    public enum SampleTypes
    {
        /// <summary>
        /// Rate of change of velocity
        /// </summary>
        ACCELERATION,
        /// <summary>
        /// The measurement of accumulated time associated with a Component
        /// </summary>
        ACCUMULATED_TIME,
        /// <summary>
        /// Rate of change of angular velocity.
        /// </summary>
        ANGULAR_ACCELERATION,
        /// <summary>
        /// Rate of change of angular position.
        /// </summary>
        ANGULAR_VELOCITY,
        /// <summary>
        /// The measurement of AC Current or a DC current. See <c>subType</c>s: <seealso cref="AmperageSubTypes"/>
        /// </summary>
        AMPERAGE,
        /// <summary>
        /// The angular position of a component relative to the  parent. See <c>subType</c>s: <seealso cref="AngleSubTypes"/>
        /// </summary>
        ANGLE,
        /// <summary>
        /// The feedrate of a linear axis. See <c>subType</c>s: <seealso cref="AxisFeedrateSubTypes"/>
        /// </summary>
        AXIS_FEEDRATE,
        /// <summary>
        /// The reading of a timing device at a specific point in  time. Clock time MUST be reported in W3C ISO 8601 format.
        /// </summary>
        CLOCK_TIME,
        /// <summary>
        /// Percentage of one component within a mixture of  components
        /// </summary>
        CONCENTRATION,
        /// <summary>
        /// The ability of a material to conduct electricity 
        /// </summary>
        CONDUCTIVITY,
        /// <summary>
        /// The displacement as the change in position of an  object
        /// </summary>
        DISPLACEMENT,
        /// <summary>
        /// The measurement of electrical energy consumption  by a component
        /// </summary>
        ELECTRICAL_ENERGY,
        /// <summary>
        /// The measurement of the amount of a substance  remaining compared to the planned maximum amount of that substance
        /// </summary>
        FILL_LEVEL,
        /// <summary>
        /// The rate of flow of a fluid
        /// </summary>
        FLOW,
        /// <summary>
        /// The measurement of the number of occurrences of a  repeating event per unit time
        /// </summary>
        FREQUENCY,
        [Obsolete("Deprecated in Rel. 1.1")]
        GLOBAL_POSITION,
        [Obsolete("Deprecated in Rel. 1.2 See FILL_LEVEL")]
        LEVEL,
        /// <summary>
        /// The measure of the push or pull introduced by an  actuator or exerted on an object
        /// </summary>
        LINEAR_FORCE,
        /// <summary>
        /// The measurement of the percentage of the standard  rating of a device
        /// </summary>
        LOAD,
        /// <summary>
        /// The measurement of the mass of an object(s) or an  amount of material
        /// </summary>
        MASS,
        /// <summary>
        /// The feedrate of the tool path. See <c>subType</c>s: <seealso cref="PathFeedrateSubTypes"/>
        /// </summary>
        PATH_FEEDRATE,
        /// <summary>
        /// The current program control point or program  coordinate in WORK coordinates. The coordinate system will revert to MACHINE coordinates if WORK coordinates are not available. See <c>subType</c>s: <seealso cref="PathPositionSubTypes"/>
        /// </summary>
        PATH_POSITION,
        /// <summary>
        /// The measure of the acidity or alkalinity.
        /// </summary>
        PH,
        /// <summary>
        /// The position of the Component. Defaults to  MACHINE coordinates. See <c>subType</c>s: <seealso cref="PositionSubTypes"/>
        /// </summary>
        POSITION,
        /// <summary>
        /// The measurement of the ratio of real power flowing  to a load to the apparent power in that AC circuit.
        /// </summary>
        POWER_FACTOR,
        /// <summary>
        /// The force per unit area exerted by a gas or liquid
        /// </summary>
        PRESSURE,
        /// <summary>
        /// The measurement of the degree to which an object  opposes an electric current through it
        /// </summary>
        RESISTANCE,
        /// <summary>
        /// The rotational speed of a rotary axis. See <c>subType</c>s: <seealso cref="RotaryVelocitySubTypes"/>
        /// </summary>
        ROTARY_VELOCITY,
        /// <summary>
        /// Measurement of a sound level or sound pressure level  relative to atmospheric pressure. See <c>subType</c>s: <seealso cref="SoundLeveSubTypes"/>
        /// </summary>
        SOUND_LEVEL,
        [Obsolete("Deprecated in Rel. 1.2. Replaced by ROTARY_VELOCITY")]
        SPINDLE_SPEED,
        /// <summary>
        /// Strain is the amount of deformation per unit length of an object when a load is applied.
        /// </summary>
        STRAIN,
        /// <summary>
        /// The measurement of temperature
        /// </summary>
        TEMPERATURE,
        /// <summary>
        /// A measurement of angular displacement
        /// </summary>
        TILT,
        /// <summary>
        /// The turning force exerted on an object or by an object
        /// </summary>
        TORQUE,
        /// <summary>
        /// The measure of the apparent power in an electrical  circuit, equal to the product of root-mean-square (RMS) voltage and RMS current’ (commonly referred to as VA)
        /// </summary>
        VOLT_AMPERE,
        /// <summary>
        /// The measurement of reactive power in an AC  electrical circuit (commonly referred to as var)
        /// </summary>
        VOLT_AMPERE_REACTIVE,
        /// <summary>
        /// The rate of change of position. 
        /// </summary>
        VELOCITY,
        /// <summary>
        /// A measurement of a fluid’s resistance to flow 
        /// </summary>
        VISCOSITY,
        /// <summary>
        /// The measurement of electrical potential between two  points. See <c>subType</c>s: <seealso cref="VoltageSubTypes"/>
        /// </summary>
        VOLTAGE,
        /// <summary>
        /// The measurement of power consumed or dissipated  by an electrical circuit or device
        /// </summary>
        WATTAGE
    }
}
