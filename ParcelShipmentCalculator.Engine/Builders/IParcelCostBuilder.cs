using ParcelShipmentCalculator.Engine.Models;
using System.Collections.Generic;

namespace ParcelShipmentCalculator.Engine.Builders
{
    public interface IParcelCostBuilder
    {
        /// <summary>
        /// Calculate the base cost of the parcel based on the dimensions
        /// </summary>
        /// <returns></returns>
        IParcelCostBuilder SetBaseCost(ParcelShipmentRequest parcel);
        
        /// <summary>
        /// Calculate the weight charge of the parcel
        /// </summary>
        /// <param name="parcel"></param>
        /// <returns></returns>
        IParcelCostBuilder AddWeightCharge(ParcelShipmentRequest parcel);

        /// <summary>
        /// Add speedy shipping charge to the end cost.If the shipment is a speedy shipment the cost is doubled
        /// </summary>
        /// <param name="parcel"></param>
        /// <returns></returns>
        IParcelCostBuilder ApplySpeedyShipping(ParcelShipmentRequest parcel);

        /// <summary>
        /// Apply all applicable discounts to the shipment
        /// </summary>
        /// <param name="parcels"></param>
        /// <returns></returns>
        IParcelCostBuilder ApplyDiscounts(ParcelShipmentRequest parcels);

        /// <summary>
        /// Get the final receipt of the shipment
        /// </summary>
        /// <returns></returns>
        ParcelShipmentReceipt Build();
    }
}