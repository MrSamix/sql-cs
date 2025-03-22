using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbInitilizer.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        // conn
        public Book Book { get; set; } // one to one
        public Sell Sell { get; set; }
    }
}
