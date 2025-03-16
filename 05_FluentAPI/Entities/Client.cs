using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Self_Task_Airlines.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public int ?AccountId { get; set; }

        // Conn
        public Account ?Account { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
}
