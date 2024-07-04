using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Standard.Contracts;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MtconnectCore.Validation
{
    public partial class NodeValidationContext
    {
        public class NodeValidator
        {
            internal NodeValidationContext Context { get; private set; }

            internal NodeValidator(NodeValidationContext context)
            {
                Context = context;
            }

            private void addException(ValidationSeverity severity, string message, params KeyValuePair<string, object>[] additionalData)
            {
                var exception = new MtconnectValidationException(severity, message, Context.Node.SourceNode);
                if (additionalData != null && additionalData.Any())
                {
                    foreach (var data in additionalData)
                    {
                        exception.Data.Add(data.Key, data.Value);
                    }
                }
                Context.Exceptions.Add(exception);
            }

            public void AddError(string message, params KeyValuePair<string, object>[] additionalData)
                => addException(ValidationSeverity.ERROR, message, additionalData);
            public void AddWarning(string message, params KeyValuePair<string, object>[] additionalData)
                => addException(ValidationSeverity.WARNING, message, additionalData);
            public void AddMessage(string message, params KeyValuePair<string, object>[] additionalData)
                => addException(ValidationSeverity.MESSAGE, message, additionalData);

            /// <summary>
            /// Validates value is not null or empty.<br/>
            /// </summary>
            /// <param name="key">Value key</param>
            /// <param name="value">Value of key</param>
            /// <returns>Fluent validation context. Returns <c>null</c> if <paramref name="value"/> is <c>null</c> or empty and <paramref name="breakIfMissing"/> is <c>true</c></returns>
            public NodeValidator IsRequired(string key, string value, bool breakIfMissing = true)
            {
                if (string.IsNullOrEmpty(value))
                {
                    AddError($"Missing '{key}' value.", Pairings.Of(key, value));
                    if (breakIfMissing)
                        return null;
                }
                return this;
            }

            /// <summary>
            /// Validates length of value.<br/>
            /// </summary>
            /// <param name="key">Value key</param>
            /// <param name="value">Value of key</param>
            /// <returns>Fluent validation context</returns>
            public NodeValidator CheckValueMaxLength(string key, string value, int maxLength = 255)
            {
                if (!string.IsNullOrEmpty(value) && value.Length > maxLength)
                {
                    AddError($"The {key} value must not exceed {maxLength} characters.", Pairings.Of(key, value), Pairings.Of($"{key}.Length", value?.Length ?? 0));
                }
                return this;
            }

            /// <summary>
            /// Validates length of value.<br/>
            /// </summary>
            /// <param name="key">Value key</param>
            /// <param name="value">Value of key</param>
            /// <returns>Fluent validation context</returns>
            public NodeValidator CheckValueMaxLength(string key, float?[] value, int maxLength = 1)
            {
                if (value != null && value.Length > maxLength)
                {
                    AddError($"The {key} value must not exceed {maxLength} items.", Pairings.Of(key, value), Pairings.Of($"{key}.Length", value?.Length ?? 0));
                }
                return this;
            }

            /// <summary>
            /// Validates <c>ID</c> value types.<br/>
            /// <list type="bullet">
            /// <item><b>Multiplicity</b>: Required</item>
            /// <item><b>Max Length</b>: 255</item>
            /// </list>
            /// </summary>
            /// <param name="key">Value key</param>
            /// <param name="value">Value of key</param>
            /// <returns>Fluent validation context</returns>
            public NodeValidator IsIdValueType(string key, string value, bool isRequired = true)
                => (isRequired
                    ? this.IsRequired(key, value)
                    : this)
                ?.CheckValueMaxLength(key, value, 255);

            /// <summary>
            /// Validates integer value types.
            /// </summary>
            /// <param name="key">Value key</param>
            /// <param name="value">Value of key</param>
            /// <returns>Fluent validation context</returns>
            public NodeValidator IsUIntValueType(string key, string value, out uint? output)
            {
                output = null;
                if (!string.IsNullOrEmpty(value))
                {
                    if (!uint.TryParse(value, out uint valueUint))
                    {
                        AddError($"Invalid '{key}' value. It MUST be an unsigned 32-bit integer.", Pairings.Of(key, value));
                    } else
                    {
                        output = valueUint;
                    }
                }
                return this;
            }

            public NodeValidator IsUIntWithinRange(string key, string value, uint minimum, uint maximum)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (!uint.TryParse(value, out uint output))
                    {
                        AddError($"Invalid '{key}' value. It MUST be an unsigned 32-bit integer.", Pairings.Of(key, value));
                    } else
                    {
                        if (output < minimum || output > maximum)
                        {
                            AddError($"Value must be represented as an unsigned 32-bit integer from {minimum} to {maximum}", Pairings.Of(key, value), Pairings.Of("minimum", minimum), Pairings.Of("maximum", maximum));
                        }
                    }
                }
                return this;
            }

            /// <summary>
            /// Validates integer value types.
            /// </summary>
            /// <param name="key">Value key</param>
            /// <param name="value">Value of key</param>
            /// <returns>Fluent validation context</returns>
            public NodeValidator IsULongValueType(string key, string value, out ulong? output)
            {
                output = null;
                if (!string.IsNullOrEmpty(value))
                {
                    if (!ulong.TryParse(value, out ulong valueUlong))
                    {
                        AddError($"Invalid '{key}' value. It MUST be an unsigned 64-bit integer.", Pairings.Of(key, value));
                    } else
                    {
                        output = valueUlong;
                    }
                }
                return this;
            }


            public NodeValidator IsULongWithinRange(string key, string value, ulong minimum, ulong maximum)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (!ulong.TryParse(value, out ulong output))
                    {
                        AddError($"Invalid '{key}' value. It MUST be an unsigned 64-bit integer.", Pairings.Of(key, value));
                    } else
                    {
                        if (output < minimum || output > maximum)
                        {
                            AddError($"Value must be represented as an unsigned 64-bit integer from {minimum} to {maximum}", Pairings.Of(key, value), Pairings.Of("minimum", minimum), Pairings.Of("maximum", maximum));
                        }
                    }
                }
                return this;
            }

            /// <summary>
            /// Validates float value types.
            /// </summary>
            /// <param name="key">Value key</param>
            /// <param name="value">Value of key</param>
            /// <returns>Fluent validation context</returns>
            public NodeValidator IsFloatValueType(string key, string value, out float? output)
            {
                output = null;
                if (!string.IsNullOrEmpty(value))
                {
                    if (!float.TryParse(value, out float floatValue))
                    {
                        AddError($"Invalid '{key}' value. It MUST be a float.", Pairings.Of(key, value));
                    } else
                    {
                        output = floatValue;
                    }
                }
                return this;
            }

            /// <summary>
            /// Validates float3d value types.
            /// </summary>
            /// <param name="key">Value key</param>
            /// <param name="value">Value of key</param>
            /// <returns>Fluent validation context</returns>
            public NodeValidator IsFloat3dValueType(string key, string value, out float?[] output)
            {
                output = null;
                if (!string.IsNullOrEmpty(value))
                {
                    string[] values = value.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    if (values.Length != 3 || values.All(o => float.TryParse(o, out _)) == false)
                    {
                        AddError($"Invalid '{key}' value. It MUST be three space-delimited floating-point numbers.", Pairings.Of(key, value));
                    } else
                    {
                        output = values.Select(o => float.TryParse(o, out float floatValue) ? floatValue : default(float?)).ToArray();
                        if (output.Count(o => o != null) != values.Length)
                        {
                            AddError($"Invalid '{key}' value. It MUST be three space-delimited floating-point numbers.", Pairings.Of(key, value));
                        }
                    }
                }
                return this;
            }

            /// <summary>
            /// Validates float array value types.
            /// </summary>
            /// <param name="key">Value key</param>
            /// <param name="value">Value of key</param>
            /// <returns>Fluent validation context</returns>
            public NodeValidator IsFloatArrayValueType(string key, string value, out float?[] output)
            {
                output = null;
                if (!string.IsNullOrEmpty(value))
                {
                    string[] values = value.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    if (values.All(o => float.TryParse(o, out _)) == false)
                    {
                        AddError($"Invalid '{key}' value. It MUST be space-delimited floating-point numbers.", Pairings.Of(key, value));
                    }
                    else
                    {
                        output = values.Select(o => float.TryParse(o, out float floatValue) ? floatValue : default(float?)).ToArray();
                        if (output.Count(o => o != null) != values.Length)
                        {
                            AddError($"Invalid '{key}' value. It MUST be space-delimited floating-point numbers.", Pairings.Of(key, value));
                        }
                    }
                }
                return this;
            }

            public NodeValidator IsFloatArrayCountWithinRange(string key, float?[] value, uint minimum, uint maximum)
            {
                if (value != null)
                {
                    if (value.Length < minimum || value.Length > maximum)
                    {
                        AddError($"Values must be represented as an unsigned 32-bit integer from {minimum} to {maximum}", Pairings.Of($"{key}.length", value?.Length), Pairings.Of("minimum", minimum), Pairings.Of("maximum", maximum));
                    }
                }
                return this;
            }


            /// <summary>
            /// Validates boolean value types.
            /// </summary>
            /// <param name="key">Value key</param>
            /// <param name="value">Value of key</param>
            /// <returns>Fluent validation context</returns>
            public NodeValidator IsBooleanValueType(string key, string value, out bool? output)
            {
                output = null;
                if (!string.IsNullOrEmpty(value))
                {
                    if (!bool.TryParse(value, out bool valueBool))
                    {
                        AddError($"Invalid '{key}' value. It MUST be a boolean.", Pairings.Of(key, value));
                    } else
                    {
                        output = valueBool;
                    }
                }
                return this;
            }

            /// <summary>
            /// Validates boolean value types.
            /// </summary>
            /// <param name="key">Value key</param>
            /// <param name="value">Value of key</param>
            /// <returns>Fluent validation context</returns>
            public NodeValidator IsDateTimeValueType(string key, string value, out DateTime? output)
            {
                output = null;
                // Split the date and time parts
                string[] dateTimeParts = value.Split('T');
                if (dateTimeParts.Length == 2)
                {
                    string datePart = dateTimeParts[0];
                    string timePart = dateTimeParts[1];

                    // Split the time part to handle fractional seconds
                    string[] timeParts = timePart.Split('.');
                    if (timeParts.Length == 1 || timeParts.Length == 2)
                    {
                        string mainTimePart = timeParts[0];
                        string fractionPart = timeParts.Length == 2 ? timeParts[1] : string.Empty;

                        // Normalize the fraction part to 7 digits (maximum for DateTime)
                        if (fractionPart.Length > 7)
                        {
                            fractionPart = fractionPart.Substring(0, 7);
                        }

                        string normalizedDateString = datePart + "T" + mainTimePart +
                            (string.IsNullOrEmpty(fractionPart) ? "" : "." + fractionPart.PadRight(7, '0'));

                        DateTime parsedDate;
                        bool isValid = DateTime.TryParseExact(
                            normalizedDateString,
                            "yyyy-MM-ddTHH:mm:ss.fffffff",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.AdjustToUniversal,
                            out parsedDate
                        );

                        if (!isValid)
                        {
                            AddError($"Invalid '{key}' value, invalid Date format.", Pairings.Of(key, value));
                            //Console.WriteLine($"The string '{dateString}' is NOT a valid date in the expected format.");
                        } else
                        {
                            output = parsedDate;
                        }
                    }
                    else
                    {
                        AddError($"Invalid '{key}' value, unexpected format.", Pairings.Of(key, value));
                        //Console.WriteLine($"The string '{dateString}' does not match the expected format.");
                    }
                }
                else
                {
                    AddError($"Invalid '{key}' value, unexpected format.", Pairings.Of(key, value));
                    //Console.WriteLine($"The string '{dateString}' does not match the expected format.");
                }
                return this;
            }

            /// <summary>
            /// Validates Enum value types.<br/>
            /// <list type="bullet">
            /// <item><b>Value Type</b>: Field of <typeparamref name="T"/></item>
            /// </list>
            /// </summary>
            /// <typeparam name="T">Reference to Enum type</typeparam>
            /// <param name="key">Value key</param>
            /// <param name="value">Value of key</param>
            /// <returns>Fluent validation context</returns>
            public NodeValidator IsEnumValueType<T>(string key, string value, out T output) where T : struct, Enum
            {
                output = default(T);
                if (!string.IsNullOrEmpty(value))
                {
                    if (!EnumHelper.TryParse(value, out T? enumValue))
                    {
                        AddError($"Invalid '{key}' value.", Pairings.Of(key, value));
                    } else
                    {
                        output = enumValue.GetValueOrDefault();
                    }
                }
                return this;
            }

            // Regular expression pattern for validating IETF RFC 4646 language tags
            private static readonly Regex Rfc4646Regex = new Regex(
                @"^[a-zA-Z]{2,8}(-[a-zA-Z0-9]{1,8})*$",
                RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
            public NodeValidator IsRfc4646LanguageTag(string key, string value)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (!Rfc4646Regex.IsMatch(value))
                    {
                        AddError($"Invalid '{key}' value.", Pairings.Of(key, value));
                    }
                }

                return this;
            }

            public NodeValidator HasMultiplicity<T>(string key, IEnumerable<T> values, int minimumCount, int maximumCount)
            {
                var count = values.Count();
                if (count < minimumCount)
                {
                    AddError($"There must be at least {minimumCount} '{key}'.", Pairings.Of(key, values), Pairings.Of($"{key}.Count", count));
                } else if (count > maximumCount)
                {
                    AddError($"There must be no more than {maximumCount} '{key}'.", Pairings.Of(key, values), Pairings.Of($"{key}.Count", count));
                }
                return this;
            }

            public NodeValidator HasAtLeastOne(params KeyValuePair<string, IEnumerable<object>>[] collections)
            {
                if (!collections.Any())
                    return this;

                foreach (var collection in collections)
                {
                    if (collection.Value != null && collection.Value.Any())
                        return this;
                }
                AddError("Must contain at least one of '" + string.Join("' or '", collections.Select(o => o.Key)) + "'.");

                return this;
            }

            public NodeValidator If(Func<NodeValidator, bool> predicate, Func<NodeValidator, NodeValidator> action)
            {
                if (predicate(this))
                    return action(this);
                return this;
            }
        }
    }
}
