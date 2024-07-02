using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts;
using System.Collections.Generic;
using System;

namespace MtconnectCore.Validation
{
    public partial class NodeValidationContext
    {
        public class NodeValueValidator<TEnum> : NodeValidator where TEnum : Enum
        {
            public string PropertyName { get; }

            public VersionComparisonTypes? ImplementationState { get; }

            public NodeValueValidator(NodeValidationContext context, string propertyName) : base(context)
            {
                PropertyName = propertyName;
                ImplementationState = EnumHelper.CompareToVersion<TEnum>(Context.Node.MtconnectVersion.GetValueOrDefault());
            }

            public NodeValueValidator<TEnum> WhileIntroduced(Func<NodeValueValidator<TEnum>, NodeValidator> action)
            {
                if (ImplementationState == VersionComparisonTypes.Implemented)
                {
                    return action(this) as NodeValueValidator<TEnum>;
                }
                return this;
            }

            public NodeValueValidator<TEnum> WhileNotIntroduced(Func<NodeValueValidator<TEnum>, NodeValidator> action)
            {
                if (ImplementationState != VersionComparisonTypes.Implemented)
                {
                    return action(this) as NodeValueValidator<TEnum>;
                }
                return this;
            }

            /// <summary>
            /// Validates the use of an Enum field in the context of the implemented version.<br/>
            /// </summary>
            /// <returns>Fluent validation context</returns>
            public NodeValueValidator<TEnum> IsImplemented()
            {
                if (ImplementationState != VersionComparisonTypes.Implemented)
                {
                    AddWarning($"The field '{PropertyName}' is not supported in version '{Context.Node.MtconnectVersion.ToName()}'.");
                }
                return this;
            }
            /// <summary>
            /// Validates the use of an Enum field in the context of the implemented version when the provided value is not null.<br/>
            /// </summary>
            /// <returns>Fluent validation context</returns>
            public NodeValueValidator<TEnum> IsImplemented(string value)
            {
                if (string.IsNullOrEmpty(value))
                    return this;
                return IsImplemented();
            }

            /// <inheritdoc cref="NodeValidator.ValidateRequired(string, string)" />
            public NodeValueValidator<TEnum> IsRequired(string value, bool breakIfMissing = true)
                => IsRequired(PropertyName, value, breakIfMissing) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> CheckValueMaxLength(string value, int maxLength = 255)
                => CheckValueMaxLength(PropertyName, value, maxLength) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> IsIdValueType(string value, bool isRequired = true)
                => IsIdValueType(PropertyName, value, isRequired) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> IsUIntValueType(string value)
                => IsUIntValueType(PropertyName, value) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> IsUIntWithinRange(string value, uint minimum, uint maximum)
                => IsUIntWithinRange(PropertyName, value, minimum, maximum) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> IsULongValueType(string value)
                => IsULongValueType(PropertyName, value) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> IsULongWithinRange(string value, ulong minimum, ulong maximum)
                => IsULongWithinRange(PropertyName, value, minimum, maximum) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> IsFloatValueType(string value)
                => IsFloatValueType(PropertyName, value) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> IsBooleanValueType(string value)
                => IsBooleanValueType(PropertyName, value) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> IsDateTimeValueType(string value)
                => IsDateTimeValueType(PropertyName, value) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> IsEnumValueType<T>(string value) where T : Enum
                => IsEnumValueType<T>(PropertyName, value) as NodeValueValidator<TEnum>;

            public NodeValueValidator<TEnum> HasMultiplicity<T>(IEnumerable<T> values, int minimumCount, int maximumCount)
                => HasMultiplicity<T>(PropertyName, values, minimumCount, maximumCount) as NodeValueValidator<TEnum>;
        
        }
    }
}
