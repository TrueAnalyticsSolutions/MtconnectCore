using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MtconnectCore.Validation
{
    /// <summary>
    /// Stores a collection of validation errors for a Response Document.
    /// </summary>
    public class ValidationReport
    {
        private Dictionary<MtconnectNode, ICollection<MtconnectValidationException>> _items = new Dictionary<MtconnectNode, ICollection<MtconnectValidationException>>();
        /// <summary>
        /// Collection of validation errors organized by their respective nodes.
        /// </summary>
        public IDictionary<MtconnectNode, MtconnectValidationException[]> Items => _items.ToDictionary(o => o.Key, o => o.Value.ToArray());

        public IEnumerable<MtconnectValidationException> Exceptions => Items.SelectMany(o => o.Value);

        /// <summary>
        /// Adds one or more validation exceptions in the context of a single node.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="exceptions"></param>
        public void AddExceptions(MtconnectNode node, params MtconnectValidationException[] exceptions)
        {
            if (!_items.ContainsKey(node)) _items.Add(node, new List<MtconnectValidationException>());

            if (exceptions.Length > 0)
            {
                foreach (var exception in exceptions)
                {
                    _items[node].Add(exception);
                }
            }
        }

        /// <summary>
        /// Creates a validation context to help log multiple exceptions in the context of a single node.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public ValidationContext CreateContext(MtconnectNode node)
        {
            return new ValidationContext(this, node);
        }

        /// <summary>
        /// Determines if there are any exceptions that are of the severity level ERROR.
        /// </summary>
        /// <returns>Flag if any exception has the severity level of ERROR.</returns>
        public bool HasErrors() => _items.Where(o => o.Value.Any(e => e.Severity == ValidationSeverity.ERROR)).Any();
    }
}
