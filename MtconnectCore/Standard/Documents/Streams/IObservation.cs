using System;

namespace MtconnectCore.Standard.Documents.Streams
{
    public interface IObservation
    {
        string DataItemId { get; }

        DateTime Timestamp { get; set; }

        ulong Sequence { get; set; }
    }
}
