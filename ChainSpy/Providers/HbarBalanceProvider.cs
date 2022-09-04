using ChainSpy.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainSpy.Providers
{
    public class HbarBalanceProvider : IBalanceProvider
    {
        private readonly HttpClient httpClient;

        public HbarBalanceProvider()
        {
            this.httpClient = new HttpClient();
        }
        public async Task<double> GetBalanceForAddress(string address)
        {
            try
            {

                
                var url = $"https://mainnet-public.mirrornode.hedera.com/api/v1/balances?account.id={address}";
                var result = await httpClient.GetStringAsync(url);

                var responseJson = System.Text.Json.JsonDocument.Parse(result);
                
                var balance = responseJson.RootElement
                                   .GetProperty("balances")[0].GetProperty("balance");
                balance.TryGetDouble(out var balanceRaw);
                 
                return balanceRaw / 100000000 ;
            }
            catch (Exception e)
            {
                return 0;
            }
            
        }
    }
}
