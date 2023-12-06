using System.ComponentModel;

namespace MtconnectCore.Standard.Contracts.Enums
{
    /// <summary>
    /// Options for supported MTConnect Standard versions.
    /// </summary>
    public enum MtconnectVersions
    {
        /// <summary>
        /// Version 1.0.1
        /// </summary>
        /// <remarks>Prepared on: October 2, 2009</remarks>
        [Description("1.0")]
        V_1_0_1 = 1 << 0,
        /// <summary>
        /// Version 1.1.0
        /// </summary>
        /// <remarks>Prepared on: April 30, 2010</remarks>
        [Description("1.1")]
        V_1_1_0 = 1 << 1,
        /// <summary>
        /// Version 1.2.0
        /// </summary>
        /// <remarks>Prepared on: February 17, 2012</remarks>
        [Description("1.2")]
        V_1_2_0 = 1 << 2,
        /// <summary>
        /// Version 1.3.0
        /// </summary>
        /// <remarks>Prepared on: September 30, 2014</remarks>
        [Description("1.3")]
        V_1_3_0 = 1 << 3,
        /// <summary>
        /// Version 1.3.1
        /// </summary>
        /// <remarks>Prepared on: June 11, 2015</remarks>
        [Description("1.3.1")]
        V_1_3_1 = 1 << 4,
        /// <summary>
        /// Version 1.4.0
        /// </summary>
        /// <remarks>Prepared on: March 31, 2018</remarks>
        [Description("1.4")]
        V_1_4_0 = 1 << 5,
        /// <inheritdoc cref="V_1_4_0"/>
        [Description("1.4.1")]
        V_1_4_1 = 1 << 6,
        /// <summary>
        /// Version 1.5.0
        /// </summary>
        [Description("1.5")]
        V_1_5_0 = 1 << 7,
        /// <inheritdoc cref="V_1_5_0"/>
        [Description("1.5.1")]
        V_1_5_1 = 1 << 8,
        /// <summary>
        /// Version 1.6.0
        /// </summary>
        /// <remarks>Prepared on: July 15, 2020</remarks>
        [Description("1.6")]
        V_1_6_0 = 1 << 9,
        /// <inheritdoc cref="V_1_6_0"/>
        [Description("1.6.1")]
        V_1_6_1 = 1 << 10,
        /// <summary>
        /// Version 1.7.0
        /// </summary>
        /// <remarks>Prepared on: February 25, 2021</remarks>
        [Description("1.7")]
        V_1_7_0 = 1 << 11,
        /// <inheritdoc cref="V_1_7_0"/>
        [Description("1.7.1")]
        V_1_7_1 = 1 << 12,
        /// <summary>
        /// Version 1.8.0
        /// </summary>
        /// <remarks>Prepared on: September 6, 2021</remarks>
        [Description("1.8")]
        V_1_8_0 = 1 << 13,
        /// <inheritdoc cref="V_1_8_0"/>
        [Description("1.8.1")]
        V_1_8_1 = 1 << 14,
        /// <summary>
        /// Version 2.0.0
        /// </summary>
        /// <remarks>Prepared on: May 24, 2022</remarks>
        [Description("2.0")]
        V_2_0_0 = 1 << 15,
        /// <inheritdoc cref="V_2_0_0"/>
        [Description("2.0.1")]
        V_2_0_1 = 1 << 16,
        /// <summary>
        /// Version 2.1.0
        /// </summary>
        /// <remarks>Prepared on: January 14, 2023</remarks>
        [Description("2.1")]
        V_2_1_0 = 1 << 17,
        /// <inheritdoc cref="V_2_1_0"/>
        [Description("2.1.1")]
        V_2_1_1 = 1 << 18,
        /// <summary>
        /// Version 2.2.0
        /// </summary>
        /// <remarks>Prepared on: July 26, 2023</remarks>
        [Description("2.2")]
        V_2_2_0 = 1 << 19,
        /// <inheritdoc cref="V_2_2_0"/>
        [Description("2.2.1")]
        V_2_2_1 = 1 << 20,
        /// <summary>
        /// Version 2.3.0
        /// </summary>
        /// <remarks>Prepared on: February 11, 2024</remarks>
        [Description("2.3")]
        V_2_3_0 = 1 << 21,
        /// <inheritdoc cref="V_2_3_0"/>
        [Description("2.3.1")]
        V_2_3_1 = 1 << 22,
    }
}
