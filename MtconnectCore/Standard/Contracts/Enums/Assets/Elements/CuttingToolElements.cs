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
}
