using ParcelShipmentCalculator.Engine.Data;
using ParcelShipmentCalculator.Engine.Models;

namespace ParcelShipmentCalculator.Engine.Builders
{
    public class ParcelCostBuilder : IParcelCostBuilder
    {
        private readonly IPriceRepository _priceRepository;
        private ParcelShipmentReceipt _parcelShipmentReceipt;

        public ParcelCostBuilder(IPriceRepository priceRepository)
        {
            this._priceRepository = priceRepository;
        }

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
        public ParcelShipmentReceipt Build() => _parcelShipmentReceipt;
    }
}
