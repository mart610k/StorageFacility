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
        /// <summary>
        /// Result of ZXing(ZebraCrossing) scanning view result
        /// </summary>
        /// <param name="result"></param>
        private async void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                // We are only interested EAN_13 barcode formats
                if(result.BarcodeFormat == ZXing.BarcodeFormat.EAN_13)
                {
                    // Sends message for which barcode was scanned then pops the current content page
                    MessagingCenter.Send<IMessageSender, string>(this, "BarcodeScanned", result.Text);
                    await Navigation.PopAsync();
                }
                // Show an alert if format was not the one expected.
                else
                {
                    await DisplayAlert("unsupported format", "Please scan a EAN13 barcode", "OK");
                }
            });
        }
    }
}