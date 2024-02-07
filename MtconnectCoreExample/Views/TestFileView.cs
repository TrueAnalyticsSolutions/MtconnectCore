using ConsoulLibrary;
using ConsoulLibrary.Views;
using MtconnectCore;
using MtconnectCore.Standard.Documents;
using MtconnectCore.Standard.Documents.Assets;
using MtconnectCore.Standard.Documents.Devices;
using MtconnectCore.Standard.Documents.Error;
using MtconnectCore.Standard.Documents.Streams;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace MtconnectCoreExample.Views
{
    public class TestFileView : DynamicView<TestFileViewModel>
    {
        public TestFileView()
        {
            Title = (new BannerEntry("MTConnect Example by File")).Message;
            Source = new TestFileViewModel();
        }

        private string _selectFileMessage() => Source.File != null ? "Select MTConnect Response Document - (Loaded)" : "Select MTConnect Response Document";
        private ConsoleColor _selectFileColor() => Source.File != null ? ConsoleColor.Green : ConsoleColor.Yellow;
        [DynamicViewOption(nameof(_selectFileMessage), nameof(_selectFileColor))]
        public void SelectFile()
        {
            string filePath;
            do
            {
                Consoul.Write("Please type/paste the filepath of the MTConnect Response Document data you wish to process:", ConsoleColor.Yellow);
                filePath = Consoul.Read();
            } while (string.IsNullOrEmpty(filePath) && !System.IO.File.Exists(filePath));
            if (filePath.StartsWith("\"") && filePath.EndsWith("\"")) filePath = filePath.Substring(1, filePath.Length - 2);
            Source.FilePath = filePath;
        }

        private string _validateMessage() => Source.File != null ? "Validate (Ready)" : "Validate (Not Ready)";
        private ConsoleColor _validateColor() => Source.File != null ? ConsoleColor.Yellow : ConsoleColor.Red;
        [DynamicViewOption(nameof(_validateMessage), nameof(_validateColor))]
        public void Validate()
        {
            try
            {
                IResponseDocument mtcDocument;

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(Source.File.FullName);

                if (MtconnectAgentService.TryParse(xDoc, out mtcDocument))
                {
                    switch (mtcDocument.Type)
                    {
                        case MtconnectCore.Standard.Contracts.Enums.DocumentTypes.Devices:
                            mtcDocument.DisplayDocumentAndValidate<DevicesDocument>();
                            break;
                        case MtconnectCore.Standard.Contracts.Enums.DocumentTypes.Streams:
                            mtcDocument.DisplayDocumentAndValidate<StreamsDocument>();
                            break;
                        case MtconnectCore.Standard.Contracts.Enums.DocumentTypes.Assets:
                            mtcDocument.DisplayDocumentAndValidate<AssetsDocument>();
                            break;
                        case MtconnectCore.Standard.Contracts.Enums.DocumentTypes.Errors:
                            mtcDocument.DisplayDocumentAndValidate<ErrorDocument>();
                            break;
                        default:
                            break;
                    }
                } else {
                    Consoul.Write("Failed to parse the file as a MTConnect Response Document.", ConsoleColor.Red);
                }
            }
            catch (Exception ex)
            {
                Consoul.Write(ex.ToString(), ConsoleColor.Red);
            }
            Consoul.Wait();
        }

        private string _countDataItemsMessage() => Source.File != null ? "Count Data Items (Ready)" : "Count Data Items (Not Ready)";
        private ConsoleColor _countDataItemsColor() => Source.File != null ? ConsoleColor.Yellow : ConsoleColor.Red;
        [DynamicViewOption(nameof(_countDataItemsMessage), nameof(_countDataItemsColor))]
        public void CountDataItems()
        {
            try
            {
                IResponseDocument mtcDocument;

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(Source.File.FullName);

                if (MtconnectAgentService.TryParse(xDoc, out mtcDocument))
                {
                    switch (mtcDocument.Type)
                    {
                        case MtconnectCore.Standard.Contracts.Enums.DocumentTypes.Devices:
                            Consoul.Write(DataItemNavigator.GetAll(mtcDocument as DevicesDocument).Count() + " Data Items");
                            break;
                        case MtconnectCore.Standard.Contracts.Enums.DocumentTypes.Streams:
                            Consoul.Write(DataItemNavigator.GetAll(mtcDocument as StreamsDocument).Count() + " Data Items");
                            break;
                        case MtconnectCore.Standard.Contracts.Enums.DocumentTypes.Assets:
                            Consoul.Write("Cannot count DataItems from Assets", ConsoleColor.Red);
                            break;
                        case MtconnectCore.Standard.Contracts.Enums.DocumentTypes.Errors:
                            Consoul.Write("DataItems are not in Errors", ConsoleColor.Red);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Consoul.Write("Failed to parse the file as a MTConnect Response Document.", ConsoleColor.Red);
                }
            }
            catch (Exception ex)
            {
                Consoul.Write(ex.ToString(), ConsoleColor.Red);
            }
            Consoul.Wait();
        }

        private string _countComponentsMessage() => Source.File != null ? "Count Components (Ready)" : "Count Components (Not Ready)";
        private ConsoleColor _countComponentsColor() => Source.File != null ? ConsoleColor.Yellow : ConsoleColor.Red;
        [DynamicViewOption(nameof(_countComponentsMessage), nameof(_countComponentsColor))]
        public void CountComponents()
        {
            try
            {
                IResponseDocument mtcDocument;

                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(Source.File.FullName);

                if (MtconnectAgentService.TryParse(xDoc, out mtcDocument))
                {
                    switch (mtcDocument.Type)
                    {
                        case MtconnectCore.Standard.Contracts.Enums.DocumentTypes.Devices:
                            Consoul.Write(DataItemNavigator.GetAllComponents(mtcDocument as DevicesDocument).Count() + " Components");
                            break;
                        case MtconnectCore.Standard.Contracts.Enums.DocumentTypes.Streams:
                            Consoul.Write(DataItemNavigator.GetAllComponents(mtcDocument as StreamsDocument).Count() + " Components");
                            break;
                        case MtconnectCore.Standard.Contracts.Enums.DocumentTypes.Assets:
                            Consoul.Write("Cannot count Components from Assets", ConsoleColor.Red);
                            break;
                        case MtconnectCore.Standard.Contracts.Enums.DocumentTypes.Errors:
                            Consoul.Write("Components are not in Errors", ConsoleColor.Red);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Consoul.Write("Failed to parse the file as a MTConnect Response Document.", ConsoleColor.Red);
                }
            }
            catch (Exception ex)
            {
                Consoul.Write(ex.ToString(), ConsoleColor.Red);
            }
            Consoul.Wait();
        }
    }
    public class TestFileViewModel {
        public string FilePath { get; set; }

        private FileInfo _fi;
        public FileInfo File {
            get{
                if (_fi == null && !string.IsNullOrEmpty(FilePath)) {
                    _fi = new FileInfo(FilePath);
                }
                return _fi;
            }
        }
    }
}
