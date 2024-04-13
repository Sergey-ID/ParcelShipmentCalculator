using System.Collections.Generic;

namespace ParcelShipmentCalculator.Engine.Models
{
    public class Parcel
    {
        /// <summary>
        /// List of three dimensions of each parcel
        /// </summary>
        public List<double> Dimensions { get; set; } = new List<double>(3);

        /// <summary>
        /// Weight of the parcel
        /// </summary>
        public double Weight { get; set; }
    }
}
