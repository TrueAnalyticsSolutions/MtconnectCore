using MtconnectCore.Standard.Contracts.Enums;
using System;

namespace MtconnectCore.Standard.Contracts.Attributes
{
    /// <summary>
    /// An attribute used to flag validation methods based on the version of the standard the MTConnect Response Document should be validated against.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class MtconnectValidationMethodAttribute : Attribute
    {
        /// <summary>
        /// Reference to the version of the MTConnect Standard that this validation method applies to.
        /// </summary>
        public MtconnectVersions Version { get; set; }

        /// <summary>
        /// A reference to the part and section of the MTConnect Standard that this validation method comes from. This reference should be relevant to the <see cref="Version"/> supplied.
        /// </summary>
        /// <example>Part 1 Section 1.0.0</example>
        public string StandardReference { get; set; }

        /// <summary>
        /// Initializes a <see cref="MtconnectValidationMethodAttribute"/> for automatic processing of a MTConnect node's XML validation.
        /// </summary>
        /// <param name="version">Reference to the MTConnect Standard version that this validation is in reference to.</param>
        /// <param name="standardReference">Reference to the part and section of the MTConnect Standard that this validation method comes from.</param>
        public MtconnectValidationMethodAttribute(MtconnectVersions version, string standardReference)
        {
            Version = version;
            StandardReference = standardReference;
        }
    }
}
