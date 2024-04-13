using System;
using System.Linq;
using ParcelShipmentCalculator.Engine.Data;
using ParcelShipmentCalculator.Engine.Models;

namespace ParcelShipmentCalculator.Engine.Builders
{
    public class ParcelCostBuilder : IParcelCostBuilder
    {
        private readonly IPriceRepository _priceRepository;
        private readonly ParcelShipmentReceipt _parcelShipmentReceipt;

        public ParcelCostBuilder(IPriceRepository priceRepository)
        {
            this._priceRepository = priceRepository;
            this._parcelShipmentReceipt = new ParcelShipmentReceipt();
        }

        /// <inheritdoc/>
        public IParcelCostBuilder SetBaseCost(ParcelShipmentRequest shipmentRequest)
        {
            foreach (var parcel in shipmentRequest.Parcels)
            {
                var maxDimension = parcel.Dimensions.Max();

                var applicableRule = _priceRepository.ParcelSizeRules
                    .Where(r => maxDimension < r.MaxDimension)
                    .OrderBy(r => r.MaxDimension)
                    .FirstOrDefault();

                if (!applicableRule.Equals(default(ParcelSizeRule)))
                {
                    var price = applicableRule.Price;

                    var receiptLine = new ReceiptLine
                    {
                        Description = $"{applicableRule.Name} Parcel with max dimension {maxDimension}",
                        Cost = price
                    };

                    _parcelShipmentReceipt.ReceiptLines.Add(receiptLine);
                }
            }

            return this;
        }

        /// <inheritdoc/>
        public IParcelCostBuilder AddWeightCharge(ParcelShipmentRequest shipmentRequest)
        {
            foreach (var parcel in shipmentRequest.Parcels)
            {
                var maxDimension = parcel.Dimensions.Max();

                // Find the size rule to determine the parcel's name (size classification)
                var sizeRule = _priceRepository.ParcelSizeRules
                    .Where(r => maxDimension < r.MaxDimension)
                    .OrderBy(r => r.MaxDimension)
                    .FirstOrDefault();

                // Find the weight rule that corresponds to the size classification
                var weightRule = _priceRepository.ParcelWeightRules
                    .FirstOrDefault(wr => wr.Name == sizeRule.Name);

                if (!weightRule.Equals(default(ParcelWeightRule)))
                {
                    var excessWeight = parcel.Weight - weightRule.WeightLimit;
                    var weightCharge = excessWeight > 0 ? (decimal)excessWeight * weightRule.OverweightChargePerKg : 0;

                    var weightChargeLine = new ReceiptLine
                    {
                        Description = $"Overweight Charge for {sizeRule.Name} Parcel",
                        Cost = weightCharge
                    };

                    _parcelShipmentReceipt.ReceiptLines.Add(weightChargeLine);
                }
            }

            return this;
        }

        /// <inheritdoc/>
        public IParcelCostBuilder ApplySpeedyShipping(ParcelShipmentRequest shipmentRequest)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public IParcelCostBuilder ApplyDiscounts(ParcelShipmentRequest shipmentRequest)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public ParcelShipmentReceipt Build() => _parcelShipmentReceipt;
    }
}
