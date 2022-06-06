using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes;

namespace MtconnectCore.Standard.Contracts.Enums.Streams
{
    /// <summary>
    /// Available values for EVENT element <see cref="EventTypes.WAIT_STATE"/>
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 6.2")]
    public enum WaitStateValues
    {
        /// <summary>
        /// An indication that execution is waiting while the equipment is powering up and is not currently available to begin producing parts or products.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 6.2")]
        POWERING_UP,
        /// <summary>
        /// An indication that the execution is waiting while the equipment is powering down but has not fully reached a stopped state.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 6.2")]
        POWERING_DOWN,
        /// <summary>
        /// An indication that the execution is waiting while one or more discrete workpieces are being loaded.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 6.2")]
        PART_LOAD,
        /// <summary>
        /// An indication that the execution is waiting while one or more discrete workpieces are being unloaded.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 6.2")]
        PART_UNLOAD,
        /// <summary>
        /// An indication that the execution is waiting while a tool or tooling is being loaded.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 6.2")]
        TOOL_LOAD,
        /// <summary>
        /// An indication that the execution is waiting while a tool or tooling is being unloaded.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 6.2")]
        TOOL_UNLOAD,
        /// <summary>
        /// An indication that the execution is waiting while bulk material or the container for bulk material used in the production process is being loaded. Bulk material includes those materials from which multiple workpieces may be created.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 6.2")]
        MATERIAL_LOAD,
        /// <summary>
        /// An indication that the execution is waiting while bulk material or the container for bulk material used in the production process is being unloaded. Bulk material includes those materials from which multiple workpieces may be created.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 6.2")]
        MATERIAL_UNLOAD,
        /// <summary>
        /// An indication that the execution is waiting while another process is completed before the execution can resume.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 6.2")]
        SECONDARY_PROCESS,
        /// <summary>
        /// An indication that the execution is waiting while the equipment is pausing but the piece of equipment has not yet reached a fully paused state.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 6.2")]
        PAUSING,
        /// <summary>
        /// An indication that the execution is waiting while the equipment is resuming the production cycle but has not yet resumed execution.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "Part 2 Section 6.2")]
        RESUMING
    }
}
