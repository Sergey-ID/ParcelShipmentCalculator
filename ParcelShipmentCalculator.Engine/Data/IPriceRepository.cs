using System.Collections.Generic;

namespace ParcelShipmentCalculator.Engine.Data
{
    public interface IPriceRepository
    {
        /// <summary>
        /// List of rules for parcel sizes
        /// </summary>
        List<ParcelSizeRule> ParcelSizeRules { get; set; }

        /// <summary>
        /// List of rules for parcel weights
        /// </summary>
        List<ParcelWeightRule> ParcelWeightRules { get; set; }
    }
}