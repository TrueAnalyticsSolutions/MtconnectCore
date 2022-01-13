using ConsoulLibrary;
using ConsoulLibrary.Views;
using MtconnectCore;
using MtconnectCore.Standard.Contracts.Errors;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace MtconnectCoreExample.Views
{
    public class AuditView : DynamicView<AuditViewModel>
    {
        public AuditView()
        {
            Title = (new BannerEntry("MTConnect Agent Audit")).Message;
            Source = new AuditViewModel();
        }

        private string _setAgentUrlMessage() => $"Set Agent Url ({(string.IsNullOrEmpty(Source.AgentUrl) ? "Not Set" : Source.AgentUrl)})";
        private ConsoleColor _setAgentUrlColor() => string.IsNullOrEmpty(Source.AgentUrl) ? ConsoleColor.Yellow : ConsoleColor.Green;
        [DynamicViewOption(nameof(_setAgentUrlMessage), nameof(_setAgentUrlColor))]
        public void SetAgentUrl()
        {
            string filePath;
            do
            {
                Consoul.Write("Please type/paste the filepath of the MTConnect Response Document data you wish to process:", ConsoleColor.Yellow);
                filePath = Consoul.Read();
            } while (string.IsNullOrEmpty(filePath));
            if (filePath.StartsWith("\"") && filePath.EndsWith("\"")) filePath = filePath.Substring(1, filePath.Length - 2);
            Source.AgentUrl = filePath;
            Source.Errors = null;
        }

        private string _performAuditMessage() => $"Perform Audit ({(Source.Errors == null ? "Not Run" : "Complete")})";
        private ConsoleColor _performAuditColor() => string.IsNullOrEmpty(Source.AgentUrl) ? ConsoleColor.Red : (Source.Errors == null ? ConsoleColor.Yellow : ConsoleColor.Green);
        [DynamicViewOption(nameof(_performAuditMessage), nameof(_performAuditColor))]
        public void PerformAudit()
        {
            Consoul.Write("Running audit... ", ConsoleColor.Gray, false);
            using (var agent = new MtconnectAgentService(new Uri(Source.AgentUrl)))
            {
                Source.Errors = agent.Audit().Result;
            }
            Consoul.Write("Done!", ConsoleColor.Green);
        }

        private string _exportAuditMessage() => $"Export Report ({(Source.Errors == null ? "Perform Audit First" : "Ready")})";
        private ConsoleColor _exportAuditColor() => string.IsNullOrEmpty(Source.AgentUrl) ? ConsoleColor.Red : (Source.Errors == null ? ConsoleColor.Red : ConsoleColor.Yellow);
        [DynamicViewOption(nameof(_exportAuditMessage), nameof(_exportAuditColor))]
        public void ExportAuditReport()
        {
            DateTime now = DateTime.Now;
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"MTConnect Agent Audit_{now.ToString("yyyy-dd-M")}.xlsx");
            using (ExcelPackage pkg = new ExcelPackage())
            {
                var reportSheet = pkg.Workbook.Worksheets.Add("Report");
                var exceptionsSheet = pkg.Workbook.Worksheets.Add("Audit Results");

                reportSheet.Cells[1, 1].Value = "Date";
                reportSheet.Cells[1, 2].Value = now.ToString();
                reportSheet.Cells[2, 1].Value = "Agent";
                reportSheet.Cells[2, 2].Value = Source.AgentUrl;
                reportSheet.Cells[2, 2].Hyperlink = new Uri(Source.AgentUrl);
                reportSheet.Cells[3, 1].Value = "Status";
                reportSheet.Cells[3, 2].Formula = @"=IF(COUNTIF(Results[Severity], ""ERROR"") > 0, ""Failed"", IF(COUNTIF(Results[Severity], ""WARNING"") > 0, ""Passed (with warnings)"", ""Passed""))";

                exceptionsSheet.Cells[1, 1].Value = "Severity";
                exceptionsSheet.Cells[1, 2].Value = "Message";
                int row = 2;
                foreach (var exception in Source.Errors)
                {
                    exceptionsSheet.Cells[row, 1].Value = exception.Severity.ToString();
                    exceptionsSheet.Cells[row, 2].Value = exception.Message;
                    row++;
                }
                row--;
                exceptionsSheet.Tables.Add(new ExcelAddressBase(1, 1, row, 2), "Results");
                exceptionsSheet.Cells[1, 1, row, 2].AutoFitColumns();

                var fi = new FileInfo(path);
                pkg.SaveAs(fi);
            }
            Consoul.Write("Saved Report!", ConsoleColor.Green);
            Consoul.Write(path, ConsoleColor.Gray);
            Consoul.Wait();
        }
    }
    public class AuditViewModel
    {
        public string AgentUrl { get; set; }

        public ICollection<MtconnectValidationException> Errors { get; set; }
    }
}
