using System;
using System.Collections.Generic;
using System.Text;

namespace MtconnectCore.Standard.Documents.Streams
{
    public interface IDataItem
    {
        string DataItemId { get; set; }

        DateTime Timestamp { get; set; }

        int Sequence { get; set; }
    }
}
