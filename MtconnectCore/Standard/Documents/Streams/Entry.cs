using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System;
using System.Collections.Generic;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    /// <summary>
    /// Child of a <see cref="IDataSet"/>
    /// </summary>
    public class Entry : MtconnectNode
    {
        /// <summary>
        /// Collected from the key attribute. Refer to Part 3 Streams - 5.6.3.3
        /// 
        /// Occurance: 1
        /// </summary>
        [MtconnectNodeAttribute(EntryAttributes.KEY)]
        public string Key { get; set; }

        /// <summary>
        /// Collected from the removed attribute. Refer to Part 3 Streams - 5.6.3.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(EntryAttributes.REMOVED)]
        public bool Removed { get; set; }

        [Obsolete("Use Entry.Result instead")]
        public string Value {
            get {
                return Result;
            }
            set { Result = value; }
        }

        /// <summary>
        /// Collected from the textcontent of the Entry element. Refer to Part 3 Streams - 5.6.3.3
        /// </summary>
        public string Result { get; set; }

        /// <inheritdoc/>
        public Entry() { }

        /// <inheritdoc/>
        public Entry(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version)
        {
            Result = xNode.InnerText;
        }

        [MtconnectVersionApplicability(MtconnectVersions.V_1_5_0, "See model.mtconnect.org/Observation Information Model/Representations/Entry")]
        private bool ValidateProperties(out ICollection<MtconnectValidationException> validationErrors)
        {
            return new NodeValidationContext(this)
                // Validate Key
                .ValidateValueProperty<EntryAttributes>(nameof(Key), (o) =>
                    o.IsImplemented(Key)?.IsRequired(Key)
                    ?.If(
                        v => string.IsNullOrEmpty(Key),
                        v => throw new MtconnectValidationException(
                            ValidationSeverity.ERROR,
                            "Entry representation MUST include a 'key' attribute with a unique value within the DataSet.",
                            SourceNode) {
                            Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.NOT_FOUND,
                            ScopeType = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY,
                            Scope = nameof(Key)
                        }
                    )
                )
                // Return validation errors
                .HasError(out validationErrors);
        }
    }
}
