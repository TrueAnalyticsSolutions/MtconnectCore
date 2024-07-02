using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Standard.Contracts;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Globalization;

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
            public NodeValidator IsUIntValueType(string key, string value)
            {
                if (!string.IsNullOrEmpty(value) && !uint.TryParse(value, out uint valueUint))
                {
                    AddError($"Invalid '{key}' value. It MUST be an unsigned 32-bit integer.", Pairings.Of(key, value));
                }
                return this;
            }

            public NodeValidator IsUIntWithinRange(string key, string value, uint minimum, uint maximum)
            {
                var valueTypeValidator = new NodeValidationContext(this.Context.Node);
                valueTypeValidator.Validate((o) => o.IsUIntValueType(key, value));
                if (valueTypeValidator.HasError())
                {
                    foreach (var exception in valueTypeValidator.Exceptions)
                        Context.Exceptions.Add(exception);
                    return this;
                }

                if (!string.IsNullOrEmpty(value) && !uint.TryParse(value, out uint valueUint))
                {
                    if (valueUint < minimum || valueUint > maximum)
                    {
                        AddError($"Value must be represented as an unsigned 32-bit integer from {minimum} to {maximum}", Pairings.Of(key, value), Pairings.Of("minimum", minimum), Pairings.Of("maximum", maximum));
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
            public NodeValidator IsULongValueType(string key, string value)
            {
                if (!string.IsNullOrEmpty(value) && !ulong.TryParse(value, out ulong valueUlong))
                {
                    AddError($"Invalid '{key}' value. It MUST be an unsigned 64-bit integer.", Pairings.Of(key, value));
                }
                return this;
            }


            public NodeValidator IsULongWithinRange(string key, string value, ulong minimum, ulong maximum)
            {
                var valueTypeValidator = new NodeValidationContext(this.Context.Node);
                valueTypeValidator.Validate((o) => o.IsUIntValueType(key, value));
                if (valueTypeValidator.HasError())
                {
                    foreach (var exception in valueTypeValidator.Exceptions)
                        Context.Exceptions.Add(exception);
                    return this;
                }

                if (!string.IsNullOrEmpty(value) && !ulong.TryParse(value, out ulong valueUlong))
                {
                    if (valueUlong < minimum || valueUlong > maximum)
                    {
                        AddError($"Value must be represented as an unsigned 64-bit integer from {minimum} to {maximum}", Pairings.Of(key, value), Pairings.Of("minimum", minimum), Pairings.Of("maximum", maximum));
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
            public NodeValidator IsFloatValueType(string key, string value)
            {
                if (!string.IsNullOrEmpty(value) && !float.TryParse(value, out float valueFloat))
                {
                    AddError($"Invalid '{key}' value. It MUST be a float.", Pairings.Of(key, value));
                }
                return this;
            }

            /// <summary>
            /// Validates boolean value types.
            /// </summary>
            /// <param name="key">Value key</param>
            /// <param name="value">Value of key</param>
            /// <returns>Fluent validation context</returns>
            public NodeValidator IsBooleanValueType(string key, string value)
            {
                if (!string.IsNullOrEmpty(value) && !bool.TryParse(value, out bool valueBool))
                {
                    AddError($"Invalid '{key}' value. It MUST be a boolean.", Pairings.Of(key, value));
                }
                return this;
            }

            /// <summary>
            /// Validates boolean value types.
            /// </summary>
            /// <param name="key">Value key</param>
            /// <param name="value">Value of key</param>
            /// <returns>Fluent validation context</returns>
            public NodeValidator IsDateTimeValueType(string key, string value)
            {
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
            public NodeValidator IsEnumValueType<T>(string key, string value) where T : Enum
            {
                if (!string.IsNullOrEmpty(value) && !EnumHelper.Contains<T>(value))
                {
                    AddError($"Invalid '{key}' value '{value}'.", Pairings.Of(key, value));
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
