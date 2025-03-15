using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_EF_CodeFirst.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        // Conn
        public Country Country { get; set; }
    }
}
