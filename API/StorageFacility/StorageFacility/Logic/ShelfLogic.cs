using StorageFacility.Classes;
using System;
using System.Collections.Generic;
using StorageFacility.Service;
using StorageFacility.DTO;
using StorageFacility.Exceptions;

namespace StorageFacility.Logic
{
    public class ShelfLogic : IShelfLogic
    {
        // Variables of Services
        IAuthService authService;
        IFileAccess fileAccess;
        IShelfService shelfService;
        IBarcodeVerifier barcodeVerifier;

        /// <summary>
        /// Production Constructor
        /// </summary>
        public ShelfLogic()
        {
            IObjectFactory objectFactory = new ObjectFactory();
            authService = objectFactory.GetAuthService();
            fileAccess = objectFactory.GetFileAccess();
            string configFilePath = fileAccess.GetCurrentWorkingDirectory() + "\\config.txt";
            IDatabaseConnection databaseConnection = objectFactory.GetDatabaseConnectionFromFile(configFilePath);
            shelfService = objectFactory.GetShelfService(databaseConnection);
            barcodeVerifier = objectFactory.GetEAN13BarcodeVerifier();
        }
        
        /// <summary>
        /// Mockup Constructor
        /// </summary>
        /// <param name="barcodeVerifier"></param>
        /// <param name="fileAccess"></param>
        /// <param name="shelfService"></param>
        /// <param name="authService"></param>
        public ShelfLogic(IBarcodeVerifier barcodeVerifier,IFileAccess fileAccess,IShelfService shelfService, IAuthService authService)
        {
            this.barcodeVerifier = barcodeVerifier;
            this.authService = authService;
            this.fileAccess = fileAccess;
            this.shelfService = shelfService;
        }

        /// <summary>
        /// Get's a list of products based on the Product ID
        /// </summary>
        /// <param name="username"></param>
        /// <param name="productID"></param>
        /// <returns></returns>
        public List<ShelfProductAmount> GetShelvesContainingProductByID(string username,string productID)
        {
            try
            {
                if (!authService.UserAllowed(username))
                {
                    throw new UserNotAuthorizedException("User is not allowed");
                }

                barcodeVerifier.Verify(productID);

                return shelfService.GetShelvesContainingProductByID(productID);

            }
            catch(Exception e)
            {
                throw e;
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// Registers a shelf, based on the inputs
        /// Uses Factory to get the necesarry services 
        /// Uses ShelfService to register the Shelf
        /// </summary>
        /// <param name="name"></param>
        /// <param name="rackName"></param>
        public void RegisterShelf(string name, string rackName)
        {
            if (authService.UserAllowed(""))
            {
                shelfService.Register(name, rackName);
            }
        }

        /// <summary>
        /// Adds a product to a shelfm based on the inputs
        /// </summary>
        /// <param name="rackName"></param>
        /// <param name="shelfName"></param>
        /// <param name="barcode"></param>
        public void AddProductToShelf(string rackName, string shelfName, string barcode)
        {
            if (authService.UserAllowed(""))
            {
                shelfService.AddProductToShelf(rackName, shelfName, barcode);
            }
        }

        /// <summary>
        /// Adds an amount to a product
        /// </summary>
        /// <param name="rackName"></param>
        /// <param name="shelfName"></param>
        /// <param name="barcode"></param>
        /// <param name="amount"></param>
        public void AddProductAmount(string rackName, string shelfName, string barcode, int amount)
        {
            if (authService.UserAllowed(""))
            {
                shelfService.AddProductAmount(rackName, shelfName, barcode, amount);
            }
        }

        /// <summary>
        /// Removes an amount of products
        /// </summary>
        /// <param name="rackName"></param>
        /// <param name="shelfName"></param>
        /// <param name="barcode"></param>
        /// <param name="amount"></param>
        public void RemoveProductAmount(string rackName, string shelfName, string barcode, int amount)
        {
            if (authService.UserAllowed(""))
            {
                shelfService.RemoveProductAmount(rackName, shelfName, barcode, amount);
            }
        }

        /// <summary>
        /// Gets a list of shelves
        /// </summary>
        /// <returns></returns>
        public List<Shelf> GetShelves()
        {
            if (authService.UserAllowed(""))
            {
                return shelfService.GetShelves();
            }
            return null;
        }

        public List<ShelfProductAmount> GetProductAmount()
        {
            if (authService.UserAllowed(""))
            {
                return shelfService.GetShelfProductAmounts();
            }
            return null;
        }
    }
}
