namespace MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes
{
    /// <summary>
    /// <c>subType</c>s of SAMPLE <c>type</c> <see cref="SampleTypes.SOUND_LEVEL"/>
    /// </summary>
    public enum SoundLeveSubTypes {
        /// <summary>
        /// No weighting factor on the frequency scale 
        /// </summary>
        NO_SCALE,
        /// <summary>
        /// A Scale weighting factor. This is the default  weighting factor if no factor is specified
        /// </summary>
        A_SCALE,
        /// <summary>
        /// B Scale weighting factor
        /// </summary>
        B_SCALE,
        /// <summary>
        /// C Scale weighting factor 
        /// </summary>
        C_SCALE,
        /// <summary>
        /// D Scale weighting factor
        /// </summary>
        D_SCALE
    }
}
