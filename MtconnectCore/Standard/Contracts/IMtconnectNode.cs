using MtconnectCore.Validation;
using System.Xml;
using System;

namespace MtconnectCore.Standard.Contracts
{
    /// <summary>
    /// An interface that represents a single MTConnect Response Document XML element.
    /// </summary>
    public interface IMtconnectNode
    {
        /// <summary>
        /// Validates the format of the MTConnect XML element.
        /// </summary>
        /// <returns>Flag for whether or not the MTConnect XML element is considered valid.</returns>
        bool TryValidate(ValidationReport report = null);

        /// <summary>
        /// Reference to the Source XmlNode.
        /// </summary>
        XmlNode GetSourceNode();
    }
}
