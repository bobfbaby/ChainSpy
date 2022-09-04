
using ChainSpy.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainSpy.Providers
{
    public class MarketProvider
    {
        private HttpClient httpClient;

        public MarketProvider()
        {
            this.httpClient = new HttpClient();

            
        }

        

        public async Task<List<CryptoPair>> GetMarketPrices()
        {
            string key = await GetApiKey();
            var url = $"https://api.binance.com/api/v3/ticker/price?symbols=[\"BTCGBP\",\"XRPBTC\",\"XLMBTC\",\"HBARBTC\"]";
            var result = await httpClient.GetStringAsync(url);

            var responseJson = System.Text.Json.JsonDocument.Parse(result);
            var pairs = await JsonConvert.DeserializeObjectAsync<List<CryptoPair>>(result.ToString());

            return pairs;
        }

        private async Task<string> GetApiKey()
        {
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("Keys\livecoinwatch.txt");
                using var reader = new StreamReader(stream);

                return await reader.ReadToEndAsync();
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
