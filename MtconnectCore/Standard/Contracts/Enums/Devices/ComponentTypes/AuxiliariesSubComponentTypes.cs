using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.ComponentTypes
{
    /// <summary>
    /// Sub-components of <see cref="ComponentTypes.AUXILIARIES"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 5.4")]
    public enum AuxiliariesSubComponentTypes
    {
        /// <summary>
        /// A tool delivery mechanism that moves tools between a ToolMagazine and a Spindle or a Turret. An AutomaticToolChanger may also transfer tools between a location outside of a piece of equipment and a ToolMagazine or Turret.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 5.4.3.1")]
        AUTOMATIC_TOOL_CHANGER,
        /// <summary>
        /// BarFeeder is an XML container that represents the information for a unit involved in delivering bar stock to a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 5.4.4")]
        BAR_FEEDER,
        /// <summary>
        /// Deposition is an XML container that represents the information for a system that manages the addition of material or state change of material being performed in an additive manufacturing process. For example, this could describe the portion of a piece of equipment that manages a material extrusion process or a vat polymerization process.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 5.4.7")]
        DEPOSITION,
        /// <summary>
        /// Environmental is an XML container that represents the information for a unit or function involved in monitoring, managing, or conditioning the environment around or within a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 5.4.5")]
        ENVIRONMENTAL,
        /// <summary>
        /// A tool mounting mechanism that holds any number of tools. Tools are located in STATIONs. Tools are positioned for use in the manufacturing process by linearly positioning the GangToolBar.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 5.4.3.4")]
        GANG_TOOL_BAR,
        /// <summary>
        /// Loader is an XML container that represents the information for a unit comprised of all the parts involved in moving and distributing materials, parts, tooling, and other items to or from a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 5.4.1")]
        LOADER,
        /// <summary>
        /// Sensor is a XML container that represents the information for a piece of equipment that responds to a physical stimulus and transmits a resulting impulse or value from a sensing unit. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 5.4.6")]
        SENSOR,
        /// <summary>
        /// A tool storage mechanism that holds any number of tools. Tools are located in POTs. POTs are moved into position to transfer tools into or out of the ToolMagazine by an AutomaticToolChanger.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 5.4.3.2")]
        TOOL_MAGAZINE,
        /// <summary>
        /// A linear or matrixed tool storage mechanism that holds any number of tools. Tools are located in STATIONs.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 5.4.3.5")]
        TOOL_RACK,
        /// <summary>
        /// ToolingDelivery is an XML container that represents the information for a unit involved in managing, positioning, storing, and delivering tooling within a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 5.4.3")]
        TOOLING_DELIVERY,
        /// <summary>
        /// A tool mounting mechanism that holds any number of tools. Tools are located in STATIONs . Tools are positioned for use in the manufacturing process by rotating the Turret.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 5.4.3.3")]
        TURRET,
        /// <summary>
        /// WasteDisposal is an XML container that represents the information for a unit comprised of all the parts involved in removing manufacturing byproducts from a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 5.4.2")]
        WASTE_DISPOSAL
    }
}
