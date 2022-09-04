using ChainSpy.Entities;
using ChainSpy.Intefaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainSpy.ViewModels
{
    [QueryProperty("Address", "address")]
    public partial class AddressDetailViewModel : BaseViewModel
    {
        private readonly IAddressService addressService;



        [ObservableProperty]
        ResolvedAddress address;

        public AddressDetailViewModel(IAddressService addressService)
        {
            this.addressService = addressService;
        }


        [RelayCommand]
        async Task DeleteAddress() {

            await this.addressService.RemoveAddress(address);


        }


    }
}
