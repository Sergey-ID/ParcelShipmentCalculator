using System.Collections.Generic;
using System.Linq;

namespace ParcelShipmentCalculator.Engine.Models
{
    public class ParcelShipmentReceipt
    {
        /// <summary>
        /// The list of receipt lines for the final representation of the shipment
        /// </summary>
        public List<ReceiptLine> ReceiptLines { get; set; } = new List<ReceiptLine>();
        /// <summary>
        /// The total cost of the shipment
        /// </summary>
        public decimal Total => ReceiptLines.Sum(x => x.Cost);

        /// <summary>
        /// Returns a list of strings that represent the receipt
        /// </summary>
        public List<string> PrintReceipt()
        {
            var receipt = new List<string>();
            foreach (var line in ReceiptLines)
            {
                receipt.Add($"{line.Description} - {line.Cost}");
            }
            receipt.Add($"Total - {Total}");
            return receipt;
        }
    }
}
