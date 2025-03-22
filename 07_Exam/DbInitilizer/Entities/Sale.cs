using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbInitilizer.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Discount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // conn
        public ICollection<Book> Books { get; set; } // many books to one sale
    }
}
