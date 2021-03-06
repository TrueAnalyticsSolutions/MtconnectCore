using MtconnectCore.Standard.Contracts.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// Available SAMPLE types according to the MTConnect Standard.
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1")]
    public enum SampleTypes
    {
        /// <summary>
        /// Rate of change of velocity
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1")]
        ACCELERATION,
        /// <summary>
        /// The measurement of accumulated time associated with a Component
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        ACCUMULATED_TIME,
        /// <summary>
        /// Rate of change of angular velocity.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1")]
        ANGULAR_ACCELERATION,
        /// <summary>
        /// Rate of change of angular position.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1")]
        ANGULAR_VELOCITY,
        /// <summary>
        /// The measurement of AC Current or a DC current. See <c>subType</c>s: <seealso cref="AmperageSubTypes"/>
        /// </summary>
        [Obsolete("Deprecated in v1.6.0")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1", MtconnectVersions.V_1_5_0)]
        AMPERAGE,
        /// <summary>
        /// The measurement of an electrical current that reverses direction at regular short intervals.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 4.2.1")]
        AMPERAGE_AC,
        /// <summary>
        /// The measurement of an electric current flowing in one direction only.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 4.2.1")]
        AMPERAGE_DC,
        /// <summary>
        /// The angular position of a component relative to the  parent. See <c>subType</c>s: <seealso cref="AngleSubTypes"/>
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1")]
        ANGLE,
        /// <summary>
        /// Negative rate of change of angular velocity.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.1")]
        ANGULAR_DECELERATION,
        /// <summary>
        /// The average rate of change of values for assets in the MTConnect streams. The average is computed over a rolling window defined by the implementation.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.1")]
        ASSET_UPDATE_RATE,
        /// <summary>
        /// The feedrate of a linear axis. See <c>subType</c>s: <seealso cref="AxisFeedrateSubTypes"/>
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1")]
        AXIS_FEEDRATE,
        /// <summary>
        /// The fluid capacity of an object or container
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
        CAPACITY_FLUID,
        /// <summary>
        /// The geometric capacity of an object or container.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
        CAPACITY_SPATIAL,
        /// <summary>
        /// The reading of a timing device at a specific point in  time. Clock time MUST be reported in W3C ISO 8601 format.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        CLOCK_TIME,
        /// <summary>
        /// Percentage of one component within a mixture of  components
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        CONCENTRATION,
        /// <summary>
        /// The ability of a material to conduct electricity 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        CONDUCTIVITY,
        /// <summary>
        /// The speed difference (relative velocity) between the cutting mechanism and the surface of the workpiece it is operating on.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
        CUTTING_SPEED,
        /// <summary>
        /// Negative rate of change of velocity.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.1")]
        DECELERATION,
        /// <summary>
        /// The volumetric mass of a material per unit volume of that material.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
        DENSITY,
        /// <summary>
        /// The rate of change in spatial volume of material deposited in an additive manufacturing process.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
        DEPOSITION_ACCELERATION_VOLUMETRIC,
        /// <summary>
        /// The density of the material deposited in an additive manufacturing process per unit of volume.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
        DEPOSITION_DENSITY,
        /// <summary>
        /// The mass of the material deposited in an additive manufacturing process.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
        DEPOSITION_MASS,
        /// <summary>
        /// The rate at which a spatial volume of material is deposited in an additive manufacturing process.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
        DEPOSITION_RATE_VOLUMETRIC,
        /// <summary>
        /// The spatial volume of material to be deposited in an additive manufacturing process.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
        DEPOSITION_VOLUME,
        /// <summary>
        /// The measured dimension of a diameter.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 4.2")]
        DIAMETER,
        /// <summary>
        /// The displacement as the change in position of an  object
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1")]
        DISPLACEMENT,
        /// <summary>
        /// The measurement of electrical energy consumption  by a component
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        ELECTRICAL_ENERGY,
        /// <summary>
        /// The measurement of the amount of time  piece of equipment or a sub-part of a piece of equipment has performed specific activities. Often used to determine when maintenance may be required for the equipment
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.1")]
        EQUIPMENT_TIMER,
        /// <summary>
        /// The measurement of the amount of a substance  remaining compared to the planned maximum amount of that substance
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        FILL_LEVEL,
        /// <summary>
        /// The rate of flow of a fluid
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        FLOW,
        /// <summary>
        /// The measurement of the number of occurrences of a  repeating event per unit time
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1")]
        FREQUENCY,
        [Obsolete("Deprecated in Rel. 1.1")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1", MtconnectVersions.V_1_0_1)]
        GLOBAL_POSITION,
        /// <summary>
        /// The amount of water vapor expressed in grams per cubic meter.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 4.2")]
        HUMIDITY_ABSOLUTE,
        /// <summary>
        /// The amount of water vapor present expressed as a percent to reach saturation at the same temperature.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 4.2")]
        HUMIDITY_RELATIVE,
        /// <summary>
        /// The ratio of the water vapor present over the total weight of the water vapor and air present expressed as a percent.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 4.2")]
        HUMIDITY_SPECIFIC,
        /// <summary>
        /// The length of an object
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        LENGTH,
        [Obsolete("Deprecated in Rel. 1.2 See FILL_LEVEL")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 4.2.1", MtconnectVersions.V_1_2_0)]
        LEVEL,
        /// <summary>
        /// The measure of the push or pull introduced by an  actuator or exerted on an object
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        LINEAR_FORCE,
        /// <summary>
        /// The measurement of the percentage of the standard  rating of a device
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1")]
        LOAD,
        /// <summary>
        /// The measurement of the mass of an object(s) or an  amount of material
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        MASS,
        /// <summary>
        /// The average rate of change of values for data items in the MTConnect streams. The average is computed over a rolling window defined by the implementation.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.1")]
        OBSERVATION_UPDATE_RATE,
        /// <summary>
        /// A measured or calculated orientation of a plane or vector relative to a cartesian coordinate system.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 4.2")]
        ORIENTATION,
        /// <summary>
        /// The feedrate of the tool path. See <c>subType</c>s: <seealso cref="PathFeedrateSubTypes"/>
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1")]
        PATH_FEEDRATE,
        /// <summary>
        /// The feedrate for the axes, or a single axis.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
        PATH_FEEDRATE_PER_REVOLUTION,
        /// <summary>
        /// The current program control point or program  coordinate in WORK coordinates. The coordinate system will revert to MACHINE coordinates if WORK coordinates are not available. See <c>subType</c>s: <seealso cref="PathPositionSubTypes"/>
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.1")]
        PATH_POSITION,
        /// <summary>
        /// The measure of the acidity or alkalinity.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "Part 2 Section 4.2.1")]
        PH,
        /// <summary>
        /// The position of the Component. Defaults to  MACHINE coordinates. See <c>subType</c>s: <seealso cref="PositionSubTypes"/>
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1")]
        POSITION,
        /// <summary>
        /// The measurement of the ratio of real power flowing  to a load to the apparent power in that AC circuit.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        POWER_FACTOR,
        /// <summary>
        /// The force per unit area exerted by a gas or liquid
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1")]
        PRESSURE,
        /// <summary>
        /// The force per unit area measured relative to a vacuum.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.1")]
        PRESSURE_ABSOLUTE,
        /// <summary>
        /// The change of pressure per unit time.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 8.1")]
        PRESSURIZATION_RATE,
        /// <summary>
        /// The measurement of the amount of time  piece of equipment has performed different types of activities associated with the process being performed at that piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.1")]
        PROCESS_TIMER,
        /// <summary>
        /// The measurement of the degree to which an object  opposes an electric current through it
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        RESISTANCE,
        /// <summary>
        /// The rotational speed of a rotary axis. See <c>subType</c>s: <seealso cref="RotaryVelocitySubTypes"/>
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        ROTARY_VELOCITY,
        /// <summary>
        /// Measurement of a sound level or sound pressure level  relative to atmospheric pressure. See <c>subType</c>s: <seealso cref="SoundLeveSubTypes"/>
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        SOUND_LEVEL,
        [Obsolete("Deprecated in Rel. 1.2. Replaced by ROTARY_VELOCITY")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1", MtconnectVersions.V_1_1_0)]
        SPINDLE_SPEED,
        /// <summary>
        /// Strain is the amount of deformation per unit length of an object when a load is applied.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        STRAIN,
        /// <summary>
        /// The measurement of temperature
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1")]
        TEMPERATURE,
        /// <summary>
        /// A measurement of a force that stretches or  elongates an object
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 8.1")]
        TENSION,
        /// <summary>
        /// A measurement of angular displacement
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        TILT,
        /// <summary>
        /// The turning force exerted on an object or by an object
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1")]
        TORQUE,
        /// <summary>
        /// The rate of change of position. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1")]
        VELOCITY,
        /// <summary>
        /// A measurement of a fluid’s resistance to flow 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        VISCOSITY,
        /// <summary>
        /// The measurement of electrical potential between two  points. See <c>subType</c>s: <seealso cref="VoltageSubTypes"/>
        /// </summary>
        [Obsolete("Deprecated in v1.6.0")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1", MtconnectVersions.V_1_5_0)]
        VOLTAGE,
        /// <summary>
        /// The measurement of the electrical potential between two points in an electrical circuit in which the current periodically reverses direction.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 4.2")]
        VOLTAGE_AC,
        /// <summary>
        /// The measurement of the electrical potential between two points in an electrical circuit in which the current is unidirectional.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 4.2")]
        VOLTAGE_DC,
        /// <summary>
        /// The measure of the apparent power in an electrical  circuit, equal to the product of root-mean-square (RMS) voltage and RMS current’ (commonly referred to as VA)
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        VOLT_AMPERE,
        /// <summary>
        /// The measurement of reactive power in an AC  electrical circuit (commonly referred to as var)
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 2 Section 3.5.10")]
        VOLT_AMPERE_REACTIVE,
        /// <summary>
        /// The fluid volume of an object or container.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
        VOLUME_FLUID,
        /// <summary>
        /// The geometric volume of an object or container.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 8.1")]
        VOLUME_SPATIAL,
        /// <summary>
        /// The measurement of power consumed or dissipated  by an electrical circuit or device
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "Part 2 Section 4.2.1")]
        WATTAGE,
        /// <summary>
        /// Measured dimension of an entity relative to the X direction of the referenced coordinate system.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 4.2")]
        X_DIMENSION,
        /// <summary>
        /// Measured dimension of an entity relative to the Y direction of the referenced coordinate system.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 4.2")]
        Y_DIMENSION,
        /// <summary>
        /// Measured dimension of an entity relative to the Z direction of the referenced coordinate system.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "Part 2 Section 4.2")]
        Z_DIMENSION
    }
}
