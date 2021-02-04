using IronBarCode;

namespace Shared.Models
{
    public class Barcode
    {
        public string BarcodeValue { get; set; }
        public BarcodeEncoding BarcodeType { get; set; }
    }
}
