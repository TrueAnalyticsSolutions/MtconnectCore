using MtconnectCore.Standard.Contracts.Enums;
using System.Xml;

namespace MtconnectCore.Standard.Documents
{
    public interface IMtconnectDocument
    {
        DocumentTypes Type { get; }

        string DocumentElementName { get; set; }

        string DataElementName { get; }

        XmlNamespaceManager NamespaceManager { get; set; }

        MtconnectVersions DocumentVersion { get; set; }
    }
}
