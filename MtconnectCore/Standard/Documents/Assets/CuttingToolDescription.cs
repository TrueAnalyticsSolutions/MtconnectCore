using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Enums;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Assets
{
    /// <summary>
    /// An element that can contain any descriptive content.
    /// </summary>
    /// <remarks>See Part 4 Section 6.1.3 of the MTConnect specification</remarks>
    public class CuttingToolDescription : MtconnectNode
    {
        /// <summary>
        /// The content of the description can be text or XML elements. This is the inner text of the XML element.
        /// </summary>
        public string Content { get; set; }

        /// <inheritdoc/>
        public CuttingToolDescription() : base() { }

        /// <inheritdoc/>
        public CuttingToolDescription(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version)
        {
            Content = xNode.Value;
        }
    }
}
