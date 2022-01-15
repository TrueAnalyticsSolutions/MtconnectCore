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
        
        /// <summary>
        /// Translates a raw string into its enum-safe equivelant.
        /// </summary>
        /// <param name="value">Raw string value</param>
        /// <returns>Enum name safe equivelant of the provided value.</returns>
        internal static string Enumify(string value)
        {
            if (value == null) return value;
            if (value.Contains("/")) value = value.Replace("/", "_PER_");
            if (value.Contains("^2")) value = value.Replace("^2", "_SQUARED_");

            if (value.EndsWith('_')) value = value.Substring(0, value.Length - 1);
            if (value.StartsWith('_')) value = value.Substring(1, value.Length - 1);

            return value.ToUpper();
        }

        internal static bool Contains(Type enumType, string value, out object enumValue)
        {
            if (value.ToUpper().Equals(value))
            {
                value = Enumify(value);
            }
            else
            {
                value = Enumify(value.FromCamelCase());
            }

            string[] enumValues = Enum.GetNames(enumType);
            string foundEnum = enumValues.FirstOrDefault(o => o.Equals(value, StringComparison.OrdinalIgnoreCase));
            return Enum.TryParse(enumType, foundEnum, out enumValue);
        }

        internal static bool Contains(Type enumType, string value) => Contains(enumType, value, out _);
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
            string[] words = System.Text.RegularExpressions.Regex.Matches(input, "(^[A-Z]+|[a-z]+(?![A-Z])|[a-z][A-Z]+)")
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
            if (!value.ToUpper().Equals(value))
            {
                value = value.FromCamelCase();
            }

            if (!ValidateToVersion(enumType, documentVersion)) return false;
            if (!Contains(enumType, value, out object enumValue)) return false;

            if (enumValue == null) return false;

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
