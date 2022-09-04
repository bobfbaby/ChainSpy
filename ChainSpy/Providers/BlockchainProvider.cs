using ChainSpy.Entities;
using ChainSpy.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainSpy.Providers
{
    public class BlockchainProvider : IBlockchainProvider
    {
        public BlockchainProvider()
        {
            this.BalanceProviders = new Dictionary<string, IBalanceProvider>() {

                {"XDC", new XdcBalanceProvider()},
                {"HBAR", new HbarBalanceProvider() },
                {"XRP", new XrpBalanceProvider() }


            };
        }

        internal Dictionary<string, IBalanceProvider> BalanceProviders { get; private set; }

        public async Task<CryptoBalance> GetBalance(Address address)
        {
            if (BalanceProviders.ContainsKey(address.BlockchainName))
            {
                var balanceProvider = BalanceProviders[address.BlockchainName];
                var balance = await balanceProvider.GetBalanceForAddress(address.LedgerAddress);
                return new CryptoBalance(address.BlockchainName, balance);

            }
            else
            {
                return new CryptoBalance(address.BlockchainName, 0.0 );
            }
        }

        public List<string> GetBlockchains()
        {
            return new List<string>() {
            
                "HBAR",
                "XRP",
                "XLM",
                "XDC",
                "XYO", 

            };
        }
    }
}
