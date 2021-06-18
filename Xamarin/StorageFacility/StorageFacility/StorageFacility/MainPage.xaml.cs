using StorageFacility.Service;
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
        IRackService rackService = new RackService();
        IShelfService shelfService = new ShelfService();

        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Upon button click, shows Create popup.
        /// Creates Rack based on popup input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Create_New_Rack(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("New Rack", "Enter Rack Name:");
            bool resultbool = await rackService.CreateRack(result);
            if (resultbool)
            {
                await DisplayAlert("New Rack", "New rack have been created", "OK");
            }
            else
            {
                await DisplayAlert("New Rack", "New rack have not been created", "OK");
            }
        }

        /// <summary>
        /// Upon button click, makes the shelf popup visible
        /// Sets the rackPicker item source
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Shelf_Visible(object sender, EventArgs e)
        {
            newShelfPopup.IsVisible = true;
            rackPicker.ItemsSource = await rackService.GetRacks();
            rackPicker.SelectedIndex = 0;
        }

        /// <summary>
        /// Upon button click, creates a shelf based on inputs
        /// Displays whether created or not afterwards
        /// Turns off Shelf Visibility
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CreateShelf(object sender, EventArgs e)
        {
            bool resultBool = await shelfService.CreateShelf(shelfName.Text, rackPicker.SelectedItem.ToString());

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

        /// <summary>
        /// Upon button click, Redirects to a new content page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Show_Register_Product(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterProduct());
        }

        private async void Find_Product_Page(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FindProducts());
        }

        private async void Show_AddToShelf(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddToShelf());
        }
    }
}
