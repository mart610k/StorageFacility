using StorageFacility.DTO;
using StorageFacility.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StorageFacility
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FindProducts : ContentPage
    {
        IShelfService ShelfService = new ShelfService();

        public ObservableCollection<ShelfProductAmount> ProductsFound  { get; private set; }


        protected override void OnAppearing()
        {
            shelfProductList.ItemsSource = ProductsFound;

            base.OnAppearing();
        }

        public FindProducts()
        {
            ProductsFound = new ObservableCollection<ShelfProductAmount>();

            InitializeComponent();
        }

        private async void FindProductsByBarcode(object sender, EventArgs e)
        {
            ProductsFound.Clear();

            List<ShelfProductAmount> test = await ShelfService.GetProductsFromBarcde(BarcodeField.Text);
            for (int i = 0; i < test.Count; i++)
            {
                ProductsFound.Add(test[i]);
            }
        }
    }
}