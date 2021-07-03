namespace MtconnectCore.Standard.Documents.Streams
{
    public class WorkOffsetCell
    {
        /// <summary>
        /// Collected from the key attribute. Refer to Part 3 Streams - 5.6.5.3.5
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Collected from the textcontent of the Cell element. Refer to Part 3 Streams - 5.6.5.3.6
        /// </summary>
        public string Value { get; set; }
    }
}
