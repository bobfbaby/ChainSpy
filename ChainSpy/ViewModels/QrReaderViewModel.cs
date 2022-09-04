using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;
using CommunityToolkit.Maui.Alerts;
using SQLite;

namespace ChainSpy.ViewModels
{
    public partial class QrReaderViewModel : BaseViewModel
    {

        [ObservableProperty]
        BarcodeReaderOptions options;

        [ObservableProperty]
        string barcodeResult;

        public QrReaderViewModel()
        {
            Options = new BarcodeReaderOptions
            {
                Formats = BarcodeFormats.All,
                AutoRotate = true,
                Multiple = false,
                TryHarder = true 
            };
        }

        [RelayCommand]
        public async Task BarcodeDetected( BarcodeResult[] e ) {

            //var toast = Toast.Make($"got barcode{e?.ToString()}");
            //toast.Show();
            if (e != null && e.Count() > 0) {

                MainThread.BeginInvokeOnMainThread(async() =>
                {
                    // Code to run on the main thread
                    await Shell.Current.GoToAsync(nameof(AddAddressPage), new Dictionary<string, object> { { "address", e[0].Value } });

                });
                
                BarcodeResult = e[0].Value; 
            }
                
        }
    }
}
