using MtconnectCore.Standard.Contracts.Attributes;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.ComponentTypes
{
    /// <summary>
    /// Types of <c>Component</c>s defined in the MTConnect Standard
    /// </summary>
    public enum ComponentTypes
    {
        /// <summary>
        /// A mechanical device for moving or controlling a mechanism or system. 
        /// </summary>
        [Obsolete("Deprecated in version 1.4.0. Due to its uniqueness, has been redefined as a piece of equipment with the ability to be represented as a Lower Level component of a parent Component element.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572381968_750236_42201", MtconnectVersions.V_1_3_1)]
        ACTUATOR,
        /// <summary>
        /// Adapters is a Component that organizes Adapter Components representing the connectivity state of the MTConnect Agent.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 5")]
        ADAPTERS,
        /// <summary>
        /// Component that provides information about the data source for an MTConnect Agent.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1605101651646_782838_139")]
        ADAPTER,
        /// <summary>
        /// system that circulates air or regulates airflow without altering temperature or humidity.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_2_3_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1696069278270_26061_1220")]
        AIR_HANDLER,
        /// <summary>
        /// Component composed of an electronic component or circuit that amplifies power, electric current, or voltage.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106460_808314_44366")]
        AMPLIFIER,
        /// <summary>
        /// ToolingDelivery composed of a tool delivery mechanism that moves tools between a  ToolMagazine and a spindle a  Turret.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1605551853978_27109_2354")]
        AUTOMATIC_TOOL_CHANGER,
        /// <summary>
        /// An XML container used to organize information for Lower Leve elements representing functional sub-systems that provide supplementary or extended capabilities for a piece of equipment, but they are not required for the basic operation of the equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1607345082819_606856_1629")]
        AUXILIARIES,
        /// <summary>
        /// abstract Component composed of removable part(s) of a piece of equipment that provides supplementary or extended functionality.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572381970_785259_42204")]
        AUXILIARY,
        /// <summary>
        /// The Axes component is a container for the actual axes of which there are currently two types:  Linear and Rotary.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1607344218033_657673_1055")]
        AXES,
        /// <summary>
        /// abstract Component composed of a motion system that provides linear or rotational motion for a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572381972_553005_42207")]
        AXIS,
        /// <summary>
        /// Component composed of a mechanical structure that transforms rotary motion into linear motion.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106460_88955_44369")]
        BALLSCREW,
        /// <summary>
        /// Loader that delivers bar stock to a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572381973_701090_42210")]
        BAR_FEEDER,
        /// <summary>
        /// Component composed of an endless flexible band that transmits motion for a piece of equipment or conveys materials and objects.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106461_211983_44372")]
        BELT,
        /// <summary>
        /// Component that slows or stops a moving object by the absorption or transfer of the energy of momentum, usually by means of friction, electrical force, or magnetic force.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106461_720908_44375")]
        BRAKE,
        /// <summary>
        /// Component composed of interconnected series of objects that band together and are used to transmit motion for a piece of equipment or to convey materials and objects.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106462_246830_44378")]
        CHAIN,
        /// <summary>
        /// Component that breaks material into smaller pieces.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106462_657166_44381")]
        CHOPPER,
        /// <summary>
        /// Component composed of a mechanism that holds a part or stock material in place.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#Structure___19_0_4_45f01b9_1643679566213_508045_1804")]
        CHUCK,
        /// <summary>
        /// Component composed of an inclined channel that conveys material.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106463_904140_44387")]
        CHUTE,
        /// <summary>
        /// Component that interrupts an electric circuit.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106464_188160_44390")]
        CIRCUIT_BREAKER,
        /// <summary>
        /// Component that strengthens, support, or fastens objects in place.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106464_145351_44393")]
        CLAMP,
        /// <summary>
        /// Component composed of a pump or other mechanism that reduces volume and increases pressure of gases in order to condense the gases to drive pneumatically powered pieces of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106465_576708_44396")]
        COMPRESSOR,
        /// <summary>
        /// The Controller component is the Component that controls a device, executes a program,  and sends instructions to the other components of the machine. It is the brains of the machine and can be asked for its current execution state and program name.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572381977_283525_42216")]
        CONTROLLER,
        /// <summary>
        /// Component that organizes  Controller entities.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_2_0_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1648551529939_657918_1127")]
        CONTROLLERS,
        /// <summary>
        /// System that provides distribution and management of fluids that remove heat from a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572381979_456626_42219")]
        COOLANT,
        /// <summary>
        /// System that extracts controlled amounts of heat to achieve a target temperature at a specified cooling rate.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1605117088875_728711_1893")]
        COOLING,
        /// <summary>
        /// Component composed of a heat exchange system that uses a fluid to transfer heat to the atmosphere.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1605117477013_561048_2109")]
        COOLING_TOWER,
        /// <summary>
        /// Auxiliary that manages the addition of material or state change of material being performed in an additive manufacturing process.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572381981_362854_42222")]
        DEPOSITION,
        /// <summary>
        /// System that manages a chemical mixture used in a manufacturing process being performed at that piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572381982_394383_42225")]
        DIELECTRIC,
        /// <summary>
        /// A opening that can be closed.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572381984_481596_42228")]
        DOOR,
        /// <summary>
        /// Component that allows material to flow for the purpose of drainage from, for example, a vessel or tank.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106466_143410_44402")]
        DRAIN,
        /// <summary>
        /// System composed of the main power supply for the piece of equipment that provides distribution of that power throughout the equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572381986_185851_42231")]
        ELECTRIC,
        /// <summary>
        /// System composed of a structure that is used to contain or isolate a piece of equipment or area.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572381987_89386_42234")]
        ENCLOSURE,
        /// <summary>
        /// Component that measures position.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106466_630446_44405")]
        ENCODER,
        /// <summary>
        /// System composed of functions that form the last link segment of a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572381988_757487_42237")]
        END_EFFECTOR,
        /// <summary>
        /// Component that observes the surroundings of another Component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572381990_149427_42240")]
        ENVIRONMENTAL,
        /// <summary>
        /// Component that is a Pot for a tool that is no longer usable for removal from a  ToolMagazine or  Turret.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1605552258379_348093_2712")]
        EXPIRED_POT,
        /// <summary>
        /// Component that emits a type of radiation.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106466_875747_44408")]
        EXPOSURE_UNIT,
        /// <summary>
        /// Component that dispenses liquid or powered materials.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106467_401181_44411")]
        EXTRUSION_UNIT,
        /// <summary>
        /// Component that produces a current of air.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106468_61130_44414")]
        FAN,
        /// <summary>
        /// Component that provides information related to an individual feature.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_2_2_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1678029650656_503771_494")]
        FEATURE_OCCURANCE,
        /// <summary>
        /// System that manages the delivery of materials within a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572381991_562093_42243")]
        FEEDER,
        /// <summary>
        /// Component through which liquids or gases are passed to remove suspended impurities or to recover solids.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106468_554120_44417")]
        FILTER,
        /// <summary>
        /// Component composed of an electromechanical actuator that produces deflection of a beam of light or energy in response to electric current through its coil in a magnetic field.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106469_237105_44420")]
        GALVANOMOTOR,
        /// <summary>
        /// ToolingDelivery composed of a tool mounting mechanism that holds any number of tools.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1605551885706_266977_2498")]
        GANG_TOOL_BAR,
        /// <summary>
        /// Component that holds a part, stock material, or any other item in place.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106469_530686_44423")]
        GRIPPER,
        /// <summary>
        /// System that delivers controlled amounts of heat to achieve a target temperature at a specified heating rate.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1605117125123_371301_1943")]
        HEATING,
        /// <summary>
        /// Component composed of a chamber or bin in which materials are stored temporarily, typically being filled through the top and dispensed through the bottom.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106470_968785_44426")]
        HOPPER,
        /// <summary>
        /// System that provides movement and distribution of pressurized liquid throughout the piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572381993_131470_42246")]
        HYDRAULIC,
        /// <summary>
        /// The information used to coordinate actions and activity between devices  or sub-systems and a device.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 5.9")]
        INTERFACES,
        /// <summary>
        /// Axis that provides prismatic motion along a fixed axis.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572381997_851399_42255")]
        LINEAR,
        /// <summary>
        /// Component that measures linear motion or position.
        /// </summary>
        [Obsolete("DEPRECATION WARNING: May be deprecated in the future. Recommend using Encoder.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106471_40319_44429")]
        LINEAR_POSITION_FEEDBACK,
        /// <summary>
        /// Structure that provides a connection between  <<abstract>> Component entities.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1587597430378_591532_1084")]
        LINK,
        /// <summary>
        /// Auxiliary that provides movement and distribution of materials, parts, tooling, and other items to or from a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572381999_206845_42258")]
        LOADER,
        /// <summary>
        /// Component that physically prohibits a  Device or Component from opening or operating.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1622457426342_839834_623")]
        LOCK,
        /// <summary>
        /// System that provides distribution and management of fluids used to lubricate portions of the piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572382000_589988_42261")]
        LUBRICATION,
        /// <summary>
        /// Resource composed of material that is consumed or used by the piece of equipment for production of parts, materials, or other types of goods.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572382002_513291_42264")]
        MATERIAL,
        /// <summary>
        /// Resources that organizes  Material types.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1630059859468_228796_88")]
        MATERIALS,
        /// <summary>
        /// Component that converts electrical, pneumatic, or hydraulic energy into mechanical energy.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106471_971269_44432")]
        MOTOR,
        /// <summary>
        /// Component composed of a viscous liquid.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106472_287785_44435")]
        OIL,
        /// <summary>
        /// Component composed of a part being processed by a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1622456766067_72580_282")]
        PART,
        /// <summary>
        /// Component that organizes Part types.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1622457074108_581195_524")]
        PARTS,
        /// <summary>
        /// PartOccurrence organizes information about a specific part as it exists at a specific place and time, such as a specific instance of a bracket at a specific timestamp.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1605547467172_656422_264")]
        PART_OCCURANCE,
        /// <summary>
        /// Component that organizes an independent operation or function within a  Controller.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572382004_482583_42267")]
        PATH,
        /// <summary>
        /// Resource composed of an individual or individuals who either control, support, or otherwise interface with a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572382005_168835_42270")]
        PERSONNEL,
        /// <summary>
        /// System that uses compressed gasses to actuate components or do work within the piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572382008_658658_42273")]
        PNEUMATIC,
        /// <summary>
        /// Power was DEPRECATED in MTConnect Version 1.1 and was replaced by  Availability data item type.
        /// </summary>
        [Obsolete("Deprecated in Rel. 1.1")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572382010_841174_42276", MtconnectVersions.V_1_0_1)]
        POWER,
        /// <summary>
        /// Component that provides power to electric mechanisms.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106472_81456_44438")]
        POWER_SUPPLY,
        /// <summary>
        /// System that delivers compressed gas or fluid and controls the pressure and rate of pressure change to a desired target set-point.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1605117029255_781563_1842")]
        PRESSURE,
        /// <summary>
        /// Component composed of a manufacturing process being executed on a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1605547261014_920934_161")]
        PROCESS,
        /// <summary>
        /// Component that organizes Process types.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1607346168906_610073_2052")]
        PROCESSES,
        /// <summary>
        /// ProcessOccurrence organizes information about the execution of a specific process that takes place at a specific place and time, such as a specific instance of part-milling occurring at a specific timestamp.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1605547395898_219029_214")]
        PROCESS_OCCURANCE,
        /// <summary>
        /// System composed of a power source associated with a piece of equipment that supplies energy to the manufacturing process separate from the  Electric system.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572382012_290973_42279")]
        PROCESS_POWER,
        /// <summary>
        /// System that provides functions used to detect or prevent harm or damage to equipment or personnel.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572382013_685011_42282")]
        PROTECTIVE,
        /// <summary>
        /// Component composed of a mechanism or wheel that turns in a frame or block and serves to change the direction of or to transmit force.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106473_162844_44441")]
        PULLEY,
        /// <summary>
        /// Component that raises, drives, exhausts, or compresses fluids or gases by means of a piston, plunger, or set of rotating vanes.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106473_448314_44444")]
        PUMP,
        /// <summary>
        /// Component composed of a rotary storage unit for material.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106474_29298_44447")]
        REEL,
        /// <summary>
        /// Component that is a Pot for a tool that has to be removed from a  ToolMagazine or  Turret to a location outside of the piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1605552258019_616231_2696")]
        REMOVAL_POT,
        /// <summary>
        /// Component composed of material or personnel involved in a manufacturing process.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572382014_307743_42285")]
        RESOURCE,
        /// <summary>
        /// An XML container used to organize information for Lower Leve elements representing types of items, materials, and personnel that support the operation of a piece of equipment or work to be performed at a location. Resources also represents materials or other items consumed or transformed by a piece of equipment for production of parts or other types of goods.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 5")]
        RESOURCES,
        /// <summary>
        /// Component that is a Pot for a tool that has been removed from spindle or  Turret and awaiting for return to a  ToolMagazine.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1605552257200_872757_2664")]
        RETURN_POT,
        /// <summary>
        /// Axis that provides rotation about a fixed axis.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572382015_53595_42288")]
        ROTARY,
        /// <summary>
        /// Component that provides a signal or measured value.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106474_940737_44450")]
        SENSING_ELEMENT,
        /// <summary>
        /// Sensor is a component that may or may not be integral to a parent component or device.  When Sensor is not integral to a parent device or component – it can function as a device. Sensor data MUST be associated with its most relevant Component and MUST be represented as a DataItem for that Component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572382017_874684_42291")]
        SENSOR,
        /// <summary>
        /// The spindle is a rotational axis that revolves at high speed and has its speed expressed in REVOLUTION/MINUTE. The spindle can also have additional data items. Spindle speed has been specified as a separate data item since it receives special treatment in many applications. Velocity is used for linear axes other than spindle.
        /// </summary>
        [Obsolete("Deprecated in version 1.1.0.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure___19_0_4_45f01b9_1643678227814_87818_1410", MtconnectVersions.V_1_0_1)]
        SPINDLE,
        /// <summary>
        /// Component that flattens or spreading materials.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106475_909781_44453")]
        SPREADER,
        /// <summary>
        /// Component that is a Pot for a tool that is awaiting transfer to a  ToolMagazine or  Turret from outside of the piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1605552257626_405215_2680")]
        STAGING_POT,
        /// <summary>
        /// Component composed of a storage or mounting location for a tool associated with a  Turret,  GangToolBar, or  ToolRack.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1605552257415_810787_2672")]
        STATION,
        /// <summary>
        /// Stock is a Structural Element that represents the material that is used in a manufacturing process and to which work is applied in a machine or piece of equipment to produce parts.<br/><br/>
        /// Stock may be either a continuous piece of material from which multiple parts may be produced or it may be a discrete piece of material that will produce a part or a set of parts.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572382018_505205_42294")]
        STOCK,
        /// <summary>
        /// Component composed of one or more cells in which chemical energy is converted into electricity and used as a source of power.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106475_664974_44456")]
        STORAGE_BATTERY,
        /// <summary>
        /// Structure is a Component that organizes the parts comprising the rigid bodies of the piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1587597358521_716746_1028")]
        STRUCTURE,
        /// <summary>
        /// Component that organizes  Structure types.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1607371600474_90853_450")]
        STRUCTURES,
        /// <summary>
        /// Component that turns on or off an electric current or makes or breaks a circuit.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106476_558459_44459")]
        SWITCH,
        /// <summary>
        /// Component that is permanently integrated into the piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572382020_336298_42297")]
        SYSTEM,
        /// <summary>
        /// The Systems component is a place holder for all the system types.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1607344852741_562899_1488")]
        SYSTEMS,
        /// <summary>
        /// Component composed of a surface for holding an object or material.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106476_995417_44462")]
        TABLE,
        /// <summary>
        /// Component generally composed of an enclosed container.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106477_651135_44465")]
        TANK,
        /// <summary>
        /// Component that provides or applies a stretch or strain to another mechanism.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106477_119326_44468")]
        TENSIONER,
        /// <summary>
        /// A sensor capable of measuring the temperature of a component. The temperature is always given in Celsius.
        /// </summary>
        [Obsolete("Deprecated in version 1.2.0. Replaced with a DataItem called Temperature.")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure___19_0_4_45f01b9_1643678703742_369144_1539", MtconnectVersions.V_1_1_0)]
        THERMOSTAT,
        /// <summary>
        /// ToolingDelivery composed of a tool storage mechanism that holds any number of tools.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1605551866030_769452_2402")]
        TOOL_MAGAZINE,
        /// <summary>
        /// ToolingDelivery composed of a linear or matrixed tool storage mechanism that holds any number of tools.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1605551899241_174607_2546")]
        TOOL_RACK,
        /// <summary>
        /// Auxiliary that manages, positions, stores, and delivers tooling within a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572382021_741508_42300")]
        TOOLING_DELIVERY,
        /// <summary>
        /// Component that physically moves a tool from one location to another.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1605552257830_675148_2688")]
        TRANSFER_ARM,
        /// <summary>
        /// Component that is a Pot for a tool that is awaiting transfer from a  ToolMagazine to spindle or  Turret.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1605552258190_552410_2704")]
        TRANSFER_POT,
        /// <summary>
        /// Component that transforms electric energy from a source to a secondary circuit.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106478_840214_44471")]
        TRANSFORMER,
        /// <summary>
        /// ToolingDelivery composed of a tool mounting mechanism that holds any number of tools.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1605551876111_523604_2450")]
        TURRET,
        /// <summary>
        /// System that evacuates gases and liquids from an enclosed and sealed space to a controlled negative pressure or a molecular density below the prevailing atmospheric level.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "https://model.mtconnect.org/#Structure___19_0_3_68e0225_1605116368942_480454_1665")]
        VACUUM,
        /// <summary>
        /// Component that halts or controls the flow of a liquid, gas, or other material through a passage, pipe, inlet, or outlet.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106478_602921_44474")]
        VALVE,
        /// <summary>
        /// Component generally composed of an open container.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106479_944360_44477")]
        VAT,
        /// <summary>
        /// A sensor capable of measuring the vibration of a component.
        /// </summary>
        [Obsolete("Deprecated in version 1.2.0. Replaced with DataItems to measure vibration (Displacement, Frequency, etc.).")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, "https://model.mtconnect.org/#Structure___19_0_4_45f01b9_1643678730400_947692_1640", MtconnectVersions.V_1_1_0)]
        VIBRATION,
        /// <summary>
        /// Auxiliary that removes manufacturing byproducts from a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1579572382023_920799_42303")]
        WASTE_DISPOSAL,
        /// <summary>
        /// Component composed of H2O
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106480_337779_44480")]
        WATER,
        /// <summary>
        /// Component composed of a string like piece or filament of relatively rigid or flexible material provided in a variety of diameters.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "https://model.mtconnect.org/#Structure___19_0_3_45f01b9_1580312106480_27284_44483")]
        WIRE,
        /// <summary>
        /// System composed of the physical process execution space within a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#Structure___19_0_3_91b028d_1587649840347_727529_300")]
        WORK_ENVELOPE,
        /// <summary>
        /// Component composed of an object or material on which a form of work is performed.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "https://model.mtconnect.org/#Structure___19_0_3_91b028d_1587650651134_415529_403")]
        WORKPIECE,
    }
}
