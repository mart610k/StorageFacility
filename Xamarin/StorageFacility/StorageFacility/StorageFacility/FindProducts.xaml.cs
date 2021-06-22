using StorageFacility.Communication;
using StorageFacility.DTO;
using StorageFacility.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StorageFacility
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FindProducts : ContentPage
    {
        IShelfService ShelfService = new ShelfService();

        public ObservableCollection<ShelfProductAmount> ProductsFound  { get; private set; }

        /// <summary>
        /// subscribe to obtain the barcode message, and check device platform.
        /// </summary>
        protected override void OnAppearing()
        {
            shelfProductList.ItemsSource = ProductsFound;

            base.OnAppearing();
            MessagingCenter.Subscribe<IMessageSender, string>(this, "BarcodeScanned", (sender, barcode) =>
            {
                BarcodeField.Text = barcode;
               
            });

            if (Device.RuntimePlatform == Device.UWP)
            {
                ScanButton.IsEnabled = false;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            MessagingCenter.Unsubscribe<IMessageSender, string>(this, "BarcodeScanned");
            return base.OnBackButtonPressed();
        }

        public FindProducts()
        {
            ProductsFound = new ObservableCollection<ShelfProductAmount>();

            InitializeComponent();
        }
        
        /// <summary>
        /// Navigates to the content page where the scanning barcodes can happen
        /// </summary>
        private async void ScanBarcode(object sender, EventArgs e)
        {
            ProductsFound.Clear();
            await Navigation.PushAsync(new BarcodeScanner());
        }

        /// <summary>
        /// Calls the services to find product by their barcode
        /// </summary>
        private async void FindProductsByBarcode(object sender, EventArgs e)
        {
            ProductsFound.Clear();

            List<ShelfProductAmount> test = await ShelfService.GetProductsFromBarcode(BarcodeField.Text);
            for (int i = 0; i < test.Count; i++)
            {
                ProductsFound.Add(test[i]);
            }
        }
    }
}