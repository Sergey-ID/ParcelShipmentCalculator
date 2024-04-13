# ParcelShipmentCalculator
Library to calculate shipment cost based on various parameters

## How to Use

This section provides a step-by-step guide on how to create parcels, initiate a shipment request, calculate costs, and generate a shipment receipt using the `ParcelCostBuilder`.

### Step 1: Create a Parcel
A `Parcel` represents a physical package with specific dimensions and weight. Here is how you create a `Parcel` object:

````csharp
var parcel = new Parcel
{
    Dimensions = new List<double> { length, width, height },  // Replace length, width, height with actual measurements
    Weight = weight  // Replace weight with the actual weight of the parcel
};
````

#### Example:

````csharp
var myParcel = new Parcel
{
    Dimensions = new List<double> { 15, 20, 10 },
    Weight = 2.5
};
````

### Step 2: Create a Parcel Shipment Request

A `ParcelShipmentRequest` includes all parcels in a shipment, indicates if the shipment should be expedited (speedy shipment), and lists any applicable discounts.

````csharp

var shipmentRequest = new ParcelShipmentRequest
{
    Parcels = new List<Parcel> { parcel },  // Add all your parcels to this list
    IsSpeedyShipment = true,  // Set to true for speedy shipment, otherwise false
    Discounts = new List<Discount>()  // Add any applicable discounts
};
````

#### Example:

````csharp
var shipmentRequest = new ParcelShipmentRequest
{
    Parcels = new List<Parcel> { myParcel },
    IsSpeedyShipment = false,
    Discounts = new List<Discount>()  // Assuming discounts are predefined and added here if applicable
};
````

### Step 3: Calculate Shipment Costs

Use the `ParcelCostBuilder` to calculate the base cost, add weight charges, apply speedy shipping, and apply discounts.

````csharp
var costBuilder = new ParcelCostBuilder();  // Assuming an instance of IPriceRepository is passed if required
costBuilder.SetBaseCost(shipmentRequest)
           .AddWeightCharge(shipmentRequest)
           .ApplySpeedyShipping(shipmentRequest)
           .ApplyDiscounts(shipmentRequest);
````

### Step 4: Generate the Shipment Receipt
Finalize the shipment cost calculation and generate a receipt detailing all charges.

````csharp
var receipt = costBuilder.Build();
var printableReceipt = receipt.PrintReceipt();

foreach (var line in printableReceipt)
{
    Console.WriteLine(line);
}
````

#### Output Example:

````shell
Medium Parcel with max dimension 50 - $8
Overweight Charge for Medium Parcel - $3
Speedy Shipping Charge - $11
Total - $22
````
