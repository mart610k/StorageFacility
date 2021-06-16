using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StorageFacility
{
    public partial class MainPage : ContentPage
    {
        APIService apiService = new APIService();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Create_New_Rack(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("New Rack", "Enter Rack Name:");
            bool resultbool = await apiService.CreateRack(result);
            if (resultbool)
            {
                await DisplayAlert("New Rack", "New rack have been created", "OK");
            }
            else
            {
                await DisplayAlert("New Rack", "New rack have not been created", "OK");
            }
        }

        private async void Shelf_Visible(object sender, EventArgs e)
        {
            newShelfPopup.IsVisible = true;
            rackPicker.ItemsSource = await apiService.GetRacks();
            rackPicker.SelectedIndex = 0;
        }

        private async void CreateShelf(object sender, EventArgs e)
        {
            bool resultBool = await apiService.CreateShelf(shelfName.Text, rackPicker.SelectedItem.ToString());

            if (resultBool)
            {
                await DisplayAlert("New Shelf", string.Format("Shelf {0} have been created, on Rack {1}", shelfName.Text, rackPicker.SelectedItem), "OK");
            }
            else
            {
                await DisplayAlert("New Shelf", "New Shelf have not been created", "OK");
            }

            newShelfPopup.IsVisible = false;
            rackPicker.ItemsSource = null;
            shelfName.Text = "";
        }
    }
}
