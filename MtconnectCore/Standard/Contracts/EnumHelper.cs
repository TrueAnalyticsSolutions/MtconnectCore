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

            if (value.EndsWith("_")) value = value.Substring(0, value.Length - 1);
            if (value.StartsWith("_")) value = value.Substring(1, value.Length - 1);

            return value.ToUpper();
        }

        internal static bool Contains(Type enumType, string value, out object enumValue)
        {
            enumValue = null;
            
            if (string.IsNullOrEmpty(value)) return false;

            if (value.ToUpper().Equals(value) == true)
            {
                value = Enumify(value);
            }
            else
            {
                if (char.IsUpper(value[0]))
                {
                    value = Enumify(value.FromPascalCase());
                } else
                {
                    value = Enumify(value.FromCamelCase());
                }
            }

            string[] enumValues = Enum.GetNames(enumType);
            string foundEnum = enumValues.FirstOrDefault(o => o.Equals(value, StringComparison.OrdinalIgnoreCase));
            if (foundEnum == null) return false;
            enumValue = Enum.Parse(enumType, foundEnum);
            return enumValue != null;
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
                return string.Join(string.Empty, parts.Select(o => WordToPascalCase(o)).ToArray());
            }
            return string.Empty;
        }

        internal static string FromCamelCase(this string input, char delimiter = '_')
        {
            //return string.Concat(input.Select((x, i) => i > 0 && char.IsUpper(x) ? delimiter + x.ToString() : x.ToString())).ToUpper();
            string[] words = System.Text.RegularExpressions.Regex.Matches(input, "(^[a-z]+|[A-Z]+(?![a-z])|[A-Z][a-z]+)")
                .OfType<System.Text.RegularExpressions.Match>()
                .Select(m => m.Value)
                .ToArray();
            return string.Join(delimiter.ToString(), words);
        }

        internal static string FromPascalCase(this string input, char delimiter = '_')
        {
            return string.Concat(input.Select((x, i) => i > 0 && char.IsUpper(x) && !char.IsUpper(input[i - 1]) ? delimiter + x.ToString() : x.ToString())).ToUpper();
            string[] words = System.Text.RegularExpressions.Regex.Matches(input, "(^[A-Z]+|[a-z]+(?![A-Z])|[a-z][A-Z]+)")
                .OfType<System.Text.RegularExpressions.Match>()
                .Select(m => m.Value)
                .ToArray();
            return string.Join(delimiter.ToString(), words);
        }

        internal static string WordToPascalCase(string input) => input.Length > 1 ? input.Substring(0, 1).ToUpper() + input.Substring(1).ToLower() : input.ToUpper();

        internal static bool IsImplemented<TEnum>(string value, MtconnectVersions documentVersion)
            => CompareToVersion(typeof(TEnum), value, documentVersion) == VersionComparisonTypes.Implemented;
        internal static bool IsImplemented<TEnum>(MtconnectVersions documentVersion)
            => CompareToVersion(typeof(TEnum), documentVersion) == VersionComparisonTypes.Implemented;
        internal static bool IsImplemented(Type enumType, string value, MtconnectVersions documentVersion)
            => CompareToVersion(enumType, value, documentVersion) == VersionComparisonTypes.Implemented;

        internal static VersionComparisonTypes? CompareToVersion<TEnum>(string value, MtconnectVersions documentVersion) => CompareToVersion(typeof(TEnum), value, documentVersion);
        internal static VersionComparisonTypes? CompareToVersion<TEnum>(MtconnectVersions documentVersion) => CompareToVersion(typeof(TEnum), documentVersion);

        internal static VersionComparisonTypes? CompareToVersion(Type enumType, string value, MtconnectVersions documentVersion)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            if (!value.ToUpper().Equals(value))
            {
                if (char.IsUpper(value[0]))
                {
                    value = value.FromPascalCase();
                } else
                {
                    value = value.FromCamelCase();
                }
            }

            var enumValidation = CompareToVersion(enumType, documentVersion);
            if (enumValidation != VersionComparisonTypes.Implemented)
                return enumValidation;
            if (!Contains(enumType, value, out object enumValue))
                return null;

            if (enumValue == null)
                return null;

            MemberInfo[] valueInfos = enumType.GetMember(enumValue.ToString());
            var valueInfo = valueInfos.FirstOrDefault(o => o.DeclaringType == enumType);
            var typedEnumValueVersion = valueInfo.GetCustomAttribute<MtconnectVersionApplicabilityAttribute>();
            if (typedEnumValueVersion != null)
            {
                return typedEnumValueVersion.Compare(documentVersion);
            }

            return VersionComparisonTypes.Implemented;
        }

        internal static VersionComparisonTypes? CompareToVersion(Type enumType, MtconnectVersions documentVersion) {
            var enumVersionAttribute = enumType.GetCustomAttribute<MtconnectVersionApplicabilityAttribute>(true);

            // Validate the enum itself
            if (enumVersionAttribute != null) {
                return enumVersionAttribute.Compare(documentVersion);
            }

            return VersionComparisonTypes.Implemented;
        }
    }
}
