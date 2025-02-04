using MtconnectCore.Standard.Contracts.Enums.RequestParameters;
using System;
using System.Collections.Generic;

namespace MtconnectCore.Standard
{
    public class ProbeRequestQuery : IRequestQuery
    {
        /// <inheritdoc cref="ProbeParameters.DEVICE"/>
        public string Device { get; set; }

        /// <inheritdoc cref="ProbeParameters.DEVICE_TYPE"/>
        public string DeviceType { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            List<string> parameters = new List<string>();

            if (!string.IsNullOrEmpty(Device)) parameters.Add($"device={Device}");

            if (!string.IsNullOrEmpty(DeviceType)) parameters.Add($"deviceType={DeviceType}");

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

            return true;
        }
    }
}
