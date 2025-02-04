namespace MtconnectCore.Standard.Documents.ExceptionsReport
{
    public class MtconnectDevicesException : MtconnectException
    {
        /// <summary>
        /// Overrides the base source as a string to represent a XPath to the node.
        /// </summary>
        public new string Source { get; set; }
    }
}
