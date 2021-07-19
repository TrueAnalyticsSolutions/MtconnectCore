namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    /// <summary>
    /// Attributes for the Composition element in the MTConnect Response document.
    /// </summary>
    public enum CompositionAttributes {
        /// <summary>
        /// The unique identifier for this element.
        /// </summary>
        ID,
        /// <summary>
        /// A unique identifier for this XML element.
        /// </summary>
        UUID,
        /// <summary>
        /// The name of the Composition element.
        /// </summary>
        NAME,
        /// <summary>
        /// The type of Composition element.
        /// <example>
        /// <list type="bullet">
        /// <item>MOTOR</item>
        /// <item>FILTER</item>
        /// <item>PUMP</item>
        /// <item>AMPLIFIER</item>
        /// </list>
        /// </example>
        /// </summary>
        TYPE
    }
}
