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
        /// Path Feedrate is defined as the rate of motion of the feed path of the tool  relative to the workpiece. A path feedrate MUST always be reported in MILLIMETER/SECOND or PERCENT for override and MUST always have a numeric CDATA value as a floating point number.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        PATH_FEEDRATE,
        /// <summary>
        /// The rate at which a component is vibrating. The frequency MUST have a numeric value and MUST be reported in HERTZ.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        FREQUENCY,
        /// <summary>
        /// The displacement as measured from zero to peak. The displacement MUST have a value reported in MILLIMETER.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        DISPLACEMENT,
        /// <summary>
        /// The global position is the three space coordinate of the tool. A global position MUST always be reported in MILLIMETER and MUST always have a numeric CDATA value as three floating point numbers (x, y, and z). Position MUST always be given in absolute coordinates.
        /// </summary>
        [Obsolete("Deprecated in version 1.1.0 of the MTConnect Standard")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2", MtconnectVersions.V_1_0_1)]
        GLOBAL_POSITION,
        /// <summary>
        /// The load on a component. The load MUST always be reported in NEWTON and MUST always have a numeric CDATA value as a floating point number.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        LOAD,
        /// <summary>
        /// A position represents the location along a linear axis. A position MUST always be reported in MILLIMETER and MUST always have a numeric CDATA value as a floating point number. Position MUST always be given in absolute coordinates.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        POSITION,
        /// <summary>
        /// The pressure on a component. The pressure MUST be a numeric value and MUST be provided in PASCALS.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        PRESSURE,
        /// <summary>
        /// The rate of rotation of a machine spindle. A spindle speed MUST always be reported in REVOLUTION/MINUTE and MUST always have a numeric CDATA value as a floating point number.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        SPINDLE_SPEED,
        /// <summary>
        /// Temperature MUST always be reported in degrees CELSIUS and MUST always have a numeric CDATA value as a floating point number.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        TEMPERATURE,
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
        /// The potential difference as measured across an electrical circuit. The voltage MUST have a numeric value and MUST be reported in VOLTS.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        VOLTS,
        /// <summary>
        /// The electrical power (volt-amps) of an electrical circuit. The watts MUST have a numeric value and MUST be reported in WATTS.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 3 Section 3.6.2")]
        WATTS
    }
}
