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
        /// BarFeeder is an XML container that represents the information for a unit involved in delivering bar stock to a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 5.4.4")]
        BAR_FEEDER,
        /// <summary>
        /// Environmental is an XML container that represents the information for a unit or function involved in monitoring, managing, or conditioning the environment around or within a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 5.4.5")]
        ENVIRONMENTAL,
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
        /// ToolingDelivery is an XML container that represents the information for a unit involved in managing, positioning, storing, and delivering tooling within a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 5.4.3")]
        TOOLING_DELIVERY,
        /// <summary>
        /// WasteDisposal is an XML container that represents the information for a unit comprised of all the parts involved in removing manufacturing byproducts from a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 5.4.2")]
        WASTE_DISPOSAL
    }
}
