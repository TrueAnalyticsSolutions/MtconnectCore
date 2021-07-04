using System;
using System.Collections.Generic;

namespace MtconnectCore.Standard
{
    public class SampleRequestQuery : RequestQuery
    {
        /// <summary>
        /// An XPath that defines specific information or a set of information to be included in an MTConnectStreams Response Document. See Part 1 Section 8.3.3.2 of MTConnect specification.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The from parameter designates the sequence number of the first observation in the buffer the Agent MUST consider publishing in the Response Document. See Part 1 Section 8.3.3.2 of MTConnect specification.
        /// </summary>
        public ulong? From { get; set; }

        /// <summary>
        /// The Agent MUST continuously publish Response Documents when the query parameters include interval using the value as the minimum period between adjacent publications. See Part 1 Section 8.3.3.2 of MTConnect specification.
        /// </summary>
        public int? Interval { get; set; }

        /// <summary>
        /// The count parameter designates the maximum number of observations the Agent MUST publish in the Response Document. See Part 1 Section 8.3.3.2 of MTConnect specification.
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// Sets the time period for the heartbeat function in an Agent. The value for heartbeat represents the amount of time after a Response Document has been published until a new Response Document MUST be published, even when no new data is available. See Part 1 Section 8.3.3.2 of MTConnect specification.
        /// </summary>
        public int? Heartbeat { get; set; }

        public SampleRequestQuery() { }

        public override string ToString()
        {
            List<string> parameters = new List<string>();

            if (!string.IsNullOrEmpty(Path)) parameters.Add($"path={Path}");

            if (From != null) parameters.Add($"from={From}");

            if (Interval != null) parameters.Add($"interval={Interval}");

            if (Count != null) parameters.Add($"count={Count}");

            if (Heartbeat != null) parameters.Add($"heartbeat={Heartbeat}");

            if (parameters.Count == 0)
            {
                return string.Empty;
            }

            return string.Join('&', parameters.ToArray());
        }

        public override bool Validate(out Exception exception)
        {
            exception = null;
            // No viable validation for Path parameter

            // From
            if (From < 0)
            {
                exception = new ArgumentOutOfRangeException("'From' parameter must be non-negative if specified. See Part 1 Section 8.3.3.2 of MTConnect specification.");
                return false;
            }

            // Interval
            if (Interval <= 0)
            {
                exception = new ArgumentOutOfRangeException("'Interval' parameter must be greater than zero. See Part 1 Section 8.3.3.2 of MTConnect specification.");
                return false;
            }

            // Count
            if (Count == 0) {
                exception = new ArgumentException("'Count' parameter cannot be zero. See Part 1 Section 8.3.3.2 of MTConnect specification.");
                return false;
            }
            if (Count < 0 && Interval != null) {
                exception = new ArgumentOutOfRangeException("'Count' parameter cannot be less than zero when 'Interval' is present. See Part 1 Section 8.3.3.2 of MTConnect specification.");
            }

            // Heartbeat
            if (Heartbeat != null && Interval == null) {
                exception = new ArgumentException("'Heartbeat' parameter can only be specified if 'Interval' is also specified. See Part 1 Section 8.3.3.2 of MTConnect specification.");
                return false;
            }

            return true;
        }
    }
}
