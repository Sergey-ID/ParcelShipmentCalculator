using System.Collections.Generic;

namespace ParcelShipmentCalculator.Engine.Data
{
    public class PriceRepository : IPriceRepository
    {
        /// <summary>
        /// List of rules for parcel sizes
        /// </summary>
        public List<ParcelSizeRule> ParcelSizeRules { get; set; }

        /// <summary>
        /// List of rules for parcel weights
        /// </summary>
        public List<ParcelWeightRule> ParcelWeightRules { get; set; }

        /// <summary>
        /// Keeps of rules to calculate the price of a parcel
        /// </summary>
        // NOTE: This is a placeholder for the actual implementation to pull data from DB
        // TODO: This should be refactored to include weight based naming and pricing
        public PriceRepository()
        {
            ParcelSizeRules = new List<ParcelSizeRule>
            {
                new ParcelSizeRule
                {
                    SizeRuleId = 1,
                    Name = "Small",
                    MaxDimension = 10,
                    Price = 3
                },
                new ParcelSizeRule
                {
                    SizeRuleId = 2,
                    Name = "Medium",
                    MaxDimension = 50,
                    Price = 8
                },
                new ParcelSizeRule
                {
                    SizeRuleId = 3,
                    Name = "Large",
                    MaxDimension = 100,
                    Price = 15
                },
                new ParcelSizeRule
                {
                    SizeRuleId = 4,
                    Name = "Extra Large",
                    MaxDimension = double.MaxValue,
                    Price = 25
                }
            };

            ParcelWeightRules = new List<ParcelWeightRule>
            {
                new ParcelWeightRule
                {
                    WeightRuleId = 1,
                    Name = "Small",
                    WeightLimit = 1,
                    OverweightChargePerKg = 2
                },
                new ParcelWeightRule
                {
                    WeightRuleId = 2,
                    Name = "Medium",
                    WeightLimit = 3,
                    OverweightChargePerKg = 2
                },
                new ParcelWeightRule
                {
                    WeightRuleId = 3,
                    Name = "Large",
                    WeightLimit = 6,
                    OverweightChargePerKg = 2
                },
                new ParcelWeightRule
                {
                    WeightRuleId = 4,
                    Name = "Extra Large",
                    WeightLimit = 10,
                    OverweightChargePerKg = 2
                }
            };
        }
    }

    public struct ParcelWeightRule
    {
        public int WeightRuleId { get; set; }
        public string Name { get; set; }
        public double WeightLimit { get; set; }
        public decimal OverweightChargePerKg { get; set; }
    }

    public struct ParcelSizeRule
    {
        public int SizeRuleId { get; set; }
        public string Name { get; set; }
        public double MaxDimension { get; set; }
        public decimal Price { get; set; }
    }
}
