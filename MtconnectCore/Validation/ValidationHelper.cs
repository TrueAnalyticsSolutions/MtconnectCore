using MtconnectCore.Standard.Contracts.Attributes;
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
                var resultException = validator.AddError("Observation MUST include a result.", Pairings.Of("result", result));
                resultException.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.NOT_FOUND;
                resultException.ScopeType = Standard.Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY;
                resultException.Scope = "result";
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
                    case SampleTypes.Orientation:
                    case SampleTypes.PathPosition:
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
                var resultException = validator.AddError("Observation MUST include a result.", Pairings.Of("result", result));
                resultException.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.NOT_FOUND;
                resultException.ScopeType = Standard.Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY;
                resultException.Scope = "result";
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
                        var resultException = validator.AddError("Event result does not match expected values.", Pairings.Of("type", type), Pairings.Of("result.Type", observationalValue.ValueEnum.Name), Pairings.Of("result", result));
                        resultException.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.TYPE_MISMATCH;
                        resultException.ScopeType = Standard.Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY;
                        resultException.Scope = "result";
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
                var typeException = validator.AddError(INVALID_TYPE_ERROR, Pairings.Of("type", type));
                typeException.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.TYPE_MISMATCH;
                typeException.ScopeType = Standard.Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY;
                typeException.Scope = "type";
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
                    var categoryException = validator.AddError("Invalid 'category' value.", Pairings.Of("category", category));
                    categoryException.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.TYPE_MISMATCH;
                    categoryException.ScopeType = Standard.Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY;
                    categoryException.Scope = "category";
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
            {
                if (!EnumHelper.Contains<UnitEnum>(nativeUnits))
                {
                    var nativeUnitsException = validator.AddError("Invalid 'nativeUnits' value.", Pairings.Of("nativeUnits", nativeUnits));
                    nativeUnitsException.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.TYPE_MISMATCH;
                    nativeUnitsException.ScopeType = Standard.Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY;
                    nativeUnitsException.Scope = "nativeUnits";
                }
            }
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
                    var interfaceStateException = validator.AddError("INTERFACE_STATE MUST be defined in an Interface", Pairings.Of("InterfaceType", parentInterfaceName));
                    interfaceStateException.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.TYPE_MISMATCH;
                    interfaceStateException.ScopeType = Standard.Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY;
                    interfaceStateException.Scope = "type";
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
            var validationResult = standardValidator.Validate((o) => o.ValidateNodeInStandard<T>(categoryType, type, subType));

            if (standardValidator.Exceptions.Any())
            {
                foreach (var exception in standardValidator.Exceptions)
                    validator.Context.Exceptions.Add(exception);
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
                        var extendedTypeException = validator.AddError($"Extended type already exists.", Pairings.Of("type", type), Pairings.Of("version", validator.Context.Node.MtconnectVersion.ToName()));
                        extendedTypeException.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.EXTENDED;
                        extendedTypeException.ScopeType = Standard.Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY;
                        extendedTypeException.Scope = "type";
                    }
                    else
                    {
                        var extendedTypeMessage = validator.AddMessage($"Extended type.", Pairings.Of("type", type));
                        extendedTypeMessage.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.EXTENDED;
                        extendedTypeMessage.ScopeType = Standard.Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY;
                        extendedTypeMessage.Scope = "type";
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
                    var invalidVersionException = validator.AddError(INVALID_TYPE_ERROR, Pairings.Of("type", type));
                    invalidVersionException.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.TYPE_MISMATCH;
                    invalidVersionException.ScopeType = Standard.Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY;
                    invalidVersionException.Scope = "type";
                    isValidType = false;
                }
            }
            else if (!EnumHelper.IsImplemented<T>(type, implementedVersion))
            {
                // At this point, type is implemented in the standard, just not the implementedVersion
                if (categoryType != CategoryEnum.CONDITION
                    || ((!EnumHelper.IsImplemented<EventTypes>(type, implementedVersion)
                            && !EnumHelper.IsImplemented<InterfaceEventEnum>(type, implementedVersion))
                        && !EnumHelper.IsImplemented<SampleTypes>(type, implementedVersion)))
                {
                    var invalidVersionException = validator.AddWarning($"Invalid 'type' value. Not implemented.", Pairings.Of("type", type), Pairings.Of("version", implementedVersion.ToName()));
                    invalidVersionException.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.TYPE_MISMATCH;
                    invalidVersionException.ScopeType = Standard.Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY;
                    invalidVersionException.Scope = "type";
                }
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
                        var invalidSubTypeException = validator.AddWarning(INVALID_SUB_TYPE_ERROR, Pairings.Of("subType", subType));
                        invalidSubTypeException.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.TYPE_MISMATCH;
                        invalidSubTypeException.ScopeType = Standard.Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY;
                        invalidSubTypeException.Scope = "subType";
                        isValidSubType = false;
                    }
                    else if (!EnumHelper.IsImplemented(obsSubType.SubTypeEnum, subType, implementedVersion))
                    {
                        var invalidSubTypeException = validator.AddWarning($"Invalid 'subType' value. Not implemented.", Pairings.Of("subType", subType), Pairings.Of("version", implementedVersion.ToName()));
                        invalidSubTypeException.Code = Standard.Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.TYPE_MISMATCH;
                        invalidSubTypeException.ScopeType = Standard.Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY;
                        invalidSubTypeException.Scope = "subType";
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
