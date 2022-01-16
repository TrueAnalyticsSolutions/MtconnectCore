using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Documents.Devices;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices
{
    /// <summary>
    /// Available options for a <c>units</c> attribute on a <see cref="DataItem.Units"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.5")]
    public enum UnitsTypes {
        /// <summary>
        /// Amps
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.5")]
        AMPERE,
        /// <summary>
        /// Degrees Celsius
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.5")]
        CELSIUS,
        /// <summary>
        /// A counted event
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.5")]
        COUNT,
        /// <summary>
        /// Geometric volume in millimeters
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 7.2.2.5")]
        CUBIC_MILLIMETER,
        /// <summary>
        /// Change of geometric volume per second
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 7.2.2.5")]
        CUBIC_MILLIMETER_PER_SECOND,
        /// <summary>
        /// Change in geometric volume per second squared
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 7.2.2.5")]
        CUBIC_MILLIMETER_PER_SECOND_SQUARED,
        /// <summary>
        /// Sound Level 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.6")]
        DECIBEL,
        /// <summary>
        /// Angle in degrees 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.5")]
        DEGREE,
        /// <summary>
        /// Angular degrees per second
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.5")]
        DEGREE_PER_SECOND,
        /// <summary>
        /// Angular acceleration in degrees per second squared
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.5")]
        DEGREE_PER_SECOND_SQUARED,
        /// <summary>
        /// A space-delimited, floating-point representation of the angular rotation in degrees around the X, Y, and Z axes relative to a cartesian coordinate system respectively in order as A, B, and C. If any of the rotations is not known, it MUST be zero (0).
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 7.2.2.5")]
        DEGREE_3D,
        /// <summary>
        /// Gram per cubic meter.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 7.2.2.5")]
        GRAM_PER_CUBIC_METER,
        /// <summary>
        /// Frequency measured in cycles per second
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.5")]
        HERTZ,
        /// <summary>
        /// A measurement of energy.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.5")]
        JOULE,
        /// <summary>
        /// Kilograms
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.5")]
        KILOGRAM,
        /// <summary>
        /// Liters
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.5")]
        LITER,
        /// <summary>
        /// Liters per second
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.5")]
        LITER_PER_SECOND,
        /// <summary>
        /// Measurement of Tilt
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.6")]
        MICRO_RADIAN,
        /// <summary>
        /// Milligram
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 7.2.2.5")]
        MILLIGRAM,
        /// <summary>
        /// Milligram per cubic millimeter
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 7.2.2.5")]
        MILLIGRAM_PER_CUBIC_MILLIMETER,
        /// <summary>
        /// Milliliter
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 7.2.2.5")]
        MILLILITER,
        /// <summary>
        /// Millimeters
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.5")]
        MILLIMETER,
        /// <summary>
        /// Millimeters per revolution.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 7.2.2.5")]
        MILLIMETER_PER_REVOLUTION,
        /// <summary>
        /// Millimeters per second 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.5")]
        MILLIMETER_PER_SECOND,
        /// <summary>
        /// Acceleration in millimeters per second squared 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.5")]
        MILLIMETER_PER_SECOND_SQUARED,
        /// <summary>
        /// A point in space identified by X, Y, and Z positions and represented by a space delimited set of numbers each expressed in millimeters.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.5")]
        MILLIMETER_3D,
        /// <summary>
        /// Force in Newtons 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.5")]
        NEWTON,
        /// <summary>
        /// Torque, a unit for force times distance. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.5")]
        NEWTON_METER,
        /// <summary>
        /// Measure of Electrical Resistance 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.6")]
        OHM,
        /// <summary>
        /// Pressure in Newtons per square meter 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.5")]
        PASCAL,
        /// <summary>
        /// Measurement of Viscosity
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.6")]
        PASCAL_SECOND,
        /// <summary>
        /// Percentage
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.5")]
        PERCENT,
        /// <summary>
        /// A measure of the acidity or alkalinity of a solution 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.1.5")]
        PH,
        /// <summary>
        /// Revolutions per minute
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.5")]
        REVOLUTION_PER_MINUTE,
        /// <summary>
        /// Revolutions per second.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 7.2.2.5")]
        REVOLUTION_PER_SECOND,
        /// <summary>
        /// Revolutions per second squared.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 7.2.2.5")]
        REVOLUTION_PER_SECOND_SQUARED,
        /// <summary>
        /// A measurement of time. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.5")]
        SECOND,
        /// <summary>
        /// A measurement of Electrical Conductivity
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.6")]
        SIEMENS_PER_METER,
        /// <summary>
        /// A status that conforms to the data item’s  controlled vocabulary. Used in events to indicate states or status.
        /// </summary>
        [Obsolete("Deprecated in version 1.1.0.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.5", MtconnectVersions.V_1_0_1)]
        STATUS,
        /// <summary>
        /// Volts
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.5")]
        VOLT,
        /// <summary>
        /// Volt-Ampere (VA) 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.6")]
        VOLT_AMPERE,
        /// <summary>
        /// Volt-Ampere Reactive (var)
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.6")]
        VOLT_AMPERE_REACTIVE,
        /// <summary>
        /// Watts
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.1.5")]
        WATT,
        /// <summary>
        /// Measurement of electrical energy, equal to one Joule 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.6")]
        WATT_SECOND
    }
}
