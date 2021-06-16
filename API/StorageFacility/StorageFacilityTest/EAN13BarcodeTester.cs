using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using StorageFacility.Classes;

namespace StorageFacilityTest
{

    class EAN13BarcodeTester
    {
        [TestCase("1234567891279")]
        [TestCase("1234567891248")]
        public void Verify_Successfull(string barcode)
        {
            IBarcodeVerifier barcodeVerifier = new EAN13BarcodeVerifier();
            Assert.True(barcodeVerifier.Verify(barcode.ToString()));
        }

        [TestCase("1234567891271")]
        public void Verify_InvalidCheckDigit(string barcode)
        {
            IBarcodeVerifier barcodeVerifier = new EAN13BarcodeVerifier();
            try
            {
                barcodeVerifier.Verify(barcode);
                Assert.Fail();
            }
            catch(FormatException fe)
            {
                Assert.AreEqual("Check digit was invalid!", fe.Message);
            }
            catch
            {
                Assert.Fail();
            }
            
        }

        [TestCase("1234e67891271")]
        [TestCase("1234E67891271")]
        [TestCase("1267891271")]
        [TestCase("123467891271")]
        public void Verify_FormatExecptionOnWrongBarcodeFormat(string barcode)
        {
            IBarcodeVerifier barcodeVerifier = new EAN13BarcodeVerifier();

            try
            {
                //If below dosent throw and exception then this is a failed test
                barcodeVerifier.Verify(barcode);
                Assert.Fail();
            }
            catch (FormatException fe)
            {
                Assert.AreEqual("Barcode format was not valid!", fe.Message);
            }
            catch
            {
                //Fail on all other kind of exception(as they should not be thrown here)
                Assert.Fail();
            }

        }
    }
}
