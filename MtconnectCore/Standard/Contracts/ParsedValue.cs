namespace MtconnectCore.Standard.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IParsedValue
    {
        /// <summary>
        /// Gets or sets the original string value from the XML or JSON data.
        /// </summary>
        string RawValue { get; set; }
    }

    public class ParsedValue<T> : IParsedValue
    {
        private string _rawValue;
        private T _value;

        /// <inheritdoc/>
        public string RawValue {
            get => _rawValue;
            set {
                _rawValue = value;
                // Attempt to convert the string value to the desired type T
                try
                {
                    if (!string.IsNullOrEmpty(value) && typeof(T).IsValueType)
                    {
                        _value = (T)Convert.ChangeType(value, typeof(T));
                    }
                    else if (typeof(T) == typeof(string))
                    {
                        _value = (T)(object)value;
                    }
                }
                catch
                {
                    // Keep _value as default(T) if conversion fails
                    _value = default;
                }
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
            var parsedValue = new ParsedValue<T> { RawValue = value };

            try
            {
                // Attempt to convert the string value to the desired type T
                if (!string.IsNullOrEmpty(value) && typeof(T).IsValueType)
                {
                    parsedValue.Value = (T)Convert.ChangeType(value, typeof(T));
                }
                else if (typeof(T) == typeof(string))
                {
                    parsedValue.Value = (T)(object)value;
                }
            }
            catch
            {
                // Keep Value as default(T) if conversion fails
            }

            return parsedValue;
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
        /// Determines if the ParsedValue is not equal to null.
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
    }
}
