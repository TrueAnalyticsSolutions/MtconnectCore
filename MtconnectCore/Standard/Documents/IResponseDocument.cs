using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Validation;
using System.Xml;

namespace MtconnectCore.Standard.Documents
{
    /// <summary>
    /// Structural interface for a MTConnect Response Document. See Part 1 Section 6 of MTConnect specification.
    /// </summary>
    public interface IResponseDocument
    {
        /// <summary>
        /// Reference to the type of MTConnect Response Document this object represents.
        /// </summary>
        DocumentTypes Type { get; }

        /// <summary>
        /// Reference to the tag name of the root XML node.
        /// </summary>
        string DocumentElementName { get; set; }

        /// <summary>
        /// Reference to the tag name of the XML node containing the document data.
        /// </summary>
        string DataElementName { get; }

        /// <summary>
        /// Reference to the XML Namespaces used throughout the document.
        /// </summary>
        XmlNamespaceManager NamespaceManager { get; set; }

        /// <summary>
        /// Reference to the release version of MTConnect this document should be held to in validation.
        /// </summary>
        MtconnectVersions DocumentVersion { get; set; }

        /// <summary>
        /// Reference to the source MTConnect Response Document.
        /// </summary>
        XmlDocument Source { get; }

        bool TryValidate(ValidationReport report);
    }
}
