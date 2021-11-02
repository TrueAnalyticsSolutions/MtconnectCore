using System;
using System.Collections.Generic;
using System.Text;

namespace MtconnectCore.Standard.Contracts.Enums.Assets.Elements
{
    public enum CuttingToolElements
    {
        /// <summary>
        /// An element that can contain any descriptive content. This can contain configuration information and manufacturer specific details. This element is defined to contain mixed content and XML elements can be added to extend the descriptive semantics of MTConnect. 
        /// </summary>
        DESCRIPTION,
        /// <summary>
        /// Reference to a ISO 13399
        /// </summary>
        CUTTING_TOOL_DEFINITION,
        /// <summary>
        /// MTConnect data regarding the use phase of this tool.
        /// </summary>
        CUTTING_TOOL_LIFE_CYCLE
    }
    public enum CuttingToolLifeCycleElements {
        /// <summary>
        /// The status of the this assembly.
        /// </summary>
        CUTTER_STATUS,
        /// <summary>
        /// The number of times this cutter has been reconditioned.
        /// </summary>
        RECONDITION_COUNT,
        /// <summary>
        /// The cutting tool life as related to this assembly.
        /// </summary>
        TOOL_LIFE,
        /// <summary>
        /// The location this tool now resides in. 
        /// </summary>
        LOCATION,
        /// <summary>
        /// The tool group this tool is assigned in the part program.
        /// </summary>
        PROGRAM_TOOL_GROUP,
        /// <summary>
        /// The number of the tool as referenced in the part program.
        /// </summary>
        PROGRAM_TOOL_NUMBER,
        /// <summary>
        /// The constrained process spindle speed for this tool 
        /// </summary>
        PROCESS_SPINDLE_SPEED,
        /// <summary>
        /// The constrained process feed rate for this tool in mm/s. 
        /// </summary>
        PROCESS_FEED_RATE,
        /// <summary>
        /// Identifier for the capability to connect any component of  the cutting tool together, except assembly items, on the machine side. Code: CCMS
        /// </summary>
        CONNECTION_CODE_MACHINE_SIDE,
        /// <summary>
        /// A collection of measurements for the tool assembly.
        /// </summary>
        MEASUREMENTS,
        /// <summary>
        /// An optional set of individual cutting items.
        /// </summary>
        CUTTING_ITEMS
    }
}
