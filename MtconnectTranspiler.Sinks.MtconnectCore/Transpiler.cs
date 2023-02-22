using ConsoulLibrary;
using Microsoft.Extensions.Logging;
using MtconnectTranspiler.Model;
using MtconnectTranspiler.Sinks.CSharp;
using MtconnectTranspiler.Sinks.CSharp.Models;
using MtconnectTranspiler.Sinks.MtconnectCore.Models;
using MtconnectTranspiler.Xmi.UML;
using Scriban.Runtime;

namespace MtconnectTranspiler.Sinks.MtconnectCore
{
    public class CategoryFunctions : ScriptObject
    {
        public static bool CategoryContains(MtconnectCoreEnum @enum, EnumItem item) => @enum.SubTypes.ContainsKey(item.Name);
    }
    internal class Transpiler : CsharpTranspiler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectPath">Expected to be <c>MtconnectCore/Standard/Contracts</c></param>
        public Transpiler(string projectPath, ILogger<Transpiler> logger = default) : base(projectPath, logger) { }

        public override void Transpile(MTConnectModel model, CancellationToken cancellationToken = default(CancellationToken))
        {
            _logger?.LogInformation("Received MTConnectModel, beginning transpilation");

            Model.SetValue("model", model, true);

            base.TemplateContext.PushGlobal(new CategoryFunctions());

            const string DataItemNamespace = "MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes";
            const string DataItemValueNamespace = "MtconnectCore.Standard.Contracts.Enums.Streams";

            // Process DataItem Types
            List<MtconnectCoreEnum> dataItemTypeEnums = new List<MtconnectCoreEnum>();
            var valueEnums = new List<MtconnectCoreEnum>();
            string[] categories = new string[] { "Sample", "Event", "Condition" };

            foreach (var category in categories)
            {
                // Get the UmlPackage for the category (ie. Samples, Events, Conditions).
                var typesPackage = model
                    ?.ObservationInformationModel
                    ?.ObservationTypes
                    ?.Elements
                    ?.Where(o => o.Name == $"{category} Types")
                    ?.FirstOrDefault() as UmlPackage;
                // Get all DataItem Type and SubType references
                var allTypes = typesPackage
                    ?.Elements
                    ?.Where(o => o is UmlClass)
                    ?.Select(o => o as UmlClass);
                // Filter to get just the Type references
                var types = allTypes
                    ?.Where(o => !o.Name.Contains("."));
                // Filter and group each SubType by the relevant Type reference
                var subTypes = allTypes
                    ?.Where(o => o.Name.Contains("."))
                    ?.GroupBy(o => o.Name.Substring(0, o.Name.IndexOf(".")), o => o)
                    ?.Where(o => o.Any())
                    ?.ToDictionary(o => o.Key, o => o?.ToList());

                var categoryEnum = new MtconnectCoreEnum(model, typesPackage, $"{category}Types") { Namespace = DataItemNamespace };

                foreach (var type in types)
                {
                    // Add type to CATEGORY enum
                    categoryEnum.AddItem(model, type);

                    // Find value
                    var typeResult = type?.Properties?.FirstOrDefault(o => o.Name == "result");
                    if (typeResult != null)
                    {
                        var typeValuesSysEnum = model
                            ?.Profile
                            ?.ProfileDataTypes
                            ?.Elements
                            ?.FirstOrDefault(o => o is UmlEnumeration && o.Id == typeResult.Id);
                        var typeValuesEnum = new MtconnectCoreEnum(model, typeValuesSysEnum as UmlEnumeration, $"{type.Name}Values");
                        valueEnums.Add(typeValuesEnum);
                    }

                    // Add subType as enum
                    if (subTypes.ContainsKey(type.Name))
                    {
                        // Register type as having a subType in the CATEGORY enum
                        if (!categoryEnum.SubTypes.ContainsKey(type.Name)) categoryEnum.SubTypes.Add(ScribanHelperMethods.ToUpperSnakeCode(type.Name), $"{type.Name}SubTypes");

                        var typeSubTypes = subTypes[type.Name];
                        var subTypeEnum = new MtconnectCoreEnum(model, type, $"{type.Name}SubTypes") { Namespace = DataItemNamespace };

                        subTypeEnum.AddItems(model, typeSubTypes);

                        // Cleanup Enum names
                        foreach (var item in subTypeEnum.Items)
                        {
                            if (!item.Name.Contains(".")) continue;
                            item.Name = ScribanHelperMethods.ToUpperSnakeCode(item.Name.Substring(item.Name.IndexOf(".") + 1));
                        }

                        // Register the DataItem SubType Enum
                        dataItemTypeEnums.Add(subTypeEnum);
                    }
                }

                // Cleanup Enum names
                foreach (var item in categoryEnum.Items)
                {
                    item.Name = ScribanHelperMethods.ToUpperSnakeCode(item.Name);
                }

                // Register the DataItem Category Enum (ie. Samples, Events, Conditions)
                dataItemTypeEnums.Add(categoryEnum);
            }

            _logger?.LogInformation($"Processing {dataItemTypeEnums.Count} DataItem types/subTypes");

            // Process the template into enum files
            processTemplate(dataItemTypeEnums, Path.Combine(ProjectPath, "Enums", "Devices", "DataItemTypes"), true);
            processTemplate(valueEnums, Path.Combine(ProjectPath, "Enums", "Streams"), true);

            // Process DataItem Values
            List<MtconnectCoreEnum> dataItemValues = new List<MtconnectCoreEnum>();

        }

        private void processDeviceModel(MTConnectDeviceInformationModel model, string @namespace = "MtconnectCore.Standard")
        {
            if (model == null) return;

            if (model.Classes != null && model.Classes.Any())
            {
                // NOTE: For now, do not build classes with this solution
                //processTemplate(
                //    model.Classes.Select(o => new MtconnectCoreClass(Model["model"] as MTConnectModel, o) { Namespace = $"{@namespace}.{o.Name}" }),
                //    ProjectPath
                //);
            }

            if (model.SubModels != null && model.SubModels.Any())
            {
                // Recursively build sub-class structure
                foreach (var subModel in model.SubModels)
                {
                    if (subModel.Name == "Component Types")
                    {
                        // Convert Component Classes into Enums
                        // Process Enums
                        processTemplate(
                            new MtconnectCoreEnum(Model["model"] as MTConnectModel, subModel),
                            Path.Combine(ProjectPath, "Enums", "Devices", "ComponentTypes"));
                    }
                    else
                    {
                        processDeviceModel(subModel, $"{@namespace}.{model.Name}");
                    }
                }
            }
        }
    }
}
