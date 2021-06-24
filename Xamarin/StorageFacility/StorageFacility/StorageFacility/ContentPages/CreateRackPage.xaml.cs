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
    public partial class CreateRackPage : ContentPage
    {
        IRackService rackService = new RackService();

        public CreateRackPage()
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
            // Auto complete on android adds an extra space at the end of the string added to the field trimming end to ensure that auto complete doesnt add an extra space
            RackNameEntry.Text = RackNameEntry.Text.TrimEnd();

            if(RackNameEntry.Text.Length == 0)
            {
                await DisplayAlert("Rack name cannot be empty","The name of a rack cannot be empty","OK");
            }
            else
            {
                bool resultbool = await rackService.CreateRack(RackNameEntry.Text);
                if (resultbool)
                {
                    await DisplayAlert("New Rack", "New rack have been created", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("New Rack", "New rack have not been created", "OK");
                }
            }
        }
    }
}