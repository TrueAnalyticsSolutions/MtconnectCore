﻿using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.ExceptionsReport;
using System;
using System.Xml;

namespace MtconnectCore.Standard.Contracts.Errors
{
    /// <summary>
    /// An exception that represents any validation error on XML nodes within a MTConnect Response Document.
    /// </summary>
    public class MtconnectValidationException : Exception
    {
        /// <inheritdoc cref="ValidationSeverity"/>
        public ValidationSeverity Severity { get; set; }

        /// <inheritdoc cref="ExceptionCodeEnum"/>
        public ExceptionCodeEnum Code { get; set; }

        /// <inheritdoc cref="ExceptionContextEnum"/>
        public ExceptionContextEnum ScopeType { get; set; }

        /// <summary>
        /// Optional reference to the scope for the context. For example, consider <see cref="ScopeType"/> == VALUE_PROPERTY, then this could be <c>category</c> for a <c>DataItem</c>.
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// Initializes a MTConnect validation exception with a specific severity and message.
        /// </summary>
        /// <param name="severity">Sets the severity level of the error.</param>
        /// <param name="message">Sets the message of the validation error.</param>
        public MtconnectValidationException(ValidationSeverity severity, string message) : base(message)
        {
            Severity = severity;
        }

        public MtconnectValidationException(ValidationSeverity severity, string message, XmlNode sourceNode) : this(severity, message)
        {
            this.Source = GetXPathToNode(sourceNode);
        }

        /// <summary>
        /// Gets the X-Path to a given Node
        /// </summary>
        /// <param name="node">The Node to get the X-Path from</param>
        /// <returns>The X-Path of the Node</returns>
        private static string GetXPathToNode(XmlNode node)
        {
            if (node.NodeType == XmlNodeType.Attribute)
            {
                // attributes have an OwnerElement, not a ParentNode; also they have             
                // to be matched by name, not found by position             
                return String.Format("{0}/@{1}", GetXPathToNode(((XmlAttribute)node).OwnerElement), node.Name);
            }
            if (node.ParentNode == null)
            {
                // the only node with no parent is the root node, which has no path
                return "";
            }

            // Get the Index
            int indexInParent = 1;
            XmlNode siblingNode = node.PreviousSibling;
            // Loop thru all Siblings
            while (siblingNode != null)
            {
                // Increase the Index if the Sibling has the same Name
                if (siblingNode.Name == node.Name)
                {
                    indexInParent++;
                }
                siblingNode = siblingNode.PreviousSibling;
            }

            // the path to a node is the path to its parent, plus "/node()[n]", where n is its position among its siblings.         
            return String.Format("{0}/m:{1}[{2}]", GetXPathToNode(node.ParentNode), node.Name, indexInParent);
        }
    }
}
