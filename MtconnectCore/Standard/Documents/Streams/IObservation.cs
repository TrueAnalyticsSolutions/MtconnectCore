namespace MtconnectCore.Standard.Documents.Streams
{
    public interface IObservation
    {
        string DataItemId { get; }

        string Timestamp { get; set; }

        string Sequence { get; set; }
    }
}
