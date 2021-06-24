using StorageFacility.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StorageFacility
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateShelfPage : ContentPage
    {
        IRackService rackService = new RackService();
        IShelfService shelfService = new ShelfService();

        public CreateShelfPage()
        {
            InitializeComponent();
            GetRaftPickerData();
        }

        private async void GetRaftPickerData()
        {
            rackPicker.ItemsSource = await rackService.GetRacks();
            rackPicker.SelectedIndex = 0;
        }

        private async void CreateShelf(object sender, EventArgs e)
        {
            shelfName.Text = shelfName.Text.TrimEnd();

            if (shelfName.Text.Length == 0)
            {
                await DisplayAlert("Shelf name cannot be empty", "The name of a shelf cannot be empty", "OK");
            }
            else
            {
                bool resultBool = await shelfService.CreateShelf(shelfName.Text, rackPicker.SelectedItem.ToString());

                if (resultBool)
                {
                    await DisplayAlert("New Shelf", string.Format("Shelf {0} have been created, on Rack {1}", shelfName.Text, rackPicker.SelectedItem), "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("New Shelf", "New Shelf have not been created", "OK");
                }
            }
        }
    }
}