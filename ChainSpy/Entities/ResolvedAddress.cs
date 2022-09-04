using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainSpy.Entities
{
    public class ResolvedAddress
    {
        public ResolvedAddress(Address address, CryptoBalance balance)
        {
            Address = address;
            Balance = balance;
        }

        public Address Address { get; }
        public CryptoBalance Balance { get; }
    }
}
