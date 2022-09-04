using SQLite;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainSpy.Entities
{
    [Table("Address")]
    public class Address
    {
        // PrimaryKey is typically numeric 
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int? Id { get; set; }

        [MaxLength(250), Unique]
        public string Name { get; set; }

        [MaxLength(500), Unique]
        public string LedgerAddress { get; set; }

        [MaxLength(100)]
        public string BlockchainName { get; set; }

    }
}
