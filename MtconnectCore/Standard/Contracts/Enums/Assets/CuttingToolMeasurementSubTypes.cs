namespace MtconnectCore.Standard.Contracts.Enums.Assets
{
    public enum CuttingToolMeasurementSubTypes {
        /// <summary>
        /// The largest diameter of the body of a tool item. 
        /// </summary>
        BODY_DIAMETER_MAX,
        /// <summary>
        /// The distance measured along the X axis from that point of the item closest to the workpiece, including the cutting item for a tool item but excluding a protruding locking mechanism for an adaptive item, to either the front of the flange on a flanged body or the beginning of the connection interface feature on the machine side for cylindrical or prismatic shanks.
        /// </summary>
        BODY_LENGTH_MAX,
        /// <summary>
        /// The maximum engagement of the cutting edge or edges with the workpiece measured perpendicular to the feed motion.
        /// </summary>
        DEPTH_OF_CUT_MAX,
        /// <summary>
        /// The maximum diameter of a circle on which the defined point Pk of each of the master inserts is located on a tool item. The normal of the machined peripheral surface points towards the axis of the cutting tool.
        /// </summary>
        CUTTING_DIAMETER_MAX,
        /// <summary>
        /// The dimension between two parallel tangents on the outside edge of a flange.
        /// </summary>
        FLANGE_DIAMETER_MAX,
        /// <summary>
        /// The largest length dimension of the cutting tool including the master insert where applicable. 
        /// </summary>
        OVERALL_TOOL_LENGTH,
        /// <summary>
        /// The dimension of the diameter of a cylindrical portion of a tool item or an adaptive item that can participate in a connection. 
        /// </summary>
        SHANK_DIAMETER,
        /// <summary>
        /// The dimension of the height of the shank.
        /// </summary>
        SHANK_HEIGHT,
        /// <summary>
        /// The dimension of the length of the shank. 
        /// </summary>
        SHANK_LENGTH,
        /// <summary>
        /// Maximum length of a cutting tool that can be used in a particular cutting operation including the non-cutting portions of the tool. 
        /// </summary>
        USABLE_LENGTH_MAX,
        /// <summary>
        /// The dimension from the yz-plane to the furthest point of the tool item or adaptive item measured in the -X direction. 
        /// </summary>
        PROTRUDING_LENGTH,
        /// <summary>
        /// The total weight of the cutting tool in grams. The force exerted by the mass of the cutting tool. 
        /// </summary>
        WEIGHT,
        /// <summary>
        /// The distance from the gauge plane or from the end of the shank to the furthest point on the tool, if a gauge plane does not exist, to the cutting reference point determined by the main function of the tool. The CuttingTool functional length will be the length of the entire tool, not a single cutting item. Each CuttingItem can have an independent FunctionalLength represented in its measurements.
        /// </summary>
        FUNCTIONAL_LENGTH
    }
}
