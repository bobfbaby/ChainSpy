using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainSpy.Intefaces
{
    interface IBalanceProvider
    {
        Task<double> GetBalanceForAddress(string address);
    }
}
