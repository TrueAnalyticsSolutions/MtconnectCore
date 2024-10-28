#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
	/// <summary>
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Enumeration__">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_">v</see></item>
	/// <item><b>Deprecated</b>: <see href="https://model.mtconnect.org/#_Version_">v</see></item>
	/// </list>
	/// </remarks>
	[Obsolete("Deprecated in v according to https://model.mtconnect.org/#_Version_")]
	
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.5.0.0")]
	public enum SampleTypes
	{
		/// <summary>
		﻿/// positive rate of change of velocity.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
		[ObservationalSubType(typeof(AccelerationSubTypes))]
		
		ACCELERATION,
		/// <summary>
		﻿/// accumulated time for an activity or event.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		
		
		ACCUMULATED_TIME,
		/// <summary>
		﻿/// strength of electrical current.<br /><br /><b>DEPRECATED</b> in <i>Version 1.6</i>. Replaced by <c>AMPERAGE_AC</c> and <c>AMPERAGE_DC</c>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// <item><b>Deprecated</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[Obsolete("Deprecated in v1.6 according to https://model.mtconnect.org/#_Version_1.6")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0", MtconnectVersions.V_1_6_0)]
		[ObservationalSubType(typeof(AmperageSubTypes))]
		
		AMPERAGE,
		/// <summary>
		﻿/// angular position.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
		[ObservationalSubType(typeof(AngleSubTypes))]
		
		ANGLE,
		/// <summary>
		﻿/// positive rate of change of angular velocity.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
		[ObservationalSubType(typeof(AngularAccelerationSubTypes))]
		
		ANGULAR_ACCELERATION,
		/// <summary>
		﻿/// rate of change of angular position.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
		
		
		ANGULAR_VELOCITY,
		/// <summary>
		﻿/// feedrate of a linear axis.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
		[ObservationalSubType(typeof(AxisFeedrateSubTypes))]
		
		AXIS_FEEDRATE,
		/// <summary>
		﻿/// maximum amount of fluid that can be held by a container.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		
		CAPACITY_FLUID,
		/// <summary>
		﻿/// maximum amount of material that can be held by a container.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		
		CAPACITY_SPATIAL,
		/// <summary>
		﻿/// percentage of one component within a mixture of components.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		
		
		CONCENTRATION,
		/// <summary>
		﻿/// ability of a material to conduct electricity.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		
		
		CONDUCTIVITY,
		/// <summary>
		﻿/// speed difference (relative velocity) between the cutting mechanism and the surface of the workpiece it is operating on.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		[ObservationalSubType(typeof(CuttingSpeedSubTypes))]
		
		CUTTING_SPEED,
		/// <summary>
		﻿/// volumetric mass of a material per unit volume of that material.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		
		DENSITY,
		/// <summary>
		﻿/// rate of change in spatial volume of material deposited in an additive manufacturing process.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		[ObservationalSubType(typeof(DepositionAccelerationVolumetricSubTypes))]
		
		DEPOSITION_ACCELERATION_VOLUMETRIC,
		/// <summary>
		﻿/// density of the material deposited in an additive manufacturing process per unit of volume.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		[ObservationalSubType(typeof(DepositionDensitySubTypes))]
		
		DEPOSITION_DENSITY,
		/// <summary>
		﻿/// mass of the material deposited in an additive manufacturing process.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		[ObservationalSubType(typeof(DepositionMassSubTypes))]
		
		DEPOSITION_MASS,
		/// <summary>
		﻿/// rate at which a spatial volume of material is deposited in an additive manufacturing process.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		[ObservationalSubType(typeof(DepositionRateVolumetricSubTypes))]
		
		DEPOSITION_RATE_VOLUMETRIC,
		/// <summary>
		﻿/// spatial volume of material to be deposited in an additive manufacturing process.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		[ObservationalSubType(typeof(DepositionVolumeSubTypes))]
		
		DEPOSITION_VOLUME,
		/// <summary>
		﻿/// change in position of an object.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
		
		
		DISPLACEMENT,
		/// <summary>
		﻿/// <see cref="Wattage">Wattage</see> used or generated by a component over an interval of time.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		
		
		ELECTRICAL_ENERGY,
		/// <summary>
		﻿/// amount of time a piece of equipment or a sub-part of a piece of equipment has performed specific activities.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		[ObservationalSubType(typeof(EquipmentTimerSubTypes))]
		
		EQUIPMENT_TIMER,
		/// <summary>
		﻿/// amount of a substance remaining compared to the planned maximum amount of that substance.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		
		
		FILL_LEVEL,
		/// <summary>
		﻿/// rate of flow of a fluid.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		
		
		FLOW,
		/// <summary>
		﻿/// number of occurrences of a repeating event per unit time.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
		
		
		FREQUENCY,
		/// <summary>
		﻿/// position in three-dimensional space.<br /><br /><b>DEPRECATED</b> in Version 1.1.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// <item><b>Deprecated</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[Obsolete("Deprecated in v1.1 according to https://model.mtconnect.org/#_Version_1.1")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0", MtconnectVersions.V_1_1_0)]
		[ObservationalSubType(typeof(GlobalPositionSubTypes))]
		
		GLOBAL_POSITION,
		/// <summary>
		﻿/// length of an object.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#_Version_1.3")]
		[ObservationalSubType(typeof(LengthSubTypes))]
		
		LENGTH,
		/// <summary>
		﻿/// level of a resource.<br /><br /><b>DEPRECATED</b> in <i>Version 1.2</i>.  See <c>FILL_LEVEL</c>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// <item><b>Deprecated</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[Obsolete("Deprecated in v1.2 according to https://model.mtconnect.org/#_Version_1.2")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1", MtconnectVersions.V_1_2_0)]
		
		
		LEVEL,
		/// <summary>
		﻿/// <i>force</i> applied to a mass in one direction only.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		
		
		LINEAR_FORCE,
		/// <summary>
		﻿/// actual versus the standard rating of a piece of equipment.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
		
		
		LOAD,
		/// <summary>
		﻿/// mass of an object(s) or an amount of material.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		
		
		MASS,
		/// <summary>
		﻿/// feedrate for the axes, or a single axis, associated with a <see cref="Path">Path</see> component.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
		[ObservationalSubType(typeof(PathFeedrateSubTypes))]
		
		PATH_FEEDRATE,
		/// <summary>
		﻿/// feedrate for the axes, or a single axis.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		[ObservationalSubType(typeof(PathFeedratePerRevolutionSubTypes))]
		
		PATH_FEEDRATE_PER_REVOLUTION,
		/// <summary>
		﻿/// position of a control point associated with a <see cref="Controller">Controller</see> or a <see cref="Path">Path</see>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1")]
		[ObservationalSubType(typeof(PathPositionSubTypes))]
		
		PATH_POSITION,
		/// <summary>
		﻿/// acidity or alkalinity of a solution.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1")]
		
		
		PH,
		/// <summary>
		﻿/// point along an axis in a <i>cartesian coordinate system</i>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
		[ObservationalSubType(typeof(PositionSubTypes))]
		
		POSITION,
		/// <summary>
		﻿/// ratio of real power flowing to a load to the apparent power in that AC circuit.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		
		
		POWER_FACTOR,
		/// <summary>
		﻿/// force per unit area measured relative to atmospheric pressure. <br /><br />Commonly referred to as gauge pressure.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
		
		
		PRESSURE,
		/// <summary>
		﻿/// amount of time a piece of equipment has performed different types of activities associated with the process being performed at that piece of equipment.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		[ObservationalSubType(typeof(ProcessTimerSubTypes))]
		
		PROCESS_TIMER,
		/// <summary>
		﻿/// degree to which a substance opposes the passage of an electric current.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		
		
		RESISTANCE,
		/// <summary>
		﻿/// rotational speed of a rotary axis.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		[ObservationalSubType(typeof(RotaryVelocitySubTypes))]
		
		ROTARY_VELOCITY,
		/// <summary>
		﻿/// sound level or sound pressure level relative to atmospheric pressure.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		[ObservationalSubType(typeof(SoundLevelSubTypes))]
		
		SOUND_LEVEL,
		/// <summary>
		﻿/// rotational speed of the rotary axis.<br /><br /><b>DEPRECATED</b> in <i>Version 1.2</i>.  Replaced by <c>ROTARY_VELOCITY</c>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// <item><b>Deprecated</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[Obsolete("Deprecated in v1.2 according to https://model.mtconnect.org/#_Version_1.2")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0", MtconnectVersions.V_1_2_0)]
		[ObservationalSubType(typeof(SpindleSpeedSubTypes))]
		
		SPINDLE_SPEED,
		/// <summary>
		﻿/// amount of deformation per unit length of an object when a load is applied.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		
		
		STRAIN,
		/// <summary>
		﻿/// degree of hotness or coldness measured on a definite scale.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
		
		
		TEMPERATURE,
		/// <summary>
		﻿/// force that stretches or elongates an object.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		
		TENSION,
		/// <summary>
		﻿/// angular displacement.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		
		
		TILT,
		/// <summary>
		﻿/// turning force exerted on an object or by an object.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
		
		
		TORQUE,
		/// <summary>
		﻿/// rate of change of position of a <see cref="Component">Component</see>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
		
		
		VELOCITY,
		/// <summary>
		﻿/// fluid's resistance to flow.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		
		
		VISCOSITY,
		/// <summary>
		﻿/// electrical potential between two points.<br /><br /><b>DEPRECATED</b> in <i>Version 1.6</i>. Replaced by <c>VOLTAGE_AC</c> and <c>VOLTAGE_DC</c>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// <item><b>Deprecated</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[Obsolete("Deprecated in v1.6 according to https://model.mtconnect.org/#_Version_1.6")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0", MtconnectVersions.V_1_6_0)]
		[ObservationalSubType(typeof(VoltageSubTypes))]
		
		VOLTAGE,
		/// <summary>
		﻿/// apparent power in an electrical circuit, equal to the product of root-mean-square (RMS) voltage and RMS current (commonly referred to as VA).
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		
		
		VOLT_AMPERE,
		/// <summary>
		﻿/// reactive power in an AC electrical circuit (commonly referred to as VAR).
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		
		
		VOLT_AMPERE_REACTIVE,
		/// <summary>
		﻿/// fluid volume of an object or container.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		[ObservationalSubType(typeof(VolumeFluidSubTypes))]
		
		VOLUME_FLUID,
		/// <summary>
		﻿/// geometric volume of an object or container.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		[ObservationalSubType(typeof(VolumeSpatialSubTypes))]
		
		VOLUME_SPATIAL,
		/// <summary>
		﻿/// power flowing through or dissipated by an electrical circuit or piece of equipment.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
		[ObservationalSubType(typeof(WattageSubTypes))]
		
		WATTAGE,
		/// <summary>
		﻿/// electric current flowing in one direction only.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		[ObservationalSubType(typeof(AmperageDCSubTypes))]
		
		AMPERAGE_DC,
		/// <summary>
		﻿/// electrical current that reverses direction at regular short intervals.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		[ObservationalSubType(typeof(AmperageACSubTypes))]
		
		AMPERAGE_AC,
		/// <summary>
		﻿/// electrical potential between two points in an electrical circuit in which the current periodically reverses direction.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		[ObservationalSubType(typeof(VoltageACSubTypes))]
		
		VOLTAGE_AC,
		/// <summary>
		﻿/// electrical potential between two points in an electrical circuit in which the current is unidirectional.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		[ObservationalSubType(typeof(VoltageDCSubTypes))]
		
		VOLTAGE_DC,
		/// <summary>
		﻿/// dimension of an entity relative to the X direction of the referenced coordinate system.<br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		
		
		X_DIMENSION,
		/// <summary>
		﻿/// dimension of an entity relative to the Y direction of the referenced coordinate system.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		
		
		Y_DIMENSION,
		/// <summary>
		﻿/// dimension of an entity relative to the Z direction of the referenced coordinate system.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		
		
		Z_DIMENSION,
		/// <summary>
		﻿/// dimension of a diameter.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		
		
		DIAMETER,
		/// <summary>
		﻿/// angular position of a plane or vector relative to a <i>cartesian coordinate system</i>
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		[ObservationalSubType(typeof(OrientationSubTypes))]
		
		ORIENTATION,
		/// <summary>
		﻿/// amount of water vapor present expressed as a percent to reach saturation at the same temperature.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		[ObservationalSubType(typeof(HumidityRelativeSubTypes))]
		
		HUMIDITY_RELATIVE,
		/// <summary>
		﻿/// amount of water vapor expressed in grams per cubic meter.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		[ObservationalSubType(typeof(HumidityAbsoluteSubTypes))]
		
		HUMIDITY_ABSOLUTE,
		/// <summary>
		﻿/// ratio of the water vapor present over the total weight of the water vapor and air present expressed as a percent.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		[ObservationalSubType(typeof(HumiditySpecificSubTypes))]
		
		HUMIDITY_SPECIFIC,
		/// <summary>
		﻿/// change of pressure per unit time.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		[ObservationalSubType(typeof(PressurizationRateSubTypes))]
		
		PRESSURIZATION_RATE,
		/// <summary>
		﻿/// negative rate of change of velocity.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		[ObservationalSubType(typeof(DecelerationSubTypes))]
		
		DECELERATION,
		/// <summary>
		﻿/// average rate of change of values for assets in the MTConnect streams. <br /><br />The average is computed over a rolling window defined by the implementation.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		
		ASSET_UPDATE_RATE,
		/// <summary>
		﻿/// negative rate of change of angular velocity.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		[ObservationalSubType(typeof(AngularDecelerationSubTypes))]
		
		ANGULAR_DECELERATION,
		/// <summary>
		﻿/// average rate of change of values for data items in the MTConnect streams. The average is computed over a rolling window defined by the implementation.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		
		OBSERVATION_UPDATE_RATE,
		/// <summary>
		﻿/// force per unit area measured relative to a vacuum.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		
		PRESSURE_ABSOLUTE,
		/// <summary>
		﻿/// percentage open where 100% is fully open and 0% is fully closed.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.0">v2.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/#_Version_2.0")]
		
		
		OPENNESS,
		/// <summary>
		﻿/// temperature at which moisture begins to condense, corresponding to saturation for a given absolute humidity.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.1">v2.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/#_Version_2.1")]
		
		
		DEW_POINT,
		/// <summary>
		﻿/// force relative to earth's gravity.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.1">v2.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/#_Version_2.1")]
		
		
		GRAVITATIONAL_FORCE,
		/// <summary>
		﻿/// acceleration relative to Earth's gravity of 9.80665 <c>METER/SECOND^2</c>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.1">v2.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/#_Version_2.1")]
		
		
		GRAVITATIONAL_ACCELERATION,
		/// <summary>
		﻿/// maximum rated charge a battery is capable of maintaining based on the battery discharging at a specified current over a specified time period.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.1">v2.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/#_Version_2.1")]
		[ObservationalSubType(typeof(BatteryCapacitySubTypes))]
		
		BATTERY_CAPACITY,
		/// <summary>
		﻿/// value of current being drawn from the <see cref="Component">Component</see>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.1">v2.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/#_Version_2.1")]
		[ObservationalSubType(typeof(DischargeRateSubTypes))]
		
		DISCHARGE_RATE,
		/// <summary>
		﻿/// value of the current being supplied to the <see cref="Component">Component</see> for the purpose of charging.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.1">v2.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/#_Version_2.1")]
		[ObservationalSubType(typeof(ChargeRateSubTypes))]
		
		CHARGE_RATE,
		/// <summary>
		﻿/// value of the battery's present capacity expressed as a percentage of the battery's maximum rated capacity.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.1">v2.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/#_Version_2.1")]
		[ObservationalSubType(typeof(BatteryChargeSubTypes))]
		
		BATTERY_CHARGE,
		/// <summary>
		﻿/// difference between actual and commanded position at the end of a motion.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.1">v2.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/#_Version_2.1")]
		[ObservationalSubType(typeof(SettlingErrorSubTypes))]
		
		SETTLING_ERROR,
		/// <summary>
		﻿/// difference between the commanded encoder/resolver position, and the actual encoder/resolver position when motion is complete.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.1">v2.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/#_Version_2.1")]
		[ObservationalSubType(typeof(SettlingErrorLinearSubTypes))]
		
		SETTLING_ERROR_LINEAR,
		/// <summary>
		﻿/// angular difference between the commanded encoder/resolver position, and the actual encoder/resolver position when motion is complete.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.1">v2.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/#_Version_2.1")]
		[ObservationalSubType(typeof(SettlingErrorAngularSubTypes))]
		
		SETTLING_ERROR_ANGULAR,
		/// <summary>
		﻿/// difference between actual and commanded position at any specific point in time during a motion.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.1">v2.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/#_Version_2.1")]
		[ObservationalSubType(typeof(FollowingErrorSubTypes))]
		
		FOLLOWING_ERROR,
		/// <summary>
		﻿/// angular difference between the commanded encoder/resolver position and the actual encoder/resolver position at any specified point in time during a motion.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.1">v2.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/#_Version_2.1")]
		[ObservationalSubType(typeof(FollowingErrorAngularSubTypes))]
		
		FOLLOWING_ERROR_ANGULAR,
		/// <summary>
		﻿/// difference between the commanded encoder/resolver position and the actual encoder/resolver position at any specified point in time during a motion.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.1">v2.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/#_Version_2.1")]
		[ObservationalSubType(typeof(FollowingErrorLinearSubTypes))]
		
		FOLLOWING_ERROR_LINEAR,
		/// <summary>
		﻿/// absolute value of the change in position along a vector.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.1">v2.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/#_Version_2.1")]
		
		
		DISPLACEMENT_LINEAR,
		/// <summary>
		﻿/// absolute value of the change in angular position around a vector
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.1">v2.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/#_Version_2.1")]
		
		
		DISPLACEMENT_ANGULAR,
		/// <summary>
		﻿/// point in a <i>cartesian coordinate system</i>.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.1">v2.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_1_0, "https://model.mtconnect.org/#_Version_2.1")]
		
		
		POSITION_CARTESIAN,
		/// <summary>
		﻿/// inability of a material to conduct electricity.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.5">v2.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_5_0, "https://model.mtconnect.org/#_Version_2.5")]
		
		
		RESISTIVITY,
		/// <summary>
		﻿/// amount of a substance in a container.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.5">v2.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_5_0, "https://model.mtconnect.org/#_Version_2.5")]
		[ObservationalSubType(typeof(FillHeightSubTypes))]
		
		FILL_HEIGHT,
		/// <summary>
		﻿/// number of particles counted by their size or other characteristics.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.5">v2.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_5_0, "https://model.mtconnect.org/#_Version_2.5")]
		[ObservationalSubType(typeof(ParticleCountSubTypes))]
		
		PARTICLE_COUNT,
		/// <summary>
		﻿/// size of particles counted by their size or other characteristics.
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.5">v2.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_5_0, "https://model.mtconnect.org/#_Version_2.5")]
		
		
		PARTICLE_SIZE,
	}
}