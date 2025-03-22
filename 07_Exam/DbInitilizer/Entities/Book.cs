using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbInitilizer.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string DistributorName { get; set; }
        public int BookSize { get; set; } = 0;
        public string Genre { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public int SalePrice { get; set; }
        public bool IsAvailable { get; set; } = true;
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public int? SubBookId { get; set; }
        public int? AccountReservationId { get; set; }
        public int? SaleId { get; set; }

        // conn
        public Account Account { get; set; } // one to one
        public Sale Sale { get; set; } // one to many
        public Book BookContinue { get; set; } 
        public Book SubBook { get; set; }

        public Sell Sell { get; set; }
    }
}
