using ConsoulLibrary;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Documents;
using System;
using System.Collections.Generic;
namespace MtconnectCoreExample
{
    public static class Helper
    {
        public static void DisplayDocumentAndValidate<T>(this IResponseDocument mtcDocument) where T : IResponseDocument {
            if (mtcDocument is T)
            {
                var options = new Newtonsoft.Json.JsonSerializerSettings() {
                     //Formatting = Newtonsoft.Json.Formatting.Indented
                };
                Consoul.Write(Newtonsoft.Json.JsonConvert.SerializeObject(mtcDocument, options), ConsoleColor.DarkGray);
                bool validationResult = ((T)mtcDocument).TryValidate(out ICollection<MtconnectCore.Standard.Contracts.Errors.MtconnectValidationException> validationErrors);
                foreach (var error in validationErrors)
                {
                    ConsoleColor color;
                    switch (error.Severity)
                    {
                        case ValidationSeverity.WARNING:
                            color = ConsoleColor.Yellow;
                            break;
                        case ValidationSeverity.ERROR:
                            color = ConsoleColor.Red;
                            break;
                        default:
                            color = ConsoleColor.Gray;
                            break;
                    }
                    Consoul.Write(error.ToString(), color);
                }

                Consoul.Write("Done!", ConsoleColor.Green);
            }
            else
            {
                Consoul.Write($"Unexpected document type", ConsoleColor.Red);
                Consoul.Write($"Document Type: {mtcDocument.Type}", ConsoleColor.Gray);
            }
        }
    }
}
