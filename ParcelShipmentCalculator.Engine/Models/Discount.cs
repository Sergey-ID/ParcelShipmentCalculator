using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelShipmentCalculator.Engine.Models
{
    public class Discount
    {
        public string Name { get; set; } = string.Empty;

        public IDiscountStrategy DiscountStrategy;
    }

    public interface IDiscountStrategy
    {
        double CalculateDiscount(List<Parcel> parcels);
    }
}
