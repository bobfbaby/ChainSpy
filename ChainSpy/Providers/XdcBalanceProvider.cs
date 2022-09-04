using ChainSpy.Intefaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ZXing.Client.Result;

namespace ChainSpy.Providers
{
    public class XdcBalanceProvider : IBalanceProvider
    {
        private readonly HttpClient httpClient;

        public XdcBalanceProvider()
        {
            this.httpClient = new HttpClient();
        }
        public async Task<double> GetBalanceForAddress(string address)
        {
            var url = $"https://arpc.xinfin.network/getBalance";
             
            var payload = new XdcPayload(address);

            var serialised = await JsonConvert.SerializeObjectAsync(payload);

            var content = new StringContent(serialised, Encoding.ASCII, "application/json");
            var result =  await httpClient.PostAsync(url, content);
            var res = await result.Content.ReadAsStringAsync();
            var responseJson = System.Text.Json.JsonDocument.Parse(res);
            var balanceHex = responseJson.RootElement
                                   .GetProperty("result") ;
            var balanceHexString = balanceHex.GetString();

            if (balanceHexString.StartsWith("0x"))
            {
                balanceHexString = balanceHexString.Replace("0x", "", StringComparison.InvariantCulture);
            }
          
            var largBalance = BigInteger.Parse(balanceHexString, System.Globalization.NumberStyles.HexNumber);
            
           
            var balance = ((double)largBalance) / 1000000000000000000;

            return balance;
        }

        class XdcPayload {
            public string JsonRpc { get; set; }

            public string Method { get; set; }

            public string[] Params { get; set; }
            
            public int Id { get; set; }

            public XdcPayload(string address)
            {
                JsonRpc = "2.0";
                Method = "eth_getBalance";
                Params = new string[] { address, "latest" };
                Id = 1;
            }
        }
    }
}
