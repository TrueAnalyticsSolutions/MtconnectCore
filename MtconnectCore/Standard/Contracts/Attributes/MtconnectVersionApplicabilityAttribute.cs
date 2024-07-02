using MtconnectCore.Standard.Contracts.Enums;
using System;

namespace MtconnectCore.Standard.Contracts.Attributes
{
    /// <summary>
    /// An attribute used to flag the applicability of an object based on the version of the standard the MTConnect Response Document should be compared against.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Enum | AttributeTargets.Struct | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class MtconnectVersionApplicabilityAttribute : Attribute
    {
        /// <summary>
        /// Reference to the version of the MTConnect Standard that this object applies to.
        /// </summary>
        public MtconnectVersions IntroducedVersion { get; set; }

        public MtconnectVersions? DeprecatedVersion { get; set; }

        /// <summary>
        /// A reference to the part and section of the MTConnect Standard that the applicability of this object is mentioned. This reference should be relevant to the <see cref="IntroducedVersion"/> supplied.
        /// </summary>
        /// <example>Part 1 Section 1.0.0</example>
        public string StandardReference { get; set; }

        /// <summary>
        /// Initializes a <see cref="MtconnectVersionApplicabilityAttribute"/> for automatic processing of a MTConnect node's XML validation.
        /// </summary>
        /// <param name="introduced">Reference to the MTConnect Standard version that this validation is in reference to.</param>
        /// <param name="standardReference">Reference to the part and section of the MTConnect Standard that this validation method comes from.</param>
        public MtconnectVersionApplicabilityAttribute(MtconnectVersions introduced, string standardReference)
        {
            IntroducedVersion = introduced;
            StandardReference = standardReference;
        }

        /// <inheritdoc cref="MtconnectVersionApplicabilityAttribute.MtconnectVersionApplicabilityAttribute(MtconnectVersions, string)"/>
        /// <param name="version">Reference to the MTConnect Standard version that this validation is in reference to.</param>
        /// <param name="standardReference">Reference to the part and section of the MTConnect Standard that this validation method comes from.</param>
        /// <param name="deprecated"></param>
        public MtconnectVersionApplicabilityAttribute(MtconnectVersions version, string standardReference, MtconnectVersions deprecated) : this(version, standardReference)
        {
            DeprecatedVersion = deprecated;
        }

        /// <summary>
        /// Compares the Response Document version against the version specified in the attribute based on the comparison method provided.
        /// </summary>
        /// <param name="documentVersion">Reference to the version of MTConnect implemented in the Response Document.</param>
        /// <returns>Flag for whether the MTConnect Response Document version matches with the specified <see cref="IntroducedVersion"/> according to the <see cref="ComparisonType"/>.</returns>
        public VersionComparisonTypes Compare(MtconnectVersions documentVersion) {
            if (documentVersion < IntroducedVersion)
                return VersionComparisonTypes.NotImplemented;
            if (documentVersion >= DeprecatedVersion)
                return VersionComparisonTypes.Deprecated;
            return VersionComparisonTypes.Implemented;
        }
    }
}
