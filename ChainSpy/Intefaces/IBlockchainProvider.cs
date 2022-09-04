using ChainSpy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainSpy.Intefaces
{
    public interface IBlockchainProvider
    {
        Task<CryptoBalance> GetBalance(Address address);
        List<string> GetBlockchains();
    }
}
