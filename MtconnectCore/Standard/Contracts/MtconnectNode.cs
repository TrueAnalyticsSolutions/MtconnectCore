using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System;
using System.Collections.Generic;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Contracts
{
    /// <summary>
    /// Represents the most basic form of a MTConnect Response Document XML node. Used for parsing a MTConnect Response Document.
    /// </summary>
    public abstract class MtconnectNode : IMtconnectNode
    {
        /// <summary>
        /// Reference to the Source XmlNode.
        /// </summary>
        [NonSerialized]
        public XmlNode SourceNode;

        /// <summary>
        /// Reference to the version of the MTConnect Standard implemented on the MTConnect Response Document.
        /// </summary>
        internal MtconnectVersions? MtconnectVersion { get; set; }

        /// <summary>
        /// A collection of Validation exceptions that are raised during initialization of a MTConnect node.
        /// </summary>
        internal List<MtconnectValidationException> InitializationErrors { get; set; } = new List<MtconnectValidationException>();

        /// <summary>
        /// Initializes a blank <see cref="IMtconnectNode"/> entity.
        /// </summary>
        public MtconnectNode() { }

        /// <summary>
        /// Initializes a <see cref="IMtconnectNode"/> entity from a MTConnect Response Document.
        /// </summary>
        /// <param name="xNode">Reference to a <see cref="XmlNode"/> as part of a larger MTConnect Response Document.</param>
        /// <param name="nsmgr">Reference to the </param>
        /// <param name="defaultNamespace"></param>
        public MtconnectNode(XmlNode xNode, XmlNamespaceManager nsmgr, string defaultNamespace, MtconnectVersions version)
        {
            SourceNode = xNode;
            MtconnectVersion = version;

            MtconnectNodeParser.UpdateFromXml(this, xNode, nsmgr, defaultNamespace, version);
        }

        public XmlNode GetSourceNode() => SourceNode;

        public bool TryAdd<T>(XmlNode xNode, XmlNamespaceManager nsmgr, ref List<T> array, out T item) where T : MtconnectNode
        {

            item = (T)MtconnectNodeParser.ConstructItemFromXml(typeof(T), xNode, nsmgr, MtconnectVersion.GetValueOrDefault());
            if (item == null) return false;

            array.Add(item);

            return true;
        }

        public bool TrySet<T>(XmlNode xNode, XmlNamespaceManager nsmgr, string propertyName, out T item) where T : MtconnectNode
        {
            item = (T)MtconnectNodeParser.ConstructItemFromXml(typeof(T), xNode, nsmgr, MtconnectVersion.GetValueOrDefault());
            if (item == null) return false;

            var propertyParser = MtconnectNodeParser.GetPropertyParser(this, propertyName);
            if (propertyParser == null) return false;

            propertyParser.Property.SetValue(this, item);

            return true;
        }

        /// <inheritdoc/>
        public virtual bool TryValidate(ValidationReport report = null)
        {
            Type nodeType = this.GetType();
            var parser = MtconnectNodeParser.GetParser(nodeType);

            return parser.TryValidate(this, report);
        }
    }
}
