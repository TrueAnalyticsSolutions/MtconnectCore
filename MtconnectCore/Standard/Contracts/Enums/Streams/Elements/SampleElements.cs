using MtconnectCore.Standard.Contracts.Attributes;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Streams.Elements
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
    public enum SampleElements
    {
        /// <summary>
        /// The acceleration of the component MUST always be reported in MILLIMETER/SECOND^2. An acceleration MUST have a numeric value.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        ACCELERATION,
        /// <summary>
        /// The accumulated time associated with a component. The AccumulatedTime MUST have a numeric value and MUST be reported in SECOND.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.8.4")]
        ACCUMULATED_TIME,
        /// <summary>
        /// The current in an electrical circuit. The amperage MUST have a numeric  348 value and MUST be reported in AMPS.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        AMPERAGE,
        /// <summary>
        /// An angle MUST always be reported in DEGREE and MUST always have a numeric CDATA value as a floating point number.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        ANGLE,
        /// <summary>
        /// The angular acceleration of the component as measured in DEGREE/SECOND^2. An acceleration MUST have a numeric value.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        ANGULAR_ACCELERATION,
        /// <summary>
        /// A angular velocity represents the rate of change in angle. An angular velocity MUST always be reported in DEGREE/SECOND and MUST always have a numeric CDATA value as a floating point number.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        ANGULAR_VELOCITY,
        /// <summary>
        /// Axis Feedrate is defined as the rate of motion of the feed axis of the tool  relative to the workpiece. An axis feedrate MUST always be reported in MILLIMETER/SECOND or PERCENT for override and MUST always have a numeric CDATA value as a floating point number.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        AXIS_FEEDRATE,
        /// <summary>
        /// The reading of a timing device at a specific point in time. The time MUST have a value reported in W3C ISO 8601 format of YYYY-MM DDThh:mm:ss.ffff
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.8.4")]
        CLOCK_TIME,
        /// <summary>
        /// Percentage of one component within a mixture of components. The Concentration MUST have a value reported in PERCENT.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.8.4")]
        CONCENTRATION,
        /// <summary>
        /// The ability of a material to conduct electricity. The Conductivity MUST have a value reported in SIEMENS/METER.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.8.4")]
        CONDUCTIVITY,
        /// <summary>
        /// The displacement as measured from zero to peak. The displacement MUST have a value reported in MILLIMETER.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        DISPLACEMENT,
        /// <summary>
        /// The measurement of electrical energy consumed by a component. ElectricalEnergy MUST have a value reported in WATT_SECOND.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.8.4")]
        ELECTRICAL_ENERGY,
        /// <summary>
        /// The measurement of the amount of time a piece of  equipment or a sub-part of a piece of equipment has performed specific activities.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.1")]
        EQUIPMENT_TIMER,
        /// <summary>
        /// The rate of flow of a fluid. The Flow MUST have a value reported in LITER/SECOND.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.8.4")]
        FLOW,
        /// <summary>
        /// The rate at which a component is vibrating. The frequency MUST have a numeric value and MUST be reported in HERTZ.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        FREQUENCY,
        /// <summary>
        /// The measurement of the amount of a substance remaining compared to the planned maximum amount of that substance. The FillLevel MUST be reported in PERCENT.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.8.4")]
        FILL_LEVEL,
        /// <summary>
        /// The length of an object, usually a piece of material or stock. The Length MUST be report in MILLIMETER.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 3 Section 3.8.4")]
        LENGTH,
        /// <summary>
        /// The measurement of the amount of push or pull introduced by an actuator or exerted on an object. The LinearForce MUST be reported in NEWTON.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.8.4")]
        LINEAR_FORCE,
        /// <summary>
        /// The load on a component. The load MUST always be reported in NEWTON and MUST always have a numeric CDATA value as a floating point number.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        LOAD,
        /// <summary>
        /// The measurement of the mass of an object(s) or an amount of material. The Mass MUST be reported in KILOGRAM.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.8.4")]
        MASS,
        /// <summary>
        /// Path Feedrate is defined as the rate of motion of the feed path of the tool  relative to the workpiece. A path feedrate MUST always be reported in MILLIMETER/SECOND or PERCENT for override and MUST always have a numeric CDATA value as a floating point number.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        PATH_FEEDRATE,
        /// <summary>
        /// The program position as given in 3 dimensional space. This position MUST default to WORK coordinates, if the WORK coordinates are defined, and MUST be given as a space delimited vector of floating point numbers given in MILLIMETER_3D units. The PathPosition will be given in the following format and MUST be listed in order X, Y, and Z: &lt;PathPosition …&gt;10.123 55.232 100.981&lt;/PathPosition&gt; Where X = 10.123, Y = 55.232, and Z = 100.981.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.8.4")]
        PATH_POSITION,
        /// <summary>
        /// The measure of acidity or akalinity. The PH MUST be a numeric value and MUST be provided in PH.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.8.4")]
        PH,
        /// <summary>
        /// The global position is the three space coordinate of the tool. A global position MUST always be reported in MILLIMETER and MUST always have a numeric CDATA value as three floating point numbers (x, y, and z). Position MUST always be given in absolute coordinates.
        /// </summary>
        [Obsolete("Deprecated in version 1.1.0 of the MTConnect Standard")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2", MtconnectVersions.V_1_0_1)]
        GLOBAL_POSITION,
        /// <summary>
        /// A position represents the location along a linear axis. A position MUST always be reported in MILLIMETER and MUST always have a numeric CDATA value as a floating point number. Position MUST always be given in absolute coordinates.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        POSITION,
        /// <summary>
        /// The measurement of the ratio of real power flowing to a load to the apparent power in that AC circuit. The PowerFactor MUST be a numeric value and MUST be provided in PERCENT.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.8.4")]
        POWER_FACTOR,
        /// <summary>
        /// The pressure on a component. The pressure MUST be a numeric value and MUST be provided in PASCALS.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        PRESSURE,
        /// <summary>
        /// The measurement of the amount of time a piece of  equipment has performed different types of activities associated with the process being performed at that piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.1")]
        PROCESS_TIMER,
        /// <summary>
        /// The measure of the degree to which an object opposes an electrical current through it. The Resistance MUST be a numeric value and MUST be provided in OHM.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.8.4")]
        RESISTANCE,
        /// <summary>
        /// The rate of rotation of a rotary axis. A RotaryVelocity speed MUST always be reported in REVOLUTION/MINUTE or PERCENT for OVERRIDE.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.8.4")]
        ROTARY_VELOCITY,
        /// <summary>
        /// The measure of acoustic sound level or sound pressure level. The SoundLevel MUST be provided in DECIBEL
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.8.4")]
        SOUND_LEVEL,
        /// <summary>
        /// The rate of rotation of a machine spindle. A spindle speed MUST always be reported in REVOLUTION/MINUTE and MUST always have a numeric CDATA value as a floating point number.
        /// </summary>
        [Obsolete("Deprecated in version 1.2.0. See RotaryVelocity instead.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2", MtconnectVersions.V_1_1_0)]
        SPINDLE_SPEED,
        /// <summary>
        /// The measured amount of deformation per unit length of an object. Strain MUST be reported as PERCENT.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.8.4")]
        STRAIN,
        /// <summary>
        /// Temperature MUST always be reported in degrees CELSIUS and MUST always have a numeric CDATA value as a floating point number.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        TEMPERATURE,
        /// <summary>
        /// The measurement of a force that stretches or  elongates an object.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 3 Section 6.1")]
        TENSION,
        /// <summary>
        /// The measured amount of angular displacement of an object. Tilt MUST be reported as MICRO_RADIAN.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.8.4")]
        TILT,
        /// <summary>
        /// The torque of the component MUST be reported in SI units of NEWTON_METER and MUST have a numeric CDATA value as a floating point number.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        TORQUE,
        /// <summary>
        /// A velocity represents the rate of change in position along one or more axis. When given as a Sample for the Axes component, it represents the magnitude of the velocity vector for all given axis, similar to a path feedrate. A velocity MUST always be reported in MILLIMETER/SECOND and MUST always have a numeric CDATA value as a floating point number.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        VELOCITY,
        /// <summary>
        /// The measurement of a fluid’s resistance to flow. Viscosity MUST be reported as PASCAL_SECOND.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.8.4")]
        VISCOSITY,
        /// <summary>
        /// The measurement of electrical potential between two points. The Voltage MUST have a numeric value and MUST be reported in VOLT.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.8.4")]
        VOLTAGE,
        /// <summary>
        /// The measurement of apparent power in an electrical circuit, equal to the product of the RMS voltage and RMS current. The VoltAmpere MUST have a numeric value and MUST be reported in VOLT_AMPERE.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.8.4")]
        VOLT_AMPERE,
        /// <summary>
        /// The measurement of reactive power in an AC electrical circuit. The VoltAmpereReactive MUST have a numeric value and MUST be reported in VOLT_AMPERE_REACTIVE.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.8.4")]
        VOLT_AMPERE_REACTIVE,
        /// <summary>
        /// The potential difference as measured across an electrical circuit. The voltage MUST have a numeric value and MUST be reported in VOLTS.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2", MtconnectVersions.V_1_1_0)]
        VOLTS,
        /// <summary>
        /// The electrical power (volt-amps) consumed or dissipated by an electrical circuit or device. The Wattage MUST have a numeric value and MUST be reported in WATT.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 3 Section 3.8.4")]
        WATTAGE,
        /// <summary>
        /// The electrical power (volt-amps) of an electrical circuit. The watts MUST have a numeric value and MUST be reported in WATTS.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        WATTS
    }
}
