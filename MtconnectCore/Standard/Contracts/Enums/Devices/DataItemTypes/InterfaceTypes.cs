using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
    public enum InterfaceTypes
    {
        /// <summary>
        /// Service to load or feed material or product to a piece of equipment from a  continuous or bulk source
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        MATERIAL_FEED,
        /// <summary>
        /// Service to request a change in the type of material or product being loaded  or fed to a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        MATERIAL_CHANGE,
        /// <summary>
        /// Service to request that material or product be removed or retracted from a  piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        MATERIAL_RETRACT,
        /// <summary>
        /// Service to request that the type of part or product being made by a piece of  equipment be changed to a different part or product type. Coupled with PART_ID to indicate the part or product type.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        PART_CHANGE,
        /// <summary>
        /// Service to request for a piece of material or product be loaded to a piece of  equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        MATERIAL_LOAD,
        /// <summary>
        /// Service to request for a piece of material or product be unloaded from a  piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        MATERIAL_UNLOAD,
        /// <summary>
        /// Service to request another piece of equipment to open a door.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        OPEN_DOOR,
        /// <summary>
        /// Service to request another piece of equipment to close a door. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        CLOSE_DOOR,
        /// <summary>
        /// Service to request another piece of equipment to open a chuck.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        OPEN_CHUCK,
        /// <summary>
        /// Service to request another piece of equipment to close a chuck. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "Part 2 Section 7.1")]
        CLOSE_CHUCK
    }
}
