using MtconnectCore.Standard.Documents.Devices;

namespace MtconnectCore.Standard.Contracts.Enums.Devices
{
    /// <summary>
    /// Available options for a <c>units</c> attribute on a <see cref="DataItem.Units"/>
    /// </summary>
    public enum UnitsTypes {
        /// <summary>
        /// Amps
        /// </summary>
        AMPERE,
        /// <summary>
        /// Degrees Celsius
        /// </summary>
        CELSIUS,
        /// <summary>
        /// A counted event
        /// </summary>
        COUNT,
        /// <summary>
        /// Sound Level 
        /// </summary>
        DECIBEL,
        /// <summary>
        /// Angle in degrees 
        /// </summary>
        DEGREE,
        /// <summary>
        /// Angular degrees per second
        /// </summary>
        DEGREE_PER_SECOND,
        /// <summary>
        /// Angular acceleration in degrees per second squared
        /// </summary>
        DEGREE_PER_SECOND_SQUARED,
        /// <summary>
        /// Frequency measured in cycles per second
        /// </summary>
        HERTZ,
        /// <summary>
        /// A measurement of energy.
        /// </summary>
        JOULE,
        /// <summary>
        /// Kilograms
        /// </summary>
        KILOGRAM,
        /// <summary>
        /// Liters
        /// </summary>
        LITER,
        /// <summary>
        /// Liters per second
        /// </summary>
        LITER_SECOND,
        /// <summary>
        /// Measurement of Tilt
        /// </summary>
        MICRO_RADIAN,
        /// <summary>
        /// Millimeters
        /// </summary>
        MILLIMETER,
        /// <summary>
        /// Millimeters per second 
        /// </summary>
        MILLIMETER_PER_SECOND,
        /// <summary>
        /// Acceleration in millimeters per second squared 
        /// </summary>
        MILLIMETER_PER_SECOND_SQUARED,
        /// <summary>
        /// A point in space identified by X, Y, and Z positions and represented by a space delimited set of numbers each expressed in millimeters.
        /// </summary>
        MILLIMETER_3D,
        /// <summary>
        /// Force in Newtons 
        /// </summary>
        NEWTON,
        /// <summary>
        /// Torque, a unit for force times distance. 
        /// </summary>
        NEWTON_METER,
        /// <summary>
        /// Measure of Electrical Resistance 
        /// </summary>
        OHM,
        /// <summary>
        /// Pressure in Newtons per square meter 
        /// </summary>
        PASCAL,
        /// <summary>
        /// Measurement of Viscosity
        /// </summary>
        PASCAL_SECOND,
        /// <summary>
        /// Percentage
        /// </summary>
        PERCENT,
        /// <summary>
        /// A measure of the acidity or alkalinity of a solution 
        /// </summary>
        PH,
        /// <summary>
        /// Revolutions per minute
        /// </summary>
        REVOLUTION_PER_MINUTE,
        /// <summary>
        /// A measurement of time. 
        /// </summary>
        SECOND,
        /// <summary>
        /// A measurement of Electrical Conductivity
        /// </summary>
        SIEMENS_PER_METER,
        /// <summary>
        /// Volts
        /// </summary>
        VOLT,
        /// <summary>
        /// Volt-Ampere (VA) 
        /// </summary>
        VOLT_AMPERE,
        /// <summary>
        /// Volt-Ampere Reactive (var)
        /// </summary>
        VOLT_AMPERE_REACTIVE,
        /// <summary>
        /// Watts
        /// </summary>
        WATT,
        /// <summary>
        /// Measurement of electrical energy, equal to one Joule 
        /// </summary>
        WATT_SECOND
    }
}
