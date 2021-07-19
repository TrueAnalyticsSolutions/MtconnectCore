namespace MtconnectCore.Standard.Contracts.Enums.Devices.Elements
{
    /// <summary>
    /// Channel represents each sensing element connected to a sensor unit.
    /// </summary>
    /// <remarks>See Part 2 Section 9.1.3.1.2 of the MTConnect specification.</remarks>
    public enum ChannelElements {
        /// <summary>
        /// An XML element that can contain any descriptive content. The CDATA of Description MAY include any additional descriptive information the implementer chooses to include regarding a sensor element.
        /// </summary>
        DESCRIPTION,
        /// <summary>
        /// Date upon which the sensor unit was last calibrated to the sensor element. The data value for CalibrationDate is provided in the CDATA for this element and MUST be represented in the W3C ISO 8601 format.
        /// </summary>
        CALIBRATION_DATE,
        /// <summary>
        /// Date upon which the sensor element is next scheduled to be calibrated with the sensor unit. The data value for NextCalibrationDate is provided in the CDATA for this element and MUST be represented in the W3C ISO 8601 format.
        /// </summary>
        NEXT_CALIBRATION_DATE,
        /// <summary>
        /// The initials of the person verifying the validity of the calibration data. The data value for CalibrationInitials is provided in the CDATA for this element and MAY be any numeric or text content.
        /// </summary>
        CALIBRATION_INITIALS
    }
}
