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
        ProductService productService = new ProductService();

        public RegisterProduct()
        {
            InitializeComponent();
        }

        private async void Validate_Input_And_Send(object sender, EventArgs e)
        {
            bool hadValidationErrors = false;


            if(!Regex.IsMatch(BarcodeEntry.Text, "^[0-9]{13}$"))
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
                await productService.CreateProduct(NameEntry.Text, BarcodeEntry.Text);
                await DisplayAlert("Successfull", string.Format("the product {0} was created with the barcode {1}", NameEntry.Text, BarcodeEntry.Text), "OK");
            }
        }
    }
}