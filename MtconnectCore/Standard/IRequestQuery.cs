using System;

namespace MtconnectCore.Standard
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRequestQuery {
        /// <summary>
        /// Determines whether the address and query parameters are formatted according to the MTConnect standard.
        /// </summary>
        /// <param name="exception">Catches an exception</param>
        /// <returns>Flag for whether or not the query, as a whole, is formatted correctly.</returns>
        bool Validate(out Exception exception);

        /// <summary>
        /// Builds the URI for the request
        /// </summary>
        /// <returns>String representing the URI</returns>
        string ToString();
    }
}
