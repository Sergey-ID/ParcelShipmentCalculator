using ParcelShipmentCalculator.Engine.Models;

namespace ParcelShipmentCalculator.Engine.Builders
{
    public class ParcelCostBuilder : IParcelCostBuilder
    {
        private ParcelShipmentReceipt _parcelShipmentReceipt;

        /// <inheritdoc/>
        public IParcelCostBuilder SetBaseCost(ParcelShipmentRequest parcel)
        {
            throw NotImplementedException();
        }

        /// <inheritdoc/>
        public IParcelCostBuilder AddWeightCharge(ParcelShipmentRequest parcel)
        {
            throw NotImplementedException();
        }

        /// <inheritdoc/>
        public IParcelCostBuilder ApplySpeedyShipping(ParcelShipmentRequest parcel)
        {
            throw NotImplementedException();
        }

        /// <inheritdoc/>
        public IParcelCostBuilder ApplyDiscounts(ParcelShipmentRequest currentParcel)
        {
            throw NotImplementedException();
        }

        /// <inheritdoc/>
        public ParcelShipmentReceipt Build()
        {
            throw NotImplementedException();
        }
    }
}
