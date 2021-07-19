using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    /// <summary>
    /// Attributes of the Component element
    /// </summary>
    /// <remarks>See Part 2 Section 4.4.2 of the MTConnect specification.</remarks>
    public enum ComponentAttributes
    {
        /// <summary>
        /// The unique identifier for this element.
        /// </summary>
        ID,
        /// <summary>
        /// The common name normally associated with a specific physical or logical part of a piece of equipment.
        /// </summary>
        NATIVE_NAME,
        /// <summary>
        /// An optional attribute that is an indication provided by a piece of equipment describing the interval in milliseconds between the completion of the reading of the data associated with the Component element until the beginning of the next sampling of that data. This indication is reported as the number of milliseconds between data captures.
        /// </summary>
        SAMPLE_INTERVAL,
        /// <summary>
        /// DEPRECATED in MTConnect Version 1.2. Replaced by <see cref="SAMPLE_INTERVAL"/>
        /// </summary>
        [Obsolete]
        SAMPLE_RATE,
        /// <summary>
        /// A unique identifier for this XML element.
        /// </summary>
        UUID,
        /// <summary>
        /// The name of the Component element.
        /// </summary>
        NAME
    }
}
