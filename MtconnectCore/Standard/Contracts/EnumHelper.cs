using System;
using System.Collections.Generic;
using System.Linq;

namespace MtconnectCore.Standard.Contracts
{
    internal static partial class EnumHelper
    {
        internal static string ToListString<TEnum>(string delimeter = "\r\n", string prefix = " - ", string suffix = "") where TEnum : Enum
        {
            string[] enumValues = Enum.GetNames(typeof(TEnum))
                .Select(o => $"{prefix}{o}{suffix}")
                .ToArray();
            return string.Join(delimeter, enumValues);
        }
        internal static bool Contains(this Enum enumValue, string value)
        {
            string[] enumValues = Enum.GetNames(enumValue.GetType());
            return enumValues.Any(o => o.Equals(value, StringComparison.OrdinalIgnoreCase));
        }
        /// <summary>
        /// Compares the provided <paramref name="value"/> against the enum values.
        /// </summary>
        /// <typeparam name="TEnum">Reference to an enum to compare against.</typeparam>
        /// <param name="value">Value to compare against the enum.</param>
        /// <returns>Flag for whether or not the <paramref name="value"/> was found in the enum.</returns>
        internal static bool Contains<TEnum>(string value)
        {
            string[] enumValues = Enum.GetNames(typeof(TEnum));
            return enumValues.Any(o => o.Equals(value, StringComparison.OrdinalIgnoreCase));
        }

        internal static string ToCamelCase(this Enum enumValue) => enumValue.ToString().ToCamelCase('_');
        internal static string ToPascalCase(this Enum enumValue) => enumValue.ToString().ToPascalCase('_');

        internal static string ToCamelCase(this string input, char delimiter = '_')
        {
            string[] parts = input.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 1)
            {
                return parts[0].ToLower();
            }
            else if (parts.Length > 1)
            {
                return parts[0].ToLower() + string.Join("", parts.Skip(1).Select(o => WordToPascalCase(o)).ToArray());
            }
            return string.Empty;
        }

        internal static string ToPascalCase(this string input, char delimiter = '_')
        {
            string[] parts = input.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 0)
            {
                return string.Join("", parts.Select(o => WordToPascalCase(o)).ToArray());
            }
            return string.Empty;
        }

        internal static string WordToPascalCase(string input) => input.Length > 1 ? input.Substring(0, 1).ToUpper() + input.Substring(1).ToLower() : input.ToUpper();

    }
}
