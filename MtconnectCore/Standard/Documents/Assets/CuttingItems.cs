using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
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
        public CuttingItems(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE) { }

        public bool TryAddCuttingItem(XmlNode xNode, XmlNamespaceManager nsmgr, out CuttingItem cuttingItem)
        {
            Logger.Verbose("Reading CuttingTool CuttingItems");
            cuttingItem = new CuttingItem(xNode, nsmgr);
            if (!cuttingItem.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Assets] CuttingTool CuttingItems:\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            _cuttingItems.Add(cuttingItem);
            return true;
        }

        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            var allErrors = new List<MtconnectValidationException>();

            if (Count <= 0) {
                allErrors.Add(new MtconnectValidationException(
                    Contracts.Enums.ValidationSeverity.ERROR,
                    $"CuttingItems 'count' must be greater than zero."));
            }

            if (Items.Count > 0) {
                foreach (var item in Items)
                {
                    if (!item.TryValidate(out ICollection<MtconnectValidationException> itemValidationErrors)) {
                        allErrors.AddRange(itemValidationErrors);
                    }
                }
            }

            validationErrors = allErrors;
            if (validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR))
            {
                return false;
            }
            return true;
        }
    }
}
