using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <summary>
    /// Reference is a pointer to information that is associated with another Structural Element defined elsewhere in the XML document for a piece of equipment.That information may be data from the other element or the entire structure of that element.
    /// </summary>
    public abstract class Reference : MtconnectNode
    {
        /// <inheritdoc cref="ReferenceAttributes.ID_REF"/>
        [MtconnectNodeAttribute(ReferenceAttributes.ID_REF)]
        public abstract string IdRef { get; set; }

        /// <inheritdoc cref="ReferenceAttributes.NAME"/>
        [MtconnectNodeAttribute(ReferenceAttributes.NAME)]
        public abstract string Name { get; set; }

        /// <inheritdoc/>
        public Reference() : base() { }

        /// <inheritdoc/>
        public Reference(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE, version) { }


        [MtconnectVersionApplicability(MtconnectVersions.V_1_4_0, "Part 2 Section 4.8")]
        protected virtual bool validateIdRef(out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            if (string.IsNullOrEmpty(IdRef))
            {
                validationErrors.Add(new MtconnectValidationException(
                    ValidationSeverity.ERROR,
                    $"Reference MUST include a unique 'idRef' attribute."));
            }
            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
