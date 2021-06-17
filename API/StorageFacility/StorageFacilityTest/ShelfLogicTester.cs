using Moq;
using NUnit.Framework;
using StorageFacility.Classes;
using StorageFacility.Exceptions;
using StorageFacility.Logic;
using StorageFacility.Service;
using System;
using System.Collections.Generic;
using System.Text;
using StorageFacility.DTO;

namespace StorageFacilityTest
{
    class ShelfLogicTester
    {
        //[TestCase("1234567891248a")]
        //[TestCase("123451248")]
        //[TestCase("123456789124834")]
        //[TestCase("abdcrestdnito")]
        //public void TestBarcodeFails



        [Test]
        public void GetShelvesContainingProductByID_UserIsNotAllowed()
        {
            //SETUP
            string username = "";
            ulong barcode = 123456879148;

            Mock<IFileAccess> iFileaccess = new Mock<IFileAccess>();
            Mock<IShelfService> iShelfService = new Mock<IShelfService>();
            Mock<IAuthService> iAuthService = new Mock<IAuthService>();
            Mock<IBarcodeVerifier> iBarCodeVerifier = new Mock<IBarcodeVerifier>();

            iAuthService.Setup(x => x.UserAllowed(username))
                   .Returns(false);

            IShelfLogic shelfLogic = new ShelfLogic(iBarCodeVerifier.Object, iFileaccess.Object, iShelfService.Object, iAuthService.Object);

            //ACT AND VERIFY
            try
            {
                shelfLogic.GetShelvesContainingProductByID(username, barcode.ToString());
                Assert.Fail();
            }
            catch (UserNotAuthorizedException unae)
            {
                iAuthService.Verify(x => x.UserAllowed(username), Times.Exactly(1));

            }
            catch
            {
                Assert.Fail();
            }

        }


        [TestCase("1234567891248a")]
        [TestCase("123451248")]
        [TestCase("123456789124834")]
        [TestCase("abdcrestdnito")]
        public void GetShelvesContainingProductByID_ThrowsFormatExceptionOnWrongBarcodeData(string barcode)
        {
            //SETUP
            Mock<IFileAccess> iFileaccess = new Mock<IFileAccess>();
            Mock<IShelfService> iShelfService = new Mock<IShelfService>();
            Mock<IAuthService> iAuthService = new Mock<IAuthService>();

            iAuthService.Setup(x => x.UserAllowed(""))
                .Returns(true);

            IShelfLogic shelfLogic = new ShelfLogic(new EAN13BarcodeVerifier(), iFileaccess.Object, iShelfService.Object, iAuthService.Object);

            //ACT AND VERIFY
            try
            {
                shelfLogic.GetShelvesContainingProductByID("", barcode);
                Assert.Fail();
            }
            catch (FormatException fe)
            {
                Assert.AreEqual("Barcode format was not valid!", fe.Message);
            }
            catch
            {
                Assert.Fail();
            }

        }

        [TestCase("1234567891242")]
        public void GetShelvesContainingProductByID_ThrowsFormatExceptionOnWrongCheckDigit(string barcode)
        {
            //SETUP
            Mock<IFileAccess> iFileaccess = new Mock<IFileAccess>();
            Mock<IShelfService> iShelfService = new Mock<IShelfService>();
            Mock<IAuthService> iAuthService = new Mock<IAuthService>();

            iAuthService.Setup(x => x.UserAllowed(""))
                .Returns(true);

            IShelfLogic productLogic = new ShelfLogic(new EAN13BarcodeVerifier(), iFileaccess.Object, iShelfService.Object, iAuthService.Object);

            //ACT AND VERIFY
            try
            {
                productLogic.GetShelvesContainingProductByID("", barcode);
                Assert.Fail();
            }
            catch (FormatException fe)
            {

                Assert.AreEqual("Check digit was invalid!", fe.Message);
            }
            catch
            {
                Assert.Fail();
            }
        }


        [Test]
        public void RegisterProduct_ServiceSuccessfullyCalled()
        {
            try
            {
                string username = "";
                ulong barcode = 123456879148;

                //SETUP
                Mock<IFileAccess> iFileaccess = new Mock<IFileAccess>();
                Mock<IShelfService> iShelfService = new Mock<IShelfService>();
                Mock<IAuthService> iAuthService = new Mock<IAuthService>();
                Mock<IBarcodeVerifier> iBarcodeVerifier = new Mock<IBarcodeVerifier>();

                iAuthService.Setup(x => x.UserAllowed(username))
                    .Returns(true);

                iFileaccess
                    .Setup(x => x.GetCurrentWorkingDirectory())
                    .Returns("C:");

                iBarcodeVerifier
                    .Setup(x => x.Verify(barcode.ToString()))
                    .Returns(true);

                iShelfService
                    .Setup(x => x.GetShelvesContainingProductByID(barcode.ToString()))
                    .Returns(new List<ShelfProductAmount>());

                IShelfLogic shelfLogic = new ShelfLogic(iBarcodeVerifier.Object, iFileaccess.Object, iShelfService.Object, iAuthService.Object);

                //ACT
                shelfLogic.GetShelvesContainingProductByID(username, barcode.ToString());

                //VERIFY
                iShelfService.Verify(x => x.GetShelvesContainingProductByID(barcode.ToString()), Times.Exactly(1));
                iAuthService.Verify(x => x.UserAllowed(username), Times.Exactly(1));
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }
    }
}
