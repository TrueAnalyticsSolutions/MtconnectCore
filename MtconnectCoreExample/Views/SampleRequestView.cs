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
            try
            {
                using (MtconnectAgentService mtcService = new MtconnectAgentService(Source.ToUri()))
                {
                    IResponseDocument mtcDocument = mtcService.Sample().Result;
                    mtcDocument.DisplayDocumentAndValidate<StreamsDocument>();
                }
            }
            catch (Exception ex)
            {
                Consoul.Write(ex.ToString(), ConsoleColor.Red);
            }
            Consoul.Wait();
        }
    }
}
