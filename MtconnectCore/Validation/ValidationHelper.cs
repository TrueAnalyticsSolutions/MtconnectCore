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
    internal static class ValidationHelper
    {

        internal static IEnumerable<MtconnectValidationException> validateId(this MtconnectNode node, string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                yield return new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Missing 'id' value.",
                    node.SourceNode);
            }
        }

        internal static IEnumerable<MtconnectValidationException> validateCategory(this MtconnectNode node, string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                yield return new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Missing 'category' value.",
                    node.SourceNode);
            }
            else if (!EnumHelper.Contains<CategoryTypes>(category))
            {
                yield return new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Invalid 'category' value.",
                    node.SourceNode);
            }
        }

        internal static IEnumerable<MtconnectValidationException> validateType(this MtconnectNode node, string category, string type, string subType)
        {
            if (string.IsNullOrEmpty(type))
            {
                yield return new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Missing 'type' value.",
                    node.SourceNode);
            }
            else if (!string.IsNullOrEmpty(category))
            {
                if (Enum.TryParse<CategoryTypes>(category, out CategoryTypes categoryType))
                {
                    IEnumerable<MtconnectValidationException> exceptions = Enumerable.Empty<MtconnectValidationException>();
                    switch (categoryType)
                    {
                        case CategoryTypes.SAMPLE:
                            exceptions = validateNode<SampleTypes>(node, categoryType, type, subType);
                            break;
                        case CategoryTypes.EVENT:
                            exceptions = validateNode<EventTypes>(node, categoryType, type, subType);
                            break;
                        case CategoryTypes.CONDITION:
                            exceptions = validateNode<ConditionTypes>(node, categoryType, type, subType);
                            break;
                        default:
                            break;
                    }
                    foreach (var exception in exceptions)
                        yield return exception;
                }
            }
        }

        internal static IEnumerable<MtconnectValidationException> validateNode<T>(this MtconnectNode node, CategoryTypes categoryType, string type, string subType) where T : Enum
        {
            var extensionErrors = validateNodeExtension<T>(node, categoryType, type, subType);

            if (extensionErrors.Any())
            {
                foreach (var extensionError in extensionErrors)
                    yield return extensionError;
                if (extensionErrors.Any(o => o.Severity == ValidationSeverity.ERROR))
                    yield break;
            }

            var standardErrors = validateNodeInStandard<T>(node, categoryType, type, subType);

            if (standardErrors.Any())
            {
                foreach (var standardError in standardErrors)
                    yield return standardError;
            }
        }

        internal static IEnumerable<MtconnectValidationException> validateNodeExtension<T>(this MtconnectNode node, CategoryTypes categoryType, string type, string subType) where T : Enum
        {
            if (!string.IsNullOrEmpty(type))
            {
                if (type.Contains(":"))
                {
                    var standardExceptions = validateNodeInStandard<T>(node, categoryType, type.Substring(type.LastIndexOf(":") + 1), subType);
                    if (!standardExceptions.Any(o => o.Severity == ValidationSeverity.ERROR))
                    {
                        yield return (new MtconnectValidationException(
                            ValidationSeverity.WARNING,
                            $"Extended type of '{type}' already exist in version '{node.MtconnectVersion}'.",
                            node.SourceNode));
                    }
                    else
                    {
                        yield return (new MtconnectValidationException(
                            ValidationSeverity.MESSAGE,
                            $"Extended type of '{type}' are used in this implementation.",
                            node.SourceNode));
                    }
                }
            }
        }

        internal static IEnumerable<MtconnectValidationException> validateNodeInStandard<T>(this MtconnectNode node, CategoryTypes categoryType, string type, string subType) where T : Enum
        {
            bool isValidType = true, isValidSubType = true;

            // Validate the observational type
            if (!EnumHelper.Contains<T>(type))
            {
                if (categoryType != CategoryTypes.CONDITION
                    || (!EnumHelper.Contains<MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.EventTypes>(type)
                    && !EnumHelper.Contains<MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.SampleTypes>(type)))
                {
                    yield return (new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                        $"Invalid 'type' value.",
                        node.SourceNode));
                    isValidType = false;
                }
            }
            else if (!EnumHelper.ValidateToVersion<T>(type, node.MtconnectVersion.GetValueOrDefault()))
            {
                if (categoryType != CategoryTypes.CONDITION
                    || (!EnumHelper.ValidateToVersion<MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.EventTypes>(type, node.MtconnectVersion.GetValueOrDefault())
                        && !EnumHelper.ValidateToVersion<MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes.SampleTypes>(type, node.MtconnectVersion.GetValueOrDefault())))
                    yield return (new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"Invalid 'type' value in version '{node.MtconnectVersion}'.",
                        node.SourceNode));
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
                        yield return (new MtconnectValidationException(
                            ValidationSeverity.ERROR,
                            $"Invalid 'subType' value.",
                            node.SourceNode));
                        isValidSubType = false;
                    }
                    else if (!EnumHelper.ValidateToVersion(obsSubType.SubTypeEnum, subType, node.MtconnectVersion.GetValueOrDefault()))
                    {
                        yield return (new MtconnectValidationException(
                            ValidationSeverity.WARNING,
                            $"Invalid 'subType' value in version '{node.MtconnectVersion}'.",
                            node.SourceNode));
                        isValidSubType = false;
                    }
                }
            }
        }

        internal static IEnumerable<MtconnectValidationException> validateUnits(this MtconnectNode node, string category, string units)
        {
            if (!string.IsNullOrEmpty(units))
            {
                if (units.Contains(":"))
                {
                    string extendedUnits = units.Substring(units.LastIndexOf(":") + 1);
                    if (!EnumHelper.Contains<UnitsTypes>(extendedUnits))
                    {
                        yield return (new MtconnectValidationException(
                            ValidationSeverity.WARNING,
                            $"Extended units '{extendedUnits}' already exist in version '{node.MtconnectVersion}'.",
                            node.SourceNode));
                    }
                    else if (!EnumHelper.ValidateToVersion<UnitsTypes>(extendedUnits, node.MtconnectVersion.GetValueOrDefault()))
                    {
                        yield return (new MtconnectValidationException(
                            ValidationSeverity.WARNING,
                            $"Invalid 'units' value in version '{node.MtconnectVersion}'.",
                            node.SourceNode));
                    }
                    else
                    {
                        yield return (new MtconnectValidationException(
                            ValidationSeverity.MESSAGE,
                            $"Extended units '{extendedUnits}' are used in this implementation.",
                            node.SourceNode));
                    }
                }
                else if (!EnumHelper.Contains<UnitsTypes>(units))
                {
                    yield return (new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"Invalid 'units' value.",
                        node.SourceNode));
                }
                else if (!EnumHelper.ValidateToVersion<UnitsTypes>(units, node.MtconnectVersion.GetValueOrDefault()))
                {
                    yield return (new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"Invalid 'units' value in version '{node.MtconnectVersion}'.",
                        node.SourceNode));
                }
            }
            else if (category.ToUpper() == "SAMPLE")
            {
                yield return (new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Missing 'units' value.",
                        node.SourceNode));
            }
        }

        internal static IEnumerable<MtconnectValidationException> validateNativeUnits(this MtconnectNode node, string nativeUnits)
        {
            if (!string.IsNullOrEmpty(nativeUnits))
            {
                if (!EnumHelper.Contains<NativeUnitsTypes>(nativeUnits) && !EnumHelper.Contains<UnitsTypes>(nativeUnits))
                {
                    yield return (new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"Invalid 'nativeUnits' value.",
                        node.SourceNode));
                }
                else if (!EnumHelper.ValidateToVersion<NativeUnitsTypes>(nativeUnits, node.MtconnectVersion.GetValueOrDefault()) && !EnumHelper.ValidateToVersion<UnitsTypes>(nativeUnits, node.MtconnectVersion.GetValueOrDefault()))
                {
                    yield return (new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"Invalid 'nativeUnits' value in version '{node.MtconnectVersion}'.",
                        node.SourceNode));
                }
            }
        }

        internal static IEnumerable<MtconnectValidationException> validateNativeScale(this MtconnectNode node, string nativeScale)
        {
            if (!string.IsNullOrEmpty(nativeScale) && !int.TryParse(nativeScale, out int nativeScaleValue))
            {
                yield return (new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Invalid 'nativeScale' value. It MUST be an integer.",
                    node.SourceNode));
            }
        }

        internal static IEnumerable<MtconnectValidationException> validateSampleRate(this MtconnectNode node, string sampleRate)
        {
            if (!string.IsNullOrEmpty(sampleRate) && !float.TryParse(sampleRate, out float sampleRateValue))
            {
                yield return (new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Invalid 'sampleRate' value. It MUST be a float.",
                    node.SourceNode));
            }
        }

        internal static IEnumerable<MtconnectValidationException> validateSignificantDigits(this MtconnectNode node, string significantDigits)
        {
            if (!string.IsNullOrEmpty(significantDigits) && !int.TryParse(significantDigits, out int significantDigitsValue))
            {
                yield return (new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Invalid 'significantDigits' value. It MUST be an integer.",
                    node.SourceNode));
            }
        }

        internal static IEnumerable<MtconnectValidationException> validateRepresentation_NotImplemented(this MtconnectNode node, string representation)
        {
            if (!string.IsNullOrEmpty(representation))
            {
                yield return (new MtconnectValidationException(
                ValidationSeverity.WARNING,
                    $"The 'representation' attribute is not supported until version '{MtconnectVersions.V_1_2_0}'.",
                    node.SourceNode));
            }
        }

        internal static IEnumerable<MtconnectValidationException> validateRepresentation(this MtconnectNode node, string representation)
        {
            if (!string.IsNullOrEmpty(representation))
            {
                if (!EnumHelper.Contains<RepresentationTypes>(representation))
                {
                    yield return (new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"Invalid 'representation' value.",
                        node.SourceNode));
                }
                else if (!EnumHelper.ValidateToVersion<RepresentationTypes>(representation, node.MtconnectVersion.GetValueOrDefault()))
                {
                    yield return (new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"Invalid 'representation' value in version '{node.MtconnectVersion}'.",
                        node.SourceNode));
                }
            }
        }

        internal static IEnumerable<MtconnectValidationException> validateCoordinateSystem(this MtconnectNode node, string coordinateSystem)
        {
            if (!string.IsNullOrEmpty(coordinateSystem))
            {
                if (!EnumHelper.Contains<CoordinateSystemTypes>(coordinateSystem))
                {
                    yield return (new MtconnectValidationException(
                        Standard.Contracts.Enums.ValidationSeverity.WARNING,
                        $"Invalid 'coordinateSystem' value.", node.SourceNode));
                }
                else if (!EnumHelper.ValidateToVersion<CoordinateSystemTypes>(coordinateSystem, node.MtconnectVersion.GetValueOrDefault()))
                {
                    yield return (new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"Invalid 'coordinateSystem' value in version '{node.MtconnectVersion}'.",
                        node.SourceNode));
                }
            }
        }

        internal static IEnumerable<MtconnectValidationException> validateCoordinateSystem_Deprecated(this MtconnectNode node, string coordinateSystem)
        {
            if (!string.IsNullOrEmpty(coordinateSystem))
            {
                yield return (new MtconnectValidationException(
                    Standard.Contracts.Enums.ValidationSeverity.WARNING,
                    $"The 'coordinateSystem' attribute was DEPRECATED in MTConnect Version '{MtconnectVersions.V_2_0_0}'.", node.SourceNode));
            }
        }

        internal static IEnumerable<MtconnectValidationException> validateStatistic(this MtconnectNode node, string statistic)
        {
            if (!string.IsNullOrEmpty(statistic))
            {
                if (!EnumHelper.Contains<StatisticTypes>(statistic))
                {
                    yield return (new MtconnectValidationException(
                        ValidationSeverity.ERROR,
                        $"Invalid 'statistic' value.",
                        node.SourceNode));
                }
                else if (!EnumHelper.ValidateToVersion<StatisticTypes>(statistic, node.MtconnectVersion.GetValueOrDefault()))
                {
                    yield return (new MtconnectValidationException(
                        ValidationSeverity.WARNING,
                        $"Invalid 'statistic' in version '{node.MtconnectVersion}'.",
                        node.SourceNode));
                }
            }
        }

        internal static IEnumerable<MtconnectValidationException> validateResetTrigger(this MtconnectNode node, string resetTrigger)
        {
            if (!string.IsNullOrEmpty(resetTrigger) && !EnumHelper.Contains<ResetTriggeredValues>(resetTrigger))
            {
                yield return (new MtconnectValidationException(
                    ValidationSeverity.WARNING,
                    $"Invalid ResetTrigger value.",
                    node.SourceNode));
            }
        }

        internal static IEnumerable<MtconnectValidationException> validateRepresentationDiscrete_Deprecated(this MtconnectNode node, string representation)
        {
            if (!string.IsNullOrEmpty(representation) && EnumHelper.Enumify(representation).Equals(RepresentationTypes.DISCRETE))
            {
                yield return (new MtconnectValidationException(
                    ValidationSeverity.WARNING,
                    $"DataItem 'representation' of 'discrete' is obsolete, the 'discrete' attribute should be used instead.",
                    node.SourceNode));
            }
        }

    }
}
