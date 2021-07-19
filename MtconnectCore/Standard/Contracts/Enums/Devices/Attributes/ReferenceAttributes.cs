namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    /// <summary>
    /// Attributes available in the abstract Reference element in the MTConnect Response document.
    /// </summary>
    /// <remarks>See Part 2 Section 4.8 of the MTConnect specification.</remarks>
    public enum ReferenceAttributes {
        /// <summary>
        /// A pointer to the id attribute of the implemented Reference target that contains the information to be associated with this XML element.
        /// </summary>
        ID_REF,
        /// <summary>
        /// The optional name of the implemented Reference target. Only informative.
        /// </summary>
        NAME
    }
}
