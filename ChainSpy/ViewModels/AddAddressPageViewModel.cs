using ChainSpy.Intefaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainSpy.ViewModels
{
    [QueryProperty("Address","address")]
    public partial class AddAddressPageViewModel : BaseViewModel
    {
        private readonly IAddressService addressService;

        [ObservableProperty]
        List<string> acceptedBlockchains;

        [ObservableProperty]
        string address;


        [ObservableProperty]
        string selectedBlockchain;


        [ObservableProperty]
        string name;

        public AddAddressPageViewModel(IAddressService addressService, IBlockchainProvider blockchainProvider)
        {
            this.addressService = addressService;

            AcceptedBlockchains = blockchainProvider.GetBlockchains();
            SelectedBlockchain = AcceptedBlockchains.FirstOrDefault();
        }

        [RelayCommand]
        async Task AddAddress() {
            await addressService.AddAddress(new Entities.Address()
            {
                Name = name,
                BlockchainName = selectedBlockchain,
                LedgerAddress = address
            }); ;

            await Shell.Current.GoToAsync("///" + nameof(MainPage));
        }

        [RelayCommand]
        async Task CancelAdd()
        {
            await Shell.Current.GoToAsync("///" + nameof(MainPage));
        }

    }
}
