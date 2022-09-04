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
        public CryptoPair BtcPrice { get; private set; }
        public double UnitPriceGbp { get; private set; }
        public double ValueInGbp { get; set; } = 0;

        internal void SetPrice(CryptoPair pair, CryptoPair btcgpb)
        {
            BtcPrice = pair;
            UnitPriceGbp = BtcPrice.Price * btcgpb.Price;
            ValueInGbp = (Balance.Balance * pair.Price) * btcgpb.Price;
        }
    }
}
