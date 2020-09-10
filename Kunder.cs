using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Biograf_Opgave
{
    class Kunder
    {
        public int Id { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Email { get; set; }
        public int Tlf { get; set; }
        public string Kundetype { get; set; }

        public Kunder(int id, string fornavn, string efternavn, string email, int tlf, string kundetype) 
        {
            Id = id;
            Fornavn = fornavn;
            Efternavn = efternavn;
            Email = email;
            Tlf = tlf;
            Kundetype = kundetype;
        }
        public override string ToString()
        {
            return (Id +" " + Fornavn + " " + Efternavn + " " + Email + " " + Tlf + " " + Kundetype);
        }
    }
}
