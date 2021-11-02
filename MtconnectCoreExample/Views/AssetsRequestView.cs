using ConsoulLibrary;
using MtconnectCore;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Documents;
using MtconnectCore.Standard.Documents.Assets;
using MtconnectCoreExample.ViewModels;
using System;
using System.Collections.Generic;

namespace MtconnectCoreExample.Views
{
    public class AssetsRequestView : RequestViewBase
    {
        public AssetsRequestView()
        {
            Title = (new BannerEntry("MTConnect Asset Example")).Message;
            Source = new RequestBase()
            {
                Directory = RequestTypes.ASSET.ToString().ToLower()
            };
        }

        public override void Send()
        {
            using (MtconnectAgentService mtcService = new MtconnectAgentService(Source.ToUri()))
            {
                IResponseDocument mtcDocument = mtcService.Asset().Result;

                mtcDocument.DisplayDocumentAndValidate<AssetsDocument>();
                Consoul.Wait();
            }
        }
    }
}
