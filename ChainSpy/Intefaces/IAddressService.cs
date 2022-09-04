using ChainSpy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainSpy.Intefaces
{
    public interface IAddressService
    {
        Task<List<Address>> GetAddresses();

        Task AddAddress(Address address);
        Task RemoveAddress(ResolvedAddress address);
    }
}
