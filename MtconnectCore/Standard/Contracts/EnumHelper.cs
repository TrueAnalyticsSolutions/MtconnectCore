using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
        
        internal static bool Contains(Type enumType, string value)
        {
            if (value.Contains("/")) value = value.Replace("/", "_PER_");
            if (value.Contains("^2")) value = value.Replace("^2", "_SQUARED_");

            string[] enumValues = Enum.GetNames(enumType);
            return enumValues.Any(o => o.Equals(value, StringComparison.OrdinalIgnoreCase));
        }
        internal static bool Contains(this Enum enumValue, string value) => Contains(enumValue.GetType(), value);
        /// <summary>
        /// Compares the provided <paramref name="value"/> against the enum values.
        /// </summary>
        /// <typeparam name="TEnum">Reference to an enum to compare against.</typeparam>
        /// <param name="value">Value to compare against the enum.</param>
        /// <returns>Flag for whether or not the <paramref name="value"/> was found in the enum.</returns>
        internal static bool Contains<TEnum>(string value) => Contains(typeof(TEnum), value);

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

        internal static string FromCamelCase(this string input, char delimiter = '_')
        {
            string[] words = System.Text.RegularExpressions.Regex.Matches(input, "(^[a-z]+|[A-Z]+(?![a-z])|[A-Z][a-z]+)")
                .OfType<System.Text.RegularExpressions.Match>()
                .Select(m => m.Value)
                .ToArray();
            return string.Join(delimiter, words);
        }

        internal static string FromPascalCase(this string input, char delimiter = '_')
        {
            string[] words = System.Text.RegularExpressions.Regex.Matches(input, "(^[a-z]+|[A-Z]+(?![a-z])|[A-Z][a-z]+)")
                .OfType<System.Text.RegularExpressions.Match>()
                .Select(m => m.Value)
                .ToArray();
            return string.Join(delimiter, words);
        }

        internal static string WordToPascalCase(string input) => input.Length > 1 ? input.Substring(0, 1).ToUpper() + input.Substring(1).ToLower() : input.ToUpper();

        internal static bool ValidateToVersion<TEnum>(string value, MtconnectVersions documentVersion) => ValidateToVersion(typeof(TEnum), value, documentVersion);
        internal static bool ValidateToVersion<TEnum>(MtconnectVersions documentVersion) => ValidateToVersion(typeof(TEnum), documentVersion);

        internal static bool ValidateToVersion(Type enumType, string value, MtconnectVersions documentVersion)
        {
            if (!ValidateToVersion(enumType, documentVersion)) return false;
            if (!Contains(enumType, value)) return false;

            if (!Enum.TryParse(enumType, value, out object? enumValue) || enumValue == null) return false;

            MemberInfo[] valueInfos = enumType.GetMember(enumValue.ToString());
            var valueInfo = valueInfos.FirstOrDefault(o => o.DeclaringType == enumType);
            var typedEnumValueVersions = valueInfo.GetCustomAttributes<MtconnectVersionApplicabilityAttribute>();
            if (typedEnumValueVersions?.Any() == true)
            {
                if (!typedEnumValueVersions.Any(o => o.Compare(documentVersion)))
                {
                    return false;
                }
            }

            return true;
        }

        internal static bool ValidateToVersion(Type enumType, MtconnectVersions documentVersion) {
            var enumVersionAttributes = enumType.GetCustomAttributes(typeof(MtconnectVersionApplicabilityAttribute), true);

            // Validate the enum itself
            if (enumVersionAttributes?.Length > 0) {
                var typedEnumVersions = (MtconnectVersionApplicabilityAttribute[])enumVersionAttributes;
                if (!typedEnumVersions.Any(o => o.Compare(documentVersion))) {
                    return false;
                }
            }

            return true;
        }
    }
}
