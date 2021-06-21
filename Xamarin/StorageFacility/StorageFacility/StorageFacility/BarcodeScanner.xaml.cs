using StorageFacility.Communication;
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
    public partial class BarcodeScanner : ContentPage, IMessageSender
    {
        public BarcodeScanner()
        {
            InitializeComponent();
        }

        private async void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                if(result.BarcodeFormat == ZXing.BarcodeFormat.EAN_13)
                {
                    MessagingCenter.Send<IMessageSender, string>(this, "BarcodeScanned", result.Text);
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("unsupported format", "Please scan a EAN13 barcode", "OK");
                }
            });
        }
    }
}