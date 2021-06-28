using StorageFacility.Communication;
using StorageFacility.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StorageFacility
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterProduct : ContentPage
    {
        IProductService productService = new ProductService();
        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<IMessageSender, string>(this, "BarcodeScanned", (sender, barcode) =>
            {
                BarcodeField.Text = barcode;

            });

            if (Device.RuntimePlatform == Device.UWP)
            {
                ScanBarcodeButton.IsEnabled = false;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            MessagingCenter.Unsubscribe<IMessageSender, string>(this, "BarcodeScanned");
            return base.OnBackButtonPressed();
        }

        public RegisterProduct()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Checks input and sends the data to create the product
        /// </summary>
        private async void Validate_Input_And_Send(object sender, EventArgs e)
        {
            bool hadValidationErrors = false;


            if(!Regex.IsMatch(BarcodeField.Text, "^[0-9]{13}$"))
            {
                await DisplayAlert("barcode", "Barcode does not fit expected lenght or have characters in it", "OK");
                hadValidationErrors = true;
            }

            if(NameEntry.Text.Length > 64)
            {
                await DisplayAlert("Name", "Product name must be below 64 charcters", "OK");

                hadValidationErrors = true;
            }

            if (!hadValidationErrors)
            {
                try
                {
                    await productService.CreateProduct(NameEntry.Text, BarcodeField.Text);
                    await DisplayAlert("Successfull", string.Format("the product {0} was created with the barcode {1}", NameEntry.Text, BarcodeField.Text), "OK");
                    await Navigation.PopAsync();
                }
                catch (Exception error)
                {
                    await DisplayAlert("Input", "Error calling API, " + error.Message, "OK");
                    return;
                }
            }
        }

        private async void Scan_Barcode(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BarcodeScanner());
        }
    }
}