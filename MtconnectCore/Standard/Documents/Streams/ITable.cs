using System.Collections.Generic;

namespace MtconnectCore.Standard.Documents.Streams
{
    public interface ITable : IRepresentation
    {
        /// <summary>
        /// Collected from the count attribute. Refer to Part 3 Streams - 5.6.5.1
        /// 
        /// Occurance: 1
        /// </summary>
        int? Count { get; set; }

        ICollection<TableEntry> Result { get; }
    }
}
