using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using System.Collections.Generic;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <summary>
    /// An XML element that contains technical information about a piece of equipment describing its physical layout or functional characteristics.
    /// </summary>
    /// <remarks>See Part 2 Section 4.4.3.2 of the MTConnect specification</remarks>
    public class ComponentConfiguration : MtconnectNode
    {
        private List<CoordinateSystem> _coordinateSystems = new List<CoordinateSystem>();
        /// <inheritdoc cref="ComponentConfigurationElements.COORDINATE_SYSTEMS"/>
        [MtconnectNodeElements("CoordinateSystems/*", nameof(TryAddCoordinateSystem))]
        public ICollection<CoordinateSystem> CoordinateSystems => _coordinateSystems;

        private List<Motion> _motion = new List<Motion>();
        /// <inheritdoc cref="ComponentConfigurationElements.MOTION"/>
        [MtconnectNodeElements("Motion/*", nameof(TryAddMotion))]
        public ICollection<Motion> Motion => _motion;

        private List<ConfigurationRelationship> _relationships = new List<ConfigurationRelationship>();
        /// <inheritdoc cref="ComponentConfigurationElements.RELATIONSHIPS"/>
        [MtconnectNodeElements("Relationships/*", nameof(TryAddRelationship))]
        public ICollection<ConfigurationRelationship> Relationships => _relationships;

        private List<SensorConfiguration> _sensorConfiguration = new List<SensorConfiguration>();
        /// <inheritdoc cref="ComponentConfigurationElements.SENSOR_CONFIGURATION"/>
        [MtconnectNodeElements("SensorConfiguration/*", nameof(TryAddSensorConfiguration))]
        public ICollection<SensorConfiguration> SensorConfiguration => _sensorConfiguration;

        private List<SolidModel> _solidModel = new List<SolidModel>();
        /// <inheritdoc cref="ComponentConfigurationElements.SOLID_MODEL"/>
        [MtconnectNodeElements("SolidModel/*", nameof(TryAddSolidModel))]
        public ICollection<SolidModel> SolidModel => _solidModel;

        private List<Specification> _specifications = new List<Specification>();
        /// <inheritdoc cref="ComponentConfigurationElements.SPECIFICATIONS"/>
        [MtconnectNodeElements("Specifications/*", nameof(TryAddSpecification))]
        public ICollection<Specification> Specifications => _specifications;

        /// <inheritdoc />
        public ComponentConfiguration() : base() { }

        /// <inheritdoc />
        public ComponentConfiguration(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        public bool TryAddCoordinateSystem(XmlNode xNode, XmlNamespaceManager nsmgr, out CoordinateSystem coordinateSystem)
            => base.TryAdd<CoordinateSystem>(xNode, nsmgr, ref _coordinateSystems, out coordinateSystem);

        public bool TryAddMotion(XmlNode xNode, XmlNamespaceManager nsmgr, out Motion motion)
            => base.TryAdd<Motion>(xNode, nsmgr, ref _motion, out motion);

        public bool TryAddRelationship(XmlNode xNode, XmlNamespaceManager nsmgr, out ConfigurationRelationship relationship)
        {
            Logger.Verbose("Reading Relationship {XnodeKey}", xNode.TryGetAttribute(ConfigurationRelationshipAttributes.ID));
            if (xNode.LocalName == ComponentConfigurationElements.DEVICE_RELATIONSHIP.ToPascalCase())
            {
                relationship = new DeviceRelationship(xNode, nsmgr, MtconnectVersion.GetValueOrDefault());
            } else if (xNode.LocalName == ComponentConfigurationElements.COMPONENT_RELATIONSHIP.ToPascalCase()) {
                relationship = new ComponentRelationship(xNode, nsmgr, MtconnectVersion.GetValueOrDefault());
            } else {
                Logger.Warn("[Invalid Probe] Relationship {XnodeTag} is not supported", xNode.LocalName);
                relationship = null;
                return false;
            }

            if (!relationship.TryValidate())
            {
                //Logger.Warn($"[Invalid Probe] Relationship:\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            _relationships.Add(relationship);
            return true;
        }

        public bool TryAddSensorConfiguration(XmlNode xNode, XmlNamespaceManager nsmgr, out SensorConfiguration sensorConfiguration)
            => base.TryAdd<SensorConfiguration>(xNode, nsmgr, ref _sensorConfiguration, out sensorConfiguration);

        public bool TryAddSolidModel(XmlNode xNode, XmlNamespaceManager nsmgr, out SolidModel solidModel)
            => base.TryAdd<SolidModel>(xNode, nsmgr, ref _solidModel, out solidModel);

        public bool TryAddSpecification(XmlNode xNode, XmlNamespaceManager nsmgr, out Specification specification)
            => base.TryAdd<Specification>(xNode, nsmgr, ref _specifications, out specification);

    }
}
