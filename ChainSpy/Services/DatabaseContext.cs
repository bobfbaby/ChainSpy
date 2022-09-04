using ChainSpy.Entities;
using ChainSpy.Intefaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainSpy.Services
{
    public class DatabaseContext : IDatabaseContext
    {
        public DatabaseContext()
        {

        }

        public string DbPath { get; private set; }

        public SQLiteAsyncConnection  GetConnection()
        {
            return new SQLiteAsyncConnection(DbPath);
        }

        public async Task SetupDatabase() {


            DbPath = Path.Combine(FileSystem.Current.AppDataDirectory, "chainspy.db");

            var db = new SQLiteAsyncConnection(DbPath);

            await db.CreateTableAsync<Address>(); 

        }
    }
}
