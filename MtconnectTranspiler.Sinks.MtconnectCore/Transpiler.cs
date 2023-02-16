using MtconnectTranspiler.Model;
using MtconnectTranspiler.Sinks.CSharp;
using MtconnectTranspiler.Sinks.CSharp.Models;
using MtconnectTranspiler.Sinks.MtconnectCore.Models;
using MtconnectTranspiler.Xmi.UML;

namespace MtconnectTranspiler.Sinks.MtconnectCore
{
    internal class Transpiler : CsharpTranspiler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectPath">Expected to be <c>MtconnectCore/Standard/Contracts</c></param>
        public Transpiler(string projectPath) : base(projectPath) { }

        public override void Transpile(MTConnectModel model, CancellationToken cancellationToken = default(CancellationToken))
        {
            Model.SetValue("model", model, true);

            const string DataItemNamespace = "MtconnectCore.Standard.Contracts.Enums.Devices.DataItemTypes";
            List<MtconnectCoreEnum> dataItemTypes = new List<MtconnectCoreEnum>();
            // Process DataItem Types
            string[] categories = new string[] { "Sample", "Event", "Condition" };

            foreach (var category in categories)
            {
                var typesPackage = model
                    ?.ObservationInformationModel
                    ?.ObservationTypes
                    ?.Elements
                    ?.Where(o => o.Name == $"{category} Types")
                    ?.FirstOrDefault() as UmlPackage;
                var allTypes = typesPackage
                    ?.Elements
                    ?.Where(o => o is UmlClass)
                    ?.Select(o => o as UmlClass);
                var types = allTypes
                    ?.Where(o => !o.Name.Contains("."));
                var subTypes = allTypes
                    ?.Where(o => o.Name.Contains("."))
                    ?.GroupBy(o => o.Name.Substring(0, o.Name.IndexOf(".")), o => o)
                    ?.Where(o => o.Any())
                    ?.ToDictionary(o => o.Key, o => o?.ToList());

                var categoryEnum = new MtconnectCoreEnum(model, typesPackage, $"{category}Types") { Namespace = DataItemNamespace };

                foreach (var type in types)
                {
                    categoryEnum.AddItem(model, type);

                    if (subTypes.ContainsKey(type.Name))
                    {
                        var typeSubTypes = subTypes[type.Name];
                        var subTypeEnum = new MtconnectCoreEnum(model, type, $"{type.Name}SubTypes") { Namespace = DataItemNamespace };

                        subTypeEnum.AddItems(model, typeSubTypes);

                        foreach (var item in subTypeEnum.Items)
                        {
                            item.Name = ScribanHelperMethods.ToPascalCode(subTypeEnum.Name.Substring(subTypeEnum.Name.IndexOf("." + 1)));
                        }

                        dataItemTypes.Add(subTypeEnum);
                    }
                }

                dataItemTypes.Add(categoryEnum);
            }
            // Process the template into enum files
            processTemplate(dataItemTypes, Path.Combine(ProjectPath, "Enums", "Devices", "DataItemTypes"), true);


            //// Process Enums
            //processTemplate(
            //    model?.Profile?.ProfileDataTypes?.Elements
            //    ?.Where(o => o is UmlEnumeration)
            //    ?.Select(o => new MtconnectCoreEnum(model, o as UmlEnumeration)),
            //    Path.Combine(ProjectPath, "Enums", "Devices", "DataItemTypes"));

            //processDeviceModel(model.DeviceModel);
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
                            Path.Combine(ProjectPath, "Enums", "Devices", "ComponentTypes"));// Path.Combine(ProjectPath, "Enums"));
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
