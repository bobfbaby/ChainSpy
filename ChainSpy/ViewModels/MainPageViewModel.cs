 
using ChainSpy.Entities;
using ChainSpy.Intefaces;
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


        [ObservableProperty]
        private ObservableCollection<ResolvedAddress> addresses;


        public MainPageViewModel(IAddressService addressService, IBlockchainProvider blockchainProvider)
        {
            Addresses = new ObservableCollection<ResolvedAddress>();
      
            this.addressService = addressService;
            this.blockchainProvider = blockchainProvider;
            
            
        }


        [RelayCommand]
        private async Task LoadData()
        {
            try
            {
                var addresses = await addressService.GetAddresses();
                Addresses = new ObservableCollection<ResolvedAddress>();

                foreach (var address in addresses)
                {
                    CryptoBalance balance = await blockchainProvider.GetBalance(address);
                    Addresses.Add(new ResolvedAddress(address, balance));
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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
