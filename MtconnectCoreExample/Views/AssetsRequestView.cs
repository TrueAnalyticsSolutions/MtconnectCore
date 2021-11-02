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
                if (mtcDocument is AssetsDocument)
                {
                    Consoul.Write(Newtonsoft.Json.JsonConvert.SerializeObject(mtcDocument), ConsoleColor.DarkGray);

                    if ((mtcDocument as AssetsDocument).TryValidate(out ICollection<MtconnectCore.Standard.Contracts.Errors.MtconnectValidationException> validationErrors) == false) {
                        foreach (var error in validationErrors)
                        {
                            if (error.Severity == ValidationSeverity.ERROR)
                            {
                                Consoul.Write(error.ToString(), ConsoleColor.Red);
                            } else
                            {
                                Consoul.Write(error.ToString(), ConsoleColor.Yellow);
                            }
                        }
                    }

                    Consoul.Write("Done!", ConsoleColor.Green);
                    Consoul.Wait();
                }
                else
                {
                    Consoul.Write($"Unexpected document type", ConsoleColor.Red);
                    Consoul.Write($"Document Type: {mtcDocument.Type}", ConsoleColor.Gray);
                    Consoul.Wait();
                }
            }
        }
    }
}
