using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Assets.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Assets.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Assets
{
    /// <inheritdoc />
    public class CuttingItems : MtconnectNode
    {
        /// <inheritdoc cref="CuttingItemsAttributes.COUNT"/>
        [MtconnectNodeAttribute(CuttingItemsAttributes.COUNT)]
        public int Count { get; set; }

        private List<CuttingItem> _cuttingItems = new List<CuttingItem>();
        [MtconnectNodeElements(nameof(CuttingItemsElements.CUTTING_ITEM), nameof(TryAddCuttingItem), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public ICollection<CuttingItem> Items => _cuttingItems;

        /// <inheritdoc />
        public CuttingItems() : base() { }

        /// <inheritdoc />
        public CuttingItems(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE, version) { }

        public bool TryAddCuttingItem(XmlNode xNode, XmlNamespaceManager nsmgr, out CuttingItem cuttingItem)
            => base.TryAdd<CuttingItem>(xNode, nsmgr, ref _cuttingItems, out cuttingItem);

        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            base.TryValidate(out validationErrors);

            if (Count <= 0) {
                validationErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"CuttingItems 'count' must be greater than zero."));
            }

            return !validationErrors.Any(o => o.Severity == ValidationSeverity.ERROR);
        }
    }
}
