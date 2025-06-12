#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums
{
	/// <summary>
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Package__EAPK_6BEE6977_1698_498c_87A6_34B5E656F773">model.mtconnect.org</seealso> for more information.
	/// </summary>
	
	
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.5.0.0")]
	public enum ComponentTypes
	{
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Component">Component</see> composed of a physical apparatus that moves or controls a mechanism or system. <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br />It takes energy usually provided by air, electric current, or liquid and converts the energy into some kind of motion.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1")]
		
		Actuator,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />abstract <see cref="Component">Component</see> composed of removable part(s) of a piece of equipment that provides supplementary or extended functionality.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Auxiliary,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />abstract <see cref="Component">Component</see> composed of a motion system that provides linear or rotational motion for a piece of equipment.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br />In robotics, the term <i>Axis</i> is synonymous with <i>Joint</i>. A <i>Joint</i> is the connection between two parts of the structure that move in relation to each other.<br /><br /><br /><br /><see cref="Linear">Linear</see> and <see cref="Rotary">Rotary</see> components <b>MUST</b> have <see cref="Component.name">name in Component</see> that <b>MUST</b> follow the conventions described below. Use the <see cref="Component.nativeName">nativeName in Component</see> for the manufacturer's name of the axis if it differs from the assigned <see cref="Component.name">name in Component</see>.<br /><br /><br /><br />MTConnect has two high-level classes for automation equipment as follows: (1) Equipment that controls cartesian coordinate axes and (2) Equipment that controls articulated axes. There are ambiguous cases where some machines exhibit both characteristics; when this occurs, the primary control system's configuration determines the classification.<br /><br /><br /><br />Examples of cartesian coordinate equipment are CNC Machine Tools, Coordinate measurement machines, as specified in ISO 841, and 3D Printers. Examples of articulated automation equipment are Robotic systems as specified in ISO 8373.<br /><br /><br /><br />The following sections define the designation of names for the axes and additional guidance when selecting the correct scheme to use for a given piece of equipment.<br /><br /><br /><br />#### Cartesian Coordinate Naming Conventions<br /><br /><br /><br />A Three-Dimensional Cartesian Coordinate control system organizes its axes orthogonally relative to a machine coordinate system where the manufacturer of the equipment specifies the origin. <br /><br /><br /><br /><see cref="Axes">Axes</see> <see cref="Component.name">name in Component</see> <b>SHOULD</b> comply with ISO 841, if possible.<br /><br /><br /><br />##### Linear Motion<br /><br /><br /><br />A piece of equipment <b>MUST</b> represent prismatic motion using a <see cref="Linear">Linear</see> axis and assign its <see cref="Component.name">name in Component</see> using the designations <c>X</c>, <c>Y</c>, and <c>Z</c>. A <see cref="Linear">Linear</see> axis <see cref="Component.name">name in Component</see> <b>MUST</b> append a monotonically increasing suffix when there are more than one parallel axes; for example, <c>X2</c>, <c>X3</c>, and <c>X4</c>. <br /><br /><br /><br />##### Rotary Motion<br /><br /><br /><br />MTConnect <b>MUST</b> assign the <see cref="Component.name">name in Component</see> to <see cref="Rotary">Rotary</see> axes exhibiting rotary motion using <c>A</c>, <c>B</c>, and <c>C</c>. A <see cref="Rotary">Rotary</see> axis <see cref="Component.name">name in Component</see> <b>MUST</b> append a monotonically increasing suffix when more than one <see cref="Rotary">Rotary</see> axis rotates around the same <see cref="Linear">Linear</see> axis; for example, <c>A2</c>, <c>A3</c>, and <c>A4</c>. <br /><br /><br /><br />#### Articulated Machine Control Systems<br /><br /><br /><br />An articulated control system's axes represent the connecting linkages between two adjacent rigid members of an assembly. The <see cref="Linear">Linear</see> axis represents prismatic motion, and the <see cref="Rotary">Rotary</see> axis represents the rotational motion of the two related members. The control organizes the axes in a kinematic chain from the mounting surface (base) to the end-effector or tooling.<br /><br /><br /><br />#### Articulated Machine Axis Names<br /><br /><br /><br />The axes of articulated machines represent forward kinematic relationships between mechanical linkages. Each axis is a connection between linkages, also referred to as joints, and <b>MUST</b> be named using a <c>J</c> followed by a monotonically increasing number; for example, <c>J1</c>, <c>J2</c>, <c>J3</c>.  The numbering starts at the base axis connected or closest to the mounting surface, <c>J1</c>, incrementing to the mechanical interface, <c>Jn</c>, where <c>n</c> is the number of the last axis. The chain forms a parent-child relationship with the parent being the axis closest to the base.<br /><br /><br /><br />A machine having an axis with more than one child <b>MUST</b> number each branch using its numeric designation followed by a branch number and a monotonically increasing number. For example, if <c>J2</c> has two children, the first child branch <b>MUST</b> be named <c>J2.1.1</c> and the second child branch <c>J2.2.1</c>. A child of the first branch <b>MUST</b> be named <c>J2.1.2</c>, incrementing to <c>J2.1.n</c>, where <c>J2.1.n</c> is the number of the last axis in that branch.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
		
		Axis,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Loader">Loader</see> that delivers bar stock to a piece of equipment.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		BarFeeder,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="System">System</see> that provides regulation or management of a system or component. <seealso href="https://www.google.com/search?q=ISO 16484-5:2017&amp;btnI=I">ISO 16484-5:2017</seealso><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br />Typical types of controllers for a piece of equipment include CNC (Computer Numerical Control), PAC (Programmable Automation Control), IPC (Industrialized Computer), or IC (Imbedded Computer).<br /><br /><br /><br />&gt; Note: In <i>XML</i> representation, <see cref="Controller">Controller</see> is a <i>top level</i> element.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
		
		Controller,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="System">System</see> that provides distribution and management of fluids that remove heat from a piece of equipment.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		
		Coolant,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Auxiliary">Auxiliary</see> that manages the addition of material or state change of material being performed in an additive manufacturing process.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br />For example, this could describe the portion of a piece of equipment that manages a material extrusion process or a vat polymerization process.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		Deposition,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="System">System</see> that manages a chemical mixture used in a manufacturing process being performed at that piece of equipment.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br />For example, this could describe the dielectric system for an EDM process or the chemical bath used in a plating process.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Dielectric,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Component">Component</see> composed of a mechanical mechanism or closure that can cover a physical access portal into a piece of equipment allowing or restricting access to other parts of the equipment.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br />The closure can be opened or closed to allow or restrict access to other parts of the equipment.<br /><br /><br /><br /><see cref="Door">Door</see> <b>MUST</b> have <see cref="DoorState">DoorState</see> data item to indicate if the door is <c>OPEN</c>, <c>CLOSED</c>, or <c>UNLATCHED</c>. A <see cref="Component">Component</see> <b>MAY</b> contain multiple <see cref="Door">Door</see> entities.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1")]
		
		Door,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="System">System</see> composed of the main power supply for the piece of equipment that provides distribution of that power throughout the equipment.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br />The electric system will provide all the data with regard to electric current, voltage, frequency, etc. that applies to the piece of equipment as a functional unit. Data regarding electric power that is specific to a <see cref="Component">Component</see> will be reported for that specific <see cref="Component">Component</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1")]
		
		Electric,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="System">System</see> composed of a structure that is used to contain or isolate a piece of equipment or area.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br /><see cref="Enclosure">Enclosure</see> may provide information regarding access to the internal components of a piece of equipment or the conditions within the enclosure. For example, <see cref="Door">Door</see> may be defined as a <i>lower level</i> <see cref="Component">Component</see> or <see cref="Composition">Composition</see> entity of the <see cref="Enclosure">Enclosure</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Enclosure,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="System">System</see> composed of functions that form the last link segment of a piece of equipment.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br />It is the part of a piece of equipment that interacts with the manufacturing process.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		EndEffector,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Component">Component</see> that observes the surroundings of another <see cref="Component">Component</see>.<br /><br /><br /><br />&gt; Note: <see cref="Environmental">Environmental</see> <b>SHOULD</b> be organized by <see cref="Auxillaries">Auxillaries</see>, <see cref="Systems">Systems</see> or <see cref="Parts">Parts</see> depending on the relationship to the <see cref="Component">Component</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Environmental,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="System">System</see> that manages the delivery of materials within a piece of equipment.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br />For example, this could describe the wire delivery system for an EDM or welding process; conveying system or pump and valve system distributing material to a blending station; or a fuel delivery system feeding a furnace.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Feeder,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="System">System</see> that provides movement and distribution of pressurized liquid throughout the piece of equipment.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1")]
		
		Hydraulic,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Component Types::Axis">Component Types::Axis</see> that provides prismatic motion along a fixed axis.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
		
		Linear,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Auxiliary">Auxiliary</see> that provides movement and distribution of materials, parts, tooling, and other items to or from a piece of equipment.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Loader,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="System">System</see> that provides distribution and management of fluids used to lubricate portions of the piece of equipment.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1")]
		
		Lubrication,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Resource">Resource</see> composed of material that is consumed or used by the piece of equipment for production of parts, materials, or other types of goods.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.8">v1.8</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/#_Version_1.8")]
		
		Material,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Component">Component</see> that organizes an independent operation or function within a <see cref="Controller">Controller</see>.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br />For many types of equipment, <see cref="Path">Path</see> organizes a set of <see cref="Axes">Axes</see>, one or more Program elements, and the data associated with the motion of a control point as it moves through space. However, it <b>MAY</b> also represent any independent function within a <see cref="Controller">Controller</see> that has unique data associated with that function.<br /><br /> <br /><br /><see cref="Path">Path</see> <b>SHOULD</b> provide an <see cref="Execution">Execution</see> data item to define the operational state of the <see cref="Controller">Controller</see> of the piece of equipment.<br /><br /><br /><br />If the <see cref="Controller">Controller</see> is capable of performing more than one independent operation or function simultaneously, a separate <see cref="Path">Path</see> <b>MUST</b> be used to organize the data associated with each independent operation or function.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1")]
		
		Path,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Resource">Resource</see> composed of an individual or individuals who either control, support, or otherwise interface with a piece of equipment.<br /><br /><br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Personnel,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="System">System</see> that uses compressed gasses to actuate components or do work within the piece of equipment.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br />&gt; Note: Actuation is usually performed using a cylinder.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1")]
		
		Pneumatic,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Power">Power</see> was <b>DEPRECATED</b> in <i>MTConnect Version 1.1</i> and was replaced by <see cref="Availability">Availability</see> data item type.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// <item><b>Deprecated</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[Obsolete("Deprecated in v1.1 according to https://model.mtconnect.org/#_Version_1.1")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0", MtconnectVersions.V_1_1_0)]
		
		Power,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="System">System</see> composed of a power source associated with a piece of equipment that supplies energy to the manufacturing process separate from the <see cref="Electric">Electric</see> system.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br />For example, this could be the power source for an EDM machining process, an electroplating line, or a welding system.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		ProcessPower,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="System">System</see> that provides functions used to detect or prevent harm or damage to equipment or personnel.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br /><see cref="Protective">Protective</see> does not include the information relating to the <see cref="Enclosure">Enclosure</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Protective,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />abstract <see cref="Component">Component</see> composed of material or personnel involved in a manufacturing process.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Resource,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Component Types::Axis">Component Types::Axis</see> that provides rotation about a fixed axis.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0")]
		
		Rotary,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Component">Component</see> that responds to a physical stimulus and transmits a resulting impulse or value from a sensing unit.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br />If modeling individual sensors, then sensor should be associated with the <see cref="Component">Component</see> that the measured value is most closely associated.<br /><br /><br /><br />When modeled as an <see cref="Auxiliary">Auxiliary</see>, sensor <b>SHOULD</b> represent an integrated <i>sensor unit</i> system that provides signal processing, conversion, and communications. A <i>sensor unit</i> may have multiple <i>sensing element</i>s.<br /><br /><br /><br />See <see cref="SensorConfiguration">SensorConfiguration</see> for more details on the use and configuration of a <see cref="Sensor">Sensor</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
		
		Sensor,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Material">Material</see> that is used in a manufacturing process and to which work is applied in a machine or piece of equipment to produce parts.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br /><see cref="Stock">Stock</see> may be either a continuous piece of material from which multiple parts may be produced or it may be a discrete piece of material that will be made into a part or a set of parts.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#_Version_1.3")]
		
		Stock,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />abstract <see cref="Component">Component</see> that is permanently integrated into the piece of equipment.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1")]
		
		System,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Auxiliary">Auxiliary</see> that manages, positions, stores, and delivers tooling within a piece of equipment.<br /><br /><br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		ToolingDelivery,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Auxiliary">Auxiliary</see> that removes manufacturing byproducts from a piece of equipment.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		WasteDisposal,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Component">Component</see> composed of part(s) comprising the rigid bodies of the piece of equipment.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		Structure,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Structure">Structure</see> that provides a connection between <see cref="Component">Component</see> entities.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		Link,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="ToolingDelivery">ToolingDelivery</see> composed of a tool mounting mechanism that holds any number of tools. <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br />Tools are located in <see cref="Station">Station</see> entities. Tools are positioned for use in the manufacturing process by linearly positioning the <see cref="GangToolBar">GangToolBar</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		GangToolBar,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="System">System</see> that delivers controlled amounts of heat to achieve a target temperature at a specified heating rate.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br />&gt; Note: As an example, Energy Delivery Method can be either through Electric heaters or Gas burners.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		Heating,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="ToolingDelivery">ToolingDelivery</see> composed of a tool delivery mechanism that moves tools between a <see cref="ToolMagazine">ToolMagazine</see> and a <i>spindle</i> a <see cref="Turret">Turret</see>.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br /><see cref="AutomaticToolChanger">AutomaticToolChanger</see> may also transfer tools between a location outside of a piece of equipment and a <see cref="ToolMagazine">ToolMagazine</see> or <see cref="Turret">Turret</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		AutomaticToolChanger,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />abstract <see cref="Component">Component</see> composed of a manufacturing process being executed on a piece of equipment.<br /><br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		Process,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="ToolingDelivery">ToolingDelivery</see> composed of a tool storage mechanism that holds any number of tools. <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br />Tools are located in <see cref="Pot">Pot</see>s. <see cref="Pot">Pot</see>s are moved into position to transfer tools into or out of the <see cref="ToolMagazine">ToolMagazine</see> by an <see cref="AutomaticToolChanger">AutomaticToolChanger</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		ToolMagazine,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Part">Part</see> that exists at a specific place and time, such as a specific instance of a bracket at a specific timestamp.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br /><see cref="PartId">PartId</see> <b>MUST</b> be defined for <see cref="PartOccurrence">PartOccurrence</see>.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Example<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />~~~~xml<br /><br />&lt;Parts id="partOccSet"&gt;<br /><br />   &lt;Components&gt;<br /><br />	   &lt;PartOccurrence id="partOccur"&gt;<br /><br />		 &lt;DataItems&gt;<br /><br />		   &lt;DataItem id="partSet" category="EVENT" representation="TABLE" type ="COMPONENT_DATA"&gt;<br /><br />			  &lt;Definition&gt;<br /><br />				 &lt;EntryDefinitions&gt;<br /><br />					  &lt;EntryDefinition keyType="PART_UNIQUE_ID"/&gt;<br /><br />				 &lt;/EntryDefinitions&gt;<br /><br />				 &lt;CellDefinitions&gt;<br /><br />					&lt;CellDefinition key="partNumber" type="PART_KIND_ID" subType="PART_NUMBER"/&gt;<br /><br />					&lt;CellDefinition key="batchId" type="PART_GROUP_ID" subType="BATCH"/&gt;<br /><br />					&lt;CellDefinition key="quantity" type="PART_COUNT" subType="TARGET"/&gt;<br /><br />					&lt;CellDefinition key="actualCompleteTime" type="PROCESS_TIME" subType="COMPLETE"/&gt;<br /><br />					&lt;CellDefinition key="partState" type="PROCESS_STATE"/&gt;<br /><br />				&lt;/CellDefinitions&gt;<br /><br />			  &lt;/Definition&gt;<br /><br />			&lt;/DataItem&gt;<br /><br />		 &lt;/DataItems&gt;<br /><br />	   &lt;/PartOccurrence&gt;<br /><br />	&lt;/Components&gt;<br /><br />&lt;/Parts&gt;<br /><br />~~~~<br /><br />{: caption="XML Device Model Example for PartOccurrence and ComponentData"}<br /><br /><br /><br /><br /><br />~~~~xml<br /><br />&lt;?xml version="1.0" encoding="UTF-8"?&gt;<br /><br />&lt;?xml-stylesheet type="text/xsl" href="/styles/Streams.xsl"?&gt;<br /><br />&lt;MTConnectStreams&gt;<br /><br />  &lt;Streams&gt;<br /><br />    &lt;DeviceStream name="VMC-3Axis" uuid="test_27MAY"&gt;<br /><br />      &lt;ComponentStream component="PartOccurrence" name="partSet" componentId="partOccur"&gt;<br /><br />        &lt;Events&gt;<br /><br />          &lt;ComponentDataTable dataItemId="partSet" timestamp="2020-10-28T19:45:43.070010Z" sequence="95" count="2"&gt;<br /><br />            &lt;Entry key="part1"&gt;<br /><br />              &lt;Cell key="actualStartTime"&gt;2009-06-15T00:00:00.000000&lt;/Cell&gt;<br /><br />              &lt;Cell key="partId"&gt;part1&lt;/Cell&gt;<br /><br />              &lt;Cell key="partName"&gt;SomeName&lt;/Cell&gt;<br /><br />              &lt;Cell key="uniqueID"&gt;abc-123&lt;/Cell&gt;<br /><br />            &lt;/Entry&gt;<br /><br />            &lt;Entry key="part2"&gt;<br /><br />              &lt;Cell key="actualStartTime"&gt;2009-06-15T00:00:00.007925&lt;/Cell&gt;<br /><br />              &lt;Cell key="partId"&gt;part2&lt;/Cell&gt;<br /><br />              &lt;Cell key="partName"&gt;AnotherName&lt;/Cell&gt;<br /><br />              &lt;Cell key="uniqueID"&gt;def-123&lt;/Cell&gt;<br /><br />            &lt;/Entry&gt;<br /><br />          &lt;/ComponentDataTable&gt;<br /><br />        &lt;/Events&gt;<br /><br />      &lt;/ComponentStream&gt;<br /><br />    &lt;/DeviceStream&gt;<br /><br />  &lt;/Streams&gt;<br /><br />&lt;/MTConnectStreams&gt;<br /><br />~~~~<br /><br />{: caption="XML Streams Response Example for PartOccurrence and ComponentData"}<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		PartOccurrence,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Component">Component</see> that provides information about the data source for an <i>MTConnect Agent</i>.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br />It <b>MAY</b> contain connectivity state of the data source and additional telemetry about the data source and source-specific information.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		Adapter,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="ToolingDelivery">ToolingDelivery</see> composed of a linear or matrixed tool storage mechanism that holds any number of tools.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br />Tools are located in <see cref="Station">Station</see> entities.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		ToolRack,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="ToolingDelivery">ToolingDelivery</see> composed of a tool mounting mechanism that holds any number of tools.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br />Tools are positioned for use in the manufacturing process by rotating the <see cref="Turret">Turret</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		Turret,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="System">System</see> that evacuates gases and liquids from an enclosed and sealed space to a controlled negative pressure or a molecular density below the prevailing atmospheric level.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		Vacuum,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="System">System</see> that extracts controlled amounts of heat to achieve a target temperature at a specified cooling rate.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br />&gt; Note: As an example, Energy Extraction Method can be via cooling water pipes running through the chamber.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		Cooling,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Process">Process</see> that takes place at a specific place and time, such as a specific instance of part-milling occurring at a specific timestamp.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br /><see cref="ProcessOccurrenceId">ProcessOccurrenceId</see> <b>MUST</b> be defined for <see cref="ProcessOccurrence">ProcessOccurrence</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		ProcessOccurrence,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="System">System</see> that delivers compressed gas or fluid and controls the pressure and rate of pressure change to a desired target set-point.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br />&gt; Note: For example, Delivery Method can be a Compressed Air or N2 tank that is piped via an inlet valve to the chamber.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#_Version_1.1")]
		
		Pressure,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />abstract <see cref="Component">Component</see> composed of a <i>part</i> being processed by a piece of equipment.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		Part,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Component">Component</see> that physically prohibits a <see cref="Device">Device</see> or <see cref="Component">Component</see> from opening or operating.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.8">v1.8</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/#_Version_1.8")]
		
		Lock,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Component">Component</see> that provides an axis of rotation for the purpose of rapidly rotating a part or a tool to provide sufficient surface speed for cutting operations.<br /><br /><br /><br /><see cref="Spindle">Spindle</see> was <b>DEPRECATED</b> in <i>MTConnect Version 1.1</i> and was replaced by <see cref="RotaryMode">RotaryMode</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// <item><b>Deprecated</b>: <see href="https://model.mtconnect.org/#_Version_1.1">v1.1</see></item>
		/// </list>
		/// </remarks>
		[Obsolete("Deprecated in v1.1 according to https://model.mtconnect.org/#_Version_1.1")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0", MtconnectVersions.V_1_1_0)]
		
		Spindle,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Component">Component</see> composed of a sensor or an instrument that measures temperature.<br /><br /><br /><br /><see cref="Thermostat">Thermostat</see> was <b>DEPRECATED</b> in <i>MTConnect Version 1.2</i> and was replaced by <see cref="Temperature">Temperature</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// <item><b>Deprecated</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[Obsolete("Deprecated in v1.2 according to https://model.mtconnect.org/#_Version_1.2")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0", MtconnectVersions.V_1_2_0)]
		
		Thermostat,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Component">Component</see> composed of a sensor or an instrument that measures the amount and/or frequency of vibration within a system.<br /><br /><br /><br /><see cref="Vibration">Vibration</see> was <b>DEPRECATED</b> in <i>MTConnect Version 1.2</i> and was replaced by <see cref="Displacement">Displacement</see>, <see cref="Frequency">Frequency</see> etc.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.0">v1.0</see></item>
		/// <item><b>Deprecated</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		[Obsolete("Deprecated in v1.2 according to https://model.mtconnect.org/#_Version_1.2")]
		[MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#_Version_1.0", MtconnectVersions.V_1_2_0)]
		
		Vibration,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> composed of a mechanism that holds a part or stock material in place.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#_Version_1.3")]
		
		Chuck,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that produces a current of air.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Fan,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that flattens or spreading materials.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		Spreader,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> composed of a mechanism or wheel that turns in a frame or block and serves to change the direction of or to transmit force.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Pulley,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that is a <see cref="Pot">Pot</see> for a tool that is awaiting transfer from a <see cref="ToolMagazine">ToolMagazine</see> to <i>spindle</i> or <see cref="Turret">Turret</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		TransferPot,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that provides power to electric mechanisms.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		PowerSupply,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that allows material to flow for the purpose of drainage from, for example, a vessel or tank.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Drain,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> composed of a mechanical structure that transforms rotary motion into linear motion.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Ballscrew,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> composed of a pump or other mechanism that reduces volume and increases pressure of gases in order to condense the gases to drive pneumatically powered pieces of equipment.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Compressor,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> composed of an inclined channel that conveys material.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Chute,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that turns on or off an electric current or makes or breaks a circuit.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Switch,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that provides or applies a stretch or strain to another mechanism.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Tensioner,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> composed of <i>H_2 O</i>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Water,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> composed of a string like piece or filament of relatively rigid or flexible material provided in a variety of diameters.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Wire,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that provides a signal or measured value.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		SensingElement,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> composed of a heat exchange system that uses a fluid to transfer heat to the atmosphere.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		CoolingTower,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that is a <see cref="Pot">Pot</see> for a tool that has to be removed from a <see cref="ToolMagazine">ToolMagazine</see> or <see cref="Turret">Turret</see> to a location outside of the piece of equipment.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		RemovalPot,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that holds a part, stock material, or any other item in place.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Gripper,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that is a <see cref="Pot">Pot</see> for a tool that is awaiting transfer to a <see cref="ToolMagazine">ToolMagazine</see> or <see cref="Turret">Turret</see> from outside of the piece of equipment.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		StagingPot,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that slows or stops a moving object by the absorption or transfer of the energy of momentum, usually by means of friction, electrical force, or magnetic force.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Brake,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> composed of a storage or mounting location for a tool associated with a <see cref="Turret">Turret</see>, <see cref="GangToolBar">GangToolBar</see>, or <see cref="ToolRack">ToolRack</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		Station,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> composed of a chamber or bin in which materials are stored temporarily, typically being filled through the top and dispensed through the bottom.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Hopper,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> composed of an endless flexible band that transmits motion for a piece of equipment or conveys materials and objects.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Belt,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that physically moves a tool from one location to another.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		TransferArm,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> composed of a rotary storage unit for material.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		Reel,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> through which liquids or gases are passed to remove suspended impurities or to recover solids.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Filter,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that is a <see cref="Pot">Pot</see> for a tool that has been removed from <i>spindle</i> or <see cref="Turret">Turret</see> and awaiting for return to a <see cref="ToolMagazine">ToolMagazine</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		ReturnPot,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> composed of interconnected series of objects that band together and are used to transmit motion for a piece of equipment or to convey materials and objects.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Chain,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> composed of an electronic component or circuit that amplifies power, electric current, or voltage.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Amplifier,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> generally composed of an open container.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		Vat,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that is a <see cref="Pot">Pot</see> for a tool that is no longer usable for removal from a <see cref="ToolMagazine">ToolMagazine</see> or <see cref="Turret">Turret</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		ExpiredPot,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> composed of a viscous liquid.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Oil,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> composed of a surface for holding an object or material.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		Table,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that breaks material into smaller pieces.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Chopper,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that halts or controls the flow of a liquid, gas, or other material through a passage, pipe, inlet, or outlet.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Valve,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> composed of a tool storage location associated with a <see cref="ToolMagazine">ToolMagazine</see> or <see cref="AutomaticToolChanger">AutomaticToolChanger</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.7">v1.7</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#_Version_1.7")]
		
		Pot,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that transforms electric energy from a source to a secondary circuit.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		Transformer,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that emits a type of radiation.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		ExposureUnit,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> generally composed of an enclosed container.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Tank,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that measures position.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Encoder,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> composed of one or more cells in which chemical energy is converted into electricity and used as a source of power. <br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		StorageBattery,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that interrupts an electric circuit.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		CircuitBreaker,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that converts electrical, pneumatic, or hydraulic energy into mechanical energy.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Motor,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that dispenses liquid or powered materials.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		ExtrusionUnit,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> composed of an electromechanical actuator that produces deflection of a beam of light or energy in response to electric current through its coil in a magnetic field.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#_Version_1.5")]
		
		Galvanomotor,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that raises, drives, exhausts, or compresses fluids or gases by means of a piston, plunger, or set of rotating vanes.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Pump,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that strengthens, support, or fastens objects in place.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		Clamp,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> that measures linear motion or position.<br /><br /><br /><br /><b>DEPRECATION WARNING</b> : May be deprecated in the future. Recommend using <see cref="Encoder">Encoder</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.4">v1.4</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#_Version_1.4")]
		
		LinearPositionFeedback,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />leaf <see cref="Component">Component</see> composed of an object or material on which a form of work is performed.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		
		Workpiece,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="System">System</see> composed of the physical process execution space within a piece of equipment.<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />Description<br /><br /><br /><br /><br /><br /><br /><br /><see cref="WorkEnvelope">WorkEnvelope</see> <b>MAY</b> provide information regarding the physical workspace and the conditions within that workspace.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#_Version_1.6")]
		
		WorkEnvelope,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><see cref="Component">Component</see> that provides information related to an individual <i>feature</i>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.2">v2.2</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#_Version_2.2")]
		
		FeatureOccurrence,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />system that circulates air or regulates airflow without altering temperature or humidity.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_2.3">v2.3</see></item>
		/// </list>
		/// </remarks>
		[MtconnectVersionApplicability(MtconnectVersions.V_2_3_0, "https://model.mtconnect.org/#_Version_2.3")]
		
		AirHandler,
	}
}