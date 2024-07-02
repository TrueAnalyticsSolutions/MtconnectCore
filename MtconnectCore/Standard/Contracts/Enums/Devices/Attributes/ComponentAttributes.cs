using MtconnectCore.Standard.Contracts.Attributes;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    /// <summary>
    /// Attributes of the Component element
    /// </summary>
    /// <remarks>See Part 2 Section 4.4.2 of the MTConnect specification.</remarks>
    public enum ComponentAttributes
    {
        /// <summary>
        /// The unique identifier for this element.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.COMPONENT)]
        ID,
        /// <summary>
        /// The name of the Component element.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.COMPONENT)]
        NAME,
        /// <summary>
        /// The common name normally associated with a specific physical or logical part of a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, Constants.ModelBrowserLinks.COMPONENT)]
        NATIVE_NAME,
        /// <summary>
        /// An optional attribute that is an indication provided by a piece of equipment describing the interval in milliseconds between the completion of the reading of the data associated with the Component element until the beginning of the next sampling of that data. This indication is reported as the number of milliseconds between data captures.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, Constants.ModelBrowserLinks.COMPONENT)]
        SAMPLE_INTERVAL,
        /// <summary>
        /// DEPRECATED in MTConnect Version 1.2. Replaced by <see cref="SAMPLE_INTERVAL"/>
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.COMPONENT, MtconnectVersions.V_1_2_0)]
        [Obsolete]
        SAMPLE_RATE,
        /// <summary>
        /// A unique identifier for this XML element.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.COMPONENT)]
        UUID,
        /// <summary>
        /// specifies the  CoordinateSystem for this  Component and its children.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_8_0, Constants.ModelBrowserLinks.COMPONENT)]
        COORDINATE_SYSTEM_ID_REF,
    }
}
