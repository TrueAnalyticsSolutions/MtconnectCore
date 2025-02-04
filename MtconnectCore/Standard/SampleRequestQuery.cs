using MtconnectCore.Standard.Contracts.Enums.RequestParameters;
using System;
using System.Collections.Generic;

namespace MtconnectCore.Standard
{
    public class SampleRequestQuery : IRequestQuery
    {
        /// <inheritdoc cref="SampleParameters.DEVICE"/>
        public string Device { get; set; }

        /// <inheritdoc cref="SampleParameters.PATH"/>
        public string Path { get; set; }

        /// <inheritdoc cref="SampleParameters.FROM"/>
        public ulong? From { get; set; }

        /// <inheritdoc cref="SampleParameters.COUNT"/>
        public int? Count { get; set; }

        /// <inheritdoc cref="SampleParameters.FREQUENCY"/>
        public int? Frequency { get; set; }

        /// <inheritdoc cref="SampleParameters.HEARTBEAT"/>
        public int? Heartbeat { get; set; }

        /// <inheritdoc cref="SampleParameters.INTERVAL"/>
        public int? Interval { get; set; }

        /// <inheritdoc cref="SampleParameters.TO"/>
        public ulong? To { get; set; }

        /// <inheritdoc cref="SampleParameters.DEVICE_TYPE"/>
        public string DeviceType { get; set; }

        public SampleRequestQuery() { }

        /// <inheritdoc/>
        public override string ToString()
        {
            List<string> parameters = new List<string>();

            if (!string.IsNullOrEmpty(Path)) parameters.Add($"path={Path}");

            if (From != null) parameters.Add($"from={From}");

            if (To != null) parameters.Add($"to={To}");

            if (Interval != null) parameters.Add($"interval={Interval}");

            if (Count != null) parameters.Add($"count={Count}");

            if (Frequency != null) parameters.Add($"frequency={Frequency}");

            if (Heartbeat != null) parameters.Add($"heartbeat={Heartbeat}");

            if (parameters.Count == 0)
            {
                return string.Empty;
            }

            return string.Join("&", parameters.ToArray());
        }

        /// <inheritdoc/>
        public bool Validate(out Exception exception)
        {
            exception = null;
            // No viable validation for Path parameter

            // From
            if (From != null)
            {
                if (From < 0)
                {
                    exception = new ArgumentOutOfRangeException("'From' parameter must be non-negative if specified. See Part 1 Section 8.3.3.2 of MTConnect specification.");
                    return false;
                }
            }

            if (To != null)
            {
                if (To < 0)
                {
                    exception = new ArgumentOutOfRangeException("'To' parameter must be non-negative if specified. See Part 1 Section 8.3.3.2 of MTConnect specification.");
                    return false;
                }
                if (From != null && To <= From)
                {
                    exception = new ArgumentOutOfRangeException("'To' parameter must be greater than from.");
                }
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
