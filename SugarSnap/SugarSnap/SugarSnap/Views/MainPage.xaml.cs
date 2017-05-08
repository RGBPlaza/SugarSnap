using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using SugarSnap.Models;
using System.Net.Http;
using ZXing.Mobile;

namespace SugarSnap.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            tap.Tapped += new EventHandler(ScreenTapped);
        }

        private MobileBarcodeScanner barcodeScanner = new MobileBarcodeScanner();
        private bool isScanning = false;

        protected override bool OnBackButtonPressed()
        {
            if (isScanning)
            {
                barcodeScanner.Cancel();
                isScanning = false;
                return true;
            }
            return base.OnBackButtonPressed();
        }

        TapGestureRecognizer tap = new TapGestureRecognizer();

        private void ScreenTapped(object sender, EventArgs e)
        {
            if (isScanning)
            {
                barcodeScanner.AutoFocus();
            }
        }

        private async void ScanBarcode(object sender, EventArgs e){

            try
            {
                isScanning = true;
                var result = await barcodeScanner.Scan(new MobileBarcodeScanningOptions() { PossibleFormats = { ZXing.BarcodeFormat.UPC_A, ZXing.BarcodeFormat.UPC_E, ZXing.BarcodeFormat.UPC_EAN_EXTENSION, ZXing.BarcodeFormat.EAN_13, ZXing.BarcodeFormat.EAN_8 } });
                HttpClient client = new HttpClient();

                if (isScanning && result != null)
                {
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "5fafd4ed0519499693a0c794dc3f0712");
                    var response = await client.GetAsync("https://dev.tescolabs.com/product/?gtin=" + result.Text);

                    await Navigation.PushAsync(new InfoPage(await response.Content.ReadAsStringAsync()));
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Let's Fix this!");
            }

        }

        private void AllergensButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AllergensPage());
        }
    }
}
