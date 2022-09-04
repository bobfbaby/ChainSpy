using ChainSpy.Entities;
using ChainSpy.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainSpy.Services
{
    public class AddressService : IAddressService
    {
        private readonly IDatabaseContext dbContext;

        public AddressService(IDatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task AddAddress(Address address)
        {
            var connection = dbContext.GetConnection();
            return connection.InsertOrReplaceAsync(address);
        }

        public Task<List<Address>> GetAddresses()
        {
            var connection = dbContext.GetConnection(); 
            return connection.Table<Address>().ToListAsync();
        }

        public   Task RemoveAddress(ResolvedAddress address)
        {
            var connection = dbContext.GetConnection();
            return connection.DeleteAsync(address.Address);
        }
    }
}
