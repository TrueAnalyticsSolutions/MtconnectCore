using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Xml;

namespace MtconnectCore.Standard.Documents
{
    /// <summary>
    /// Structural interface for a MTConnect Response Document. See Part 1 Section 6 of MTConnect specification.
    /// </summary>
    public interface IResponseDocument
    {
        DocumentTypes Type { get; }

        string DocumentElementName { get; set; }

        string DataElementName { get; }

        XmlNamespaceManager NamespaceManager { get; set; }

        MtconnectVersions DocumentVersion { get; set; }

        bool TryValidate(out ICollection<MtconnectValidationException> validationErrors);
    }
}
