using ConsoulLibrary;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Documents;
using MtconnectCore.Validation;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

                var report = new ValidationReport();

                bool validationResult = ((T)mtcDocument).TryValidate(report);
                foreach (var error in report.Exceptions)
                {
                    ConsoleColor color;
                    switch (error.Severity)
                    {
                        case ValidationSeverity.INFO:
                            color = ConsoleColor.Blue;
                            break;
                        case ValidationSeverity.WARNING:
                            color = ConsoleColor.Yellow;
                            break;
                        case ValidationSeverity.ERROR:
                            color = ConsoleColor.Red;
                            break;
                        case ValidationSeverity.FATAL:
                            color = ConsoleColor.DarkRed;
                            break;
                        default:
                            color = ConsoleColor.Gray;
                            break;
                    }
                    Consoul.Write(error.Source, ConsoleColor.Gray);
                    Consoul.Write($"{error.Message}", color);
                    if (error.Data != null && error.Data.Count > 0)
                    {
                        foreach (DictionaryEntry item in error.Data)
                        {
                            Consoul.Write($"\t{item.Key}={item.Value}", ConsoleColor.Gray, false);
                        }
                        Consoul.Write("");
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
