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
            try
            {
                using (MtconnectAgentService mtcService = new MtconnectAgentService(Source.ToUri()))
                {
                    IResponseDocument mtcDocument = mtcService.Current().Result;
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
