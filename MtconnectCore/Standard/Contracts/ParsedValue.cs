namespace MtconnectCore.Standard.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class ParsedValue<T> : IParsedValue
    {
        private string _rawValue;
        private T _value;

        /// <inheritdoc/>
        public string RawValue {
            get => _rawValue;
            set {
                _rawValue = value;
                _value = ParseValue(value);
            }
        }

        /// <summary>
        /// Gets or sets the value successfully parsed to the expected type <typeparamref name="T"/>.
        /// </summary>
        public T Value {
            get => _value;
            set {
                _value = value;
                _rawValue = value?.ToString();
            }
        }

        /// <summary>
        /// Implicitly converts a string to a ParsedValue of the expected type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="value">The original string value.</param>
        public static implicit operator ParsedValue<T>(string value)
        {
            return new ParsedValue<T> { RawValue = value };
        }

        /// <summary>
        /// Implicitly converts a ParsedValue to the expected type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="parsedValue">The ParsedValue instance.</param>
        public static implicit operator T(ParsedValue<T> parsedValue)
        {
            return parsedValue.Value;
        }

        /// <summary>
        /// Determines if the ParsedValue is equal to null or another ParsedValue instance.
        /// </summary>
        public static bool operator ==(ParsedValue<T> left, ParsedValue<T> right)
        {
            if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
                return true;

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;

            return EqualityComparer<T>.Default.Equals(left.Value, right.Value);
        }

        /// <summary>
        /// Determines if the ParsedValue is not equal to null or another ParsedValue instance.
        /// </summary>
        public static bool operator !=(ParsedValue<T> left, ParsedValue<T> right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines if the ParsedValue is equal to a value.
        /// </summary>
        public static bool operator ==(ParsedValue<T> left, T right)
        {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null);

            return EqualityComparer<T>.Default.Equals(left.Value, right);
        }

        /// <summary>
        /// Determines if the ParsedValue is not equal to a value.
        /// </summary>
        public static bool operator !=(ParsedValue<T> left, T right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Returns true if the ParsedValue contains a non-null value.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is ParsedValue<T> other)
            {
                return this == other;
            }

            if (obj is T value)
            {
                return EqualityComparer<T>.Default.Equals(Value, value);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (Value != null ? Value.GetHashCode() : 0);
        }

        /// <summary>
        /// Returns the string representation of the value, preferring the successfully parsed value if available.
        /// </summary>
        /// <returns>The string representation of the value.</returns>
        public override string ToString() => Value?.ToString() ?? RawValue;

        /// <summary>
        /// Parses the string value to the expected type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="value">The string value to parse.</param>
        /// <returns>The parsed value of type <typeparamref name="T"/>.</returns>
        private T ParseValue(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                {
                    return default;
                }

                Type targetType = typeof(T);

                // Handle nullable types
                bool isNullable = Nullable.GetUnderlyingType(targetType) != null;
                if (isNullable)
                {
                    targetType = Nullable.GetUnderlyingType(targetType);
                }

                // Handle enums using EnumHelper
                if (targetType.IsEnum)
                {
                    if (EnumHelper.TryParse(targetType, value, out object enumValue))
                    {
                        return (T)enumValue;
                    }
                    else
                    {
                        //throw new InvalidCastException($"Cannot convert '{value}' to {targetType.Name}.");
                        return default;
                    }
                }
                // Handle arrays
                else if (targetType.IsArray)
                {
                    Type elementType = targetType.GetElementType();
                    string[] elements = value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    Array array = Array.CreateInstance(elementType, elements.Length);

                    for (int i = 0; i < elements.Length; i++)
                    {
                        string elementValue = elements[i].Trim();

                        // Handle enum arrays using EnumHelper
                        if (elementType.IsEnum)
                        {
                            if (EnumHelper.TryParse(elementType, elementValue, out object enumArrayValue))
                            {
                                array.SetValue(enumArrayValue, i);
                            }
                            else
                            {
                                //throw new InvalidCastException($"Cannot convert '{elementValue}' to {elementType.Name}.");
                                return default;
                            }
                        }
                        else
                        {
                            array.SetValue(Convert.ChangeType(elementValue, elementType), i);
                        }
                    }
                    return (T)(object)array;
                }
                // Handle other value types and strings
                else if (targetType.IsValueType || targetType == typeof(string))
                {
                    return (T)Convert.ChangeType(value, targetType);
                }
                // Handle types using TypeConverter
                else
                {
                    TypeConverter converter = TypeDescriptor.GetConverter(targetType);
                    if (converter.CanConvertFrom(typeof(string)))
                    {
                        return (T)converter.ConvertFrom(value);
                    }
                    else
                    {
                        //throw new InvalidCastException($"Cannot convert from string to {targetType.Name}.");
                        return default;
                    }
                }
            }
            catch
            {
                return default;
            }
        }
    }
}
