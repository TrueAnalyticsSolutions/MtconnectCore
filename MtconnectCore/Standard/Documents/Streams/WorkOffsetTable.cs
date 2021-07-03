using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using System.Collections.Generic;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class WorkOffsetTable : DataItem
    {
        /// <summary>
        /// Collected from the subType attribute. Refer to Part 3 Streams - 5.6.5.1
        /// 
        /// Occurance: 0..1
        /// </summary>
        public string SubType { get; set; }

        /// <summary>
        /// Collected from the name attribute. Refer to Part 3 Streams - 5.6.5.1
        /// 
        /// Occurance: 0..1
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Collected from the compositionId attribute. Refer to Part 3 Streams - 5.6.5.1
        /// 
        /// Occurance: 0..1
        /// </summary>
        public string CompositionId { get; set; }

        /// <summary>
        /// Collected from the resetTriggered attribute. Refer to Part 3 Streams - 5.6.5.1
        /// 
        /// Occurance: 0..1
        /// </summary>
        public ResetTriggers ResetTriggered { get; set; }

        /// <summary>
        /// Collected from the count attribute. Refer to Part 3 Streams - 5.6.5.1
        /// 
        /// Occurance: 1
        /// </summary>
        public int Count { get; set; }

        private List<WorkOffsetTableEntry> _entries = new List<WorkOffsetTableEntry>();
        public ICollection<WorkOffsetTableEntry> Entries => _entries;
    }
}
