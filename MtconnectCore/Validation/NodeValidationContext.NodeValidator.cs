using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Standard.Contracts;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using MtconnectCore.Standard.Contracts.Enums.ExceptionsReport;

namespace MtconnectCore.Validation
{
    public partial class NodeValidationContext
    {
        public class NodeValidator
        {
            internal NodeValidationContext Context { get; private set; }

            protected virtual string HelpLink { get; set; }

            internal NodeValidator(NodeValidationContext context)
            {
                Context = context;
            }

            internal NodeValidator(NodeValidationContext context, string helpLink) : this(context)
            {
                HelpLink = helpLink;
            }

            private MtconnectValidationException addException(ValidationSeverity severity, string message, params KeyValuePair<string, object>[] additionalData)
            {
                var exception = new MtconnectValidationException(severity, message, Context.Node.SourceNode);
                if (additionalData != null && additionalData.Any())
                {
                    foreach (var data in additionalData)
                    {
                        exception.Data.Add(data.Key, data.Value);
                    }
                }
                if (!string.IsNullOrEmpty(HelpLink))
                {
                    exception.HelpLink = HelpLink;
                }
                Context.Exceptions.Add(exception);

                return exception;
            }

            public MtconnectValidationException AddFatal(string message, params KeyValuePair<string, object>[] additionalData)
                => addException(ValidationSeverity.FATAL, message, additionalData);

            public MtconnectValidationException AddError(string message, params KeyValuePair<string, object>[] additionalData)
                => addException(ValidationSeverity.ERROR, message, additionalData);
            public MtconnectValidationException AddWarning(string message, params KeyValuePair<string, object>[] additionalData)
                => addException(ValidationSeverity.WARNING, message, additionalData);
            public MtconnectValidationException AddMessage(string message, params KeyValuePair<string, object>[] additionalData)
                => addException(ValidationSeverity.INFO, message, additionalData);

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
                    var exception = AddError($"Missing '{key}' value.", Pairings.Of(key, value));
                    exception.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.NOT_FOUND;
                    exception.Scope = key;
                    exception.ScopeType = ExceptionContextEnum.VALUE_PROPERTY;

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
                    var exception = AddError($"The {key} value must not exceed {maxLength} characters.", Pairings.Of(key, value), Pairings.Of($"{key}.Length", value?.Length ?? 0));
                    exception.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.INVALID_FORMAT;
                    exception.Scope = key;
                    exception.ScopeType = ExceptionContextEnum.VALUE_PROPERTY;
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
                    var exception = AddError($"The {key} value must not exceed {maxLength} items.", Pairings.Of(key, value), Pairings.Of($"{key}.Length", value?.Length ?? 0));
                    exception.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.INVALID_FORMAT;
                    exception.Scope = key;
                    exception.ScopeType = ExceptionContextEnum.VALUE_PROPERTY;
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
                        var exception = AddError($"Invalid '{key}' value. It MUST be an unsigned 32-bit integer.", Pairings.Of(key, value));
                        exception.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.INVALID_FORMAT;
                        exception.Scope = key;
                        exception.ScopeType = ExceptionContextEnum.VALUE_PROPERTY;
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
                        var exception = AddError($"Invalid '{key}' value. It MUST be an unsigned 32-bit integer.", Pairings.Of(key, value));
                        exception.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.INVALID_FORMAT;
                        exception.Scope = key;
                        exception.ScopeType = ExceptionContextEnum.VALUE_PROPERTY;
                    } else
                    {
                        if (output < minimum || output > maximum)
                        {
                            var exception = AddError($"Value must be represented as an unsigned 32-bit integer from {minimum} to {maximum}", Pairings.Of(key, value), Pairings.Of("minimum", minimum), Pairings.Of("maximum", maximum));
                            exception.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.INVALID_FORMAT;
                            exception.Scope = key;
                            exception.ScopeType = ExceptionContextEnum.VALUE_PROPERTY;
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
                        var exception = AddError($"Invalid '{key}' value. It MUST be an unsigned 64-bit integer.", Pairings.Of(key, value));
                        exception.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.INVALID_FORMAT;
                        exception.Scope = key;
                        exception.ScopeType = ExceptionContextEnum.VALUE_PROPERTY;
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
                        var exception = AddError($"Invalid '{key}' value. It MUST be an unsigned 64-bit integer.", Pairings.Of(key, value));
                        exception.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.INVALID_FORMAT;
                        exception.Scope = key;
                        exception.ScopeType = ExceptionContextEnum.VALUE_PROPERTY;
                    } else
                    {
                        if (output < minimum || output > maximum)
                        {
                            var exception = AddError($"Value must be represented as an unsigned 64-bit integer from {minimum} to {maximum}", Pairings.Of(key, value), Pairings.Of("minimum", minimum), Pairings.Of("maximum", maximum));
                            exception.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.INVALID_FORMAT;
                            exception.Scope = key;
                            exception.ScopeType = ExceptionContextEnum.VALUE_PROPERTY;
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
                        var exception = AddError($"Invalid '{key}' value. It MUST be a float.", Pairings.Of(key, value));
                        exception.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.INVALID_FORMAT;
                        exception.Scope = key;
                        exception.ScopeType = ExceptionContextEnum.VALUE_PROPERTY;
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
                        var exception = AddError($"Invalid '{key}' value. It MUST be three space-delimited floating-point numbers.", Pairings.Of(key, value));
                        exception.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.INVALID_FORMAT;
                        exception.Scope = key;
                        exception.ScopeType = ExceptionContextEnum.VALUE_PROPERTY;
                    } else
                    {
                        output = values.Select(o => float.TryParse(o, out float floatValue) ? floatValue : default(float?)).ToArray();
                        if (output.Count(o => o != null) != values.Length)
                        {
                            var exception = AddError($"Invalid '{key}' value. It MUST be three space-delimited floating-point numbers.", Pairings.Of(key, value));
                            exception.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.INVALID_FORMAT;
                            exception.Scope = key;
                            exception.ScopeType = ExceptionContextEnum.VALUE_PROPERTY;
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
                        var exception = AddError($"Invalid '{key}' value. It MUST be space-delimited floating-point numbers.", Pairings.Of(key, value));
                        exception.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.INVALID_FORMAT;
                        exception.Scope = key;
                        exception.ScopeType = ExceptionContextEnum.VALUE_PROPERTY;
                    }
                    else
                    {
                        output = values.Select(o => float.TryParse(o, out float floatValue) ? floatValue : default(float?)).ToArray();
                        if (output.Count(o => o != null) != values.Length)
                        {
                            var exception = AddError($"Invalid '{key}' value. It MUST be space-delimited floating-point numbers.", Pairings.Of(key, value));
                            exception.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.INVALID_FORMAT;
                            exception.Scope = key;
                            exception.ScopeType = ExceptionContextEnum.VALUE_PROPERTY;
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
                        var exception = AddError($"Values must be represented as an unsigned 32-bit integer from {minimum} to {maximum}", Pairings.Of($"{key}.length", value?.Length), Pairings.Of("minimum", minimum), Pairings.Of("maximum", maximum));
                        exception.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.INVALID_FORMAT;
                        exception.Scope = key;
                        exception.ScopeType = ExceptionContextEnum.VALUE_PROPERTY;
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
                        var exception = AddError($"Invalid '{key}' value. It MUST be a boolean.", Pairings.Of(key, value));
                        exception.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.INVALID_FORMAT;
                        exception.Scope = key;
                        exception.ScopeType = ExceptionContextEnum.VALUE_PROPERTY;
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
                            var exception = AddError($"Invalid '{key}' value, invalid Date format.", Pairings.Of(key, value));
                            exception.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.INVALID_FORMAT;
                            exception.Scope = key;
                            exception.ScopeType = ExceptionContextEnum.VALUE_PROPERTY;
                            //Console.WriteLine($"The string '{dateString}' is NOT a valid date in the expected format.");
                        } else
                        {
                            output = parsedDate;
                        }
                    }
                    else
                    {
                        var exception = AddError($"Invalid '{key}' value, unexpected format.", Pairings.Of(key, value));
                        exception.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.INVALID_FORMAT;
                        exception.Scope = key;
                        exception.ScopeType = ExceptionContextEnum.VALUE_PROPERTY;
                        //Console.WriteLine($"The string '{dateString}' does not match the expected format.");
                    }
                }
                else
                {
                    var exception = AddError($"Invalid '{key}' value, unexpected format.", Pairings.Of(key, value));
                    exception.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.INVALID_FORMAT;
                    exception.Scope = key;
                    exception.ScopeType = ExceptionContextEnum.VALUE_PROPERTY;
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
                        var exception = AddError($"Invalid '{key}' value.", Pairings.Of(key, value));
                        exception.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.INVALID_FORMAT;
                        exception.Scope = key;
                        exception.ScopeType = ExceptionContextEnum.VALUE_PROPERTY;
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
                        var exception = AddError($"Invalid '{key}' value.", Pairings.Of(key, value));
                        exception.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.INVALID_FORMAT;
                        exception.Scope = key;
                        exception.ScopeType = ExceptionContextEnum.VALUE_PROPERTY;
                    }
                }

                return this;
            }

            /// <summary>
            /// Tests whether or not the <paramref name="values"/> length falls within the range of <paramref name="minimumCount"/> and <paramref name="maximumCount"/>.
            /// </summary>
            /// <typeparam name="T"><paramref name="values"/> collection generic type</typeparam>
            /// <param name="key">VALUE_PROPERTY name</param>
            /// <param name="values">Collection to test</param>
            /// <param name="minimumCount">Range minimum</param>
            /// <param name="maximumCount">Range maximum</param>
            /// <returns>Fluent validation context</returns>
            public NodeValidator HasMultiplicity<T>(string key, IEnumerable<T> values, int minimumCount, int maximumCount)
            {
                var count = values.Count();
                if (count < minimumCount)
                {
                    var exception = AddError($"There must be at least {minimumCount} '{key}'.", Pairings.Of(key, values), Pairings.Of($"{key}.Count", count));
                    exception.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.INVALID_FORMAT;
                    exception.Scope = key;
                    exception.ScopeType = ExceptionContextEnum.PART;
                } else if (count > maximumCount)
                {
                    var exception = AddError($"There must be no more than {maximumCount} '{key}'.", Pairings.Of(key, values), Pairings.Of($"{key}.Count", count));
                    exception.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.INVALID_FORMAT;
                    exception.Scope = key;
                    exception.ScopeType = ExceptionContextEnum.PART;
                }
                return this;
            }

            /// <summary>
            /// Tests whether or not the collections contains any items.
            /// </summary>
            /// <param name="collections">Key value pair where the key is a VALUE_PROPERTY name and the value is the collection associated with the property.</param>
            /// <returns>Fluent validation context</returns>
            public NodeValidator HasAtLeastOne(params KeyValuePair<string, IEnumerable<object>>[] collections)
            {
                if (!collections.Any())
                    return this;

                foreach (var collection in collections)
                {
                    if (collection.Value != null && collection.Value.Any())
                        return this;
                }
                var exception = AddError("Must contain at least one of '" + string.Join("' or '", collections.Select(o => o.Key)) + "'.");
                exception.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.INVALID_FORMAT;
                exception.Scope = string.Join(", ", collections.Select(o => o.ToString()));
                exception.ScopeType = ExceptionContextEnum.PART;

                return this;
            }

            /// <summary>
            /// Performs an <paramref name="action"/> based on the condition of the <paramref name="predicate"/>
            /// </summary>
            /// <param name="predicate">Expression that determines whether or not to execute the <paramref name="action"/></param>
            /// <param name="action">Function that is called if the <paramref name="predicate"/> returns <c>true</c></param>
            /// <returns>Fluent validation context</returns>
            public NodeValidator If(Func<NodeValidator, bool> predicate, Func<NodeValidator, NodeValidator> action)
            {
                if (predicate(this))
                    return action(this);
                return this;
            }
        }
    }
}
