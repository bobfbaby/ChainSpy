 
using ChainSpy.Entities;
using ChainSpy.Intefaces;
using ChainSpy.Providers;
using ChainSpy.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Address = ChainSpy.Entities.Address;

namespace ChainSpy.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        private readonly IAddressService addressService;
        private readonly IBlockchainProvider blockchainProvider;
        private readonly MarketProvider marketProvider;


        [ObservableProperty]
        private ObservableCollection<ResolvedAddress> addresses;

        [ObservableProperty]
        private ResolvedAddress selectedAddress;

        [ObservableProperty]
        private double totalValue;

        public MainPageViewModel(IAddressService addressService, IBlockchainProvider blockchainProvider, MarketProvider marketProvider)
        {
            Addresses = new ObservableCollection<ResolvedAddress>();
      
            this.addressService = addressService;
            this.blockchainProvider = blockchainProvider;
            this.marketProvider = marketProvider;
        }


        [RelayCommand]
        private async Task LoadData()
        {
            try
            {
                var addresses = await addressService.GetAddresses();
                Addresses = new ObservableCollection<ResolvedAddress>();
                var prices = await marketProvider.GetMarketPrices();

                var btcgpb = prices.FirstOrDefault(x => x.Pair == "BTCGBP");

                foreach (var address in addresses)
                {
                    CryptoBalance balance = await blockchainProvider.GetBalance(address);

                    var pair =  prices.FirstOrDefault(x => x.Pair == $"{address.BlockchainName}BTC");

                    var resolved = new ResolvedAddress(address, balance);

                    if (pair != null && btcgpb != null)
                    {
                        resolved.SetPrice(pair, btcgpb);
                    }
                    Addresses.Add(resolved);
                }

                TotalValue = Addresses.Sum(x => x.ValueInGbp);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [RelayCommand]
        async Task SelectedAddressChanged() {

            var o = selectedAddress;
            await Shell.Current.GoToAsync(nameof(AddressDetailPage), new Dictionary<string, object>() { { "address", o } });

        }



        [RelayCommand]
        private async Task ScanQr() {
            await Shell.Current.GoToAsync(nameof(QrReaderPage));
        }
        [RelayCommand]
        private async Task AddAddress()
        {
            await Shell.Current.GoToAsync(nameof(AddAddressPage));
        }


        [RelayCommand]
        private async Task RefreshData()
        {
            await LoadData();
        }


    }
}
