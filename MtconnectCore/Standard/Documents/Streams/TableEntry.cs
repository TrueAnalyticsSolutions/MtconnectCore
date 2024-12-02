using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Streams.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Streams.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using MtconnectCore.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Streams
{
    public class TableEntry : MtconnectNode
    {
        /// <summary>
        /// Collected from the key attribute. Refer to Part 3 Streams - 5.6.5.3.3
        /// 
        /// Occurance: 1
        /// </summary>
        [MtconnectNodeAttribute(TableEntryAttributes.KEY)]
        public string Key { get; set; }

        /// <summary>
        /// Collected from the removed attribute. Refer to Part 3 Streams - 5.6.5.3.3
        /// 
        /// Occurance: 0..1
        /// </summary>
        [MtconnectNodeAttribute(TableEntryAttributes.REMOVED)]
        public bool Removed { get; set; }

        private List<Cell> _cells = new List<Cell>();
        [MtconnectNodeElements(TableEntryElements.CELL, nameof(TryAddCell))]
        public ICollection<Cell> Cells => _cells;


        /// <inheritdoc/>
        public TableEntry() : base() { }

        /// <inheritdoc/>
        public TableEntry(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

        public bool TryAddCell(XmlNode xNode, XmlNamespaceManager nsmgr, out Cell entry) => base.TryAdd<Cell>(xNode, nsmgr, ref _cells, out entry);

        [MtconnectVersionApplicability(MtconnectVersions.V_1_6_0, "See model.mtconnect.org/Observation Information Model/Representations/Cell")]
        private bool ValidateProperties(out ICollection<MtconnectValidationException> validationErrors)
        {
            return new NodeValidationContext(this)
                // Validate Cell Key uniqueness
                .ValidateValueProperty<TableEntryElements>(nameof(Cells), (o) =>
                    o.IsImplemented()
                    ?.If(
                        v => _cells.Count > 0 && !_cells.All(c => _cells.Count(e => e.Key == c.Key) == 1),
                        v => throw new MtconnectValidationException(
                            ValidationSeverity.ERROR,
                            "TableEntry Cell 'key' must be a unique identifier for each key-value pair within the TableEntry.",
                            SourceNode) {
                            Code = Contracts.Enums.ExceptionsReport.ExceptionCodeEnum.DUPLICATE_ENTRY,
                            SourceContext = Contracts.Enums.ExceptionsReport.ExceptionContextEnum.VALUE_PROPERTY,
                            SourceContextScope = "TableEntry Cell.Key"
                        }
                    )
                )
                // Return validation errors
                .HasError(out validationErrors);
        }
    }
}
