using NUnit.Framework;
using StorageFacility.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Extras.Moq;
using StorageFacility.Classes;
using Moq;
using StorageFacility.Exceptions;

namespace StorageFacilityTest
{
    class ProductLogicTester
    {


        [TestCase("1234567891248a")]
        [TestCase("123451248")]
        [TestCase("123456789124834")]
        [TestCase("abdcrestdnito")]
        public void RegisterProduct_ThrowsFormatExceptionOnWrongBarcodeData(string barcode)
        {
            //SETUP
            Mock<IFileAccess> iFileaccess = new Mock<IFileAccess>();
            Mock<IProductService> iProductService = new Mock<IProductService>();
            Mock<IAuthService> iAuthService = new Mock<IAuthService>();

            iAuthService.Setup(x => x.UserAllowed(""))
                .Returns(true);

            IProductLogic productLogic = new ProductLogic(new EAN13BarcodeVerifier(), iFileaccess.Object, iProductService.Object, iAuthService.Object);

            //ACT AND VERIFY
            try
            {
                productLogic.RegisterProduct("", barcode, "Product");
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
        public void RegisterProduct_ThrowsFormatExceptionOnWrongCheckDigit(string barcode)
        {
            //SETUP
            Mock<IFileAccess> iFileaccess = new Mock<IFileAccess>();
            Mock<IProductService> iProductService = new Mock<IProductService>();
            Mock<IAuthService> iAuthService = new Mock<IAuthService>();

            iAuthService.Setup(x => x.UserAllowed(""))
                .Returns(true);

            IProductLogic productLogic = new ProductLogic(new EAN13BarcodeVerifier(),iFileaccess.Object, iProductService.Object, iAuthService.Object);

            //ACT AND VERIFY
            try
            {
                productLogic.RegisterProduct("", barcode, "Product");
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

        [TestCase("12345678901234567890123456789012345678901234567890123456789012345")]
        public void RegisterProduct_ThrowsFormatExceptionNameTooLong(string productName)
        {
            //SETUP
            Mock<IFileAccess> iFileaccess = new Mock<IFileAccess>();
            Mock<IProductService> iProductService = new Mock<IProductService>();
            Mock<IBarcodeVerifier> iBarcodeVerifier = new Mock<IBarcodeVerifier>();
            Mock<IAuthService> iAuthService = new Mock<IAuthService>();

            iAuthService.Setup(x => x.UserAllowed(""))
                .Returns(true);

            IProductLogic productLogic = new ProductLogic(iBarcodeVerifier.Object, iFileaccess.Object, iProductService.Object, iAuthService.Object);

            //ACT AND VERIFY
            try
            {
                productLogic.RegisterProduct("","1234567891248", productName);
                Assert.Fail();
            }
            catch (FormatException fe)
            {
                Assert.AreEqual("Product Name Too long!", fe.Message);
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
                string productName = "ProductName";

                //SETUP
                Mock<IFileAccess> iFileaccess = new Mock<IFileAccess>();
                Mock<IBarcodeVerifier> iBarcodeVerifier = new Mock<IBarcodeVerifier>();
                Mock<IProductService> iProductService = new Mock<IProductService>();
                Mock<IAuthService> iAuthService = new Mock<IAuthService>();

                iAuthService.Setup(x => x.UserAllowed(username))
                    .Returns(true);

                iFileaccess
                    .Setup(x => x.GetCurrentWorkingDirectory())
                    .Returns("C:");

                iBarcodeVerifier
                    .Setup(x => x.Verify(barcode.ToString()))
                    .Returns(true);

                iProductService
                    .Setup(x => x.Register(barcode, productName));

                ProductLogic productLogic = new ProductLogic(iBarcodeVerifier.Object, iFileaccess.Object, iProductService.Object,iAuthService.Object);

                //ACT
                productLogic.RegisterProduct(username,barcode.ToString(), productName);

                //VERIFY
                iProductService.Verify(x => x.Register(barcode, productName), Times.Exactly(1));
                iAuthService.Verify(x => x.UserAllowed(username), Times.Exactly(1));
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }
        [Test]
        public void RegisterProduct_UserIsNotAllowed()
        {
            //SETUP
            string username = "";
            ulong barcode = 123456879148;
            string productName = "ProductName";

            Mock<IFileAccess> iFileaccess = new Mock<IFileAccess>();
            Mock<IBarcodeVerifier> iBarcodeVerifier = new Mock<IBarcodeVerifier>();
            Mock<IProductService> iProductService = new Mock<IProductService>();
            Mock<IAuthService> iAuthService = new Mock<IAuthService>();

            iAuthService.Setup(x => x.UserAllowed(username))
                   .Returns(false);

            ProductLogic productLogic = new ProductLogic(iBarcodeVerifier.Object, iFileaccess.Object, iProductService.Object, iAuthService.Object);

            //ACT AND VERIFY
            try
            {
                productLogic.RegisterProduct(username, barcode.ToString(), productName);
                Assert.Fail();
            }
            catch(UserNotAuthorizedException unae)
            {
                iAuthService.Verify(x => x.UserAllowed(username), Times.Exactly(1));
                
            }
            catch
            {
                Assert.Fail();
            }

        }
    }
}
