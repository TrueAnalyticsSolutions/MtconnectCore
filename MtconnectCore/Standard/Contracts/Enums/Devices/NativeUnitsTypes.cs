using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Documents.Devices;

namespace MtconnectCore.Standard.Contracts.Enums.Devices
{
    /// <summary>
    /// Available options for a <c>nativeUnits</c> attribute on a <see cref="DataItem.NativeUnits"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
    public enum NativeUnitsTypes {
        /// <summary>
        /// A measure of Viscosity
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.9")]
        CENTIPOISE,
        /// <summary>
        /// Rotational velocity in degrees per minute
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
        DEGREE_PER_MINUTE,
        /// <summary>
        /// Temperature in Fahrenheit 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
        FAHRENHEIT,
        /// <summary>
        /// Feet
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
        FOOT,
        /// <summary>
        /// Feet per minute 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
        FOOT_PER_MINUTE,
        /// <summary>
        /// Feet per second
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
        FOOT_PER_SECOND,
        /// <summary>
        /// Acceleration in feet per second squared
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
        FOOT_PER_SECOND_SQUARED,
        /// <summary>
        /// A point in space identified by X, Y, and Z positions and represented by a space delimited set of numbers each expressed in feet. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
        FOOT_3D,
        /// <summary>
        /// Gallons per minute. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
        GALLON_PER_MINUTE,
        /// <summary>
        /// A measurement of time in hours
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 7.2.2.6")]
        HOUR,
        /// <summary>
        /// Inches
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
        INCH,
        /// <summary>
        /// Inches per minute
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
        INCH_PER_MINUTE,
        /// <summary>
        /// Inches per second
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
        INCH_PER_SECOND,
        /// <summary>
        /// Acceleration in inches per second squared
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
        INCH_PER_SECOND_SQUARED,
        /// <summary>
        /// A point in space identified by X, Y, and Z positions and represented by a space delimited set of numbers each expressed in inches. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
        INCH_3D,
        /// <summary>
        /// A measure of torque in inch pounds.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
        INCH_POUND,
        /// <summary>
        /// A measurement of temperature
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 6.2.2.8")]
        KELVIN,
        /// <summary>
        /// A measurement in kilowatt.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
        KILOWATT,
        /// <summary>
        /// Kilowatt hours which is 3.6 mega joules. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
        KILOWATT_HOUR,
        /// <summary>
        /// Measurement of volume of a fluid 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.9")]
        LITER,
        /// <summary>
        /// Measurement of rate of flow of a fluid
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.9")]
        LITER_PER_MINUTE,
        /// <summary>
        /// Velocity in millimeters per minute 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
        MILLIMETER_PER_MINUTE,
        /// <summary>
        /// A measurement of time in minutes
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 7.2.2.6")]
        MINUTE,
        /// <summary>
        /// US pounds
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
        POUND,
        /// <summary>
        /// Pressure in pounds per square inch (PSI).
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
        POUND_PER_INCH_SQUARED,
        /// <summary>
        /// Angle in radians 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
        RADIAN,
        /// <summary>
        /// Velocity in radians per minute. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
        RADIAN_PER_MINUTE,
        /// <summary>
        /// Velocity in radians per second
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
        RADIAN_PER_SECOND,
        /// <summary>
        /// Rotational acceleration in radian per second squared
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
        RADIAN_PER_SECOND_SQUARED,
        /// <summary>
        /// Rotational velocity in revolution per second
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
        REVOLUTION_PER_SECOND,
        /// <summary>
        /// Unsupported units
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.6")]
        OTHER
    }
}
