using Newtonsoft.Json.Linq;
using StorageFacility.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageFacility.DTO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StorageFacility
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddToShelf : ContentPage
    {
        // Initiating Services
        IShelfService shelfService = new ShelfService();
        IProductService ProductService = new ProductService();

        // Initiating Lists
        List<string> shelfNames = new List<string>();
        List<string> rackNames = new List<string>();
        List<string> productNames = new List<string>();
        List<string> barcodes = new List<string>();


        public AddToShelf()
        {
            InitializeComponent();
            //Get's the necesary shelves and products
            GetShelves();
            GetProducts();
        }

        /// <summary>
        /// Upon button click, adds a product to a shelf
        /// Based upon a Picker item chosen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AddProductToShelf(object sender, EventArgs e)
        {
            string shelf = shelfPicker.SelectedItem.ToString();
            string rack = "";

            for (int i = 0; i < shelfNames.Count; i++)
            {
                if (shelfNames[i] == shelf)
                {
                    rack = rackNames[i];
                }
            }

            string product = ProductPicker.SelectedItem.ToString();
            string barcode = "";

            for (int i = 0; i < productNames.Count; i++)
            {
                if (productNames[i] == product)
                {
                    barcode = barcodes[i];
                }
            }
            //TODO --MBA Ensure that on 400 an exception is not thrown, and the user is aware that the shelf already contains said product.
            bool resultBool = await shelfService.AddProductToShelf(rack, shelf, barcode);

            if (resultBool)
            {
                await DisplayAlert("Add Product", string.Format("Product {0} have been added to Shelf {1}", product, shelf), "OK");
            }
            else
            {
                await DisplayAlert("Add Product", "Product have not been added", "OK");
            }
            await Navigation.PopToRootAsync();
        }

        /// <summary>
        /// Gets the shelves
        /// Adds to the respective list
        /// </summary>
        private async void GetShelves()
        {
            List<Shelf> shelves = await shelfService.GetShelves();
            foreach (var item in shelves)
            {
                shelfNames.Add(item.Name);
                rackNames.Add(item.RackName);
            }
            shelfPicker.ItemsSource = shelfNames;
            shelfPicker.SelectedIndex = 0;
            
        }

        /// <summary>
        /// Gets the products
        /// Adds to the respective list
        /// </summary>
        private async void GetProducts()
        {
            List<Product> products = await ProductService.GetProducts();

            foreach (var item in products)
            {
                productNames.Add(item.Name);
                barcodes.Add(item.Barcode.ToString());
            }
            ProductPicker.ItemsSource = productNames;
            ProductPicker.SelectedIndex = 0;
        }

        private void shelfPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < shelfNames.Count; i++)
            {
                if (shelfNames[i] == shelfPicker.SelectedItem.ToString())
                {
                    RackLabel.Text = "Rack: " + rackNames[i];
                }
            }
        }
    }
}