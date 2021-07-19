namespace MtconnectCore.Standard.Contracts.Enums.Devices.Elements
{
    /// <summary>
    /// An element that can contain descriptive content defining the configuration information for Sensor. For Sensor, the valid configuration is SensorConfiguration which provides data from a subset of items commonly found in a transducer electronic data sheet for sensors and actuators called TEDS. TEDS formats are defined in IEEE 1451.0 and 1451.4 transducer interface standards (ref 15 and 16, respectively). MTConnect does not support all of the data represented in the TEDS data, nor does it duplicate the function of the TEDS data sheets.
    /// </summary>
    public enum SensorConfigurationElements {
        /// <summary>
        /// Version number for the sensor unit as specified by the manufacturer.
        /// </summary>
        FIRMWARE_VERSION,
        /// <summary>
        /// Date upon which the sensor unit was last calibrated.
        /// </summary>
        CALIBRATION_DATE,
        /// <summary>
        /// Date upon which the sensor unit is next scheduled to be calibrated.
        /// </summary>
        NEXT_CALIBRATION_DATE,
        /// <summary>
        /// The initials of the person verifying the validity of the calibration data.
        /// </summary>
        CALIBRATION_INITIALS,
        /// <summary>
        /// When Sensor represents multiple sensing elements, each sensing element is represented by a Channel for the Sensor.
        /// </summary>
        CHANNELS,
        /// <summary>
        /// Channel represents each sensing element connected to a sensor unit.
        /// </summary>
        CHANNEL
    }
}
