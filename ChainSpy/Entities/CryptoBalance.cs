using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainSpy.Entities
{
    public class CryptoBalance
    {
        public CryptoBalance(string blockchainName, double balance)
        {
            BlockchainName = blockchainName;
            Balance = balance;
        }

        public string BlockchainName { get; }
        public double Balance { get; }
    }
}
