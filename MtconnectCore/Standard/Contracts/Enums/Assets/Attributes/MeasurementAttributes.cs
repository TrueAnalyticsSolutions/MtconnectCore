namespace MtconnectCore.Standard.Contracts.Enums.Assets.Attributes
{
    public enum MeasurementAttributes {
        /// <summary>
        /// The number of significant digits in the reported value. This is used by applications to determine accuracy of values. This MAY be specified for all numeric values.
        /// </summary>
        SIGNIFICANT_DIGITS,
        /// <summary>
        /// The units for the measurements. MTConnect defines all the units for each measurement, so this is mainly for documentation sake. See MTConnect Part 2 – Components and Data Items section 4.1.5: units for the full list. 
        /// </summary>
        UNITS,
        /// <summary>
        /// The units the measurement was originally recorded in. This is only necessary if they differ from units. See MTConnect Part 2 – Components and Data Items section 4.1.8: nativeUnits for the full list. 
        /// </summary>
        NATIVE_UNITS,
        /// <summary>
        /// A shop specific code for this measurement. ISO 13399 codes MAY be used to for these codes as well.
        /// </summary>
        CODE,
        /// <summary>
        /// The maximum value for this measurement. Exceeding this value would indicate the tool is not usable.
        /// </summary>
        MAXIMUM,
        /// <summary>
        /// The minimum value for this measurement. Exceeding this value would indicate the tool is not usable.
        /// </summary>
        MINIMUM,
        /// <summary>
        /// The as advertised value for this measurement.
        /// </summary>
        NOMINAL
    }
}
