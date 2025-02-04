#pragma warning disable 0618
#pragma warning disable 1574
using System;
using System.CodeDom.Compiler;
using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums
{
	/// <summary>
	/// <br/>Visit <seealso href="https://model.mtconnect.org/#Enumeration__EAID_67CD6E1B_53E3_45c1_B84F_B0732F79528D">model.mtconnect.org</seealso> for more information.
	/// </summary>
	/// <remarks>
	/// <list type="bullet">
	/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
	/// </list>
	/// </remarks>
	[MtconnectVersionApplicability(MtconnectVersions.V_1_2_0, "https://model.mtconnect.org/#_Version_1.2")]
	[GeneratedCode("MtconnectTranspiler.Sinks.MtconnectCore", "2.5.0.0")]
	public enum RepresentationEnum
	{
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />series of sampled data.<br /><br /><br /><br />The data is reported for a specified number of samples and each sample is reported with a fixed period.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		TIME_SERIES,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />measured value of the sample data.<br /><br /><br /><br />If no <see cref="DataItem.representation">representation in DataItem</see> is specified for a data item, the <see cref="DataItem.representation">representation in DataItem</see> <b>MUST</b> be determined to be <c>VALUE</c>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.2">v1.2</see></item>
		/// </list>
		/// </remarks>
		VALUE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br /><b>DEPRECATED</b> as <see cref="DataItem.representation">representation in DataItem</see> type in <i>MTConnect Version 1.5</i>. Replaced by the <see cref="DataItem.discrete">discrete in DataItem</see>.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.3">v1.3</see></item>
		/// <item><b>Deprecated</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		[Obsolete("Deprecated in v1.5 according to https://model.mtconnect.org/#_Version_1.5")]
		DISCRETE,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />reported value(s) are represented as a set of <i>key-value pair</i>s.<br /><br /><br /><br />Each reported value in the <i>data set</i> <b>MUST</b> have a unique key.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.5">v1.5</see></item>
		/// </list>
		/// </remarks>
		DATA_SET,
		/// <summary>
		﻿/// <br /><br /><br /><br /><br /><br />two dimensional set of <i>key-value pair</i>s where the <see cref="Entry">Entry</see> represents a row, and the value is a set of <i>key-value pair</i> <see cref="Cell">Cell</see> elements. <br /><br /><br /><br />A <i>table</i> follows the same behavior as the <i>data set</i> for change tracking, clearing, and history. When an <see cref="Entry">Entry</see> changes, all <see cref="Cell">Cell</see> elements update as a single unit following the behavior of a <i>data set</i>.<br /><br /><br /><br />&gt; Note: It is best to use <see cref="Variable">Variable</see> if the <see cref="Cell">Cell</see> entities represent multiple semantic types.<br /><br /><br /><br />Each <see cref="Entry">Entry</see> in the <i>table</i> <b>MUST</b> have a unique key. Each <see cref="Cell">Cell</see> of each <see cref="Entry">Entry</see> in the <i>table</i> <b>MUST</b> have a unique key.<br /><br /><br /><br />See <see cref="Representation">Representation</see> in <see cref="Observation Information Model">Observation Information Model</see>, for a description of <see cref="Entry">Entry</see> and <see cref="Cell">Cell</see> elements.<br /><br /><br /><br />
		/// </summary>
		/// <remarks>
		/// <list type="bullet">
		/// <item><b>Introduced</b>: <see href="https://model.mtconnect.org/#_Version_1.6">v1.6</see></item>
		/// </list>
		/// </remarks>
		TABLE,
	}
}