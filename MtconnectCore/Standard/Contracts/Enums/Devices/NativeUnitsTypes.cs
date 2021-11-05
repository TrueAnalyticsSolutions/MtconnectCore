using MtconnectCore.Standard.Documents.Devices;

namespace MtconnectCore.Standard.Contracts.Enums.Devices
{
    /// <summary>
    /// Available options for a <c>nativeUnits</c> attribute on a <see cref="DataItem.NativeUnits"/>
    /// </summary>
    public enum NativeUnitsTypes {
        /// <summary>
        /// A measure of Viscosity
        /// </summary>
        CENTIPOISE,
        /// <summary>
        /// Rotational velocity in degrees per minute
        /// </summary>
        DEGREE_PER_MINUTE,
        /// <summary>
        /// Temperature in Fahrenheit 
        /// </summary>
        FAHRENHEIT,
        /// <summary>
        /// Feet
        /// </summary>
        FOOT,
        /// <summary>
        /// Feet per minute 
        /// </summary>
        FOOT_PER_MINUTE,
        /// <summary>
        /// Feet per second
        /// </summary>
        FOOT_PER_SECOND,
        /// <summary>
        /// Acceleration in feet per second squared
        /// </summary>
        FOOT_PER_SECOND_SQUARED,
        /// <summary>
        /// A point in space identified by X, Y, and Z positions and represented by a space delimited set of numbers each expressed in feet. 
        /// </summary>
        FOOT_3D,
        /// <summary>
        /// Gallons per minute. 
        /// </summary>
        GALLON_PER_MINUTE,
        /// <summary>
        /// Inches
        /// </summary>
        INCH,
        /// <summary>
        /// Inches per minute
        /// </summary>
        INCH_PER_MINUTE,
        /// <summary>
        /// Inches per second
        /// </summary>
        INCH_PER_SECOND,
        /// <summary>
        /// Acceleration in inches per second squared
        /// </summary>
        INCH_PER_SECOND_SQUARED,
        /// <summary>
        /// A point in space identified by X, Y, and Z positions and represented by a space delimited set of numbers each expressed in inches. 
        /// </summary>
        INCH_3D,
        /// <summary>
        /// A measure of torque in inch pounds.
        /// </summary>
        INCH_POUND,
        /// <summary>
        /// A measurement in kilowatt.
        /// </summary>
        KILOWATT,
        /// <summary>
        /// Kilowatt hours which is 3.6 mega joules. 
        /// </summary>
        KILOWATT_HOUR,
        /// <summary>
        /// Measurement of volume of a fluid 
        /// </summary>
        LITER,
        /// <summary>
        /// Measurement of rate of flow of a fluid
        /// </summary>
        LITER_PER_MINUTE,
        /// <summary>
        /// Velocity in millimeters per minute 
        /// </summary>
        MILLIMETER_PER_MINUTE,
        /// <summary>
        /// US pounds
        /// </summary>
        POUND,
        /// <summary>
        /// Pressure in pounds per square inch (PSI).
        /// </summary>
        POUND_PER_INCH_SQUARED,
        /// <summary>
        /// Angle in radians 
        /// </summary>
        RADIAN,
        /// <summary>
        /// Velocity in radians per second
        /// </summary>
        RADIAN_PER_SECOND,
        /// <summary>
        /// Rotational acceleration in radian per second squared
        /// </summary>
        RADIAN_PER_SECOND_SQUARED,
        /// <summary>
        /// Velocity in radians per minute. 
        /// </summary>
        RADIAN_PER_MINUTE,
        /// <summary>
        /// Rotational velocity in revolution per second
        /// </summary>
        REVOLUTION_PER_SECOND,
        /// <summary>
        /// Unsupported units
        /// </summary>
        OTHER
    }
}
