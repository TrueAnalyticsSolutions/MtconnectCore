﻿using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Elements
{
    /// <summary>
    /// Elements contained within the Component element in the MTConnect Response document.
    /// </summary>
    /// <remarks>See Part 2 Section 4.4.3 of the MTConnect specification.</remarks>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DeviceModel.COMPONENT)]
    public enum ComponentElements {
        /// <summary>
        /// An element that can contain any descriptive content.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DeviceModel.COMPONENT)]
        DESCRIPTION,
        /// <summary>
        /// A container for the Composition elements (See <see cref="MtconnectCore.Standard.Documents.Devices.Composition"/>) associated with this Component element.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, Constants.ModelBrowserLinks.DeviceModel.COMPONENT)]
        COMPOSITIONS,
        /// <summary>
        /// See <see cref="MtconnectCore.Standard.Documents.Devices.Composition"/>.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, Constants.ModelBrowserLinks.DeviceModel.COMPONENT)]
        COMPOSITION,
        /// <summary>
        /// A container for Lower Level Component XML elements associated with this parent Component.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DeviceModel.COMPONENT)]
        COMPONENTS,
        /// <summary>
        /// See <see cref="MtconnectCore.Standard.Documents.Devices.Component"/>.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DeviceModel.COMPONENT)]
        COMPONENT,
        /// <summary>
        /// An XML element that contains technical information about a piece of equipment describing its physical layout or functional characteristics.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, Constants.ModelBrowserLinks.DeviceModel.COMPONENT)]
        CONFIGURATION,
        /// <summary>
        /// A container for the Data Entities (See <see cref="MtconnectCore.Standard.Documents.Devices.DataItem"/>) associated with this Component element.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DeviceModel.COMPONENT)]
        DATA_ITEMS,
        /// <summary>
        /// See <see cref="MtconnectCore.Standard.Documents.Devices.DataItem"/>.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DeviceModel.COMPONENT)]
        DATA_ITEM,
        /// <summary>
        /// A container for the Reference elements associated with this Component element.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, Constants.ModelBrowserLinks.DeviceModel.COMPONENT)]
        REFERENCES,
        /// <summary>
        /// See <see cref="MtconnectCore.Standard.Documents.Devices.Reference"/>.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, Constants.ModelBrowserLinks.DeviceModel.COMPONENT)]
        REFERENCE,
        /// <summary>
        /// A ComponentRef element as an implementation.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, Constants.ModelBrowserLinks.DeviceModel.COMPONENT)]
        COMPONENT_REF,
        /// <summary>
        /// A DataItemRef element as an implementation.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, Constants.ModelBrowserLinks.DeviceModel.COMPONENT)]
        DATA_ITEM_REF,
        /// <summary>
        /// Component that organizes Interface types.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, Constants.ModelBrowserLinks.DeviceModel.INTERFACES)]
        INTERFACES,
        /// <summary>
        /// Abstract Component that coordinates actions and activities between pieces of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, Constants.ModelBrowserLinks.DeviceModel.INTERFACES)]
        INTERFACE
    }
}
