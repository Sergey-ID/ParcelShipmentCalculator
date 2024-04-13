using ParcelShipmentCalculator.Engine.Builders;
using ParcelShipmentCalculator.Engine.Data;
using ParcelShipmentCalculator.Engine.Models;

namespace ParcelShipmentCalculator.Engine.UnitTests
{
    public class ParcelCostBuilderTests
    {
        //NOTE: If total is correct then line items are correct
        [Theory]
        [InlineData(new double[] { 5, 5, 5 }, 3)]   // Small parcel
        [InlineData(new double[] { 1, 5, 9 }, 3)]   // Small parcel
        [InlineData(new double[] { 25, 25, 25 }, 8)]  // Medium parcel
        [InlineData(new double[] { 5, 10, 10 }, 8)]  // Medium parcel
        [InlineData(new double[] { 75, 75, 75 }, 15)] // Large parcel
        [InlineData(new double[] { 25, 50, 99 }, 15)] // Large parcel
        [InlineData(new double[] { 100, 100, 100 }, 25)] // XL parcel
        [InlineData(new double[] { 10, 10, 150 }, 25)] // XL parcel
        public void CalculateParcelBaseCost_VariousSizes_CorrectClassification(double[] dimensions, decimal expectedPrice)
        {
            // Arrange
            var priceRepo = new PriceRepository();
            var parcelCostBuilder = new ParcelCostBuilder(priceRepo);
            var parcel = new Parcel
            {
                Dimensions = dimensions.ToList(),
                Weight = 5  // Weight does not affect size calculation
            };

            // Act
            var receipt = parcelCostBuilder.SetBaseCost(new ParcelShipmentRequest() { Parcels = {parcel} }).Build();

            // Assert
            Assert.Equal(expectedPrice, receipt.Total);
        }

        [Theory]
        [MemberData(nameof(MultipleParcelDataTotalValue))]
        public void CalculateParcelBaseCost_MultipleParcels_CorrectTotal(List<double[]> dimensionsList, decimal expectedTotal)
        {
            // Arrange
            var priceRepo = new PriceRepository();
            var parcelCostBuilder = new ParcelCostBuilder(priceRepo);
            var parcels = dimensionsList.Select(dimensions => new Parcel
            {
                Dimensions = dimensions.ToList(),
                Weight = 5  // Weight does not affect size calculation
            }).ToList();

            // Act
            var receipt = parcelCostBuilder.SetBaseCost(new ParcelShipmentRequest() { Parcels = parcels }).Build();

            // Assert
            Assert.Equal(expectedTotal, receipt.Total);
        }

        public static IEnumerable<object[]> MultipleParcelDataTotalValue =>
            new List<object[]>
            {
                new object[]
                {
                    new List<double[]>
                    {
                        new double[] { 1, 5, 9 }, 
                        new double[] { 25, 25, 25 }
                    }, // Two parcels
                    11 // Expected total price
                },
                new object[]
                {
                    new List<double[]>
                    {
                        new double[] { 10, 5, 9 },  
                        new double[] { 25, 25, 25 },
                        new double[] { 25, 50, 99 },
                        new double[] { 100, 100, 100 },
                        new double[] { 10, 10, 150 }
                    }, // 5 parcels
                    81 // Expected total price
                },
                new object[]
                {
                    new List<double[]>
                    {
                        new double[] { 10, 10, 10 }, 
                        new double[] { 25, 50, 50 },
                        new double[] { 25, 50, 100 },
                    }, // Three parcels
                    48 // Expected total price
                }
            };
    }
}