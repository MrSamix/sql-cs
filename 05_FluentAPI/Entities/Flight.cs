using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Self_Task_Airlines.Entities
{
    public class Flight
    {
        public int Id { get; set; }
        public int AirplaneId { get; set; }
        public ICollection<Client> Clients { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string LocationFrom { get; set; }
        public string LocationTo { get; set; }

        // Conn
        public Airplane Airplane { get; set; }



    }
}
