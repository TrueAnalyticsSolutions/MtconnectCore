using Microsoft.Extensions.Logging;
using MtconnectTranspiler.Sinks.MtconnectCore.Models;
using MtconnectTranspiler.CodeGenerators.ScribanTemplates;
using MtconnectTranspiler.Sinks.CSharp.Contracts.Interfaces;
using Mtconnect;
using ConsoulLibrary;
using System.Data;

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

            var dataItemTypeEnums = new List<MtconnectCoreEnum>();
            var dataItemValueEnums = new List<MtconnectCoreEnum>();

            var CategoryEnum = new Dictionary<string, MtconnectCoreEnum>() {
                { "Condition", new MtconnectCoreEnum() {
                    Name = "ConditionTypes"
                } },
                { "Event", new MtconnectCoreEnum() {
                    Name = "EventTypes"
                } },
                { "Sample", new MtconnectCoreEnum() {
                    Name = "SampleTypes"
                } }
            };

            foreach (var type in MtconnectTranspiler.Sinks.CSharp.NavigationExtensions.GetObservationTypes())
            {
                var typeEnum = new MtconnectCoreEnum(type);

                CategoryEnum[type.Category].SubTypes.Add(typeEnum.Clone() as MtconnectCoreEnum);
                if (typeEnum.SubTypes?.Any() == true)
                {
                    dataItemTypeEnums.Add(typeEnum.Clone() as MtconnectCoreEnum);
                    dataItemTypeEnums[dataItemTypeEnums.Count - 1].Namespace = DataItemNamespace;
                    dataItemTypeEnums[dataItemTypeEnums.Count - 1].FilenameSuffix = "SubTypes";
                }

                if (typeEnum.Values?.Any() == true)
                {
                    var valueEnum = typeEnum.Clone() as MtconnectCoreEnum;
                    valueEnum.Namespace = DataItemValueNamespace;
                    valueEnum.FilenameSuffix = "Values";
                    valueEnum.SubTypes.Clear();
                    dataItemValueEnums.Add(valueEnum);
                }

            }

            foreach (var categoryType in CategoryEnum)
            {
                dataItemTypeEnums.Add(categoryType.Value.Clone() as MtconnectCoreEnum);
                dataItemTypeEnums[dataItemTypeEnums.Count - 1].Namespace = DataItemNamespace;
            }

            // Process the template into enum files
            _logger?.LogInformation($"Processing {dataItemTypeEnums.Count} DataItem types/subTypes");
            _generator.ProcessTemplate(dataItemTypeEnums.DistinctBy(o => o.Name), Path.Combine(_generator.OutputPath, "Enums", "Devices", "DataItemTypes"), true);

            _logger?.LogInformation($"Processing {dataItemValueEnums.Count} DataItem values");
            _generator.ProcessTemplate(dataItemValueEnums, Path.Combine(_generator.OutputPath, "Enums", "Streams"), true);

            var dataTypes = new MtconnectCoreEnum[] {
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.ApplicationCategoryEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.ApplicationTypeEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.AssetTypeEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.CategoryEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.CompositionTypeEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.CompositionStateActionEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.CompositionStateLateralEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.CompositionStateMotionEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.CompositionStateSwitchedEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.CompositionStateVerticalEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.CoordinateSystemEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.CoordinateSystemTypeEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.CriticalityTypeEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.DirectionLinearEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.DirectionRotaryEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.FileStateEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.InterfaceStateEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.RelationshipTypeEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.ResetTriggeredEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.MediaTypeEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.MotionActuationTypeEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.MotionTypeEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.NativeUnitEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.QualifierEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.CriticalityTypeEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.RepresentationEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.StatisticEnum),
                new MtconnectCoreEnum(Mtconnect.MtconnectModel.DataTypesPackage.UnitEnum),
            };
            _logger?.LogInformation($"Processing data types");
            _generator.ProcessTemplate(dataTypes, Path.Combine(_generator.OutputPath, "Enums", "DataTypes"), true);

            // Process ComponentTypes enum
            _logger?.LogInformation($"Processing component types");
            var componentEnum = new MtconnectCoreEnum() {
                Name = "ComponentTypes",
                HelpUrl = "https://model.mtconnect.org/#Package__EAPK_6BEE6977_1698_498c_87A6_34B5E656F773",
                Summary = ""
            };
            var componentTypes = new List<IEnumInstance>();
            foreach (var componentClass in Mtconnect.MtconnectModel.DeviceInformationModelPackage.ComponentsPackage.ComponentTypesPackage.Classes)
            {
                componentEnum.Values.Add(new MtconnectCoreEnumItem(componentClass));
            }
            _generator.ProcessTemplate(componentEnum, Path.Combine(_generator.OutputPath, "Enums", "Devices", "ComponentTypes"), true);

            string enumFolderName;

            // Process Device Information Model
            ProcessModelPacakgeEnums("Devices", Mtconnect.MtconnectModel.DeviceInformationModelPackage);

            // Process Device Information Model
            ProcessModelPacakgeEnums("Streams", Mtconnect.MtconnectModel.ObservationInformationModelPackage);

            // Process Asset Information Model
            ProcessModelPacakgeEnums("Assets", Mtconnect.MtconnectModel.AssetInformationModelPackage);

            // Process Interface Information Model
            ProcessModelPacakgeEnums("Interfaces", Mtconnect.MtconnectModel.InterfaceInteractionModelPackage);

            // TODO: Handle Enum and Class types for properties. Replace *EnumMetaClass with reference to newly created Enum. Replace *Class with reference to other interfaces.
            //var classes = new List<MtconnectCoreInterface>();
            //foreach (var item in MtconnectModel.Packages)
            //    getClasses(item, classes);
            //_generator.ProcessTemplate(classes, Path.Combine(_generator.OutputPath, "Interfaces"), true);
        }

        private void ProcessModelPacakgeEnums(string enumFolderName, IPackage rootPackage)
        {
            _logger?.LogInformation($"Processing {enumFolderName} Information Model");
            var elements = new List<MtconnectCoreEnum>();
            var attributes = new List<MtconnectCoreEnum>();
            ProcessDeviceInformationModel(elements, attributes, rootPackage);
            _generator.ProcessTemplate(attributes, Path.Combine(_generator.OutputPath, "Enums", enumFolderName, "Attributes"));
            _generator.ProcessTemplate(elements, Path.Combine(_generator.OutputPath, "Enums", enumFolderName, "Elements"));
        }

        private static void ProcessDeviceInformationModel(List<MtconnectCoreEnum> elementsEnums, List<MtconnectCoreEnum> attributesEnums, IPackage package)
        {
            // Process package "Classes"
            foreach (var modelClass in package.Classes)
            {
                // Process "Attributes"
                var valueProperties = modelClass.Properties.Properties.Where(o => string.IsNullOrEmpty(o.Aggregation));
                if (valueProperties.Any())
                {
                    var attributesEnum = new MtconnectCoreEnum() {
                        Name = $"{modelClass.Name}Attributes",
                        HelpUrl = modelClass.HelpUrl,
                        Summary = modelClass.Summary,
                        NormativeVersion = modelClass.NormativeVersion,
                        DeprecatedVersion = modelClass.DeprecatedVersion,
                        Values = valueProperties.Select(o => new MtconnectCoreEnumItem() {
                            Name = o.Name,
                            HelpUrl = modelClass.HelpUrl,
                            Summary = o.Summary,
                            NormativeVersion = o.NormativeVersion,
                            DeprecatedVersion = o.DeprecatedVersion
                        }).ToList()
                    };
                    attributesEnums.Add(attributesEnum);
                }

                // Process "Parts"
                var parts = modelClass.Properties.Properties.Where(o => o.Aggregation == "composite");
                if (parts.Any())
                {
                    var elementsEnum = new MtconnectCoreEnum() {
                        Name = $"{modelClass.Name}Elements",
                        HelpUrl = modelClass.HelpUrl,
                        Summary = modelClass.Summary,
                        NormativeVersion = modelClass.NormativeVersion,
                        DeprecatedVersion = modelClass.DeprecatedVersion,
                        Values = parts.Select(o => new MtconnectCoreEnumItem() {
                            Name = o.Name,
                            HelpUrl = modelClass.HelpUrl,
                            Summary = o.Summary,
                            NormativeVersion = o.NormativeVersion,
                            DeprecatedVersion = o.DeprecatedVersion
                        }).ToList()
                    };
                    elementsEnums.Add(elementsEnum);
                }
            }

            // Recurse into deeper packages
            if (package.Packages.Any())
            {
                foreach (var subPackage in package.Packages)
                {
                    ProcessDeviceInformationModel(elementsEnums, attributesEnums, subPackage);
                }
            }
        }

        internal void getClasses(IPackage package, List<MtconnectCoreInterface> classes)
        {
            const string InterfaceNamespace = "MtconnectCore.Standard.Contracts.Interfaces";
            foreach (var item in package.Classes)
                classes.Add(new MtconnectCoreInterface(item) { Namespace = InterfaceNamespace });
            foreach (var item in package.Packages)
                getClasses(item, classes);
        }
    }
}
