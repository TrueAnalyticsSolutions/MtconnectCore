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

                if (((T)mtcDocument).TryValidate(out ICollection<MtconnectCore.Standard.Contracts.Errors.MtconnectValidationException> validationErrors) == false)
                {
                    foreach (var error in validationErrors)
                    {
                        if (error.Severity == ValidationSeverity.ERROR)
                        {
                            Consoul.Write(error.ToString(), ConsoleColor.Red);
                        }
                        else
                        {
                            Consoul.Write(error.ToString(), ConsoleColor.Yellow);
                        }
                    }
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
