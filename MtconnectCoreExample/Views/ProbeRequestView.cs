using ConsoulLibrary;
using MtconnectCore;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Documents;
using MtconnectCore.Standard.Documents.Devices;
using MtconnectCoreExample.ViewModels;
using System;

namespace MtconnectCoreExample.Views
{
    public class ProbeRequestView : RequestViewBase
    {
        public ProbeRequestView()
        {
            Title = (new BannerEntry("MTConnect Probe Example")).Message;
            Source = new RequestBase()
            {
                Directory = RequestTypes.PROBE.ToString().ToLower()
            };
        }

        public override void Send()
        {
            using (MtconnectAgentService mtcService = new MtconnectAgentService(Source.ToUri()))
            {
                IResponseDocument mtcDocument = mtcService.Probe().Result;
                mtcDocument.DisplayDocumentAndValidate<DevicesDocument>();
                Consoul.Wait();
            }
        }
    }
}
