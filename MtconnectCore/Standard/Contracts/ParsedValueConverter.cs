using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace MtconnectCore.Standard.Contracts
{
    public class ParsedValueConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            // Allow conversion from string to ParsedValue<T>
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string stringValue)
            {
                // If context is null, we cannot access PropertyDescriptor, so we'll skip that logic
                if (context != null)
                {
                    var propertyType = context.PropertyDescriptor.PropertyType;
                    if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(ParsedValue<>))
                    {
                        var genericArgument = propertyType.GetGenericArguments()[0];
                        return CreateParsedValueInstance(propertyType, genericArgument, stringValue, culture);
                    }
                }
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value != null)
            {
                var propertyType = value.GetType();
                if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(ParsedValue<>))
                {
                    var rawValueProperty = propertyType.GetProperty("RawValue");
                    var valueProperty = propertyType.GetProperty("Value");

                    if (destinationType == typeof(string))
                    {
                        // Return the RawValue as string
                        return rawValueProperty.GetValue(value)?.ToString();
                    }

                    // If converting to the generic type, return the Value property
                    if (destinationType == propertyType.GetGenericArguments()[0])
                    {
                        return valueProperty.GetValue(value);
                    }
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        private object CreateParsedValueInstance(Type propertyType, Type genericArgument, string stringValue, CultureInfo culture)
        {
            // Use reflection to create an instance of ParsedValue<T> with the string value
            var parsedValueInstance = Activator.CreateInstance(propertyType);
            var rawValueProperty = propertyType.GetProperty("RawValue");
            var valueProperty = propertyType.GetProperty("Value");

            // Set the RawValue property
            rawValueProperty.SetValue(parsedValueInstance, stringValue);

            try
            {
                // Attempt to convert the string to the generic argument type
                var convertedValue = Convert.ChangeType(stringValue, genericArgument, culture);
                valueProperty.SetValue(parsedValueInstance, convertedValue);
            }
            catch
            {
                // If conversion fails, leave the Value property as its default value
            }

            return parsedValueInstance;
        }
    }
}
