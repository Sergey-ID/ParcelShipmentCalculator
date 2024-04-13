using ParcelShipmentCalculator.Engine.Builders;
using ParcelShipmentCalculator.Engine.Data;
using ParcelShipmentCalculator.Engine.Models;

namespace ParcelShipmentCalculator.Engine.UnitTests
{
    public class ParcelCostBuilderTests
    {
        [Theory]
        [InlineData(new double[] { 5, 5, 5 }, 3)]   // Small parcel
        [InlineData(new double[] { 1, 5, 9 }, 3)]   // Small parcel
        [InlineData(new double[] { 25, 25, 25 }, 8)]  // Medium parcel
        [InlineData(new double[] { 5, 10, 10 }, 8)]  // Medium parcel
        [InlineData(new double[] { 75, 75, 75 }, 15)] // Large parcel
        [InlineData(new double[] { 25, 50, 99 }, 15)] // Large parcel
        [InlineData(new double[] { 150, 150, 150 }, 25)] // XL parcel
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
    }
}