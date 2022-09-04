using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainSpy.Intefaces
{
    public interface IDatabaseContext
    {
        Task SetupDatabase();

        SQLiteAsyncConnection GetConnection();
    }
}
