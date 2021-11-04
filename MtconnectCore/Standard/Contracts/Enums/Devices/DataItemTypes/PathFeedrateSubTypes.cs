namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.PATH_FEEDRATE"/>
    /// </summary>
    public enum PathFeedrateSubTypes {
        /// <summary>
        /// The three-dimensional feedrate derived from the  Controller.
        /// </summary>
        ACTUAL,
        /// <summary>
        /// The feedrate as specified in the program
        /// </summary>
        COMMANDED,
        /// <summary>
        /// The operator’s overridden value. Percent of commanded.
        /// </summary>
        OVERRIDE
    }
}
