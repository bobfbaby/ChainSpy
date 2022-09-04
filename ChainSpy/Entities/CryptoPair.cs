using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace ChainSpy.Entities
{
    public class CryptoPair
    {
        [JsonProperty("symbol")]
        public string Pair { get; set; }

        public double Price { get; set; }

    }
}
