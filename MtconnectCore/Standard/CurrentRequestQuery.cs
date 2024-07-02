using MtconnectCore.Standard.Contracts.Enums.RequestParameters;
using System;
using System.Collections.Generic;

namespace MtconnectCore.Standard
{
    public class CurrentRequestQuery : IRequestQuery
    {
        /// <inheritdoc cref="CurrentParameters.DEVICE"/>
        public string Device { get; set; }

        /// <inheritdoc cref="CurrentParameters.PATH"/>
        public string Path { get; set; }

        /// <inheritdoc cref="CurrentParameters.AT"/>
        public ulong? At { get; set; }

        /// <inheritdoc cref="CurrentParameters.INTERVAL"/>
        public int? Interval { get; set; }

        /// <inheritdoc cref="CurrentParameters.DEVICE_TYPE"/>
        public string DeviceType { get; set; }

        public CurrentRequestQuery() { }

        /// <inheritdoc/>
        public override string ToString()
        {
            List<string> parameters = new List<string>();
            
            if (!string.IsNullOrEmpty(Path)) parameters.Add($"path={Path}");

            if (At != null) parameters.Add($"at={At}");

            if (Interval != null) parameters.Add($"interval={Interval}");

            if (!string.IsNullOrEmpty(DeviceType)) parameters.Add($"deviceType={DeviceType}");

            if (parameters.Count == 0) {
                return string.Empty;
            }

            return string.Join("&", parameters.ToArray());
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
