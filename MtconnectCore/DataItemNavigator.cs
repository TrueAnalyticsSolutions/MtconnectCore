using Devices = MtconnectCore.Standard.Documents.Devices;
using Streams = MtconnectCore.Standard.Documents.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data;

namespace MtconnectCore
{
    /// <summary>
    /// A helper class for navigating Response Documents
    /// </summary>
    public static class DataItemNavigator
    {
        #region Devices Response Document
        /// <summary>
        /// Recursively collects data items from the document level
        /// </summary>
        /// <param name="document">Reference to the root document</param>
        /// <returns>Collection of data items</returns>
        public static IEnumerable<Devices.DataItem> GetAll(this Devices.DevicesDocument document)
        {
            var dataItems = new List<Devices.DataItem>();

            foreach (var device in document.Items)
            {
                var deviceItems = GetAll(device);
                if (deviceItems.Any())
                    dataItems.AddRange(deviceItems);
            }

            return dataItems;
        }
        /// <summary>
        /// Recursively collects data items from the device level
        /// </summary>
        /// <param name="device">Reference to the root device</param>
        /// <returns>Collection of data items</returns>
        public static IEnumerable<Devices.DataItem> GetAll(this Devices.Device device)
        {
            var dataItems = new List<Devices.DataItem>();
            var deviceItems = device.DataItems;
            if (deviceItems.Any())
                dataItems.AddRange(deviceItems);

            if (device.Components.Any())
            {
                foreach (var component in device.Components)
                {
                    var componentItems = GetAll(component);
                    if (componentItems.Any())
                        dataItems.AddRange(componentItems);
                }
            }

            return dataItems;
        }
        /// <summary>
        /// Recursively collects data items from the component level
        /// </summary>
        /// <param name="component">Reference to the root component</param>
        /// <returns>Collection of data items</returns>
        public static IEnumerable<Devices.DataItem> GetAll(this Devices.Component component)
        {
            var dataItems = new List<Devices.DataItem>();
            var componentItems = component.DataItems;
            if (componentItems.Any())
                dataItems.AddRange(componentItems);

            if (component.SubComponents.Any())
            {
                foreach (var subComponent in component.SubComponents)
                {
                    var subComponentItems = GetAll(subComponent);
                    if (subComponentItems.Any())
                        dataItems.AddRange(subComponentItems);
                }
            }

            return dataItems;
        }

        public static IEnumerable<Devices.Component> GetAllComponents(this Devices.DevicesDocument document)
        {
            var components = new List<Devices.Component>();

            foreach (var device in document.Items)
            {
                var deviceComponents = GetAllComponents(device);
                if (deviceComponents.Any())
                    components.AddRange(deviceComponents);
            }

            return components;
        }
        public static IEnumerable<Devices.Component> GetAllComponents(this Devices.Device device)
        {
            var components = new List<Devices.Component>();
            var deviceComponents = device.Components;
            if (deviceComponents.Any())
                components.AddRange(deviceComponents);

            if (device.Components.Any())
            {
                foreach (var component in device.Components)
                {
                    var componentItems = GetAllComponents(component);
                    if (componentItems.Any())
                        components.AddRange(componentItems);
                }
            }

            return components;
        }
        public static IEnumerable<Devices.Component> GetAllComponents(this Devices.Component component)
        {
            var components = new List<Devices.Component>();
            var componentItems = component.SubComponents;
            if (componentItems.Any())
                components.AddRange(componentItems);

            if (component.SubComponents.Any())
            {
                foreach (var subComponent in component.SubComponents)
                {
                    var subComponentItems = GetAllComponents(subComponent);
                    if (subComponentItems.Any())
                        components.AddRange(subComponentItems);
                }
            }

            return components;
        }

        /// <summary>
        /// Searches the data item collection for data items with the provided type (and subtype)
        /// </summary>
        /// <param name="dataItems">Reference to data item collection to search</param>
        /// <param name="type">Lookup key</param>
        /// <param name="subType">Optional, secondary lookup key</param>
        /// <returns>Collection of matches</returns>
        private static IEnumerable<Devices.DataItem> FindByType(IEnumerable<Devices.DataItem> dataItems, string type, string subType = null)
            => dataItems
                .Where(o => o.Type == type && (!string.IsNullOrEmpty(subType) ? o.SubType == subType : true));
        /// <summary>
        /// Searches the document structure for data items with the provided type (and subtype)
        /// </summary>
        /// <param name="document">Reference to document structure to search</param>
        /// <param name="type">Lookup key</param>
        /// <param name="subType">Optional, secondary lookup key</param>
        /// <returns>Collection of matches</returns>
        public static IEnumerable<Devices.DataItem> FindByType(this Devices.DevicesDocument document, string type, string subType = null)
        {
            var dataItems = new List<Devices.DataItem>();

            foreach (var device in document.Items)
            {
                var deviceItems = FindByType(device, type, subType);
                if (deviceItems.Any())
                    dataItems.AddRange(deviceItems);
            }

            return dataItems;
        }
        /// <summary>
        /// Searches the device structure for data items with the provided type (and subtype)
        /// </summary>
        /// <param name="device">Reference to device structure to search</param>
        /// <param name="type">Lookup key</param>
        /// <param name="subType">Optional, secondary lookup key</param>
        /// <returns>Collection of matches</returns>
        public static IEnumerable<Devices.DataItem> FindByType(this Devices.Device device, string type, string subType = null)
        {
            var dataItems = new List<Devices.DataItem>();
            var deviceItems = FindByType(device.DataItems, type, subType);
            if (deviceItems.Any())
                dataItems.AddRange(deviceItems);

            if (device.Components.Any())
            {
                foreach (var component in device.Components)
                {
                    var componentItems = FindByType(component, type, subType);
                    if (componentItems.Any())
                        dataItems.AddRange(componentItems);
                }
            }

            return dataItems;
        }
        /// <summary>
        /// Searches the component structure for data items with the provided type (and subtype)
        /// </summary>
        /// <param name="component">Reference to component structure to search</param>
        /// <param name="type">Lookup key</param>
        /// <param name="subType">Optional, secondary lookup key</param>
        /// <returns>Collection of matches</returns>
        public static IEnumerable<Devices.DataItem> FindByType(this Devices.Component component, string type, string subType = null)
        {
            var dataItems = new List<Devices.DataItem>();
            var componentItems = FindByType(component.DataItems, type, subType);
            if (componentItems.Any())
                dataItems.AddRange(componentItems);

            if (component.SubComponents.Any())
            {
                foreach (var subComponent in component.SubComponents)
                {
                    var subComponentItems = FindByType(subComponent, type, subType);
                    if (subComponentItems.Any())
                        dataItems.AddRange(subComponentItems);
                }
            }

            return dataItems;
        }

        /// <summary>
        /// Searches the data item collection for data items with the provided id
        /// </summary>
        /// <param name="dataItems">Reference to data item collection to search</param>
        /// <param name="dataItemId">Lookup key</param>
        /// <returns>Collection of matches</returns>
        private static IEnumerable<Devices.DataItem> FindById(IEnumerable<Devices.DataItem> dataItems, string dataItemId)
            => dataItems
                .Where(o => o.Id == dataItemId);
        /// <summary>
        /// Searches the document structure for data items with the provided id
        /// </summary>
        /// <param name="document">Reference to document structure to search</param>
        /// <param name="dataItemId">Lookup key</param>
        /// <returns>Collection of matches</returns>
        public static IEnumerable<Devices.DataItem> FindById(this Devices.DevicesDocument document, string dataItemId)
        {
            var dataItems = new List<Devices.DataItem>();

            foreach (var device in document.Items)
            {
                var deviceItems = FindById(device, dataItemId);
                if (deviceItems.Any())
                    dataItems.AddRange(deviceItems);
            }

            return dataItems;
        }
        /// <summary>
        /// Searches the device structure for data items with the provided id
        /// </summary>
        /// <param name="device">Reference to document structure to search</param>
        /// <param name="dataItemId">Lookup key</param>
        /// <returns>Collection of matches</returns>
        public static IEnumerable<Devices.DataItem> FindById(this Devices.Device device, string dataItemId)
        {
            var dataItems = new List<Devices.DataItem>();
            var deviceItems = FindById(device.DataItems, dataItemId);
            if (deviceItems.Any())
                dataItems.AddRange(deviceItems);

            if (device.Components.Any())
            {
                foreach (var component in device.Components)
                {
                    var componentItems = FindById(component, dataItemId);
                    if (componentItems.Any())
                        dataItems.AddRange(componentItems);
                }
            }

            return dataItems;
        }
        /// <summary>
        /// Searches the component structure for data items with the provided id
        /// </summary>
        /// <param name="component">Reference to document structure to search</param>
        /// <param name="dataItemId">Lookup key</param>
        /// <returns>Collection of matches</returns>
        public static IEnumerable<Devices.DataItem> FindById(this Devices.Component component, string dataItemId)
        {
            var dataItems = new List<Devices.DataItem>();
            var componentItems = FindById(component.DataItems, dataItemId);
            if (componentItems.Any())
                dataItems.AddRange(componentItems);

            if (component.SubComponents.Any())
            {
                foreach (var subComponent in component.SubComponents)
                {
                    var subComponentItems = FindById(subComponent, dataItemId);
                    if (subComponentItems.Any())
                        dataItems.AddRange(subComponentItems);
                }
            }

            return dataItems;
        }

        /// <summary>
        /// Searches the data item collection for data items with the provided name
        /// </summary>
        /// <param name="dataItems">Reference to data item collection to search</param>
        /// <param name="name">Lookup key</param>
        /// <returns>Collection of matches</returns>
        private static IEnumerable<Devices.DataItem> FindByName(IEnumerable<Devices.DataItem> dataItems, string name)
            => dataItems
                .Where(o => o.Name == name);
        /// <summary>
        /// Searches the document structure for data items with the provided name
        /// </summary>
        /// <param name="document">Reference to document structure to search</param>
        /// <param name="name">Lookup key</param>
        /// <returns>Collection of matches</returns>
        public static IEnumerable<Devices.DataItem> FindByName(this Devices.DevicesDocument document, string name)
        {
            var dataItems = new List<Devices.DataItem>();

            foreach (var device in document.Items)
            {
                var deviceItems = FindByName(device, name);
                if (deviceItems.Any())
                    dataItems.AddRange(deviceItems);
            }

            return dataItems;
        }
        /// <summary>
        /// Searches the device structure for data items with the provided name
        /// </summary>
        /// <param name="device">Reference to device structure to search</param>
        /// <param name="name">Lookup key</param>
        /// <returns>Collection of matches</returns>
        public static IEnumerable<Devices.DataItem> FindByName(this Devices.Device device, string name)
        {
            var dataItems = new List<Devices.DataItem>();
            var deviceItems = FindByName(device.DataItems, name);
            if (deviceItems.Any())
                dataItems.AddRange(deviceItems);

            if (device.Components.Any())
            {
                foreach (var component in device.Components)
                {
                    var componentItems = FindByName(component, name);
                    if (componentItems.Any())
                        dataItems.AddRange(componentItems);
                }
            }

            return dataItems;
        }
        /// <summary>
        /// Searches the component structure for data items with the provided name
        /// </summary>
        /// <param name="component">Reference to component structure to search</param>
        /// <param name="name">Lookup key</param>
        /// <returns>Collection of matches</returns>
        public static IEnumerable<Devices.DataItem> FindByName(this Devices.Component component, string name)
        {
            var dataItems = new List<Devices.DataItem>();
            var componentItems = FindByName(component.DataItems, name);
            if (componentItems.Any())
                dataItems.AddRange(componentItems);

            if (component.SubComponents.Any())
            {
                foreach (var subComponent in component.SubComponents)
                {
                    var subComponentItems = FindByName(subComponent, name);
                    if (subComponentItems.Any())
                        dataItems.AddRange(subComponentItems);
                }
            }

            return dataItems;
        }
        #endregion

        #region Streams Response Document
        /// <summary>
        /// Recursively collects data items from the document level
        /// </summary>
        /// <param name="document">Reference to the root document</param>
        /// <returns>Collection of data items</returns>
        public static IEnumerable<Streams.Observation> GetAll(this Streams.StreamsDocument document)
        {
            var dataItems = new List<Streams.Observation>();

            foreach (var device in document.Items)
            {
                var deviceItems = GetAll(device);
                if (deviceItems.Any())
                    dataItems.AddRange(deviceItems);
            }

            return dataItems;
        }
        /// <summary>
        /// Recursively collects data items from the device level
        /// </summary>
        /// <param name="device">Reference to the root device</param>
        /// <returns>Collection of data items</returns>
        public static IEnumerable<Streams.Observation> GetAll(this Streams.Device device)
        {
            var dataItems = new List<Streams.Observation>();

            if (device.Components.Any())
            {
                foreach (var component in device.Components)
                {
                    var componentItems = GetAll(component);
                    if (componentItems.Any())
                        dataItems.AddRange(componentItems);
                }
            }

            return dataItems;
        }
        /// <summary>
        /// Recursively collects data items from the component level
        /// </summary>
        /// <param name="component">Reference to the root component</param>
        /// <returns>Collection of data items</returns>
        public static IEnumerable<Streams.Observation> GetAll(this Streams.Component component)
        {
            var dataItems = new List<Streams.Observation>();
            if (component.Conditions.Any())
                dataItems.AddRange(component.Conditions);
            if (component.Events.Any())
                dataItems.AddRange(component.Events);
            if (component.Samples.Any())
                dataItems.AddRange(component.Samples);

            return dataItems;
        }

        public static IEnumerable<Streams.Component> GetAllComponents(this Streams.StreamsDocument document)
        {
            var components = new List<Streams.Component>();

            foreach (var device in document.Items)
            {
                var deviceComponents = GetAllComponents(device);
                if (deviceComponents.Any())
                    components.AddRange(deviceComponents);
            }

            return components;
        }
        public static IEnumerable<Streams.Component> GetAllComponents(this Streams.Device device)
        {
            var components = new List<Streams.Component>();
            var deviceComponents = device.Components;
            if (deviceComponents.Any())
                components.AddRange(deviceComponents);

            return components;
        }

        /// <summary>
        /// Searches the observation collection for observations with the provided type (and subtype)
        /// </summary>
        /// <param name="observations">Reference to observation collection to search</param>
        /// <param name="type">Lookup key</param>
        /// <param name="subType">Optional, secondary lookup key</param>
        /// <returns>Collection of matches</returns>
        private static IEnumerable<Streams.Observation> FindByType(IEnumerable<Streams.Observation> observations, string type, string subType = null)
            => observations
                .Where(o => o.Type == type && (!string.IsNullOrEmpty(subType) ? o.SubType == subType : true));
        /// <summary>
        /// Searches the document structure for observations with the provided type (and subtype)
        /// </summary>
        /// <param name="document">Reference to document structure to search</param>
        /// <param name="type">Lookup key</param>
        /// <param name="subType">Optional, secondary lookup key</param>
        /// <returns>Collection of matches</returns>
        public static IEnumerable<Streams.Observation> FindByType(this Streams.StreamsDocument document, string type, string subType = null)
        {
            var observations = new List<Streams.Observation>();

            foreach (var device in document.Items)
            {
                var deviceObservations = FindByType(device, type, subType);
                if (deviceObservations.Any())
                    observations.AddRange(deviceObservations);
            }

            return observations;
        }
        /// <summary>
        /// Searches the device structure for observations with the provided type (and subtype)
        /// </summary>
        /// <param name="device">Reference to device structure to search</param>
        /// <param name="type">Lookup key</param>
        /// <param name="subType">Optional, secondary lookup key</param>
        /// <returns>Collection of matches</returns>
        public static IEnumerable<Streams.Observation> FindByType(this Streams.Device device, string type, string subType = null)
        {
            var observations = new List<Streams.Observation>();

            var deviceObservations = new List<Streams.Observation>();
            if (deviceObservations.Any())
                observations.AddRange(deviceObservations);

            foreach (var component in device.Components)
            {
                var componentObservations = FindByType(component, type, subType);
                if (componentObservations.Any())
                    observations.AddRange(componentObservations);
            }

            return observations;
        }
        /// <summary>
        /// Searches the component structure for observations with the provided type (and subtype)
        /// </summary>
        /// <param name="component">Reference to component structure to search</param>
        /// <param name="type">Lookup key</param>
        /// <param name="subType">Optional, secondary lookup key</param>
        /// <returns>Collection of matches</returns>
        public static IEnumerable<Streams.Observation> FindByType(this Streams.Component component, string type, string subType = null)
        {
            var observations = new List<Streams.Observation>();

            var componentEvents = FindByType(component.Events, type, subType);
            if (componentEvents.Any())
                observations.AddRange(componentEvents);
            var componentConditions = FindByType(component.Conditions, type, subType);
            if (componentConditions.Any())
                observations.AddRange(componentConditions);
            var componentSamples = FindByType(component.Samples, type, subType);
            if (componentSamples.Any())
                observations.AddRange(componentSamples);

            return observations;
        }

        /// <summary>
        /// Searches the observation collection for observations with the provided id
        /// </summary>
        /// <param name="observations">Reference to observation collection to search</param>
        /// <param name="dataItemId">Lookup key</param>
        /// <returns>Collection of matches</returns>
        private static IEnumerable<Streams.Observation> FindById(IEnumerable<Streams.Observation> observations, string dataItemId)
            => observations
                .Where(o => o.DataItemId == dataItemId);
        /// <summary>
        /// Searches the document structure for observations with the provided id
        /// </summary>
        /// <param name="document">Reference to document structure to search</param>
        /// <param name="dataItemId">Lookup key</param>
        /// <returns>Collection of matches</returns>
        public static IEnumerable<Streams.Observation> FindById(this Streams.StreamsDocument document, string dataItemId)
        {
            var observations = new List<Streams.Observation>();

            foreach (var device in document.Items)
            {
                var deviceObservations = FindById(device, dataItemId);
                if (deviceObservations.Any())
                    observations.AddRange(deviceObservations);
            }

            return observations;
        }
        /// <summary>
        /// Searches the device structure for observations with the provided id
        /// </summary>
        /// <param name="device">Reference to device structure to search</param>
        /// <param name="dataItemId">Lookup key</param>
        /// <returns>Collection of matches</returns>
        public static IEnumerable<Streams.Observation> FindById(this Streams.Device device, string dataItemId)
        {
            var observations = new List<Streams.Observation>();

            var deviceObservations = new List<Streams.Observation>();
            if (deviceObservations.Any())
                observations.AddRange(deviceObservations);

            foreach (var component in device.Components)
            {
                var componentObservations = FindById(component, dataItemId);
                if (componentObservations.Any())
                    observations.AddRange(componentObservations);
            }

            return observations;
        }
        /// <summary>
        /// Searches the component structure for observations with the provided id
        /// </summary>
        /// <param name="component">Reference to component structure to search</param>
        /// <param name="dataItemId">Lookup key</param>
        /// <returns>Collection of matches</returns>
        public static IEnumerable<Streams.Observation> FindById(this Streams.Component component, string dataItemId)
        {
            var observations = new List<Streams.Observation>();

            var componentEvents = FindById(component.Events, dataItemId);
            if (componentEvents.Any())
                observations.AddRange(componentEvents);
            var componentConditions = FindById(component.Conditions, dataItemId);
            if (componentConditions.Any())
                observations.AddRange(componentConditions);
            var componentSamples = FindById(component.Samples, dataItemId);
            if (componentSamples.Any())
                observations.AddRange(componentSamples);

            return observations;
        }

        /// <summary>
        /// Searches the observation collection for observations with the provided name
        /// </summary>
        /// <param name="observations">Reference to observation collection to search</param>
        /// <param name="name">Lookup key</param>
        /// <returns>Collection of matches</returns>
        private static IEnumerable<Streams.Observation> FindByName(IEnumerable<Streams.Observation> observations, string name)
            => observations
                .Where(o => o.Name == name);
        /// <summary>
        /// Searches the documen structure for observations with the provided name
        /// </summary>
        /// <param name="document">Reference to document structure to search</param>
        /// <param name="name">Lookup key</param>
        /// <returns>Collection of matches</returns>
        public static IEnumerable<Streams.Observation> FindByName(this Streams.StreamsDocument document, string name)
        {
            var observations = new List<Streams.Observation>();

            foreach (var device in document.Items)
            {
                var deviceObservations = FindByName(device, name);
                if (deviceObservations.Any())
                    observations.AddRange(deviceObservations);
            }

            return observations;
        }
        /// <summary>
        /// Searches the device structure for observations with the provided name
        /// </summary>
        /// <param name="device">Reference to device structure to search</param>
        /// <param name="name">Lookup key</param>
        /// <returns>Collection of matches</returns>
        public static IEnumerable<Streams.Observation> FindByName(this Streams.Device device, string name)
        {
            var observations = new List<Streams.Observation>();

            var deviceObservations = new List<Streams.Observation>();
            if (deviceObservations.Any())
                observations.AddRange(deviceObservations);

            foreach (var component in device.Components)
            {
                var componentObservations = FindByName(component, name);
                if (componentObservations.Any())
                    observations.AddRange(componentObservations);
            }

            return observations;
        }
        /// <summary>
        /// Searches the component structure for observations with the provided name
        /// </summary>
        /// <param name="component">Reference to component structure to search</param>
        /// <param name="name">Lookup key</param>
        /// <returns>Collection of matches</returns>
        public static IEnumerable<Streams.Observation> FindByName(this Streams.Component component, string name)
        {
            var observations = new List<Streams.Observation>();

            var componentEvents = FindByName(component.Events, name);
            if (componentEvents.Any())
                observations.AddRange(componentEvents);
            var componentConditions = FindByName(component.Conditions, name);
            if (componentConditions.Any())
                observations.AddRange(componentConditions);
            var componentSamples = FindByName(component.Samples, name);
            if (componentSamples.Any())
                observations.AddRange(componentSamples);

            return observations;
        }
        #endregion
    }
}
