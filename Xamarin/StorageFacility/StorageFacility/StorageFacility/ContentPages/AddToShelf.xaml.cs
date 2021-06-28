using Newtonsoft.Json.Linq;
using StorageFacility.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageFacility.DTO;
using System.Collections.ObjectModel;
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
        ObservableCollection<Shelf> shelves = new ObservableCollection<Shelf>();
        ObservableCollection<Product> products = new ObservableCollection<Product>();


        protected override void OnAppearing()
        {
            shelfPicker.ItemsSource = shelves;
            productPicker.ItemsSource = products;
            base.OnAppearing();
        }

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
            string shelf = null;
            string rack = null;
            string product = null;
            string barcode = null;

            if (shelfPicker.SelectedItem == null)
            {
                await DisplayAlert("Select Shelf", "You have not selected a shelf", "OK");
                return;
            }

            if (shelfPicker.SelectedItem is Shelf)
            {
                shelf = ((Shelf)shelfPicker.SelectedItem).Name;
                rack = ((Shelf)shelfPicker.SelectedItem).RackName;
            }

            if (productPicker.SelectedItem == null)
            {
                await DisplayAlert("Select Product", "You have not selected a product", "OK");
                return;
            }

            if (productPicker.SelectedItem is Product)
            {
                barcode = ((Product)productPicker.SelectedItem).Barcode.ToString();
                product = ((Product)productPicker.SelectedItem).Name;
            }

            //TODO --MBA Ensure that on 400 an exception is not thrown, and the user is aware that the shelf already contains said product.
            try
            {
                bool resultBool = await shelfService.AddProductToShelf(rack, shelf, barcode);

                if (resultBool)
                {
                    await DisplayAlert("Add Product", string.Format("Product {0} have been added to Shelf {1}", product, shelf), "OK");
                }
                else
                {
                    await DisplayAlert("Add Product", "Product have not been added", "OK");
                }
            }
            catch (Exception error)
            {
                await DisplayAlert("Input", "Error calling API, " + error.Message, "OK");
                return;
            }
            await Navigation.PopToRootAsync();
        }

        /// <summary>
        /// Gets the shelves
        /// Adds to the respective list
        /// </summary>
        private async void GetShelves()
        {
            List<Shelf> tempShelves = await shelfService.GetShelves();
            foreach (Shelf item in tempShelves)
            {
                shelves.Add(item);
            }
            shelfPicker.SelectedIndex = 0;
            
        }

        /// <summary>
        /// Gets the products
        /// Adds to the respective list
        /// </summary>
        private async void GetProducts()
        {
            List<Product> tempProduct = await ProductService.GetProducts();

            foreach (Product product in tempProduct)
            {
                products.Add(product);
            }
            productPicker.SelectedIndex = 0;
        }
    }
}