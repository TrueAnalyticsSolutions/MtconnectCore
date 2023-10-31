
namespace MtconnectCore.Standard.Documents.Streams
{
    public interface ITimeSeries : IRepresentation
    {
        int? SampleCount { get; set; }

        float[] Result { get; set; }
    }
}
