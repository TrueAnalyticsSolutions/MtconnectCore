using ConsoulLibrary;
using MtconnectCore;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Documents;
using MtconnectCore.Standard.Documents.Streams;
using MtconnectCoreExample.ViewModels;
using System;

namespace MtconnectCoreExample.Views
{
    public class SampleRequestView : RequestViewBase
    {
        public SampleRequestView()
        {
            Title = (new BannerEntry("MTConnect Sample Example")).Message;
            Source = new RequestBase()
            {
                Directory = RequestTypes.SAMPLE.ToString().ToLower()
            };
        }

        public override void Send()
        {
            IMtconnectDocument rawStreamDocument = AgentConnector.QueryAsync(Source.ToUri()).Result;
            if (rawStreamDocument.Type == DocumentTypes.Streams)
            {
                StreamsDocument streamResult = (StreamsDocument)rawStreamDocument;

                Consoul.Write(Newtonsoft.Json.JsonConvert.SerializeObject(streamResult), ConsoleColor.DarkGray);

                Consoul.Write("Done!", ConsoleColor.Green);
                Consoul.Wait();
            }
            else
            {
                Consoul.Write($"Unexpected document type", ConsoleColor.Red);
                Consoul.Wait();
            }
        }
    }
}
