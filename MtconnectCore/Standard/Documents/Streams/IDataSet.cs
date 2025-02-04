using MtconnectCore.Standard.Contracts;
using System.Collections.Generic;

namespace MtconnectCore.Standard.Documents.Streams
{
    public interface IDataSet : IRepresentation
    {
        /// <summary>
        /// Collected from the count attribute. Refer to Part 3 Streams - 5.6.3.1
        /// 
        /// Occurance: 1
        /// </summary>
        ParsedValue<uint?> Count { get; set; }

        /// <summary>
        /// Collected from Sample elements. Refer to Part 3 Streams - 4.3.3
        /// </summary>
        ICollection<Entry> Result { get; }
    }
}
