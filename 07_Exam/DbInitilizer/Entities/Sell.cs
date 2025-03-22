using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbInitilizer.Entities
{
    public class Sell
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int AccountId { get; set; }
        public DateTime SellDate { get; set; }

        // conn
        public Book Book { get; set; }
        public Account Account { get; set; }
    }
}
