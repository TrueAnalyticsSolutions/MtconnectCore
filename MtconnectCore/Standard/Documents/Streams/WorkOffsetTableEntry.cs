using System.Collections.Generic;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class WorkOffsetTableEntry
    {
        /// <summary>
        /// Collected from the key attribute. Refer to Part 3 Streams - 5.6.5.3.3
        /// 
        /// Occurance: 1
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Collected from the removed attribute. Refer to Part 3 Streams - 5.6.5.3.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        public bool Removed { get; set; }

        private List<WorkOffsetCell> _cells = new List<WorkOffsetCell>();
        public ICollection<WorkOffsetCell> Cells => _cells;
    }
}
