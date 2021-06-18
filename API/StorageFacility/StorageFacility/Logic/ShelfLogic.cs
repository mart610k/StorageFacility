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
        IAuthService authService;
        IFileAccess fileAccess;
        IShelfService shelfService;
        IBarcodeVerifier barcodeVerifier;

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
        

        public ShelfLogic(IBarcodeVerifier barcodeVerifier,IFileAccess fileAccess,IShelfService shelfService, IAuthService authService)
        {
            this.barcodeVerifier = barcodeVerifier;
            this.authService = authService;
            this.fileAccess = fileAccess;
            this.shelfService = shelfService;
        }

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

        public void AddProductToShelf(string rackName, string shelfName, string barcode)
        {
            if (authService.UserAllowed(""))
            {
                shelfService.AddProductToShelf(rackName, shelfName, barcode);
            }
        }

        public void AddProductAmount(string rackName, string shelfName, string barcode, int amount)
        {
            if (authService.UserAllowed(""))
            {
                shelfService.AddProductAmount(rackName, shelfName, barcode, amount);
            }
        }

        public void RemoveProductAmount(string rackName, string shelfName, string barcode, int amount)
        {
            if (authService.UserAllowed(""))
            {
                shelfService.RemoveProductAmount(rackName, shelfName, barcode, amount);
            }
        }

        public List<Shelf> GetShelves()
        {
            if (authService.UserAllowed(""))
            {
                return shelfService.GetShelves();
            }
            return null;
        }
    }
}
