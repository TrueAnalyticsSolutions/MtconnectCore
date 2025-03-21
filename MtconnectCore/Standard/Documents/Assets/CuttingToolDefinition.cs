﻿using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Assets.Attributes;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Assets
{
    /// <inheritdoc />
    public class CuttingToolDefinition : MtconnectNode
    {
        /// <inheritdoc cref="CuttingToolDefinitionAttributes.FORMAT"/>
        [MtconnectNodeAttribute(CuttingToolDefinitionAttributes.FORMAT)]
        public string Format { get; set; }

        /// <summary>
        /// The content of the description can be text or XML elements. This is the outer XML of the XML element.
        /// </summary>
        public string Content { get; set; }

        /// <inheritdoc/>
        public CuttingToolDefinition() : base() { }

        /// <inheritdoc/>
        public CuttingToolDefinition(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version)
        {
            Content = xNode.OuterXml;
        }
    }
}
