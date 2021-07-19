using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using MtconnectCore.Standard.Contracts.Errors;
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
        [MtconnectNodeElements("CoordinateSystems/*", nameof(TryAddCoordinateSystem), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ICollection<CoordinateSystem> CoordinateSystems => _coordinateSystems;

        private List<Relationship> _relationships = new List<Relationship>();
        /// <inheritdoc cref="ComponentConfigurationElements.RELATIONSHIPS"/>
        [MtconnectNodeElements("Relationships/*", nameof(TryAddRelationship), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ICollection<Relationship> Relationships => _relationships;

        private List<SensorConfiguration> _sensorConfiguration = new List<SensorConfiguration>();
        /// <inheritdoc cref="ComponentConfigurationElements.SENSOR_CONFIGURATION"/>
        [MtconnectNodeElements("SensorConfiguration/*", nameof(TryAddSensorConfiguration), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ICollection<SensorConfiguration> SensorConfiguration => _sensorConfiguration;

        private List<Specification> _specifications = new List<Specification>();
        /// <inheritdoc cref="ComponentConfigurationElements.SPECIFICATIONS"/>
        [MtconnectNodeElements("Specifications/*", nameof(TryAddSpecification), XmlNamespace = Constants.DEFAULT_DEVICES_XML_NAMESPACE)]
        public ICollection<Specification> Specifications => _specifications;

        /// <inheritdoc cref="MtconnectNode.MtconnectNode()"/>
        public ComponentConfiguration() : base() { }

        /// <inheritdoc cref="MtconnectNode.MtconnectNode(XmlNode, XmlNamespaceManager, string)"/>
        public ComponentConfiguration(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE) { }

        public bool TryAddCoordinateSystem(XmlNode xNode, XmlNamespaceManager nsmgr, out CoordinateSystem coordinateSystem)
        {
            Logger.Verbose("Reading CoordinateSystem {XnodeKey}", xNode.TryGetAttribute(CoordinateSystemAttributes.ID));
            coordinateSystem = new CoordinateSystem(xNode, nsmgr);
            if (!coordinateSystem.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Probe] CoordinateSystem:\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            _coordinateSystems.Add(coordinateSystem);
            return true;
        }

        public bool TryAddRelationship(XmlNode xNode, XmlNamespaceManager nsmgr, out Relationship relationship)
        {
            Logger.Verbose("Reading Relationship {XnodeKey}", xNode.TryGetAttribute(RelationshipAttributes.ID));
            if (xNode.LocalName == ComponentConfigurationElements.DEVICE_RELATIONSHIP.ToPascalCase())
            {
                relationship = new DeviceRelationship(xNode, nsmgr);
            } else if (xNode.LocalName == ComponentConfigurationElements.COMPONENT_RELATIONSHIP.ToPascalCase()) {
                relationship = new ComponentRelationship(xNode, nsmgr);
            } else {
                Logger.Warn("[Invalid Probe] Relationship {XnodeTag} is not supported", xNode.LocalName);
                relationship = null;
                return false;
            }

            if (!relationship.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Probe] Relationship:\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            _relationships.Add(relationship);
            return true;
        }

        public bool TryAddSpecification(XmlNode xNode, XmlNamespaceManager nsmgr, out Specification specification)
        {
            Logger.Verbose("Reading Specification {XnodeKey}", xNode.TryGetAttribute(SpecificationAttributes.TYPE));
            specification = new Specification(xNode, nsmgr);
            if (!specification.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Probe] Specification:\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            _specifications.Add(specification);
            return true;
        }

        public bool TryAddSensorConfiguration(XmlNode xNode, XmlNamespaceManager nsmgr, out SensorConfiguration sensorConfiguration)
        {
            Logger.Verbose("Reading SensorConfiguration");
            sensorConfiguration = new SensorConfiguration(xNode, nsmgr);
            if (!sensorConfiguration.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Probe] SensorConfiguration:\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            _sensorConfiguration.Add(sensorConfiguration);
            return true;
        }
    }
}
