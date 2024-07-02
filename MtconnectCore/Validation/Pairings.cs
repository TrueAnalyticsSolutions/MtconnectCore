using System.Collections.Generic;

namespace MtconnectCore.Validation
{
    /// <summary>
    /// Shortcut methods for creating <see cref="KeyValuePair"/> for use with params arguments
    /// </summary>
    public static class Pairings
    {
        /// <summary>
        /// Creates <see cref="KeyValuePair"/>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static KeyValuePair<string, IEnumerable<object>> Of(string key, IEnumerable<object> value)
            => new KeyValuePair<string, IEnumerable<object>>(key, value);

        /// <summary>
        /// Creates <see cref="KeyValuePair"/>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static KeyValuePair<string, object> Of(string key, object value)
            => new KeyValuePair<string, object>(key, value);
    }
}
