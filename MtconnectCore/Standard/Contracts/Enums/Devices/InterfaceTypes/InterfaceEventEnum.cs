using MtconnectCore.Standard.Contracts.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.InterfaceTypes
{
    public enum InterfaceEventEnum
    {
        /// <summary>
        /// operating state of the service to close a chuck.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#Enumeration___19_0_3_68e0225_1646992208875_933134_35")]
        CLOSE_CHUCK,
        /// <summary>
        /// operating state of the service to close a door.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#Enumeration___19_0_3_68e0225_1646992208875_933134_35")]
        CLOSE_DOOR,
        /// <summary>
        /// operational state of an Interface.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#Enumeration___19_0_3_68e0225_1646992208875_933134_35")]
        INTERFACE_STATE,
        /// <summary>
        /// perating state of the service to change the type of material or product being loaded or fed to a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#Enumeration___19_0_3_68e0225_1646992208875_933134_35")]
        MATERIAL_CHANGE,
        /// <summary>
        /// operating state of the service to advance material or feed product to a piece of equipment from a continuous or bulk source.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#Enumeration___19_0_3_68e0225_1646992208875_933134_35")]
        MATERIAL_FEED,
        /// <summary>
        /// operating state of the service to load a piece of material or product.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#Enumeration___19_0_3_68e0225_1646992208875_933134_35")]
        MATERIAL_LOAD,
        /// <summary>
        /// operating state of the service to remove or retract material or product.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#Enumeration___19_0_3_68e0225_1646992208875_933134_35")]
        MATERIAL_RETRACT,
        /// <summary>
        /// operating state of the service to unload a piece of material or product.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#Enumeration___19_0_3_68e0225_1646992208875_933134_35")]
        MATERIAL_UNLOAD,
        /// <summary>
        /// operating state of the service to open a chuck.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#Enumeration___19_0_3_68e0225_1646992208875_933134_35")]
        OPEN_CHUCK,
        /// <summary>
        /// operating state of the service to open a door.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#Enumeration___19_0_3_68e0225_1646992208875_933134_35")]
        OPEN_DOOR,
        /// <summary>
        /// operating state of the service to change the part or product associated with a piece of equipment to a different part or product.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, "https://model.mtconnect.org/#Enumeration___19_0_3_68e0225_1646992208875_933134_35")]
        PART_CHANGE,
    }
}
