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
    internal static class ValidationHelper
    {
        internal static NodeValidationContext.NodeValidator ValidateType(this NodeValidationContext.NodeValidator validator, string type, string subType)
        {
            if (!string.IsNullOrEmpty(type))
            {
                foreach (CategoryTypes category in Enum.GetValues(typeof(CategoryTypes)))
                {
                    var categoryValidator = new NodeValidationContext.NodeValidator(new NodeValidationContext(validator.Context.Node));
                    switch (category)
                    {
                        case CategoryTypes.SAMPLE:
                            categoryValidator.ValidateNode<SampleTypes>(category, type, subType);
                            break;
                        case CategoryTypes.EVENT:
                            categoryValidator.ValidateNode<EventTypes>(category, type, subType);
                            break;
                        case CategoryTypes.CONDITION:
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
                            return validator;
                    }
                } else
                {
                    validator.AddError("Invalid 'category' value.", Pairings.Of("category", category));
                }
            }
            return validator;
        }

        internal static NodeValidationContext.NodeValidator ValidateNativeUnits(this NodeValidationContext.NodeValidator validator, string nativeUnits)
        {
            if (!string.IsNullOrEmpty(nativeUnits) && !EnumHelper.Contains<NativeUnitsTypes>(nativeUnits))
                if (!EnumHelper.Contains<UnitsTypes>(nativeUnits))
                    validator.AddError("Invalid 'nativeUnits' value.", Pairings.Of("nativeUnits", nativeUnits));
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
        internal static NodeValidationContext.NodeValidator ValidateNodeExtension<T>(this NodeValidationContext.NodeValidator validator, CategoryTypes categoryType, string type, string subType) where T : Enum
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
                        validator.AddWarning($"Extended type already exists.", Pairings.Of("type", type), Pairings.Of("version", validator.Context.Node.MtconnectVersion.ToName()));
                    }
                    else
                    {
                        validator.AddWarning($"Extended type used in this implementation.", Pairings.Of("type", type));
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
                    validator.AddError(INVALID_TYPE_ERROR, Pairings.Of("type", type));
                    isValidType = false;
                }
            }
            else if (!EnumHelper.IsImplemented<T>(type, implementedVersion))
            {
                if (categoryType != CategoryTypes.CONDITION
                    || (!EnumHelper.IsImplemented<MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.EventTypes>(type, implementedVersion)
                        && !EnumHelper.IsImplemented<MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.SampleTypes>(type, implementedVersion)))
                    validator.AddWarning($"Invalid 'type' value in version.", Pairings.Of("type", type), Pairings.Of("version", implementedVersion.ToName()));
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
                        validator.AddError(INVALID_SUB_TYPE_ERROR, Pairings.Of("subType", subType));
                        isValidSubType = false;
                    }
                    else if (!EnumHelper.IsImplemented(obsSubType.SubTypeEnum, subType, implementedVersion))
                    {
                        validator.AddWarning($"Invalid 'subType' value in version.", Pairings.Of("subType", subType), Pairings.Of("version", implementedVersion.ToName()));
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
