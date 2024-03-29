﻿using MtconnectCore.Standard.Contracts.Attributes;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Assets
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.10.1")]
    public enum CuttingToolStatusTypes
    {
        /// <summary>
        /// A new tool that has not been used or first use. Marks the start of the tool history.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.10.1")]
        NEW,
        /// <summary>
        /// Indicates the tool is available for use. If this is not present, the tool is currently not ready to be used
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.10.1")]
        AVAILABLE,
        /// <summary>
        /// Indicates the tool is unavailable for use in metal removal. If this is not present, the tool is currently not ready to be used
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.10.1")]
        UNAVAILABLE,
        /// <summary>
        /// Indicates if this tool is has been committed to a device for use and is not available for use in any other device. If this is not present, this tool has not been allocated for this device and can be used by another device
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.10.1")]
        ALLOCATED,
        /// <summary>
        /// Indicates this Cutting Tool has not been committed to a process and can be allocated. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.10.1")]
        UNALLOCATED,
        /// <summary>
        /// The tool has been measured.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.10.1")]
        MEASURED,
        /// <summary>
        /// The cutting tool has been reconditioned. See ReconditionCount for the number of times this cutter has been reconditioned.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.10.1")]
        RECONDITIONED,
        /// <summary>
        /// The tool is in process and has remaining tool life.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.10.1")]
        USED,
        /// <summary>
        /// The cutting tool has reached the end of its useful life.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.10.1")]
        EXPIRED,
        /// <summary>
        /// Premature tool failure.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.10.1")]
        BROKEN,
        /// <summary>
        /// This cutting tool cannot be used until it is entered into the system. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.10.1")]
        NOT_REGISTERED,
        /// <summary>
        /// The cutting tool is an indeterminate state. This is the default value. 
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "Part 4 Section 6.1.10.1")]
        UNKNOWN
    }
}
