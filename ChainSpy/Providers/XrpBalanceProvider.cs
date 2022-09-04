using ChainSpy.Intefaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ChainSpy.Providers
{
    public class XrpBalanceProvider : IBalanceProvider
    {
        private readonly HttpClient httpClient;

        public XrpBalanceProvider()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<double> GetBalanceForAddress(string address)
        {
            var url = $"https://xrplcluster.com/e";

            var payload = new XrpPayload(address);

            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            var serialised = await JsonConvert.SerializeObjectAsync(payload, Formatting.None, serializerSettings);

            var content = new StringContent(serialised, Encoding.ASCII, "application/json");
            var result = await httpClient.PostAsync(url, content);
            var res = await result.Content.ReadAsStringAsync();
            var responseJson = System.Text.Json.JsonDocument.Parse(res);
            var balanceItem = responseJson.RootElement
                                   .GetProperty("result")
                                   .GetProperty("account_data")
                                   .GetProperty("Balance");
            var balanceInt = long.TryParse( balanceItem.GetString(), out var balanceLong); 

            var balance = balanceLong / 1000000.0;

            return balance;
        }
    }

    class XrpPayload
    {
         
        public string Method { get; set; }

        public List<dynamic> Params { get; set; }
         
        public XrpPayload(string address)
        {
            
            Method = "account_info";
            Params = new List<dynamic>();
            Params.Add(new {
                account = address,
                strict = true,
                ledger_index = "current",
                queue = true
            });

 
        

        }
        
    }
}
