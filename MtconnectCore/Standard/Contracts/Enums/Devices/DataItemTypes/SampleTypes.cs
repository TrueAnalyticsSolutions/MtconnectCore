using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	/// View in the MTConnect Model browser <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso>
	﻿	/// </summary>
	
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "0.0.12.0")]
	public enum SampleTypes
	{
		/// <summary>
		﻿/// {{def(SampleEnum:ACCELERATION)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
        [ObservationalSubType(typeof(AccelerationSubTypes))]
		ACCELERATION,
		/// <summary>
		﻿/// {{def(SampleEnum:ACCUMULATED_TIME)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		ACCUMULATED_TIME,
		/// <summary>
		﻿/// {{def(SampleEnum:AMPERAGE)}}
		/// </summary>
		[Obsolete("Deprecated according to https://model.mtconnect.org/")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/", MtconnectVersions.V_1_6_0)]
		AMPERAGE,
		/// <summary>
		﻿/// {{def(SampleEnum:ANGLE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		ANGLE,
		/// <summary>
		﻿/// {{def(SampleEnum:ANGULAR_ACCELERATION)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		ANGULAR_ACCELERATION,
		/// <summary>
		﻿/// {{def(SampleEnum:ANGULAR_VELOCITY)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		ANGULAR_VELOCITY,
		/// <summary>
		﻿/// {{def(SampleEnum:AXIS_FEEDRATE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		AXIS_FEEDRATE,
		/// <summary>
		﻿/// {{def(SampleEnum:CAPACITY_FLUID)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		CAPACITY_FLUID,
		/// <summary>
		﻿/// {{def(SampleEnum:CAPACITY_SPATIAL)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		CAPACITY_SPATIAL,
		/// <summary>
		﻿/// {{def(SampleEnum:CONCENTRATION)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		CONCENTRATION,
		/// <summary>
		﻿/// {{def(SampleEnum:CONDUCTIVITY)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		CONDUCTIVITY,
		/// <summary>
		﻿/// {{def(SampleEnum:CUTTING_SPEED)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		CUTTING_SPEED,
		/// <summary>
		﻿/// {{def(SampleEnum:DENSITY)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		DENSITY,
		/// <summary>
		﻿/// {{def(SampleEnum:DEPOSITION_ACCELERATION_VOLUMETRIC)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		DEPOSITION_ACCELERATION_VOLUMETRIC,
		/// <summary>
		﻿/// {{def(SampleEnum:DEPOSITION_DENSITY)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		DEPOSITION_DENSITY,
		/// <summary>
		﻿/// {{def(SampleEnum:DEPOSITION_MASS)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		DEPOSITION_MASS,
		/// <summary>
		﻿/// {{def(SampleEnum:DEPOSITION_RATE_VOLUMETRIC)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		DEPOSITION_RATE_VOLUMETRIC,
		/// <summary>
		﻿/// {{def(SampleEnum:DEPOSITION_VOLUME)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		DEPOSITION_VOLUME,
		/// <summary>
		﻿/// {{def(SampleEnum:DISPLACEMENT)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		DISPLACEMENT,
		/// <summary>
		﻿/// {{def(SampleEnum:ELECTRICAL_ENERGY)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		ELECTRICAL_ENERGY,
		/// <summary>
		﻿/// {{def(SampleEnum:EQUIPMENT_TIMER)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		EQUIPMENT_TIMER,
		/// <summary>
		﻿/// {{def(SampleEnum:FILL_LEVEL)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		FILL_LEVEL,
		/// <summary>
		﻿/// {{def(SampleEnum:FLOW)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		FLOW,
		/// <summary>
		﻿/// {{def(SampleEnum:FREQUENCY)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		FREQUENCY,
		/// <summary>
		﻿/// {{def(SampleEnum:GLOBAL_POSITION)}}
		/// </summary>
		[Obsolete("Deprecated according to https://model.mtconnect.org/")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/", MtconnectVersions.V_1_1_0)]
		GLOBAL_POSITION,
		/// <summary>
		﻿/// {{def(SampleEnum:LENGTH)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/")]
		LENGTH,
		/// <summary>
		﻿/// {{def(SampleEnum:LEVEL)}}
		/// </summary>
		[Obsolete("Deprecated according to https://model.mtconnect.org/")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/", MtconnectVersions.V_1_2_0)]
		LEVEL,
		/// <summary>
		﻿/// {{def(SampleEnum:LINEAR_FORCE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		LINEAR_FORCE,
		/// <summary>
		﻿/// {{def(SampleEnum:LOAD)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		LOAD,
		/// <summary>
		﻿/// {{def(SampleEnum:MASS)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		MASS,
		/// <summary>
		﻿/// {{def(SampleEnum:PATH_FEEDRATE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		PATH_FEEDRATE,
		/// <summary>
		﻿/// {{def(SampleEnum:PATH_FEEDRATE_PER_REVOLUTION)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		PATH_FEEDRATE_PER_REVOLUTION,
		/// <summary>
		﻿/// {{def(SampleEnum:PATH_POSITION)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		PATH_POSITION,
		/// <summary>
		﻿/// {{def(SampleEnum:PH)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/")]
		P_H,
		/// <summary>
		﻿/// {{def(SampleEnum:POSITION)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		POSITION,
		/// <summary>
		﻿/// {{def(SampleEnum:POWER_FACTOR)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		POWER_FACTOR,
		/// <summary>
		﻿/// {{def(SampleEnum:PRESSURE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		PRESSURE,
		/// <summary>
		﻿/// {{def(SampleEnum:PROCESS_TIMER)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		PROCESS_TIMER,
		/// <summary>
		﻿/// {{def(SampleEnum:RESISTANCE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		RESISTANCE,
		/// <summary>
		﻿/// {{def(SampleEnum:ROTARY_VELOCITY)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		ROTARY_VELOCITY,
		/// <summary>
		﻿/// {{def(SampleEnum:SOUND_LEVEL)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		SOUND_LEVEL,
		/// <summary>
		﻿/// {{def(SampleEnum:SPINDLE_SPEED)}}
		/// </summary>
		[Obsolete("Deprecated according to https://model.mtconnect.org/")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/", MtconnectVersions.V_1_2_0)]
		SPINDLE_SPEED,
		/// <summary>
		﻿/// {{def(SampleEnum:STRAIN)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		STRAIN,
		/// <summary>
		﻿/// {{def(SampleEnum:TEMPERATURE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		TEMPERATURE,
		/// <summary>
		﻿/// {{def(SampleEnum:TENSION)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/")]
		TENSION,
		/// <summary>
		﻿/// {{def(SampleEnum:TILT)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		TILT,
		/// <summary>
		﻿/// {{def(SampleEnum:TORQUE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		TORQUE,
		/// <summary>
		﻿/// {{def(SampleEnum:VELOCITY)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		VELOCITY,
		/// <summary>
		﻿/// {{def(SampleEnum:VISCOSITY)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		VISCOSITY,
		/// <summary>
		﻿/// {{def(SampleEnum:VOLTAGE)}}
		/// </summary>
		[Obsolete("Deprecated according to https://model.mtconnect.org/")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/", MtconnectVersions.V_1_6_0)]
		VOLTAGE,
		/// <summary>
		﻿/// {{def(SampleEnum:VOLT_AMPERE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		VOLT_AMPERE,
		/// <summary>
		﻿/// {{def(SampleEnum:VOLT_AMPERE_REACTIVE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/")]
		VOLT_AMPERE_REACTIVE,
		/// <summary>
		﻿/// {{def(SampleEnum:VOLUME_FLUID)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		VOLUME_FLUID,
		/// <summary>
		﻿/// {{def(SampleEnum:VOLUME_SPATIAL)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/")]
		VOLUME_SPATIAL,
		/// <summary>
		﻿/// {{def(SampleEnum:WATTAGE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/")]
		WATTAGE,
		/// <summary>
		﻿/// {{def(SampleEnum:AMPERAGE_DC)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		AMPERAGE_D_C,
		/// <summary>
		﻿/// {{def(SampleEnum:AMPERAGE_AC)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		AMPERAGE_A_C,
		/// <summary>
		﻿/// {{def(SampleEnum:VOLTAGE_AC)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		VOLTAGE_A_C,
		/// <summary>
		﻿/// {{def(SampleEnum:VOLTAGE_DC)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		VOLTAGE_D_C,
		/// <summary>
		﻿/// {{def(SampleEnum:X_DIMENSION)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		X_DIMENSION,
		/// <summary>
		﻿/// {{def(SampleEnum:Y_DIMENSION)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		Y_DIMENSION,
		/// <summary>
		﻿/// {{def(SampleEnum:Z_DIMENSION)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		Z_DIMENSION,
		/// <summary>
		﻿/// {{def(SampleEnum:DIAMETER)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		DIAMETER,
		/// <summary>
		﻿/// {{def(SampleEnum:ORIENTATION)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		ORIENTATION,
		/// <summary>
		﻿/// {{def(SampleEnum:HUMIDITY_RELATIVE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		HUMIDITY_RELATIVE,
		/// <summary>
		﻿/// {{def(SampleEnum:HUMIDITY_ABSOLUTE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		HUMIDITY_ABSOLUTE,
		/// <summary>
		﻿/// {{def(SampleEnum:HUMIDITY_SPECIFIC)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/")]
		HUMIDITY_SPECIFIC,
		/// <summary>
		﻿/// {{def(SampleEnum:PRESSURIZATION_RATE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		PRESSURIZATION_RATE,
		/// <summary>
		﻿/// {{def(SampleEnum:DECELERATION)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		DECELERATION,
		/// <summary>
		﻿/// {{def(SampleEnum:ASSET_UPDATE_RATE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		ASSET_UPDATE_RATE,
		/// <summary>
		﻿/// {{def(SampleEnum:ANGULAR_DECELERATION)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		ANGULAR_DECELERATION,
		/// <summary>
		﻿/// {{def(SampleEnum:OBSERVATION_UPDATE_RATE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		OBSERVATION_UPDATE_RATE,
		/// <summary>
		﻿/// The force per unit area measured relative to a vacuum.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/")]
		PRESSURE_ABSOLUTE,
		/// <summary>
		﻿/// {{def(SampleEnum:OPENNESS)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/")]
		OPENNESS,
		/// <summary>
		﻿/// {{def(SampleEnum:DEW_POINT)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		DEW_POINT,
		/// <summary>
		﻿/// {{def(SampleEnum:GRAVITATIONAL_FORCE)}}  > Note: $$<c>Mass</c> x <c>GravitationalAcceleration</c>$$
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		GRAVITATIONAL_FORCE,
		/// <summary>
		﻿/// {{def(SampleEnum:GRAVITATIONAL_ACCELERATION)}}  
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		GRAVITATIONAL_ACCELERATION,
		/// <summary>
		﻿/// {{def(SampleEnum:BATTERY_CAPACITY)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		BATTERY_CAPACITY,
		/// <summary>
		﻿/// {{def(SampleEnum:DISCHARGE_RATE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		DISCHARGE_RATE,
		/// <summary>
		﻿/// {{def(SampleEnum:CHARGE_RATE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		CHARGE_RATE,
		/// <summary>
		﻿/// {{def(SampleEnum:BATTERY_CHARGE)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		BATTERY_CHARGE,
		/// <summary>
		﻿/// {{def(SampleEnum:SETTLING_ERROR)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		SETTLING_ERROR,
		/// <summary>
		﻿/// {{def(SampleEnum:SETTLING_ERROR_LINEAR)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		SETTLING_ERROR_LINEAR,
		/// <summary>
		﻿/// {{def(SampleEnum:SETTLING_ERROR_ANGULAR)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		SETTLING_ERROR_ANGULAR,
		/// <summary>
		﻿/// {{def(SampleEnum:FOLLOWING_ERROR)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		FOLLOWING_ERROR,
		/// <summary>
		﻿/// {{def(SampleEnum:FOLLOWING_ERROR_ANGULAR)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		FOLLOWING_ERROR_ANGULAR,
		/// <summary>
		﻿/// {{def(SampleEnum:FOLLOWING_ERROR_LINEAR)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		FOLLOWING_ERROR_LINEAR,
		/// <summary>
		﻿/// {{def(SampleEnum:DISPLACEMENT_LINEAR)}}  > Note: The displacement vector <b>MAY</b> be defined by the motion of the owning <see cref="component">component</see>.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		DISPLACEMENT_LINEAR,
		/// <summary>
		﻿/// {{def(SampleEnum:DISPLACEMENT_ANGULAR)}}  > Note: The displacement vector <b>MAY</b> be defined by the motion of the owning <see cref="component">component</see>.
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		DISPLACEMENT_ANGULAR,
		/// <summary>
		﻿/// {{def(SampleEnum:POSITION_CARTESIAN)}}
		/// </summary>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/")]
		POSITION_CARTESIAN,
	}
}