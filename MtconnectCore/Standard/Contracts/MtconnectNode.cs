using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
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
        internal XmlNode SourceNode { get; set; }

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

        public bool TryAdd<T>(XmlNode xNode, XmlNamespaceManager nsmgr, ref List<T> array, out T item) where T : MtconnectNode
        {

            item = (T)MtconnectNodeParser.ConstructItemFromXml(typeof(T), xNode, nsmgr, MtconnectVersion.GetValueOrDefault());
            if (item == null) return false;

            array.Add(item);

            if (!item.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn("[Invalid MtconnectNode] Parsing type '{MtconnectNodeType}' from XmlNode '{XnodeName}':\r\n{ValidationExceptions}", typeof(T).Name, xNode.LocalName, ExceptionHelper.ToString(validationExceptions));
            }
            if (validationExceptions.Any())
            {
                InitializationErrors.AddRange(validationExceptions);
            }
            return !validationExceptions.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        public bool TrySet<T>(XmlNode xNode, XmlNamespaceManager nsmgr, string propertyName, out T item) where T : MtconnectNode
        {
            item = (T)MtconnectNodeParser.ConstructItemFromXml(typeof(T), xNode, nsmgr, MtconnectVersion.GetValueOrDefault());
            if (item == null) return false;

            var propertyParser = MtconnectNodeParser.GetPropertyParser(this, propertyName);
            if (propertyParser == null) return false;

            propertyParser.Property.SetValue(this, item);

            if (!item.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn("[Invalid MtconnectNode] Parsing type '{MtconnectNodeType}' from XmlNode '{XnodeName}':\r\n{ValidationExceptions}", propertyParser.Type.Name, xNode.LocalName, ExceptionHelper.ToString(validationExceptions));
            }
            if (validationExceptions.Any())
            {
                InitializationErrors.AddRange(validationExceptions);
            }
            return !validationExceptions.Any(o => o.Severity == ValidationSeverity.ERROR);
        }

        /// <inheritdoc/>
        public virtual bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();// InitializationErrors.ToList();

            Type thisType = this.GetType();
            var parser = MtconnectNodeParser.GetParser(thisType);

            parser.TryValidate(this, out ICollection<MtconnectValidationException> errors);
            foreach (MtconnectValidationException error in errors)
            {
                validationErrors.Add(error);
            }

            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
