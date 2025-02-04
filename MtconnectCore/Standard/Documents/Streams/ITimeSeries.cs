
namespace MtconnectCore.Standard.Documents.Streams
{
    public interface ITimeSeries : IRepresentation
    {
        string SampleCount { get; set; }

        float[] Result { get; set; }
    }
}
