using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageFacility.Classes
{
    public interface IBarcodeVerifier
    {
        /// <summary>
        /// Verify the incoming barcode
        /// </summary>
        /// <param name="barcode">Barcode to verify</param>
        /// <returns>if the barcode is valid</returns>
        bool Verify(string barcode);
    }
}
