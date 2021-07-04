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
            using (MtconnectAgentService mtcService = new MtconnectAgentService(Source.ToUri()))
            {
                StreamsDocument mtcDocument = mtcService.Sample().Result;
                if (mtcDocument is StreamsDocument)
                {
                    Consoul.Write(Newtonsoft.Json.JsonConvert.SerializeObject(mtcDocument), ConsoleColor.DarkGray);

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
}
