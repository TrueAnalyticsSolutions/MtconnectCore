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
            //new MtconnectCoreEnum(Mtconnect.MtconnectModel.DeviceInformationModelPackage.ComponentsPackage.ComponentTypesPackage.Enums);
            _logger?.LogInformation($"Processing data types");
            _generator.ProcessTemplate(dataTypes, Path.Combine(_generator.OutputPath, "Enums", "DataTypes"), true);

            _logger?.LogInformation($"Processing component types");
            var componentEnum = new MtconnectCoreEnum();
            var componentTypes = new List<IEnumInstance>();
            foreach (var componentClass in Mtconnect.MtconnectModel.DeviceInformationModelPackage.ComponentsPackage.ComponentTypesPackage.Classes)
            {
                componentEnum.Values.Add(new MtconnectCoreEnumItem(componentClass));
            }
            _generator.ProcessTemplate(componentEnum, Path.Combine(_generator.OutputPath, "Enums", "ComponentTypes"), true);

            // TODO: Handle Enum and Class types for properties. Replace *EnumMetaClass with reference to newly created Enum. Replace *Class with reference to other interfaces.
            //var classes = new List<MtconnectCoreInterface>();
            //foreach (var item in MtconnectModel.Packages)
            //    getClasses(item, classes);
            //_generator.ProcessTemplate(classes, Path.Combine(_generator.OutputPath, "Interfaces"), true);
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
