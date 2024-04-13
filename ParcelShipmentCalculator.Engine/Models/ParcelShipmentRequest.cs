using System.Collections.Generic;

namespace ParcelShipmentCalculator.Engine.Models
{
    public class ParcelShipmentRequest
    {
        /// <summary>
        /// List of parcels in the shipment
        /// </summary>
        public List<Parcel> Parcels { get; set; } = new List<Parcel>();
        /// <summary>
        /// This flag indicates if the shipment is a speedy shipment
        /// </summary>
        public bool IsSpeedyShipment { get; set; }

        /// <summary>
        /// A list of discounts that apply to the shipment
        /// </summary>
        public List<Discount> Discounts { get; set; } = new List<Discount>();
    }
}
