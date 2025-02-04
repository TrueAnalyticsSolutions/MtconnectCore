namespace MtconnectCore.Standard.Contracts
{
    public interface IParsedValue
    {
        /// <summary>
        /// Gets or sets the original string value from the XML or JSON data.
        /// </summary>
        string RawValue { get; set; }
    }
}
