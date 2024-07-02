using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Documents.Devices;
using System;

namespace MtconnectCore.Standard.Contracts.Enums.Devices.Attributes
{
    /// <summary>
    /// Attributes for a <see cref="DataItem"/> element in the MTConnectDevices Response Document.
    /// </summary>
    /// <remarks>See Part 2 Section 7.2.2 of the MTConnect specification.</remarks>
    [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DATA_ITEM)]
    public enum DataItemAttributes
    {
        /// <summary>
        /// The unique identifier for this element.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DATA_ITEM)]
        ID,
        /// <summary>
        /// The name of the data item.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DATA_ITEM)]
        NAME,
        /// <summary>
        /// The type of data being measured. Examples of types are:
        /// <list type="bullet">
        /// <item>POSITION</item>
        /// <item>VELOCITY</item>
        /// <item>ANGLE</item>
        /// <item>BLOCK</item>
        /// <item>ROTARY_VELOCITY</item>
        /// </list>
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DATA_ITEM)]
        TYPE,
        /// <summary>
        /// Specifies the kind of information provided by a data item. The available options are:
        /// <list type="bullet">
        /// <item>SAMPLE</item>
        /// <item>EVENT</item>
        /// <item>CONDITION</item>
        /// </list>
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DATA_ITEM)]
        CATEGORY,
        /// <summary>
        /// The unit of measurement for the reported value of the data item.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DATA_ITEM)]
        UNITS,
        /// <summary>
        /// A sub-categorization of the data item type. For example, the subType of POSITION can be ACTUAL or COMMANDED.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DATA_ITEM)]
        SUB_TYPE,
        /// <summary>
        /// The native units of measurement for the reported value of the data item.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_1_0, Constants.ModelBrowserLinks.DATA_ITEM)]
        NATIVE_UNITS,
        /// <summary>
        /// Describes the type of statistical calculation performed on a series of data samples to provide the reported data value. Examples of statistic are:
        /// <list type="bullet">
        /// <item>AVERAGE</item>
        /// <item>MINIMUM</item>
        /// <item>MAXIMUM</item>
        /// <item>ROOT_MEAN_SQUARE</item>
        /// <item>RANGE</item>
        /// <item>MEDIAN</item>
        /// <item>MODE</item>
        /// <item>STANDARD_DEVIATION</item>
        /// </list>
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, Constants.ModelBrowserLinks.DATA_ITEM)]
        STATISTIC,
        /// <summary>
        /// Description of a means to interpret data consisting of multiple data points or as a single value.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, Constants.ModelBrowserLinks.DATA_ITEM)]
        REPRESENTATION,
        /// <summary>
        /// The nativeUnits may not be scaled to directly represent the original measured value. nativeScale MAY be used to convert the reported value to represent the original measured value. As an example, the <see cref="NATIVE_UNITS"/> may be reported as GALLON/MINUTE. TH emeasured value may actually be in 1000 GALLON/MINUTE. The value of the reported data mAY be divided by the nativeScale to convert the reported value to its original measured value and units.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DATA_ITEM)]
        NATIVE_SCALE,
        /// <summary>
        /// The number of significant digits in the reported value.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DATA_ITEM)]
        SIGNIFICANT_DIGITS,
        /// <summary>
        /// For measured values relative to a coordinate system like POSITION, the coordinate system being used may be reported. The available values for coordinateSystem are:
        /// <list type="bullet">
        /// <item>WORK</item>
        /// <item>MACHINE</item>
        /// </list>
        /// </summary>
        [Obsolete("Deprecated in 2.0")]
        [MtconnectVersionApplicability(MtconnectVersions.V_1_0_1, Constants.ModelBrowserLinks.DATA_ITEM, MtconnectVersions.V_2_0_0)]
        COORDINATE_SYSTEM,
        /// <summary>
        /// The identifier attribute of the <see cref="Composition"/> element that the reported data is most closely associated.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, Constants.ModelBrowserLinks.DATA_ITEM)]
        COMPOSITION_ID,
        /// <summary>
        /// The rate at which successive samples of a data item are recorded by a piece of equipment. <see cref="SAMPLE_RATE"/> is expressed in terms of samples per second. If the <see cref="SAMPLE_RATE"/> is smaller than one, the number can be represented as a floating point number. For example a rate 1 per 10 seconds would be 0.1.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, Constants.ModelBrowserLinks.DATA_ITEM)]
        SAMPLE_RATE,
        /// <summary>
        /// An indication signifying whether each value reported for the Data Entity is significant and whether duplicate values are to be suppressed. <c>true</c> indicates that each update to the Data Entity’s value is significant and duplicate values MUST NOT be suppressed. <c>false</c> indicates that duplicated values MUST be suppressed.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, Constants.ModelBrowserLinks.DATA_ITEM)]
        DISCRETE,
        /// <summary>
        /// The associated <see cref="CoordinateSystem"/> context for the <see cref="DataItem"/>.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, Constants.ModelBrowserLinks.DATA_ITEM)]
        COORDINATE_SYSTEM_ID_REF
    }
}
