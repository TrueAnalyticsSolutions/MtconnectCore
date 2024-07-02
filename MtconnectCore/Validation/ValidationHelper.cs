using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes;
using MtconnectCore.Standard.Contracts.Enums.Devices;
using MtconnectCore.Standard.Contracts.Enums.Streams;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Standard.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System;
using System.Runtime.CompilerServices;

namespace MtconnectCore.Validation
{
    public class NodeValidationContext
    {
        public MtconnectNode Node { get; set; }

        public ICollection<MtconnectValidationException> Exceptions { get; set; } = new List<MtconnectValidationException>();

        public NodeValidationContext(MtconnectNode node)
        {
            Node = node;
        }

        /// <summary>
        /// Indicates whether a collection of exceptions contains any <c>ERROR</c>-level severities.
        /// </summary>
        /// <param name="errors">Collection of validation exceptions</param>
        /// <returns>Flag for whether or not any of the exceptions are <c>ERROR</c>-level severity</returns>
        public bool HasError(out ICollection<MtconnectValidationException> errors)
        {
            errors = Exceptions;
            return HasError();
        }

        public bool HasError()
            => Exceptions.Any(o => o.Severity == ValidationSeverity.ERROR);

        public NodeValidationContext Validate(Func<NodeValidator, NodeValidator> validator)
        {
            try
            {
                validator.Invoke(new NodeValidator(this));
            }
            catch (Exception ex)
            {
                Exceptions.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Exception prevented further validation of {Node.SourceNode.LocalName}",
                    Node.SourceNode));
            }
            return this;
        }

        public NodeValidationContext ValidateValueProperty<TEnum>(string propertyName, Func<NodeValueValidator<TEnum>, NodeValidator> validator)
        {
            try
            {
                validator.Invoke(new NodeValueValidator<TEnum>(this, propertyName));
            }
            catch (Exception ex)
            {
                Exceptions.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Exception prevented further validation of {Node.SourceNode.LocalName}",
                    Node.SourceNode));
            }
            return this;
        }

        public class NodeValueValidator<TEnum> : NodeValidator
        {
            public string PropertyName { get; }

            public VersionComparisonTypes? ImplementationState { get; }

            public NodeValueValidator(NodeValidationContext context, string propertyName) : base(context)
            {
                PropertyName = propertyName;
                ImplementationState = EnumHelper.CompareToVersion<TEnum>(Context.Node.MtconnectVersion.GetValueOrDefault());
            }

            public NodeValueValidator<TEnum> WhileIntroduced(Func<NodeValidator, NodeValidator> action)
            {
                if (ImplementationState == VersionComparisonTypes.Implemented)
                {
                    return action(this) as NodeValueValidator<TEnum>;
                }
                return this;
            }

            public NodeValueValidator<TEnum> WhileNotIntroduced(Func<NodeValidator, NodeValidator> action)
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
            public NodeValueValidator<TEnum> ValidateValueProperty()
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
            public NodeValueValidator<TEnum> ValidateValueProperty(string value)
            {
                if (string.IsNullOrEmpty(value))
                    return null;
                return ValidateValueProperty();
            }
        }
        public class NodeValidator
        {
            internal NodeValidationContext Context { get; private set; }

            internal NodeValidator(NodeValidationContext context)
            {
                Context = context;
            }

            public void AddError(string message)
                => Context.Exceptions.Add(new MtconnectValidationException(ValidationSeverity.ERROR, message, Context.Node.SourceNode));
            public void AddWarning(string message)
                => Context.Exceptions.Add(new MtconnectValidationException(ValidationSeverity.WARNING, message, Context.Node.SourceNode));
            public void AddMessage(string message)
                => Context.Exceptions.Add(new MtconnectValidationException(ValidationSeverity.MESSAGE, message, Context.Node.SourceNode));



            /// <summary>
            /// Validates value is not null or empty.<br/>
            /// </summary>
            /// <param name="key">Value key</param>
            /// <param name="value">Value of key</param>
            /// <returns>Fluent validation context</returns>
            public NodeValidator ValidateRequired(string key, string value)
            {
                if (string.IsNullOrEmpty(value))
                {
                    AddError($"Missing '{key}' value.");
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
            public NodeValidator ValidateValueMaxLength(string key, string value, int maxLength = 255)
            {
                if (!string.IsNullOrEmpty(value) && value.Length > maxLength)
                {
                    AddError($"The {key} value must not exceed {maxLength} characters.");
                    return null;
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
            public NodeValidator ValidateIdValueType(string key, string value, bool isRequired = true)
                => (isRequired
                    ? this.ValidateRequired(key, value)
                    : this)
                ?.ValidateValueMaxLength(key, value, 255);

            /// <summary>
            /// Validates integer value types.
            /// </summary>
            /// <param name="key">Value key</param>
            /// <param name="value">Value of key</param>
            /// <returns>Fluent validation context</returns>
            public NodeValidator ValidateIntegerValueType(string key, string value)
            {
                if (!string.IsNullOrEmpty(value) && !int.TryParse(value, out int valueInt))
                {
                    AddError($"Invalid '{key}' value. It MUST be an integer.");
                    return null;
                }
                return this;
            }

            /// <summary>
            /// Validates float value types.
            /// </summary>
            /// <param name="key">Value key</param>
            /// <param name="value">Value of key</param>
            /// <returns>Fluent validation context</returns>
            public NodeValidator ValidateFloatValueType(string key, string value)
            {
                if (!string.IsNullOrEmpty(value) && !float.TryParse(value, out float valueFloat))
                {
                    AddError($"Invalid '{key}' value. It MUST be a float.");
                    return null;
                }
                return this;
            }

            /// <summary>
            /// Validates boolean value types.
            /// </summary>
            /// <param name="key">Value key</param>
            /// <param name="value">Value of key</param>
            /// <returns>Fluent validation context</returns>
            public NodeValidator ValidateBooleanValueType(string key, string value)
            {
                if (!string.IsNullOrEmpty(value) && !bool.TryParse(value, out bool valueBool))
                {
                    AddError($"Invalid '{key}' value. It MUST be a boolean.");
                    return null;
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
            public NodeValidator ValidateEnumValue<T>(string key, string value) where T : Enum
            {
                if (!string.IsNullOrEmpty(value) && !EnumHelper.Contains<T>(value))
                {
                    AddError($"Invalid '{key}' value '{value}'.");
                    return null;
                }
                return this;
            }

            public NodeValidator HasMultiplicity<T>(string key, IEnumerable<T> values, int minimumCount, int maximumCount)
            {
                var count = values.Count();
                if (count < minimumCount)
                {
                    AddError($"There must be at least {minimumCount} '{key}'");
                    return null;
                } else if (count > maximumCount)
                {
                    AddError($"There must be no more than {maximumCount} '{key}'");
                    return null;
                }
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

    internal static class ValidationHelper
    {
        /// <summary>
        /// Validates the <c>type</c> and <c>subtype</c> attributes.<br/>
        /// <list type="bullet">
        /// <item><b>Multiplicity</b>: Required</item>
        /// <item>Unnecessary Extensions</item>
        /// <item><b>Value Type</b>: <see cref="SampleTypes" />, <see cref="EventTypes" />, or <see cref="ConditionTypes" /> (Any Data Item Type)</item>
        /// <item>Deprecation</item>
        /// <item>Sub-Type valid for Type</item>
        /// </list>
        /// </summary>
        /// <param name="validator">Reference to <see cref="MtconnectNode"/></param>
        /// <param name="category"><c>category</c> value for reference</param>
        /// <param name="type"><c>type</c> value for reference</param>
        /// <param name="subType"><c>subtype</c> value for reference</param>
        /// <returns>Collection of validation exceptions</returns>
        internal static NodeValidationContext.NodeValidator ValidateType(this NodeValidationContext.NodeValidator validator, string category, string type, string subType)
        {
            if (string.IsNullOrEmpty(type))
            {
                validator.AddError($"Missing 'type' value.");
                return null;
            }
            else if (!string.IsNullOrEmpty(category))
            {
                if (Enum.TryParse<CategoryTypes>(category, out CategoryTypes categoryType))
                {
                    switch (categoryType)
                    {
                        case CategoryTypes.SAMPLE:
                            return validator.ValidateNode<SampleTypes>(categoryType, type, subType);
                        case CategoryTypes.EVENT:
                            return validator.ValidateNode<EventTypes>(categoryType, type, subType);
                        case CategoryTypes.CONDITION:
                            // TODO: Check for ANY Data Item type
                            return validator.ValidateNode<ConditionTypes>(categoryType, type, subType);
                        default:
                            return null;
                    }
                } else
                {
                    return null;
                }
            }
            return validator;
        }

        internal static NodeValidationContext.NodeValidator ValidateNativeUnits(this NodeValidationContext.NodeValidator validator, string nativeUnits)
        {
            if (string.IsNullOrEmpty(nativeUnits))
                return null;
            if (!EnumHelper.Contains<NativeUnitsTypes>(nativeUnits))
                if (!EnumHelper.Contains<UnitsTypes>(nativeUnits))
                    return null;
            return validator;

        }

        /// <summary>
        /// Dynamically validates the <c>type</c> and <c>subtype</c> attributes.<br/>
        /// <list type="bullet">
        /// <item>Unnecessary Extensions</item>
        /// <item><b>Value Type</b>: <see cref="SampleTypes" />, <see cref="EventTypes" />, or <see cref="ConditionTypes" /> (Any Data Item Type)</item>
        /// <item>Deprecation</item>
        /// <item>Sub-Type valid for Type</item>
        /// </list>
        /// </summary>
        /// <typeparam name="T">Generic Data Item type enum.</typeparam>
        /// <param name="validator">Reference to <see cref="MtconnectNode"/></param>
        /// <param name="categoryType">Deserialized <c>category</c> value for reference</param>
        /// <param name="type"><c>type</c> value for reference</param>
        /// <param name="subType"><c>subtype</c> value for reference</param>
        /// <returns>Collection of validation exceptions</returns>
        internal static NodeValidationContext.NodeValidator ValidateNode<T>(this NodeValidationContext.NodeValidator validator, CategoryTypes categoryType, string type, string subType) where T : Enum
        {
            var extensionValidator = validator.ValidateNodeExtension<T>(categoryType, type, subType);

            if (extensionValidator == null)
                return extensionValidator;
            

            var standardValidator = validator.ValidateNodeInStandard<T>(categoryType, type, subType);

            if (standardValidator == null)
                return standardValidator;

            return validator;
        }

        /// <summary>
        /// Dynamically validates the <c>type</c> and <c>subtype</c> attributes for extensions to the standard.<br/>
        /// <list type="bullet">
        /// <item>Unnecessary Extensions</item>
        /// </list>
        /// </summary>
        /// <typeparam name="T">Generic Data Item type enum.</typeparam>
        /// <param name="validator">Reference to <see cref="MtconnectNode"/></param>
        /// <param name="categoryType">Deserialized <c>category</c> value for reference</param>
        /// <param name="type"><c>type</c> value for reference</param>
        /// <param name="subType"><c>subtype</c> value for reference</param>
        /// <returns>Collection of validation exceptions</returns>
        internal static NodeValidationContext.NodeValidator ValidateNodeExtension<T>(this NodeValidationContext.NodeValidator validator, CategoryTypes categoryType, string type, string subType) where T : Enum
        {
            if (!string.IsNullOrEmpty(type))
            {
                if (type.Contains(":"))
                {
                    var standardValidator = validator.ValidateNodeInStandard<T>(categoryType, type.Substring(type.LastIndexOf(":") + 1), subType);
                    if (!validator.Context.Exceptions.Any(o => o.Severity == ValidationSeverity.ERROR))
                    {
                        validator.AddWarning($"Extended type of '{type}' already exist in version '{validator.Context.Node.MtconnectVersion}'.");
                    }
                    else
                    {
                        validator.AddWarning($"Extended type of '{type}' are used in this implementation.");
                    }
                }
            }
            return validator;
        }

        /// <summary>
        /// Dynamically validates the <c>type</c> and <c>subtype</c> attributes for implementation in the standard.<br/>
        /// <list type="bullet">
        /// <item><b>Value Type</b>: <see cref="SampleTypes" />, <see cref="EventTypes" />, or <see cref="ConditionTypes" /> (Any Data Item Type)</item>
        /// <item>Deprecation</item>
        /// <item>Sub-Type valid for Type</item>
        /// </list>
        /// </summary>
        /// <typeparam name="T">Generic Data Item type enum.</typeparam>
        /// <param name="validator">Reference to <see cref="MtconnectNode"/></param>
        /// <param name="categoryType">Deserialized <c>category</c> value for reference</param>
        /// <param name="type"><c>type</c> value for reference</param>
        /// <param name="subType"><c>subtype</c> value for reference</param>
        /// <returns>Collection of validation exceptions</returns>
        internal static NodeValidationContext.NodeValidator ValidateNodeInStandard<T>(this NodeValidationContext.NodeValidator validator, CategoryTypes categoryType, string type, string subType) where T : Enum
        {
            bool isValidType = true, isValidSubType = true;
            MtconnectVersions implementedVersion = validator.Context.Node.MtconnectVersion.GetValueOrDefault();

            // Validate the observational type
            if (!EnumHelper.Contains<T>(type))
            {
                if (categoryType != CategoryTypes.CONDITION
                    || (!EnumHelper.Contains<MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.EventTypes>(type)
                    && !EnumHelper.Contains<MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.SampleTypes>(type)))
                {
                    validator.AddError($"Invalid 'type' value.");
                    isValidType = false;
                }
            }
            else if (!EnumHelper.IsImplemented<T>(type, implementedVersion))
            {
                if (categoryType != CategoryTypes.CONDITION
                    || (!EnumHelper.IsImplemented<MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.EventTypes>(type, implementedVersion)
                        && !EnumHelper.IsImplemented<MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.SampleTypes>(type, implementedVersion)))
                    validator.AddWarning($"Invalid 'type' value in version '{implementedVersion}'.");
                isValidType = false;
            }

            if (isValidType && !string.IsNullOrEmpty(subType))
            {
                // Get the Enum and look for an attribute pointing to the SubType enum
                Type enumType = typeof(T);
                MemberInfo[] typeValueInfos = enumType.GetMember(type);
                var valueInfo = typeValueInfos.FirstOrDefault(o => o.DeclaringType == enumType);
                var obsSubType = valueInfo?.GetCustomAttribute<ObservationalSubTypeAttribute>();
                // Validate the observational sub-type
                if (obsSubType != null)
                {
                    if (!EnumHelper.Contains(obsSubType.SubTypeEnum, subType))
                    {
                        validator.AddError($"Invalid 'subType' value.");
                        isValidSubType = false;
                    }
                    else if (!EnumHelper.IsImplemented(obsSubType.SubTypeEnum, subType, implementedVersion))
                    {
                        validator.AddWarning($"Invalid 'subType' value in version '{implementedVersion}'.");
                        isValidSubType = false;
                    }
                }
            }

            if (!isValidType || !isValidSubType)
                return null;

            return validator;
        }
    }
}
