namespace MtconnectCore.Standard.Contracts.Enums
{
    /// <summary>
    /// An enumeration of available methods of parsing MTConnect node names from a MTConnect document
    /// </summary>
    public enum MtconnectNodeNameProcessors
    {
        /// <summary>
        /// Processes a XML node name to a camel case string.
        /// <example>camelCase</example>
        /// </summary>
        CamelCase,
        /// <summary>
        /// Processes a XML node name to a pascal case string.
        /// <example>PascalCase</example>
        /// </summary>
        PascalCase,
        /// <summary>
        /// Processes a XML node name to a snake case string.
        /// <example>snake_case</example>
        /// </summary>
        SnakeCase,
        /// <summary>
        /// Processes a XML node name to a lower case string.
        /// <example>lower case</example>
        /// </summary>
        Lower,
        /// <summary>
        /// Processes a XML node name to a upper case string.
        /// <example>UPPER CASE</example>
        /// </summary>
        Upper,
        /// <summary>
        /// Performs no string operations on the XML node name.
        /// </summary>
        None
    }
}
