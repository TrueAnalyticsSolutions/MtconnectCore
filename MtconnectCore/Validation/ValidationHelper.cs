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

            public NodeValidator IfNotNull(string value)
                => string.IsNullOrEmpty(value) ? null : this;

            private NodeValidator UpToVersion(MtconnectVersions maximumVersion, Func<NodeValidator, NodeValidator> action)
            {
                if (Context.Node.MtconnectVersion < maximumVersion)
                {
                    return action(this);
                }
                return this;
            }

            private NodeValidator SinceVersion(MtconnectVersions minimumVersion, Func<NodeValidator, NodeValidator> action)
            {
                if (Context.Node.MtconnectVersion >= minimumVersion)
                {
                    return action(this);
                }
                return this;
            }

            /// <summary>
            /// Validates the use of an Enum field in the context of the implemented version.<br/>
            /// </summary>
            /// <typeparam name="T">Reference to Enum type</typeparam>
            /// <param name="entityName">Value key</param>
            /// <param name="propertyName">Value of key</param>
            /// <returns>Fluent validation context</returns>
            public NodeValidator ValidateValueProperty<T>(string entityName, string propertyName) where T : Enum
            {
                if (!string.IsNullOrEmpty(propertyName) && !EnumHelper.ValidateToVersion<T>(propertyName, Context.Node.MtconnectVersion.GetValueOrDefault()))
                {
                    AddWarning($"The '{entityName}' field '{propertyName}' is not supported in version '{Context.Node.MtconnectVersion.ToName()}'.");
                }
                return this;
            }

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
            /// Validates value is null or empty.<br/>
            /// </summary>
            /// <param name="key">Value key</param>
            /// <param name="value">Value of key</param>
            /// <param name="minimumVersion">Minimum version of MTConnect that the item was implemented.</param>
            /// <returns>Fluent validation context</returns>
            public NodeValidator ValidateNotImplemented(string key, string value, MtconnectVersions minimumVersion)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    AddError($"The '{key}' attribute is not supported until version '{minimumVersion.ToName()}'.");
                    return null;
                }
                return this;
            }

            /// <summary>
            /// Validates value is not null or empty.<br/>
            /// </summary>
            /// <param name="key">Value key</param>
            /// <param name="value">Value of key</param>
            /// <param name="maximumVersion">Maximum version of MTConnect that the item was supported.</param>
            /// <returns>Fluent validation context</returns>
            public NodeValidator ValidateDeprecated(string key, string value, MtconnectVersions maximumVersion)
            {
                return this.UpToVersion(maximumVersion, (o) =>
                    o.If((p) => !string.IsNullOrEmpty(value), (a) => {
                        a.AddWarning($"The '{key}' attribute is no longer supported since version '{maximumVersion.ToName()}'.");
                        return a;
                    })
                );
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
                    AddError($"Invalid '{key}' value.");
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
            else if (!EnumHelper.ValidateToVersion<T>(type, implementedVersion))
            {
                if (categoryType != CategoryTypes.CONDITION
                    || (!EnumHelper.ValidateToVersion<MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.EventTypes>(type, implementedVersion)
                        && !EnumHelper.ValidateToVersion<MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.SampleTypes>(type, implementedVersion)))
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
                    else if (!EnumHelper.ValidateToVersion(obsSubType.SubTypeEnum, subType, implementedVersion))
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

        ///// <summary>
        ///// Validates the <c>units</c> attribute.<br/>
        ///// <list type="bullet">
        ///// <item><b>Multiplicity</b>: Required for SAMPLE category</item>
        ///// <item>Unnecessary Extensions</item>
        ///// <item>Deprecation</item>
        ///// <item><b>Value Type</b>: <see cref="UnitsTypes" /></item>
        ///// </list>
        ///// </summary>
        ///// <param name="node">Reference to <see cref="MtconnectNode"/></param>
        ///// <param name="category"><c>category</c> value for reference</param>
        ///// <param name="units"><c>units</c> value for reference</param>
        ///// <returns>Collection of validation exceptions</returns>
        //internal static IEnumerable<MtconnectValidationException> ValidateUnits(this MtconnectNode node, string category, string units)
        //{
        //    if (!string.IsNullOrEmpty(units))
        //    {
        //        if (units.Contains(":"))
        //        {
        //            string extendedUnits = units.Substring(units.LastIndexOf(":") + 1);
        //            if (!EnumHelper.Contains<UnitsTypes>(extendedUnits))
        //            {
        //                yield return (new MtconnectValidationException(
        //                    ValidationSeverity.WARNING,
        //                    $"Extended units '{extendedUnits}' already exist in version '{node.MtconnectVersion}'.",
        //                    node.SourceNode));
        //            }
        //            else if (!EnumHelper.ValidateToVersion<UnitsTypes>(extendedUnits, node.MtconnectVersion.GetValueOrDefault()))
        //            {
        //                yield return (new MtconnectValidationException(
        //                    ValidationSeverity.WARNING,
        //                    $"Invalid 'units' value in version '{node.MtconnectVersion}'.",
        //                    node.SourceNode));
        //            }
        //            else
        //            {
        //                yield return (new MtconnectValidationException(
        //                    ValidationSeverity.MESSAGE,
        //                    $"Extended units '{extendedUnits}' are used in this implementation.",
        //                    node.SourceNode));
        //            }
        //        }
        //        else if (!EnumHelper.Contains<UnitsTypes>(units))
        //        {
        //            yield return (new MtconnectValidationException(
        //                ValidationSeverity.WARNING,
        //                $"Invalid 'units' value.",
        //                node.SourceNode));
        //        }
        //        else if (!EnumHelper.ValidateToVersion<UnitsTypes>(units, node.MtconnectVersion.GetValueOrDefault()))
        //        {
        //            yield return (new MtconnectValidationException(
        //                ValidationSeverity.WARNING,
        //                $"Invalid 'units' value in version '{node.MtconnectVersion}'.",
        //                node.SourceNode));
        //        }
        //    }
        //    else if (category.ToUpper() == "SAMPLE")
        //    {
        //        yield return (new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Missing 'units' value.",
        //                node.SourceNode));
        //    }
        //}

        ///// <summary>
        ///// Validates the <c>nativeUnits</c> attribute.<br/>
        ///// <list type="bullet">
        ///// <item><b>Multiplicity</b>: Optional</item>
        ///// <item>Deprecation</item>
        ///// <item><b>Value Type</b>: <see cref="NativeUnitsTypes" /></item>
        ///// </list>
        ///// </summary>
        ///// <param name="node">Reference to <see cref="MtconnectNode"/></param>
        ///// <param name="nativeUnits"><c>nativeUnits</c> value for reference</param>
        ///// <returns>Collection of validation exceptions</returns>
        //internal static IEnumerable<MtconnectValidationException> ValidateNativeUnits(this MtconnectNode node, string nativeUnits)
        //{
        //    if (!string.IsNullOrEmpty(nativeUnits))
        //    {
        //        if (!EnumHelper.Contains<NativeUnitsTypes>(nativeUnits) && !EnumHelper.Contains<UnitsTypes>(nativeUnits))
        //        {
        //            yield return (new MtconnectValidationException(
        //                ValidationSeverity.WARNING,
        //                $"Invalid 'nativeUnits' value.",
        //                node.SourceNode));
        //        }
        //        else if (!EnumHelper.ValidateToVersion<NativeUnitsTypes>(nativeUnits, node.MtconnectVersion.GetValueOrDefault()) && !EnumHelper.ValidateToVersion<UnitsTypes>(nativeUnits, node.MtconnectVersion.GetValueOrDefault()))
        //        {
        //            yield return (new MtconnectValidationException(
        //                ValidationSeverity.WARNING,
        //                $"Invalid 'nativeUnits' value in version '{node.MtconnectVersion}'.",
        //                node.SourceNode));
        //        }
        //    }
        //}

        ///// <summary>
        ///// Validates the <c>nativeScale</c> attribute.<br/>
        ///// <list type="bullet">
        ///// <item><b>Multiplicity</b>: Optional</item>
        ///// <item><b>Value Type</b>: <see cref="Int32" /></item>
        ///// </list>
        ///// </summary>
        ///// <param name="node">Reference to <see cref="MtconnectNode"/></param>
        ///// <param name="nativeScale"><c>nativeScale</c> value for reference</param>
        ///// <returns>Collection of validation exceptions</returns>
        //internal static IEnumerable<MtconnectValidationException> ValidateNativeScale(this MtconnectNode node, string nativeScale)
        //{
        //    if (!string.IsNullOrEmpty(nativeScale) && !int.TryParse(nativeScale, out int nativeScaleValue))
        //    {
        //        yield return (new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Invalid 'nativeScale' value. It MUST be an integer.",
        //            node.SourceNode));
        //    }
        //}

        ///// <summary>
        ///// Validates the <c>sampleRate</c> attribute.<br/>
        ///// <list type="bullet">
        ///// <item><b>Multiplicity</b>: Optional</item>
        ///// <item><b>Value Type</b>: <see cref="float" /></item>
        ///// </list>
        ///// </summary>
        ///// <param name="node">Reference to <see cref="MtconnectNode"/></param>
        ///// <param name="sampleRate"><c>sampleRate</c> value for reference</param>
        ///// <returns>Collection of validation exceptions</returns>
        //internal static IEnumerable<MtconnectValidationException> ValidateSampleRate(this MtconnectNode node, string sampleRate)
        //{
        //    if (!string.IsNullOrEmpty(sampleRate) && !float.TryParse(sampleRate, out float sampleRateValue))
        //    {
        //        yield return (new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Invalid 'sampleRate' value. It MUST be a float.",
        //            node.SourceNode));
        //    }
        //}

        ///// <summary>
        ///// Validates the <c>significantDigits</c> attribute.<br/>
        ///// <list type="bullet">
        ///// <item><b>Multiplicity</b>: Optional</item>
        ///// <item><b>Value Type</b>: <see cref="int" /></item>
        ///// </list>
        ///// </summary>
        ///// <param name="node">Reference to <see cref="MtconnectNode"/></param>
        ///// <param name="significantDigits"><c>significantDigits</c> value for reference</param>
        ///// <returns>Collection of validation exceptions</returns>
        //internal static IEnumerable<MtconnectValidationException> ValidateSignificantDigits(this MtconnectNode node, string significantDigits)
        //{
        //    if (!string.IsNullOrEmpty(significantDigits) && !int.TryParse(significantDigits, out int significantDigitsValue))
        //    {
        //        yield return (new MtconnectValidationException(
        //            ValidationSeverity.ERROR,
        //            $"Invalid 'significantDigits' value. It MUST be an integer.",
        //            node.SourceNode));
        //    }
        //}

        ///// <summary>
        ///// Validates the <c>representation</c> attribute in the context of <c>representation</c> not being implemented yet.<br/>
        ///// <list type="bullet">
        ///// <item><b>Multiplicity</b>: 0 (before 1.2.0)</item>
        ///// </list>
        ///// </summary>
        ///// <param name="node">Reference to <see cref="MtconnectNode"/></param>
        ///// <param name="representation"><c>representation</c> value for reference</param>
        ///// <returns>Collection of validation exceptions</returns>
        //internal static IEnumerable<MtconnectValidationException> ValidateRepresentation_NotImplemented(this MtconnectNode node, string representation)
        //{
        //    if (!string.IsNullOrEmpty(representation))
        //    {
        //        yield return (new MtconnectValidationException(
        //        ValidationSeverity.WARNING,
        //            $"The 'representation' attribute is not supported until version '{MtconnectVersions.V_1_2_0}'.",
        //            node.SourceNode));
        //    }
        //}

        ///// <summary>
        ///// Validates the <c>representation</c> attribute.<br/>
        ///// <list type="bullet">
        ///// <item><b>Multiplicity</b>: Optional</item>
        ///// <item><b>Value Type</b>: <see cref="RepresentationTypes" /></item>
        ///// </list>
        ///// </summary>
        ///// <param name="node">Reference to <see cref="MtconnectNode"/></param>
        ///// <param name="representation"><c>representation</c> value for reference</param>
        ///// <returns>Collection of validation exceptions</returns>
        //internal static IEnumerable<MtconnectValidationException> ValidateRepresentation(this MtconnectNode node, string representation)
        //{
        //    if (!string.IsNullOrEmpty(representation))
        //    {
        //        if (!EnumHelper.Contains<RepresentationTypes>(representation))
        //        {
        //            yield return (new MtconnectValidationException(
        //                ValidationSeverity.WARNING,
        //                $"Invalid 'representation' value.",
        //                node.SourceNode));
        //        }
        //        else if (!EnumHelper.ValidateToVersion<RepresentationTypes>(representation, node.MtconnectVersion.GetValueOrDefault()))
        //        {
        //            yield return (new MtconnectValidationException(
        //                ValidationSeverity.WARNING,
        //                $"Invalid 'representation' value in version '{node.MtconnectVersion}'.",
        //                node.SourceNode));
        //        }
        //    }
        //}

        ///// <summary>
        ///// Validates the <c>coordinateSystem</c> attribute.<br/>
        ///// <list type="bullet">
        ///// <item><b>Multiplicity</b>: Optional</item>
        ///// <item>Deprecation</item>
        ///// <item><b>Value Type</b>: <see cref="CoordinateSystemTypes" /></item>
        ///// </list>
        ///// </summary>
        ///// <param name="node">Reference to <see cref="MtconnectNode"/></param>
        ///// <param name="coordinateSystem"><c>coordinateSystem</c> value for reference</param>
        ///// <returns>Collection of validation exceptions</returns>
        //internal static IEnumerable<MtconnectValidationException> ValidateCoordinateSystem(this MtconnectNode node, string coordinateSystem)
        //{
        //    if (!string.IsNullOrEmpty(coordinateSystem))
        //    {
        //        if (!EnumHelper.Contains<CoordinateSystemTypes>(coordinateSystem))
        //        {
        //            yield return (new MtconnectValidationException(
        //                Standard.Contracts.Enums.ValidationSeverity.WARNING,
        //                $"Invalid 'coordinateSystem' value.", node.SourceNode));
        //        }
        //        else if (!EnumHelper.ValidateToVersion<CoordinateSystemTypes>(coordinateSystem, node.MtconnectVersion.GetValueOrDefault()))
        //        {
        //            yield return (new MtconnectValidationException(
        //                ValidationSeverity.WARNING,
        //                $"Invalid 'coordinateSystem' value in version '{node.MtconnectVersion}'.",
        //                node.SourceNode));
        //        }
        //    }
        //}

        ///// <summary>
        ///// Validates the <c>coordinateSystem</c> attribute in the context of <c>coordinateSystem</c> not being implemented yet.<br/>
        ///// <list type="bullet">
        ///// <item><b>Multiplicity</b>: 0 (after 2.0.0)</item>
        ///// </list>
        ///// </summary>
        ///// <param name="node">Reference to <see cref="MtconnectNode"/></param>
        ///// <param name="coordinateSystem"><c>coordinateSystem</c> value for reference</param>
        ///// <returns>Collection of validation exceptions</returns>
        //internal static IEnumerable<MtconnectValidationException> ValidateCoordinateSystem_Deprecated(this MtconnectNode node, string coordinateSystem)
        //{
        //    if (!string.IsNullOrEmpty(coordinateSystem))
        //    {
        //        yield return (new MtconnectValidationException(
        //            Standard.Contracts.Enums.ValidationSeverity.WARNING,
        //            $"The 'coordinateSystem' attribute was DEPRECATED in MTConnect Version '{MtconnectVersions.V_2_0_0}'.", node.SourceNode));
        //    }
        //}

        ///// <summary>
        ///// Validates the <c>statistic</c> attribute.<br/>
        ///// <list type="bullet">
        ///// <item><b>Multiplicity</b>: Optional</item>
        ///// <item>Deprecation</item>
        ///// <item><b>Value Type</b>: <see cref="StatisticTypes" /></item>
        ///// </list>
        ///// </summary>
        ///// <param name="node">Reference to <see cref="MtconnectNode"/></param>
        ///// <param name="statistic"><c>statistic</c> value for reference</param>
        ///// <returns>Collection of validation exceptions</returns>
        //internal static IEnumerable<MtconnectValidationException> ValidateStatistic(this MtconnectNode node, string statistic)
        //{
        //    if (!string.IsNullOrEmpty(statistic))
        //    {
        //        if (!EnumHelper.Contains<StatisticTypes>(statistic))
        //        {
        //            yield return (new MtconnectValidationException(
        //                ValidationSeverity.ERROR,
        //                $"Invalid 'statistic' value.",
        //                node.SourceNode));
        //        }
        //        else if (!EnumHelper.ValidateToVersion<StatisticTypes>(statistic, node.MtconnectVersion.GetValueOrDefault()))
        //        {
        //            yield return (new MtconnectValidationException(
        //                ValidationSeverity.WARNING,
        //                $"Invalid 'statistic' in version '{node.MtconnectVersion}'.",
        //                node.SourceNode));
        //        }
        //    }
        //}

        ///// <summary>
        ///// Validates the <c>resetTriggered</c> attribute.<br/>
        ///// <list type="bullet">
        ///// <item><b>Multiplicity</b>: Optional</item>
        ///// <item><b>Value Type</b>: <see cref="ResetTriggeredValues" /></item>
        ///// </list>
        ///// </summary>
        ///// <param name="node">Reference to <see cref="MtconnectNode"/></param>
        ///// <param name="resetTrigger"><c>resetTrigger</c> value for reference</param>
        ///// <returns>Collection of validation exceptions</returns>
        //internal static IEnumerable<MtconnectValidationException> ValidateResetTrigger(this MtconnectNode node, string resetTrigger)
        //{
        //    if (!string.IsNullOrEmpty(resetTrigger) && !EnumHelper.Contains<ResetTriggeredValues>(resetTrigger))
        //    {
        //        yield return (new MtconnectValidationException(
        //            ValidationSeverity.WARNING,
        //            $"Invalid ResetTrigger value.",
        //            node.SourceNode));
        //    }
        //}

        ///// <summary>
        ///// Validates the <c>representation</c> attribute in the context of after it was deprecated.<br/>
        ///// <list type="bullet">
        ///// <item><b>Multiplicity</b>: Optional</item>
        ///// <item><b>Value Type</b>: <see cref="RepresentationTypes" /> EXCEPT <see cref="RepresentationTypes.DISCRETE"/></item>
        ///// </list>
        ///// </summary>
        ///// <param name="node">Reference to <see cref="MtconnectNode"/></param>
        ///// <param name="representation"><c>representation</c> value for reference</param>
        ///// <returns>Collection of validation exceptions</returns>
        //internal static IEnumerable<MtconnectValidationException> ValidateRepresentationDiscrete_Deprecated(this MtconnectNode node, string representation)
        //{
        //    if (!string.IsNullOrEmpty(representation) && EnumHelper.Enumify(representation).Equals(RepresentationTypes.DISCRETE))
        //    {
        //        yield return (new MtconnectValidationException(
        //            ValidationSeverity.WARNING,
        //            $"DataItem 'representation' of 'discrete' is obsolete, the 'discrete' attribute should be used instead.",
        //            node.SourceNode));
        //    }
        //}

    }
}
