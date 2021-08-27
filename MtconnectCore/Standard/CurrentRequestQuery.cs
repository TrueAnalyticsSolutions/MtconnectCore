using System;
using System.Collections.Generic;
using System.Text;

namespace MtconnectCore.Standard
{
    public class CurrentRequestQuery : IRequestQuery
    {
        /// <summary>
        /// An XPath that defines specific information or a set of information to be included in an MTConnectStreams Response Document. See Part 1 Section 8.3.2.2 of MTConnect specification.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Requests that the MTConnect Response Documents MUST include the current value for all Data Entities relative to the time that a specific sequence number was recorded. See Part 1 Section 8.3.2.2 of MTConnect specification.
        /// </summary>
        public ulong? At { get; set; }

        /// <summary>
        /// The Agent MUST continuously publish Response Documents when the query parameters include interval using the value as the period between adjacent publications. See Part 1 Section 8.3.2.2 of MTConnect specification.
        /// </summary>
        public int? Interval { get; set; }

        public CurrentRequestQuery() { }

        /// <inheritdoc/>
        public override string ToString()
        {
            List<string> parameters = new List<string>();
            
            if (!string.IsNullOrEmpty(Path)) parameters.Add($"path={Path}");

            if (At != null) parameters.Add($"at={At}");

            if (Interval != null) parameters.Add($"interval={Interval}");

            if (parameters.Count == 0) {
                return string.Empty;
            }

            return string.Join('&', parameters.ToArray());
        }

        /// <inheritdoc/>
        public bool Validate(out Exception exception)
        {
            exception = null;
            // No viable validation for Path parameter

            // At
            if (At < 0) {
                exception = new ArgumentOutOfRangeException("'At' parameter must be non-negative if specified. See Part 1 Section 8.3.2.2 of MTConnect specification.");
                return false;
            }
            if (At != null && Interval != null) {
                exception = new InvalidOperationException("'At' cannot be used in conjunction with the 'Interval' parameter since this would cause an Agent to repeatedly return the same data. See Part 1 Section 8.3.2.2 of MTConnect specification.");
                return false;
            }

            // Interval
            if (Interval <= 0) {
                exception = new ArgumentOutOfRangeException("'Interval' parameter must be greater than zero. See Part 1 Section 8.3.2.2 of MTConnect specification.");
                return false;
            }

            return true;
        }
    }
}
