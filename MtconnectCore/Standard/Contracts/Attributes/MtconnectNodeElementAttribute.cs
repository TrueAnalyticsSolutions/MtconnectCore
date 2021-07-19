namespace MtconnectCore.Standard.Contracts.Attributes
{
    /// <inheritdoc cref="MtconnectNodeAttribute"/>
    public class MtconnectNodeElementAttribute : MtconnectNodeAttribute
    {
        /// <summary>
        /// Initializes a <see cref="MtconnectNodeElementAttribute"/> for automatic processing of a MTConnect node's XML inner text.
        /// </summary>
        /// <param name="name"></param>
        public MtconnectNodeElementAttribute(object name) : base(name) { }
    }
}
