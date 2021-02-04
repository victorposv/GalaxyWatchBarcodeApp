using IronBarCode;
using Shared.Models;
using System.Drawing;

namespace Shared.Services
{
    public class BarcodeService : IBarcodeService
    {
        public Barcode ReadBarcode(string imagePath)
        {
            var barcode = BarcodeReader.QuicklyReadOneBarcode(imagePath);

            if (barcode != null)
                return new Barcode {BarcodeValue = barcode.Value, BarcodeType = barcode.BarcodeType };
            else
                return null;
        }

        public Bitmap CreateBarcodeImage(Barcode barcodeData)
        {
            var barcode = BarcodeWriter.CreateBarcode(barcodeData.BarcodeValue, barcodeData.BarcodeType);
            
            return barcode.ToBitmap();
        }
    }
}
