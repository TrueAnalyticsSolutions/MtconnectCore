using MtconnectCore.Standard.Contracts.Attributes;

namespace MtconnectCore.Standard.Contracts.Enums.Devices
{
    [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.6.1.1")]
    public enum SolidModelMediaTypes
    {
        /// <summary>
        /// ISO 10303 STEP AP203 or AP242 format.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.6.1.1")]
        STEP,
        /// <summary>
        /// Stereolithography file format.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.6.1.1")]
        STL,
        /// <summary>
        /// Geometry Description Markup Language.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.6.1.1")]
        GDML,
        /// <summary>
        /// Wavefront OBJ file format.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.6.1.1")]
        OBJ,
        /// <summary>
        /// ISO 17506.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.6.1.1")]
        COLLADA,
        /// <summary>
        /// Initial Graphics Exchange Specification.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.6.1.1")]
        IGES,
        /// <summary>
        /// Autodesk file format.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.6.1.1")]
        _3DS,
        /// <summary>
        /// Dassault file format.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.6.1.1")]
        ACIS,
        /// <summary>
        /// Parasolid XT Siemens data interchange format.
        /// </summary>
        [MtconnectVersionApplicability(MtconnectVersions.V_1_7_0, "Part 2 Section 9.6.1.1")]
        X_T
    }
}
