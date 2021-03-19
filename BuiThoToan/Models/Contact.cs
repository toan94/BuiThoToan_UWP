using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuiThoToan.Models
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
    }
}
