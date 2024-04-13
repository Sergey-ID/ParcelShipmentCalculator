using System.Collections.Generic;

namespace ParcelShipmentCalculator.Engine.Models
{
    public class ParcelShipmentRequest : Parcel
    {
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
