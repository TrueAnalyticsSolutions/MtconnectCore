﻿using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Assets.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Assets
{
    /// <inheritdoc />
    public class AssetsDocument : ResponseDocument<AssetsDocumentHeader, Asset>
    {
        /// <inheritdoc />
        public override DocumentTypes Type => DocumentTypes.Assets;

        /// <inheritdoc />
        public override string DataElementName => AssetsElements.ASSETS.ToPascalCase();

        [MtconnectNodeElements(AssetsElements.HEADER, nameof(TrySetHeader))]
        internal override AssetsDocumentHeader _header { get; set; }
        /// <inheritdoc />
        public AssetsDocumentHeader Header => (AssetsDocumentHeader)_header;

        /// <inheritdoc />
        public AssetsDocument(XmlDocument xDoc) : base(xDoc)
        {
            _header = new AssetsDocumentHeader(xDoc.DocumentElement.FirstChild, NamespaceManager, MtconnectVersion.GetValueOrDefault());
        }

        /// <inheritdoc />
        public override bool TryAddItem(XmlNode xNode, XmlNamespaceManager nsmgr, out Asset item) {
            Logger.Verbose("Reading Assets");
            switch (xNode.LocalName)
            {
                case "CuttingTool":
                    item = new CuttingTool(xNode, nsmgr, DocumentVersion);
                    if (!item.TryValidate())
                    {
                        //Logger.Warn($"[Invalid Assets] CuttingTool:\r\n{ExceptionHelper.ToString(validationExceptions)}");
                        return false;
                    } else
                    {
                        _items.Add(item);
                    }

                    break;
                default:
                    Logger.Error(new MtconnectValidationException(
                        Contracts.Enums.ValidationSeverity.ERROR,
                        $"Invalid Asset type. '{xNode.LocalName}' is not recognized by MtconnectCore.",
                        xNode)
                    {
                        Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.TYPE_MISMATCH,
                        ScopeType = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.PART,
                        Scope = nameof(Asset)
                    });
                    item = null;
                    return false;
            }

            return true;
        }
    }
}
