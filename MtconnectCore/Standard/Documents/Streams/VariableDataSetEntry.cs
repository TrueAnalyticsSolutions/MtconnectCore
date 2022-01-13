using MtconnectCore.Standard.Contracts;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class VariableDataSetEntry : MtconnectNode
    {
        /// <summary>
        /// Collected from the key attribute. Refer to Part 3 Streams - 5.6.3.3
        /// 
        /// Occurance: 1
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Collected from the removed attribute. Refer to Part 3 Streams - 5.6.3.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        public bool Removed { get; set; }

        /// <summary>
        /// Collected from the textcontent of the Entry element. Refer to Part 3 Streams - 5.6.3.3
        /// </summary>
        public string Value { get; set; }
    }
}
