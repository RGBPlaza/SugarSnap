using Newtonsoft.Json;
using SugarSnap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SugarSnap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScannerPage : ContentPage
    {
        public ScannerPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            barcodeScanner.Cancel();
            return base.OnBackButtonPressed();
        }

        ZXing.Mobile.MobileBarcodeScanner barcodeScanner = new ZXing.Mobile.MobileBarcodeScanner();

    }
}
