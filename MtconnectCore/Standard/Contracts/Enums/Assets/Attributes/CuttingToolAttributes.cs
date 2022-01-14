using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Assets.Attributes
{
    public enum CuttingToolAttributes {
        /// <summary>
        /// The unique identifier of the instance of this tool. The unique identifier of the instance of this tool. This will be the same as the toolId and serialNumber in most cases. The assetId SHOULD be the combination of the toolId and serialNumber as in toolId.serialNumber or an equivalent implementation dependent identification scheme.
        /// </summary>
        ASSET_ID,
        /// <summary>
        /// The unique identifier for this assembly. The unique identifier for this assembly. This is defined as an XML string type and is implementation dependent.
        /// </summary>
        SERIAL_NUMBER,
        /// <summary>
        /// The manufacturers of the cutting tool. An optional attribute referring to the manufacturers of this tool, for this element, this will reference the Tool Item and Adaptive Items specifically. The Cutting Items manufacturers’ will be an attribute of the CuttingItem elements. The representation will be a comma (,) delimited list of manufacturer names. This can be any series of numbers and letters as defined by the XML type string. 
        /// </summary>
        MANUFACTURERS,
        /// <summary>
        /// The time this asset was last modified. Always given in UTC. The  timestamp MUST be provided in UTC (Universal Time Coordinate, also known as GMT). This is the time the asset data was last modified.
        /// </summary>
        TIMESTAMP,
        /// <summary>
        /// The device’s UUID that supplied this data. This optional element References to the UUID attribute given in the device element. This can be any series of numbers and letters as defined by the XML type NMTOKEN. 
        /// </summary>
        DEVICE_UUID,
        /// <summary>
        /// The identifier for the class of cutting tool. The identifier for a class of cutting tools. This is defined as an XML string type and is implementation dependent.
        /// </summary>
        TOOL_ID,
    }
}
