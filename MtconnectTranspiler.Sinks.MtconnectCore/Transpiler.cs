using Microsoft.Extensions.Logging;
using MtconnectTranspiler.Sinks.MtconnectCore.Models;
using MtconnectTranspiler.CodeGenerators.ScribanTemplates;
using MtconnectTranspiler.Sinks.CSharp.Contracts.Interfaces;

namespace MtconnectTranspiler.Sinks.MtconnectCore
{
    internal class Transpiler
    {
        /// <inheritdoc cref="ILogger"/>
        private readonly ILogger<Transpiler> _logger;
        private readonly IScribanTemplateGenerator _generator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectPath">Expected to be <c>MtconnectCore/Standard/Contracts</c></param>
        public Transpiler(IScribanTemplateGenerator generator, ILogger<Transpiler> logger = default)
        {
            _generator = generator;
            _logger = logger;
        }

        public async Task TranspileAsync(CancellationToken token = default)
        {
            _logger?.LogInformation("Received MTConnectModel, beginning transpilation");

            const string DataItemNamespace = "MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes";
            const string DataItemValueNamespace = "MtconnectCore.Standard.Contracts.Enums.Streams";

            // Process DataItem Types/Sub-Types
            //var dataItemTypeEnums = new List<MtconnectCoreEnum>();
            //var valueEnums = new List<MtconnectCoreEnum>();
            //var valueTypes = new List<MtconnectValueType>();
            ////var unitHelper = new UnitHelper(model);

            //string[] categories = new string[] { "Sample", "Event", "Condition" };

            //var modelEnumSubTypes = Mtconnect.MtconnectModel
            //    .ObservationInformationModelPackage
            //    .ObservationTypesPackage
            //    .EventTypesPackage
            //    .Classes
            //    .Where(o => o.Name.Contains("."))
            //    .Concat(
            //        Mtconnect.MtconnectModel
            //            .ObservationInformationModelPackage
            //            .ObservationTypesPackage
            //            .SampleTypesPackage
            //            .Classes
            //            .Where(o => o.Name.Contains("."))
            //    )
            //    .Concat(
            //        Mtconnect.MtconnectModel
            //            .ObservationInformationModelPackage
            //            .ObservationTypesPackage
            //            .ConditionTypesPackage
            //            .Classes
            //            .Where(o => o.Name.Contains("."))
            //    );
            ////model.JumpToPackage(MTConnectHelper.PackageNavigationTree.Profile.DataTypes)
            ////        .Enumerations
            ////        .FirstOrDefault(o => o.Name == $"DataItemSubTypeEnum");
            //foreach (string category in categories)
            //{
            //    // Get the UmlPackage for the category (ie. Samples, Events, Conditions).
            //    var typesPackage = Mtconnect.MtconnectModel
            //        .ObservationInformationModelPackage
            //        .ObservationTypesPackage
            //        .Packages
            //        .FirstOrDefault(o => o.Name.StartsWith(category));
            //        //MTConnectHelper
            //        //.JumpToPackage(model!, MTConnectHelper.PackageNavigationTree.ObservationInformationModel.ObservationTypes)?
            //        //.Packages
            //        //.FirstOrDefault(o => o.Name == $"{category} Types")
            //        //?? throw new NullReferenceException($"Cannot find {category} package type");

            //    // Get all DataItem Type and SubType references
            //    var allTypes = typesPackage.Classes;
            //    // Filter to get just the Type references
            //    var modelTypes = (allTypes
            //        .Where(o => !o.Name.Contains('.')))
            //        ?? throw new NullReferenceException($"Cannot find {category} root types");
            //    //var modelEnumTypes = model.JumpToPackage(MTConnectHelper.PackageNavigationTree.Profile.DataTypes)
            //    //        .Enumerations
            //    //        .FirstOrDefault(o => o.Name == $"{category}Enum");
            //    // Filter and group each SubType by the relevant Type reference
            //    //var subTypes = (allTypes
            //    //    ?.Where(o => o!.Name.Contains('.'))
            //    //    ?.GroupBy(o => o!.Name[..o.Name.IndexOf(".")], o => o)
            //    //    ?.Where(o => o.Any())
            //    //    ?.ToDictionary(o => o.Key, o => o.ToList()))
            //    //    ?? throw new NullReferenceException($"Cannot find {category} sub types");

            //    var categoryEnum = new MtconnectCoreEnum(model!, typesPackage!, $"{category}Types") { Namespace = DataItemNamespace };

            //    //var dataTypesPackage = MTConnectHelper
            //    //    .JumpToPackage(model!, MTConnectHelper.PackageNavigationTree.Profile.DataTypes);

            //    foreach (UmlClass modelType in modelTypes)
            //    {
            //        //var modelTypeEnumId = (modelType.Properties?.FirstOrDefault(o => o.Name == "type")?.DefaultValue as UmlInstanceValue)
            //        //    ?.Instance;
            //        //var modelTypeEnum = modelEnumTypes
            //        //    ?.Items
            //        //    ?.FirstOrDefault(o => o.Id == modelTypeEnumId);

            //        //if (categoryEnum.Items.Any(o => o.SysML_ID == modelTypeEnum.Id))
            //        //    continue;

            //        MtconnectCoreEnum typeValuesEnum;
            //        MtconnectValueType typeValues = null;

            //        // Add type to CATEGORY enum
            //        //categoryEnum.Add(model, modelTypeEnum);

            //        string? valueType = null;

            //        // Find the value type for the observational type
            //        var typeResult = modelType?.Properties?.FirstOrDefault(o => o.Name.Equals("result", StringComparison.OrdinalIgnoreCase));
            //        if (!string.IsNullOrEmpty(typeResult?.PropertyType))
            //        {
            //            // Attempt to find a UmlEnumeration as the value type
            //            var typeValuesSysEnum = dataTypesPackage
            //                .Enumerations
            //                .GetById(typeResult?.PropertyType);
            //            // Attempt to find a UmlDataType as the value type
            //            var typeValuesSysDataType = dataTypesPackage
            //                .DataTypes
            //                .GetById(typeResult?.PropertyType);

            //            // Make first attempt to process the value type in the context of an EVENT, which uses Enumerations for some of its values
            //            if (typeValuesSysEnum != null)
            //            {
            //                valueType = "string";

            //                // Create the value type enumeration
            //                typeValues = new MtconnectEventValueType(model!, typeValuesSysEnum) {
            //                    Namespace = DataItemValueNamespace,
            //                    Name = $"{modelType!.Name}",
            //                    ReferenceId = typeValuesSysEnum.Id
            //                };

            //                // Create the Enum for value options
            //                typeValuesEnum = new MtconnectCoreEnum(model!, typeValuesSysEnum) {
            //                    Namespace = DataItemValueNamespace,
            //                    Name = $"{modelType!.Name}Values",
            //                    ReferenceId = typeValuesSysEnum.Id
            //                };
            //                // Cleanup Enum names
            //                foreach (EnumItem value in typeValuesEnum.Items)
            //                    value.Name = value.SysML_Name;

            //                // Add value type reference
            //                if (!categoryEnum.ValueTypes.ContainsKey(modelType.Name))
            //                    categoryEnum.ValueTypes.Add(CSharpHelperMethods.ToUpperSnakeCode(modelType.Name), $"{modelType.Name}Values");


            //                valueEnums.Add(typeValuesEnum);
            //            }
            //            else if (typeValuesSysDataType != null)
            //            {
            //                valueType = CSharpHelperMethods.ToPrimitiveType(typeValuesSysDataType)?.Name ?? "string";
            //            }
            //        }

            //        if (string.IsNullOrEmpty(valueType))
            //        {
            //            valueType = category == "Sample"
            //                ? "float"
            //                : category == "Condition"
            //                    ? "Condition"
            //                    : "string";
            //        }

            //        // If the previous logic didn't create value type from UmlEnumeration, try a primitive type
            //        if (typeValues == null)
            //            typeValues = new MtconnectValueType(
            //                category,
            //                valueType,
            //                model!,
            //                modelType!) {
            //                Namespace = DataItemValueNamespace,
            //                Category = category,
            //                ReferenceId = modelType!.Properties.FirstOrDefault(o => o.Name.Equals("result", StringComparison.OrdinalIgnoreCase))?.PropertyType
            //            };

            //        // Attempt to add native units
            //        string? expectedUnits = null;
            //        var unitsAttribute = modelType!.Properties.FirstOrDefault(o => o.Name.Equals("units", StringComparison.OrdinalIgnoreCase));
            //        if (unitsAttribute != null)
            //        {
            //            if (unitsAttribute.DefaultValue is UmlInstanceValue)
            //            {
            //                string defaultValueInstance = (unitsAttribute.DefaultValue as UmlInstanceValue).Instance;
            //                // Find the instance in the Profile.Data Types.UnitEnum package
            //                var unit = MTConnectHelper
            //                    .JumpToPackage(model!, MTConnectHelper.PackageNavigationTree.Profile.DataTypes)?
            //                    .Enumerations
            //                    .GetByName("UnitEnum")
            //                    .Items?
            //                    .FirstOrDefault(o => o.Id == defaultValueInstance);
            //                if (unit != null)
            //                    expectedUnits = UnitHelper.ToEnumSafe(unit.Name);
            //            }
            //            else if (unitsAttribute.DefaultValue is UmlLiteralString)
            //            {
            //                string defaultValueValue = (unitsAttribute.DefaultValue as UmlLiteralString).Value;
            //                // TODO: Check the unit.value attribute, see Amperage as an example with AMPERE
            //                expectedUnits = defaultValueValue;
            //            }
            //            else
            //            {
            //                _logger?.LogTrace("Unidentified units type: {UnitType}", unitsAttribute.DefaultValueElement.GetAttribute("type", "http://www.omg.org/spec/XMI/20131001"));
            //            }

            //            if (!string.IsNullOrEmpty(expectedUnits))
            //                unitHelper.TypeLookup.TryAdd(CSharpHelperMethods.ToUpperSnakeCode(modelType.Name!), expectedUnits);
            //        }

            //        if (typeValues != null)
            //        {
            //            typeValues.ExpectedUnits = expectedUnits;
            //            // Update value type based on presence of Unit type
            //            if (category == "Sample" && expectedUnits?.Contains("3D") == true)
            //            {
            //                typeValues.Category = "Sample3D";
            //                typeValues.ValueType = "float[]";
            //            }
            //            foreach (var value in typeValues.Items)
            //                value.Name = value.SysML_Name;
            //            valueTypes.Add(typeValues);
            //        }

            //        // Add subType as enum
            //        if (subTypes.ContainsKey(modelType.Name!))
            //        {
            //            // Register type as having a subType in the CATEGORY enum
            //            if (!categoryEnum.SubTypes.ContainsKey(modelType.Name!)) categoryEnum.SubTypes.Add(CSharpHelperMethods.ToUpperSnakeCode(modelType.Name), $"{modelType.Name}SubTypes");

            //            MtconnectCoreEnum subTypeEnum = new(model!, modelType, $"{modelType.Name}SubTypes") {
            //                Namespace = DataItemNamespace,
            //                ReferenceId = modelType.Id
            //            };

            //            List<UmlClass?>? typeSubTypes = subTypes[modelType.Name!];
            //            foreach (var typeSubType in typeSubTypes)
            //            {
            //                var modelSubTypeEnumId = (typeSubType.Properties?.FirstOrDefault(o => o.Name == "subType")?.DefaultValue as UmlInstanceValue)
            //                    ?.Instance;
            //                var modelSubTypeEnum = modelEnumSubTypes
            //                    ?.Items
            //                    ?.FirstOrDefault(o => o.Id == modelSubTypeEnumId);

            //                subTypeEnum.Add(model, typeSubType);
            //                if (modelSubTypeEnum != null)
            //                    subTypeEnum.Items.Last().Name = modelSubTypeEnum.Name;
            //            }
            //            // Cleanup Enum names
            //            foreach (EnumItem item in subTypeEnum.Items)
            //            {
            //                if (item.Name.Contains('.'))
            //                    item.Name = CSharpHelperMethods.ToUpperSnakeCode(item.SysML_Name[(item.SysML_Name.IndexOf(".") + 1)..]);

            //                // Register type as having a subType in the Value Type class
            //                if (typeValues != null && !typeValues.SubTypes.Contains(item.Name))
            //                    typeValues.SubTypes.Add(item.Name);
            //            }


            //            // Register the DataItem SubType Enum
            //            dataItemTypeEnums.Add(subTypeEnum);
            //        }
            //    }

            //    // Cleanup Enum names
            //    foreach (EnumItem item in categoryEnum.Items)
            //    {
            //        item.Name = item.SysML_Name;
            //    }

            //    // Register the DataItem Category Enum (ie. Samples, Events, Conditions)
            //    dataItemTypeEnums.Add(categoryEnum);
            //}

            var dataItemTypeEnums = new List<MtconnectCoreEnum>();
            var dataItemValueEnums = new List<MtconnectCoreEnum>();

            foreach (var type in MtconnectTranspiler.Sinks.CSharp.NavigationExtensions.GetObservationTypes())
            {
                var typeEnum = new MtconnectCoreEnum(type);

                if (typeEnum.SubTypes?.Any() == true)
                {
                    foreach (var subType in typeEnum.SubTypes)
                    {
                        dataItemTypeEnums.Add(subType);
                    }
                }

                if (typeEnum.Values?.Any() == true)
                {
                    dataItemValueEnums.Add(typeEnum);
                }

                dataItemTypeEnums.Add(typeEnum);
            }

            _logger?.LogInformation($"Processing {dataItemTypeEnums.Count} DataItem types/subTypes");

            // Process the template into enum files
            _generator.ProcessTemplate(dataItemTypeEnums.DistinctBy(o => o.Name), Path.Combine(_generator.OutputPath, "Enums", "Devices", "DataItemTypes"), true);
            _generator.ProcessTemplate(dataItemValueEnums, Path.Combine(_generator.OutputPath, "Enums", "Streams"), true);
            var dataTypes = new MtconnectCoreEnum[] {
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.CategoryEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.CompositionTypeEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.CoordinateSystemEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.CoordinateSystemTypeEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.RelationshipTypeEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.MotionActuationTypeEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.MotionTypeEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.NativeUnitEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.QualifierEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.CriticalityTypeEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.RepresentationEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.StatisticEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.UnitEnum),
            };
            foreach (var type in dataTypes)
            {
                _generator.ProcessTemplate(type, Path.Combine(_generator.OutputPath, "Enums", "Devices"));
            }
        }
    }
}
