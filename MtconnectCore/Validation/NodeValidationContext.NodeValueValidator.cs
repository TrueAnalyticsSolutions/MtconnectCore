using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts;
using System.Collections.Generic;
using System;

namespace MtconnectCore.Validation
{
    /// <summary>
    /// Provides the context for node validation operations within the MTConnect framework.
    /// </summary>
    public partial class NodeValidationContext
    {
        /// <summary>
        /// Validator class that validates node values based on a specified enumeration type, 
        /// where the enumeration contains fields representing property names of an entity.
        /// </summary>
        /// <typeparam name="TEnum">The enumeration type representing property names for an entity.</typeparam>
        public class NodeValueValidator<TEnum> : NodeValidator where TEnum : Enum
        {
            /// <summary>
            /// Gets the name of the property being validated, derived from the enum value.
            /// </summary>
            public string PropertyName { get; }

            /// <summary>
            /// Gets the implementation state of the property based on version comparison.
            /// </summary>
            public VersionComparisonTypes? ImplementationState { get; }

            /// <summary>
            /// Initializes a new instance of the <see cref="NodeValueValidator{TEnum}"/> class.
            /// </summary>
            /// <param name="context">The validation context.</param>
            /// <param name="propertyName">The name of the property being validated, typically derived from the enum value.</param>
            public NodeValueValidator(NodeValidationContext context, string propertyName) : base(context)
            {
                PropertyName = propertyName;
                ImplementationState = EnumHelper.CompareToVersion<TEnum>(Context.Node.MtconnectVersion.GetValueOrDefault());
            }

            public NodeValueValidator(NodeValidationContext context, string propertyName, string helpLink) : this(context, propertyName)
            {
                HelpLink = helpLink;
            }

            /// <summary>
            /// Executes the provided action if the property represented by the enum value has been introduced (implemented).
            /// </summary>
            /// <param name="action">The action to execute.</param>
            /// <returns>The current instance of <see cref="NodeValueValidator{TEnum}"/> for fluent validation.</returns>
            public NodeValueValidator<TEnum> WhileIntroduced(Func<NodeValueValidator<TEnum>, NodeValidator> action)
            {
                if (ImplementationState == VersionComparisonTypes.Implemented)
                {
                    return action(this) as NodeValueValidator<TEnum>;
                }
                return this;
            }

            /// <summary>
            /// Executes the provided action if the property represented by the enum value has not been introduced (not implemented).
            /// </summary>
            /// <param name="action">The action to execute.</param>
            /// <returns>The current instance of <see cref="NodeValueValidator{TEnum}"/> for fluent validation.</returns>
            public NodeValueValidator<TEnum> WhileNotIntroduced(Func<NodeValueValidator<TEnum>, NodeValidator> action)
            {
                if (ImplementationState != VersionComparisonTypes.Implemented)
                {
                    return action(this) as NodeValueValidator<TEnum>;
                }
                return this;
            }

            /// <summary>
            /// Validates that the property represented by the enum field is implemented in the current MTConnect version.
            /// </summary>
            /// <returns>The current instance of <see cref="NodeValueValidator{TEnum}"/> for fluent validation.</returns>
            public NodeValueValidator<TEnum> IsImplemented()
            {
                if (ImplementationState != VersionComparisonTypes.Implemented)
                {
                    AddWarning($"The field '{PropertyName}' is not supported in version '{Context.Node.MtconnectVersion.ToName()}'.");
                }
                return this;
            }

            /// <summary>
            /// Validates that the property represented by the enum field is implemented in the current MTConnect version when the provided value is not null.
            /// </summary>
            /// <param name="value">The value to validate.</param>
            /// <returns>The current instance of <see cref="NodeValueValidator{TEnum}"/> for fluent validation.</returns>
            public NodeValueValidator<TEnum> IsImplemented(string value)
            {
                if (string.IsNullOrEmpty(value))
                    return this;
                return IsImplemented();
            }

            public NodeValueValidator<TEnum> IsImplemented<T>(ParsedValue<T> value)
                => IsImplemented(value?.RawValue);

            /// <summary>
            /// Validates that the property represented by the enum field is required and the value is not null or empty.
            /// </summary>
            /// <param name="value">The value to validate.</param>
            /// <param name="breakIfMissing">Indicates whether to break the validation chain if the value is missing.</param>
            /// <returns>The current instance of <see cref="NodeValueValidator{TEnum}"/> for fluent validation.</returns>
            public NodeValueValidator<TEnum> IsRequired(string value, bool breakIfMissing = true)
                => IsRequired(PropertyName, value, breakIfMissing) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> IsRequired<T>(ParsedValue<T> value, bool breakIfMissing = true)
                => IsRequired(value?.RawValue, breakIfMissing);

            /// <summary>
            /// Checks if the length of the value for the property represented by the enum field does not exceed the specified maximum length.
            /// </summary>
            /// <param name="value">The value to validate.</param>
            /// <param name="maxLength">The maximum allowed length.</param>
            /// <returns>The current instance of <see cref="NodeValueValidator{TEnum}"/> for fluent validation.</returns>
            public NodeValueValidator<TEnum> CheckValueMaxLength(string value, int maxLength = 255)
                => CheckValueMaxLength(PropertyName, value, maxLength) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> CheckValueMaxLength<T>(ParsedValue<T> value, int maxLength = 255)
                => CheckValueMaxLength(value?.RawValue, maxLength);

            /// <summary>
            /// Validates if the value for the property represented by the enum field is a valid identifier and optionally checks if it is required.
            /// </summary>
            /// <param name="value">The value to validate.</param>
            /// <param name="isRequired">Indicates if the value is required.</param>
            /// <returns>The current instance of <see cref="NodeValueValidator{TEnum}"/> for fluent validation.</returns>
            public NodeValueValidator<TEnum> IsIdValueType(string value, bool isRequired = true)
                => IsIdValueType(PropertyName, value, isRequired) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> IsIdValueType<T>(ParsedValue<T> value, bool isRequired = true)
                => IsIdValueType(value?.RawValue, isRequired);

            /// <summary>
            /// Validates if the value for the property represented by the enum field can be converted to a UInt and outputs the result.
            /// </summary>
            /// <param name="value">The value to validate.</param>
            /// <param name="output">The output UInt value if valid.</param>
            /// <returns>The current instance of <see cref="NodeValueValidator{TEnum}"/> for fluent validation.</returns>
            public NodeValueValidator<TEnum> IsUIntValueType(string value, out uint? output)
                => IsUIntValueType(PropertyName, value, out output) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> IsUIntValueType(ParsedValue<uint> value, out uint? output)
                => IsUIntValueType(value?.RawValue, out output);

            public NodeValueValidator<TEnum> IsUIntValueType(ParsedValue<uint?> value, out uint? output)
                => IsUIntValueType(value?.RawValue, out output);

            /// <summary>
            /// Validates if the value for the property represented by the enum field is within the specified UInt range.
            /// </summary>
            /// <param name="value">The value to validate.</param>
            /// <param name="minimum">The minimum allowed value.</param>
            /// <param name="maximum">The maximum allowed value.</param>
            /// <returns>The current instance of <see cref="NodeValueValidator{TEnum}"/> for fluent validation.</returns>
            public NodeValueValidator<TEnum> IsUIntWithinRange(string value, uint minimum, uint maximum)
                => IsUIntWithinRange(PropertyName, value, minimum, maximum) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> IsUIntWithinRange(ParsedValue<uint> value, uint minimum, uint maximum)
                => IsUIntWithinRange(value?.RawValue, minimum, maximum);

            public NodeValueValidator<TEnum> IsUIntWithinRange(ParsedValue<uint?> value, uint minimum, uint maximum)
                => IsUIntWithinRange(value?.RawValue, minimum, maximum);

            /// <summary>
            /// Validates if the value for the property represented by the enum field can be converted to a ULong and outputs the result.
            /// </summary>
            /// <param name="value">The value to validate.</param>
            /// <param name="output">The output ULong value if valid.</param>
            /// <returns>The current instance of <see cref="NodeValueValidator{TEnum}"/> for fluent validation.</returns>
            public NodeValueValidator<TEnum> IsULongValueType(string value, out ulong? output)
                => IsULongValueType(PropertyName, value, out output) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> IsULongValueType(ParsedValue<ulong> value, out ulong? output)
                => IsULongValueType(value?.RawValue, out output);

            public NodeValueValidator<TEnum> IsULongValueType(ParsedValue<ulong?> value, out ulong? output)
                => IsULongValueType(value?.RawValue, out output);

            /// <summary>
            /// Validates if the value for the property represented by the enum field is within the specified ULong range.
            /// </summary>
            /// <param name="value">The value to validate.</param>
            /// <param name="minimum">The minimum allowed value.</param>
            /// <param name="maximum">The maximum allowed value.</param>
            /// <returns>The current instance of <see cref="NodeValueValidator{TEnum}"/> for fluent validation.</returns>
            public NodeValueValidator<TEnum> IsULongWithinRange(string value, ulong minimum, ulong maximum)
                => IsULongWithinRange(PropertyName, value, minimum, maximum) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> IsULongWithinRange(ParsedValue<ulong> value, ulong minimum, ulong maximum)
                => IsULongWithinRange(value?.RawValue, minimum, maximum);

            public NodeValueValidator<TEnum> IsULongWithinRange(ParsedValue<ulong?> value, ulong minimum, ulong maximum)
                => IsULongWithinRange(value?.RawValue, minimum, maximum);

            /// <summary>
            /// Validates if the value for the property represented by the enum field can be converted to a Float and outputs the result.
            /// </summary>
            /// <param name="value">The value to validate.</param>
            /// <param name="output">The output Float value if valid.</param>
            /// <returns>The current instance of <see cref="NodeValueValidator{TEnum}"/> for fluent validation.</returns>
            public NodeValueValidator<TEnum> IsFloatValueType(string value, out float? output)
                => IsFloatValueType(PropertyName, value, out output) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> IsFloatValueType(ParsedValue<float> value, out float? output)
                => IsFloatValueType(value?.RawValue, out output);

            public NodeValueValidator<TEnum> IsFloatValueType(ParsedValue<float?> value, out float? output)
                => IsFloatValueType(value?.RawValue, out output);

            /// <summary>
            /// Validates if the value for the property represented by the enum field can be converted to a 3D Float array and outputs the result.
            /// </summary>
            /// <param name="value">The value to validate.</param>
            /// <param name="output">The output 3D Float array if valid.</param>
            /// <returns>The current instance of <see cref="NodeValueValidator{TEnum}"/> for fluent validation.</returns>
            public NodeValueValidator<TEnum> IsFloat3dValueType(string value, out float?[] output)
                => IsFloat3dValueType(PropertyName, value, out output) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> IsFloat3dValueType(ParsedValue<float[]> value, out float?[] output)
                => IsFloat3dValueType(value?.RawValue, out output);

            public NodeValueValidator<TEnum> IsFloat3dValueType(ParsedValue<float?[]> value, out float?[] output)
                => IsFloat3dValueType(value?.RawValue, out output);

            /// <summary>
            /// Validates if the value for the property represented by the enum field can be converted to a Float array and outputs the result.
            /// </summary>
            /// <param name="value">The value to validate.</param>
            /// <param name="output">The output Float array if valid.</param>
            /// <returns>The current instance of <see cref="NodeValueValidator{TEnum}"/> for fluent validation.</returns>
            public NodeValueValidator<TEnum> IsFloatArrayValueType(string value, out float?[] output)
                => IsFloatArrayValueType(PropertyName, value, out output) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> IsFloatArrayValueType(ParsedValue<float[]> value, out float?[] output)
                => IsFloatArrayValueType(value?.RawValue, out output);

            public NodeValueValidator<TEnum> IsFloatArrayValueType(ParsedValue<float?[]> value, out float?[] output)
                => IsFloatArrayValueType(value?.RawValue, out output);

            /// <summary>
            /// Validates if the number of elements in the Float array for the property represented by the enum field is within the specified range.
            /// </summary>
            /// <param name="key">The key representing the property.</param>
            /// <param name="value">The Float array to validate.</param>
            /// <param name="minimum">The minimum allowed number of elements.</param>
            /// <param name="maximum">The maximum allowed number of elements.</param>
            /// <returns>The current instance of <see cref="NodeValueValidator{TEnum}"/> for fluent validation.</returns>
            public NodeValueValidator<TEnum> IsFloatArrayCountWithinRange(string key, float?[] value, uint minimum, uint maximum)
                => IsFloatArrayCountWithinRange(PropertyName, value, minimum, maximum) as NodeValueValidator<TEnum>;

            /// <summary>
            /// Validates if the value for the property represented by the enum field can be converted to a Boolean and outputs the result.
            /// </summary>
            /// <param name="value">The value to validate.</param>
            /// <param name="output">The output Boolean value if valid.</param>
            /// <returns>The current instance of <see cref="NodeValueValidator{TEnum}"/> for fluent validation.</returns>
            public NodeValueValidator<TEnum> IsBooleanValueType(string value, out bool? output)
                => IsBooleanValueType(PropertyName, value, out output) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> IsBooleanValueType(ParsedValue<bool> value, out bool? output)
                => IsBooleanValueType(value?.RawValue, out output);

            public NodeValueValidator<TEnum> IsBooleanValueType(ParsedValue<bool?> value, out bool? output)
                => IsBooleanValueType(value?.RawValue, out output);

            /// <summary>
            /// Validates if the value for the property represented by the enum field can be converted to a DateTime and outputs the result.
            /// </summary>
            /// <param name="value">The value to validate.</param>
            /// <param name="output">The output DateTime value if valid.</param>
            /// <returns>The current instance of <see cref="NodeValueValidator{TEnum}"/> for fluent validation.</returns>
            public NodeValueValidator<TEnum> IsDateTimeValueType(string value, out DateTime? output)
                => IsDateTimeValueType(PropertyName, value, out output) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> IsDateTimeValueType(ParsedValue<DateTime> value, out DateTime? output)
                => IsDateTimeValueType(value?.RawValue, out output);

            public NodeValueValidator<TEnum> IsDateTimeValueType(ParsedValue<DateTime?> value, out DateTime? output)
                => IsDateTimeValueType(value?.RawValue, out output);

            /// <summary>
            /// Validates if the value for the property represented by the enum field can be converted to the specified enum type and outputs the result.
            /// </summary>
            /// <typeparam name="T">The target enum type to which the value should be converted.</typeparam>
            /// <param name="value">The value to validate.</param>
            /// <param name="output">The output enum value if valid.</param>
            /// <returns>The current instance of <see cref="NodeValueValidator{TEnum}"/> for fluent validation.</returns>
            public NodeValueValidator<TEnum> IsEnumValueType<T>(string value, out T output) where T : struct, Enum
                => IsEnumValueType<T>(PropertyName, value, out output) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> IsEnumValueType<T>(ParsedValue<T> value, out T output) where T : struct, Enum
                => IsEnumValueType<T>(value?.RawValue, out output);

            public NodeValueValidator<TEnum> IsEnumValueType<T>(ParsedValue<T?> value, out T output) where T : struct, Enum
                => IsEnumValueType<T>(value?.RawValue, out output);

            /// <summary>
            /// Validates if the value for the property represented by the enum field conforms to the RFC 4646 language tag format.
            /// </summary>
            /// <param name="value">The value to validate.</param>
            /// <returns>The current instance of <see cref="NodeValueValidator{TEnum}"/> for fluent validation.</returns>
            public NodeValueValidator<TEnum> IsRfc4646LanguageTag(string value)
                => IsRfc4646LanguageTag(PropertyName, value) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> IsRfc4646LanguageTag<T>(ParsedValue<T> value)
                => IsRfc4646LanguageTag(value?.RawValue);

            /// <summary>
            /// Validates if the collection of values for the property represented by the enum field falls within the specified multiplicity range.
            /// </summary>
            /// <typeparam name="T">The type of the values in the collection.</typeparam>
            /// <param name="values">The collection of values to validate.</param>
            /// <param name="minimumCount">The minimum allowed count of the values.</param>
            /// <param name="maximumCount">The maximum allowed count of the values.</param>
            /// <returns>The current instance of <see cref="NodeValueValidator{TEnum}"/> for fluent validation.</returns>
            public NodeValueValidator<TEnum> HasMultiplicity<T>(IEnumerable<T> values, int minimumCount, int maximumCount)
                => HasMultiplicity<T>(PropertyName, values, minimumCount, maximumCount) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> HasMultiplicity<T>(ParsedValue<IEnumerable<T>> values, int minimumCount, int maximumCount)
                => HasMultiplicity(values.Value, minimumCount, maximumCount);

        }
    }
}
