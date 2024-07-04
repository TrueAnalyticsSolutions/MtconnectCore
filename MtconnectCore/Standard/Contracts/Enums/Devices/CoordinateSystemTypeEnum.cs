using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices
{
    /// <summary>
    /// Available options for CoordinateSystem types.
    /// </summary>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.DeviceModel.COORDINATE_SYSTEM)]
    public enum CoordinateSystemTypeEnum
    {
        /// <summary>
        /// coordinate system referenced to the base mounting surface. Ref:ISO 9787:2013 A base mounting surface is a connection surface between the arm and its supporting structure.Ref:ISO 9787:2013 For non-robotic devices, it is the connection surface between the device and its supporting structure.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.DeviceModel.COORDINATE_SYSTEM)]
        BASE,
        /// <summary>
        /// coordinate system referenced to the sensor which monitors the site of the task. Ref:ISO 9787:2013
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.DeviceModel.COORDINATE_SYSTEM)]
        CAMERA,
        /// <summary>
        /// coordinate system referenced to the home position and orientation of the primary axes of a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.DeviceModel.COORDINATE_SYSTEM)]
        MACHINE,
        /// <summary>
        /// coordinate system referenced to the site of the task. Ref:ISO 9787:2013
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.DeviceModel.COORDINATE_SYSTEM)]
        MECHANICAL_INTERFACE,
        /// <summary>
        /// coordinate system referenced to one of the components of a mobile platform. Ref:ISO 8373:2012
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.DeviceModel.COORDINATE_SYSTEM)]
        MOBILE_PLATFORM,
        /// <summary>
        /// coordinate system referenced to the object. Ref:ISO 9787:2013
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.DeviceModel.COORDINATE_SYSTEM)]
        OBJECT,
        /// <summary>
        /// coordinate system referenced to the site of the task. ef:ISO 9787:2013
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.DeviceModel.COORDINATE_SYSTEM)]
        TASK,
        /// <summary>
        /// coordinate system referenced to the tool or to the end effector attached to the mechanical interface. Ref:ISO 9787:2013
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.DeviceModel.COORDINATE_SYSTEM)]
        TOOL,
        /// <summary>
        /// stationary coordinate system referenced to earth, which is independent of the robot motion. Ref:ISO 9787:2013 For non-robotic devices, stationary coordinate system referenced to earth, which is independent of the motion of a piece of equipment.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, Constants.ModelBrowserLinks.DeviceModel.COORDINATE_SYSTEM)]
        WORLD,
    }
}
