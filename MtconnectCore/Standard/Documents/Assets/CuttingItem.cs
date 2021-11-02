using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Assets.Attributes;
using MtconnectCore.Standard.Contracts.Enums.Assets.Elements;
using MtconnectCore.Standard.Contracts.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using static MtconnectCore.Logging.MtconnectCoreLogger;

namespace MtconnectCore.Standard.Documents.Assets
{
    /// <inheritdoc />
    public class CuttingItem : MtconnectNode
    {
        /// <inheritdoc cref="CuttingItemAttributes.INDICES"/>
        public int[] Indices { get; set; }

        /// <inheritdoc cref="CuttingItemAttributes.ITEM_ID"/>
        [MtconnectNodeAttribute(CuttingItemAttributes.ITEM_ID)]
        public string ItemId { get; set; }

        /// <inheritdoc cref="CuttingItemAttributes.MANUFACTURERS"/>
        [MtconnectNodeAttribute(CuttingItemAttributes.MANUFACTURERS)]
        public string Manufacturers { get; set; }

        /// <inheritdoc cref="CuttingItemAttributes.GRADE"/>
        [MtconnectNodeAttribute(CuttingItemAttributes.GRADE)]
        public string Grade { get; set; }

        /// <inheritdoc cref="CuttingItemElements.DESCRIPTION"/>
        [MtconnectNodeElement(nameof(CuttingItemElements.DESCRIPTION), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public string Description { get; set; }

        /// <inheritdoc cref="CuttingItemElements.LOCUS"/>
        [MtconnectNodeElement(nameof(CuttingItemElements.LOCUS), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public string Locus { get; set; }

        private List<ItemLife> _itemLives = new List<ItemLife>();
        [MtconnectNodeElements(nameof(CuttingItemElements.ITEM_LIFE), nameof(TryAddItemLife), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public ICollection<ItemLife> ItemLives => _itemLives;

        private List<CuttingItemMeasurement> _measurements = new List<CuttingItemMeasurement>();
        [MtconnectNodeElements("Measurements/m:*", nameof(TryAddMeasurement), XmlNamespace = Constants.DEFAULT_XML_NAMESPACE)]
        public ICollection<CuttingItemMeasurement> Measurements => _measurements;

        /// <inheritdoc />
        public CuttingItem() : base() { }

        /// <inheritdoc />
        public CuttingItem(XmlNode xNode, XmlNamespaceManager nsmgr) : base(xNode, nsmgr, Constants.DEFAULT_XML_NAMESPACE)
        {
            Indices = TryGetIndices(nsmgr, out _);
        }

        public int[] TryGetIndices(XmlNamespaceManager nsmgr, out ICollection<MtconnectValidationException> validationErrors)
        {
            validationErrors = new List<MtconnectValidationException>();
            var indices = new List<int>();

            string attributeName = EnumHelper.ToCamelCase(CuttingItemAttributes.INDICES);
            string rawIndices = SourceNode.Attributes[attributeName]?.Value;// SourceNode.TryGetAttribute(CuttingItemAttributes.INDICES, null, nsmgr.LookupNamespace(Constants.DEFAULT_XML_NAMESPACE));
            if (!string.IsNullOrEmpty(rawIndices))
            {
                string[] strIndices = rawIndices.Split(',', StringSplitOptions.RemoveEmptyEntries);
                foreach (string strIndex in strIndices)
                {
                    if (strIndex.Contains('-'))
                    {
                        string[] strRange = strIndex.Split('-');
                        int min, max;
                        if (strRange.Length == 2 && int.TryParse(strRange[0], out min) && int.TryParse(strRange[1], out max))
                        {
                            for (int i = min; i <= max; i++)
                            {
                                indices.Add(i);
                            }
                        }
                        else
                        {
                            validationErrors.Add(
                                new MtconnectValidationException(
                                    Contracts.Enums.ValidationSeverity.ERROR,
                                    $"Invalid range format in CuttingItem 'indices'. Invalid part: '{strIndex}'. Full attribute source: '{rawIndices}'."
                                )
                            );
                        }
                    }
                    else
                    {
                        if (int.TryParse(strIndex, out int index))
                        {
                            indices.Add(index);
                        }
                        else
                        {
                            validationErrors.Add(
                                new MtconnectValidationException(
                                    Contracts.Enums.ValidationSeverity.ERROR,
                                    $"Invalid index format in CuttingItem 'indices'. Invalid part: '{strIndex}'. Full attribute source: '{rawIndices}'."
                                )
                            );
                        }
                    }
                }
            }
            else
            {
                validationErrors.Add(
                    new MtconnectValidationException(
                        Contracts.Enums.ValidationSeverity.ERROR,
                        $"Missing 'indices' in CuttingItem."
                    )
                );
            }
            return indices.ToArray();
        }

        public bool TryAddItemLife(XmlNode xNode, XmlNamespaceManager nsmgr, out ItemLife itemLife)
        {
            Logger.Verbose($"Reading CuttingItem ItemLife...");
            itemLife = new ItemLife(xNode, nsmgr);
            if (!itemLife.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Asset] ItemLife of Asset:\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            _itemLives.Add(itemLife);
            return true;
        }

        public bool TryAddMeasurement(XmlNode xNode, XmlNamespaceManager nsmgr, out CuttingItemMeasurement measurement)
        {
            Logger.Verbose($"Reading CuttingTool Measurements...");
            measurement = new CuttingItemMeasurement(xNode, nsmgr);
            if (!measurement.TryValidate(out ICollection<MtconnectValidationException> validationExceptions))
            {
                Logger.Warn($"[Invalid Asset] CuttingItemMeasurements of Asset:\r\n{ExceptionHelper.ToString(validationExceptions)}");
                return false;
            }
            _measurements.Add(measurement);
            return true;
        }

        public override bool TryValidate(out ICollection<MtconnectValidationException> validationErrors)
        {
            var allErrors = new List<MtconnectValidationException>();

            if (ItemLives.Count > 0)
            {
                foreach (var itemLife in ItemLives)
                {
                    if (!itemLife.TryValidate(out ICollection<MtconnectValidationException> itemLifeErrors))
                    {
                        allErrors.AddRange(itemLifeErrors);
                    }
                }
            }

            if (Measurements?.Any() == true)
            {
                foreach (var measurement in Measurements)
                {
                    if (!measurement.TryValidate(out ICollection<MtconnectValidationException> measurementErrors))
                    {
                        allErrors.AddRange(measurementErrors);
                    }
                }
            }

            //if (TryGetIndices(nsmgr, out ICollection<MtconnectValidationException> indicesErrors) != null)
            //{
            //    allErrors.AddRange(indicesErrors);
            //}

            validationErrors = allErrors;
            if (validationErrors.Any(o => o.Severity == Contracts.Enums.ValidationSeverity.ERROR))
            {
                return false;
            }
            return true;
        }
    }
}
