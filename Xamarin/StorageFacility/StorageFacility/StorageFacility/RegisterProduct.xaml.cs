﻿using StorageFacility.Service;
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
            NameEntry.Text = NameEntry.Text.TrimEnd();

            if (!Regex.IsMatch(BarcodeEntry.Text, "^[0-9]{13}$"))
            {
                await DisplayAlert("barcode format error", "Barcode does not fit expected lenght or have characters in it", "OK");
                hadValidationErrors = true;
            }

            if(NameEntry.Text.Length > 64)
            {
                await DisplayAlert("Product name too long", "Product name must be below 64 charcters", "OK");

                hadValidationErrors = true;
            }
            else if (NameEntry.Text.Length == 0)
            {
                await DisplayAlert("Product name cannot be empty", "The name of a product cannot be empty", "OK");

                hadValidationErrors = true;
            }

            if (!hadValidationErrors)
            {
                await productService.CreateProduct(NameEntry.Text, BarcodeEntry.Text);
                await DisplayAlert("Successfull", string.Format("the product {0} was created with the barcode {1}", NameEntry.Text, BarcodeEntry.Text), "OK");
                await Navigation.PopAsync();
            }
        }
    }
}