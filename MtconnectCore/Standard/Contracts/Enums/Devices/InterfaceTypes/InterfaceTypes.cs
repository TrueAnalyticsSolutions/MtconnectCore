using MtconnectCore.Standard.Contracts.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.InterfaceTypes
{
    public enum InterfaceTypes
    {
        /// <summary>
        ///  Interface that coordinates the operations between a bar feeder and another piece of equipment. Bar feeder is a piece of equipment that pushes bar stock (i.e., long pieces of material of various shapes) into an associated piece of equipment – most typically a lathe or turning center.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, Constants.ModelBrowserLinks.DeviceModel.BAR_FEEDER_INTERFACE)]
        BAR_FEEDER_INTERFACE,
        /// <summary>
        ///  Interface that coordinates the operations between two pieces of equipment, one of which controls the operation of a chuck. The piece of equipment that is controlling the chuck MUST provide the data item  ChuckState as part of the set of information provided.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, Constants.ModelBrowserLinks.DeviceModel.CHUCK_INTERFACE)]
        CHUCK_INTERFACE,
        /// <summary>
        /// Interface that coordinates the operations between two pieces of equipment, one of which controls the operation of a door. The piece of equipment that is controlling the door MUST provide data item DoorState as part of the set of information provided.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, Constants.ModelBrowserLinks.DeviceModel.DOOR_INTERFACE)]
        DOOR_INTERFACE,
        /// <summary>
        /// Interface that coordinates the operations between a piece of equipment and another associated piece of equipment used to automatically handle various types of materials or services associated with the original piece of equipment. <br/>A material handler is a piece of equipment capable of providing any one, or more, of a variety of support services for another piece of equipment or a process like:<br/>
        /// <list type="bullet">
        /// <item>Loading/unloading material or tooling</item>
        /// <item>Part inspection</item>
        /// <item>Testing</item>
        /// <item>Cleaning</item>
        /// </list><br/>
        /// A robot is a common example of a material handler.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, Constants.ModelBrowserLinks.DeviceModel.MATERIAL_HANDLER_INTERFACE)]
        MATERIAL_HANDLER_INTERFACE,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, Constants.ModelBrowserLinks.DeviceModel.REQUESTER)]
        REQUESTER,
        [MtconnectVersionApplicability(MtconnectVersions.V_1_3_0, Constants.ModelBrowserLinks.DeviceModel.RESPONDER)]
        RESPONDER
    }
}
