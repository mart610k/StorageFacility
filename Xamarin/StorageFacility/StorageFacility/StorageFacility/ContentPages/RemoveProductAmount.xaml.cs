using StorageFacility.DTO;
using StorageFacility.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StorageFacility.ContentPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RemoveProductAmount : ContentPage
    {
        // Initiating Services
        IShelfService shelfService = new ShelfService();

        // Initiating Lists
        ObservableCollection<ShelfProductAmount> ShelfProducts = new ObservableCollection<ShelfProductAmount>();
        public RemoveProductAmount()
        {
            InitializeComponent();
            GetData();
        }
        protected override void OnAppearing()
        {
            dataPicker.ItemsSource = ShelfProducts;
            base.OnAppearing();
        }

        private async void GetData()
        {
            List<ShelfProductAmount> TempList = await shelfService.GetProductAmount();
            foreach (ShelfProductAmount item in TempList)
            {
                ShelfProducts.Add(item);
            }
            dataPicker.SelectedIndex = 0;
        }

        private void dataPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maxRemove = ((ShelfProductAmount)dataPicker.SelectedItem).Amount;

            AmountOfProducts.Text = "Current Amount: " + ((ShelfProductAmount)dataPicker.SelectedItem).Amount.ToString() + "\r\n"
                + "Can remove " + maxRemove + " " + ((ShelfProductAmount)dataPicker.SelectedItem).Product.Name;
        }

        private async void RemoveAmount(object sender, EventArgs e)
        {
            string shelf = null;
            string rack = null;
            string barcode = null;
            string product = null;
            int amount = 0;

            if (dataPicker.SelectedItem == null)
            {
                await DisplayAlert("Select Product", "You have not selected a product", "OK");
                return;
            }

            if (dataPicker.SelectedItem is ShelfProductAmount)
            {
                shelf = ((ShelfProductAmount)dataPicker.SelectedItem).Shelf.Name;
                rack = ((ShelfProductAmount)dataPicker.SelectedItem).Shelf.RackName;
                barcode = ((ShelfProductAmount)dataPicker.SelectedItem).Product.Barcode.ToString();
                product = ((ShelfProductAmount)dataPicker.SelectedItem).Product.Name;
            }

            if (AmountEntry.Text == null)
            {
                await DisplayAlert("Add Amount", "You have not Entered an Amount", "OK");
                return;
            }
            else if (Regex.IsMatch(AmountEntry.Text, "^[0-9]{0,3}$"))
            {
                try
                {
                    amount = Convert.ToByte(AmountEntry.Text);
                }
                catch (OverflowException)
                {
                    await DisplayAlert("Format", "Input Number is too big", "OK");
                    return;
                }
            }
            else
            {
                await DisplayAlert("Input", "Format Number is above 3 Signs or Format is not a Number", "OK");
                return;
            }

            //TODO --MBA Ensure that on 400 an exception is not thrown, and the user is aware that the shelf already contains said product.
            try
            {
                bool resultBool = await shelfService.RemoveProductAmount(rack, shelf, barcode, amount);

                if (resultBool)
                {
                    await DisplayAlert("Remove Product", string.Format("{0} {1} have been removed from Shelf {2}", amount, product, shelf), "OK");
                }
                else
                {
                    await DisplayAlert("Remove Product", "Product have not been removed", "OK");
                }
            }
            catch (Exception error)
            {
                await DisplayAlert("Input", "Error calling API, " + error.Message, "OK");
                return;
            }
            await Navigation.PopToRootAsync();
        }
    }
}