namespace MtconnectCore.Standard.Documents.ExceptionsReport
{
    public class MtconnectStreamsException : MtconnectException
    {
        /// <summary>
        /// Overrides the base source as an integer to represent a reference to the sequence # of an observation.
        /// </summary>
        public new int Source { get; set; }
    }
}
