using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StorageFacility.Classes;
using StorageFacility.Exceptions;
using StorageFacility.Service;

namespace StorageFacility.Logic
{
    public class ProductLogic : IProductLogic
    {
        // Initiate Interfaces
        IBarcodeVerifier barcodeVerifier;
        IFileAccess fileAccess;
        IProductService productService;
        IAuthService authService;

        /// <summary>
        /// Production Constructor
        /// </summary>
        public ProductLogic()
        {
            IObjectFactory objectFactory = new ObjectFactory();
            fileAccess = objectFactory.GetFileAccess();
            barcodeVerifier = objectFactory.GetEAN13BarcodeVerifier();
            productService = new ProductService(objectFactory.GetDatabaseConnectionFromFile(fileAccess.GetCurrentWorkingDirectory() + "\\config.txt"));
            authService = objectFactory.GetAuthService();
        }

        /// <summary>
        /// Mockup Constructor
        /// </summary>
        /// <param name="barcodeVerifier"></param>
        /// <param name="fileAccess"></param>
        /// <param name="productService"></param>
        /// <param name="authService"></param>
        public ProductLogic(IBarcodeVerifier barcodeVerifier, IFileAccess fileAccess, IProductService productService,IAuthService authService)
        {
            this.barcodeVerifier = barcodeVerifier;
            this.fileAccess = fileAccess;
            this.productService = productService;
            this.authService = authService;
        }

        /// <summary>
        /// Registers a Product, based on the inputs
        /// Uses Factory to get the necesarry services 
        /// Uses ProductService to register the Shelf
        /// Uses BarcodeVerifier to verify if it's valid
        /// </summary>
        /// <param name="username"></param>
        /// <param name="barcode"></param>
        /// <param name="name"></param>
        public void RegisterProduct(string username, string barcode, string name)
        {
            try
            {
                if (!authService.UserAllowed(username))
                {
                    throw new UserNotAuthorizedException("User is not allowed");
                }
                barcodeVerifier.Verify(barcode);

                if (name.Length >= 64)
                {
                    throw new FormatException("Product Name Too long!");
                }
                productService.Register(ulong.Parse(barcode), name);
                return;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
