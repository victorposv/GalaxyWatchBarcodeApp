using Shared.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace Shared.Services
{
    public interface IBarcodeService
    {
        Barcode ReadBarcode(string imagePath);
        Bitmap CreateBarcodeImage(Barcode barcodeData);
    }
}