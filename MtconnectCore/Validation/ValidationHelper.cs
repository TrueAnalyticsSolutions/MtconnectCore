﻿using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes;
using MtconnectCore.Standard.Contracts.Enums.Devices;
using MtconnectCore.Standard.Contracts.Enums.Streams;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts;
using System.Linq;
using System.Reflection;
using System;
using MtconnectCore.Standard.Contracts.Enums.Devices.InterfaceTypes;

namespace MtconnectCore.Validation
{
    internal static class ValidationHelper
    {

        internal static NodeValidationContext.NodeValidator ValidateSampleObservationResult(this NodeValidationContext.NodeValidator validator, string type, string result)
        {
            if (string.IsNullOrEmpty(result))
            {
                validator.AddError("Observation MUST include a result.", Pairings.Of("result", result));
            }
            else if (result.Equals(Constants.UNAVAILABLE, StringComparison.OrdinalIgnoreCase))
            {
                return validator;
            }
            if (Enum.TryParse<SampleTypes>(type, out SampleTypes sampleType))
            {
                // NOTE: Only validate the VALUE, not the Sub-Type
                switch (sampleType)
                {
                    //case SampleTypes.CLOCK_TIME:
                    //    var iso8601 = new Regex(@"^(?:[1-9]\d{3}-(?:(?:0[1-9]|1[0-2])-(?:0[1-9]|1\d|2[0-8])|(?:0[13-9]|1[0-2])-(?:29|30)|(?:0[13578]|1[02])-31)|(?:[1-9]\d(?:0[48]|[2468][048]|[13579][26])|(?:[2468][048]|[13579][26])00)-02-29)T(?:[01]\d|2[0-3]):[0-5]\d:[0-5]\d(?:Z|[+-][01]\d:[0-5]\d)$");
                    //    if (!iso8601.IsMatch(Value))
                    //    {
                    //        validationErrors.Add(new MtconnectValidationException(
                    //            ValidationSeverity.ERROR,
                    //            $"ClockTime MUST be reported in W3C ISO 8601 format.",
                    //            SourceNode));
                    //    }
                    //    break;
                    case SampleTypes.ORIENTATION:
                    case SampleTypes.PATH_POSITION:
                        return validator.IsFloat3dValueType("result", result, out _);
                    default:
                        break;
                }
            }

            return validator;
        }
        internal static NodeValidationContext.NodeValidator ValidateEventObservationResult(this NodeValidationContext.NodeValidator validator, string type, string result)
        {
            if (string.IsNullOrEmpty(result))
            {
                validator.AddError("Observation MUST include a result.", Pairings.Of("result", result));
            } else if (result.Equals(Constants.UNAVAILABLE, StringComparison.OrdinalIgnoreCase))
            {
                return validator;
            }
            else if (Enum.TryParse<EventTypes>(EnumHelper.FromPascalCase(type), out EventTypes eventType))
            {
                var eventFieldType = typeof(EventTypes).GetField(EnumHelper.FromPascalCase(type));
                var observationalValue = eventFieldType.GetCustomAttribute<ObservationalValueAttribute>();
                // Event type has an enumerable value
                if (observationalValue != null)
                {
                    if (!EnumHelper.Contains(observationalValue.ValueEnum, result))
                    {
                        validator.AddError("Observation result does not match expected values.", Pairings.Of("type", type), Pairings.Of("result.Type", observationalValue.ValueEnum.Name), Pairings.Of("result", result));
                    }
                }
            }

            return validator;
        }

        /// <summary>
        /// Validates a <see cref="MtconnectNode"/> <c>type</c> and <c>subType</c> against all Data Item types across all categories.
        /// </summary>
        /// <param name="validator">Reference to node validator.</param>
        /// <param name="type">Reference to the <c>type</c> value from the node</param>
        /// <param name="subType">Reference to the <c>subType</c> value from the node</param>
        /// <returns>Fluent validator context</returns>
        internal static NodeValidationContext.NodeValidator ValidateType(this NodeValidationContext.NodeValidator validator, string type, string subType)
        {
            if (!string.IsNullOrEmpty(type))
            {
                foreach (CategoryEnum category in Enum.GetValues(typeof(CategoryEnum)))
                {
                    var categoryValidator = new NodeValidationContext.NodeValidator(new NodeValidationContext(validator.Context.Node));
                    switch (category)
                    {
                        case CategoryEnum.SAMPLE:
                            categoryValidator.ValidateNode<SampleTypes>(category, type, subType);
                            break;
                        case CategoryEnum.EVENT:
                            categoryValidator.ValidateNode<EventTypes>(category, type, subType);
                            break;
                        case CategoryEnum.CONDITION:
                            // TODO: Check for ANY Data Item type
                            categoryValidator.ValidateNode<ConditionTypes>(category, type, subType);
                            break;
                        default:
                            break;
                    }

                    //Determine if it was valid type
                    if (!categoryValidator.Context.Exceptions.Any(o => o.Message == INVALID_TYPE_ERROR))
                    {
                        foreach (var exception in categoryValidator.Context.Exceptions)
                        {
                            validator.Context.Exceptions.Add(exception);
                        }
                        return validator;
                    }
                }
                validator.AddError(INVALID_TYPE_ERROR, Pairings.Of("type", type));
            }
            return validator;
        }

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
            if (!string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(category))
            {
                if (Enum.TryParse<CategoryEnum>(category, out CategoryEnum categoryType))
                {
                    switch (categoryType)
                    {
                        case CategoryEnum.SAMPLE:
                            return validator.ValidateNode<SampleTypes>(categoryType, type, subType);
                        case CategoryEnum.EVENT:
                            return validator.ValidateNode<EventTypes>(categoryType, type, subType);
                        case CategoryEnum.CONDITION:
                            // TODO: Check for ANY Data Item type
                            return validator.ValidateNode<ConditionTypes>(categoryType, type, subType);
                        default:
                            return validator;
                    }
                } else
                {
                    validator.AddError("Invalid 'category' value.", Pairings.Of("category", category));
                }
            }
            return validator;
        }
        internal static NodeValidationContext.NodeValidator ValidateType(this NodeValidationContext.NodeValidator validator, ParsedValue<CategoryEnum> category, string type, string subType)
            => ValidateType(validator, category.RawValue, type, subType);

        /// <summary>
        /// Validates a <see cref="MtconnectNode"/> <c>nativeUnits</c> against standard <see cref="NativeUnitEnum"/> and <see cref="UnitEnum"/>.
        /// </summary>
        /// <param name="validator">Reference to node validator</param>
        /// <param name="nativeUnits">Refernece to the <c>nativeUnits</c> value from the node</param>
        /// <returns>Fluent validator context</returns>
        internal static NodeValidationContext.NodeValidator ValidateNativeUnits(this NodeValidationContext.NodeValidator validator, string nativeUnits)
        {
            if (!string.IsNullOrEmpty(nativeUnits) && !EnumHelper.Contains<NativeUnitEnum>(nativeUnits))
                if (!EnumHelper.Contains<UnitEnum>(nativeUnits))
                    validator.AddError("Invalid 'nativeUnits' value.", Pairings.Of("nativeUnits", nativeUnits));
            return validator;

        }
        internal static NodeValidationContext.NodeValidator ValidateNativeUnits(this NodeValidationContext.NodeValidator validator, ParsedValue<NativeUnitEnum> nativeUnits)
            => ValidateNativeUnits(validator, nativeUnits?.RawValue);

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
        internal static NodeValidationContext.NodeValidator ValidateNode<T>(this NodeValidationContext.NodeValidator validator, CategoryEnum categoryType, string type, string subType) where T : Enum
        {
            // Check interfaces
            if (type.Equals("INTERFACE_STATE", StringComparison.OrdinalIgnoreCase))
            {
                var parentInterfaceName = validator.Context.Node.SourceNode.ParentNode.ParentNode.LocalName;
                if (!EnumHelper.Contains<InterfaceTypes>(parentInterfaceName))
                {
                    validator.AddError("INTERFACE_STATE MUST be defined in an Interface", Pairings.Of("InterfaceType", parentInterfaceName));
                }
                return validator;
            }

            var extensionValidator = new NodeValidationContext(validator.Context.Node);
            extensionValidator.Validate((o) => o.ValidateNodeExtension<T>(categoryType, type, subType));

            if (extensionValidator.Exceptions.Any())
            {
                foreach (var exception in extensionValidator.Exceptions)
                    validator.Context.Exceptions.Add(exception);
                return validator;
            }


            var standardValidator = new NodeValidationContext(validator.Context.Node);
            standardValidator.Validate((o) => o.ValidateNodeInStandard<T>(categoryType, type, subType));

            if (standardValidator.HasError())
            {
                foreach (var exception in standardValidator.Exceptions)
                    validator.Context.Exceptions.Add(exception);
                return validator;
            }

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
        internal static NodeValidationContext.NodeValidator ValidateNodeExtension<T>(this NodeValidationContext.NodeValidator validator, CategoryEnum categoryType, string type, string subType) where T : Enum
        {
            if (!string.IsNullOrEmpty(type))
            {
                if (type.Contains(":"))
                {
                    string nonExtendedType = type.Substring(type.LastIndexOf(":") + 1);
                    var standardValidator = new NodeValidationContext(validator.Context.Node);
                    standardValidator.Validate((o) => o.ValidateNodeInStandard<T>(categoryType, nonExtendedType, subType));
                    if (!standardValidator.HasError())
                    {
                        validator.AddError($"Extended type already exists in this version of MTConnect.", Pairings.Of("type", type), Pairings.Of("version", validator.Context.Node.MtconnectVersion.ToName()));
                    }
                    else
                    {
                        validator.AddMessage($"Extended type used in this implementation.", Pairings.Of("type", type));
                    }
                }
            }
            return validator;
        }

        private const string INVALID_TYPE_ERROR = "Invalid 'type' value.";
        private const string INVALID_SUB_TYPE_ERROR = "Invalid 'subType' value.";

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
        internal static NodeValidationContext.NodeValidator ValidateNodeInStandard<T>(this NodeValidationContext.NodeValidator validator, CategoryEnum categoryType, string type, string subType) where T : Enum
        {
            bool isValidType = true, isValidSubType = true;
            MtconnectVersions implementedVersion = validator.Context.Node.MtconnectVersion.GetValueOrDefault();

            // Validate the observational type
            if (!EnumHelper.Contains<T>(type))
            {
                if (categoryType != CategoryEnum.CONDITION
                    && ((!EnumHelper.Contains<EventTypes>(type)
                        && !EnumHelper.Contains<InterfaceEventEnum>(type))
                    && !EnumHelper.Contains<SampleTypes>(type)))
                {
                    validator.AddError(INVALID_TYPE_ERROR, Pairings.Of("type", type));
                    isValidType = false;
                }
            }
            else if (!EnumHelper.IsImplemented<T>(type, implementedVersion))
            {
                if (categoryType != CategoryEnum.CONDITION
                    && ((!EnumHelper.IsImplemented<EventTypes>(type, implementedVersion)
                            && !EnumHelper.IsImplemented<InterfaceEventEnum>(type, implementedVersion))
                        && !EnumHelper.IsImplemented<SampleTypes>(type, implementedVersion)))
                    validator.AddWarning($"Invalid 'type' value. Not implemented in this version of MTConnect.", Pairings.Of("type", type), Pairings.Of("version", implementedVersion.ToName()));
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
                        validator.AddWarning(INVALID_SUB_TYPE_ERROR, Pairings.Of("subType", subType));
                        isValidSubType = false;
                    }
                    else if (!EnumHelper.IsImplemented(obsSubType.SubTypeEnum, subType, implementedVersion))
                    {
                        validator.AddWarning($"Invalid 'subType' value in this version of MTConnect.", Pairings.Of("subType", subType), Pairings.Of("version", implementedVersion.ToName()));
                        isValidSubType = false;
                    }
                }
            }

            //if (!isValidType || !isValidSubType)
            //    return null;

            return validator;
        }
    }
}
