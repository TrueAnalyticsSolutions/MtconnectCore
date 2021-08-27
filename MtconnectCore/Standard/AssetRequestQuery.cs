using System;
using System.Collections.Generic;

namespace MtconnectCore.Standard
{
    public class AssetRequestQuery : IRequestQuery
    {
        /// <summary>
        /// Defines the type of MTConnect Asset to be returned in the MTConnectAssets Response Document. See Part 1 Section 8.3.4.2 of MTConnect specification.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// If the value of the removed parameter in the query is true, then Asset Documents for Assets that have been marked as removed from a piece of equipment will be included in the Response Document. If the value of the removed parameter in the query is false, then Asset Documents for Assets that have been marked as removed from a piece of equipment will not be included in the Response Document. See Part 1 Section 8.3.4.2 of MTConnect specification.
        /// </summary>
        public bool? Removed { get; set; }

        /// <summary>
        /// Defines the maximum number of Asset Documents to return in an MTConnectAssets Response Document. See Part 1 Section 8.3.4.2 of MTConnect specification.
        /// </summary>
        public int? Count { get; set; }

        public AssetRequestQuery() { }

        /// <inheritdoc/>
        public override string ToString()
        {
            List<string> parameters = new List<string>();

            if (!string.IsNullOrEmpty(Type)) parameters.Add($"type={Type}");

            if (Removed != null) parameters.Add($"removed={Removed}");

            if (Count != null) parameters.Add($"count={Count}");

            if (parameters.Count == 0)
            {
                return string.Empty;
            }

            return string.Join('&', parameters.ToArray());
        }

        /// <inheritdoc/>
        public bool Validate(out Exception exception)
        {
            exception = null;
            // No viable validation for Type parameter

            // No viable validation for Removed parameter

            // Count
            if (Count <= 0)
            {
                exception = new ArgumentOutOfRangeException("'Count' parameter must be greater than zero. See Part 1 Section 8.3.4.2 of MTConnect specification.");
                return false;
            }

            return true;
        }

    }
}
