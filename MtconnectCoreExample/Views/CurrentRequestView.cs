using ConsoulLibrary;
using ConsoulLibrary.Views;
using MtconnectCore;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Documents;
using MtconnectCore.Standard.Documents.Streams;
using MtconnectCoreExample.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MtconnectCoreExample.Views
{
    public class CurrentRequestView : RequestViewBase
    {
        public CurrentRequestView()
        {
            Title = (new BannerEntry("MTConnect Current Example")).Message;
            Source = new RequestBase()
            {
                Directory = RequestTypes.CURRENT.ToString().ToLower()
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
