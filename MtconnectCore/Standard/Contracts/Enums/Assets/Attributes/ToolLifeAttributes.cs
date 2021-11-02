namespace MtconnectCore.Standard.Contracts.Enums.Assets.Attributes
{
    public enum ToolLifeAttributes {
        /// <summary>
        /// The type of tool life being accumulated.
        /// </summary>
        TYPE,
        /// <summary>
        /// Indicates if the tool life counts from zero to maximum or maximum to zero.
        /// </summary>
        COUNT_DIRECTION,
        /// <summary>
        /// The point at which a tool life warning will be raised.
        /// </summary>
        WARNING,
        /// <summary>
        /// The end of life limit for this tool. If the countDirection is DOWN, the point at which this tool should be expired, usually zero. If the countDirection is UP, this is the upper limit for which this tool should be expired. 
        /// </summary>
        LIMIT,
        /// <summary>
        /// The initial life of the tool when it is new. 
        /// </summary>
        INITIAL
    }
}
