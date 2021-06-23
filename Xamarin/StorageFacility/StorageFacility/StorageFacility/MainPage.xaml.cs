using StorageFacility.ContentPages;
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
            await Navigation.PushAsync(new CreateRackPage());
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

            await Navigation.PushAsync(new CreateShelfPage());
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

        /// <summary>
        /// Navigates to the find products content page
        /// </summary>
        private async void Find_Product_Page(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FindProducts());
        }

        /// <summary>
        /// Shows the content page to add product to shelf
        /// </summary>
        private async void Show_AddToShelf(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddToShelf());
        }

        private async void Show_AddProductAmount(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProductAmount());
        }
    }
}
