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
    }
}
