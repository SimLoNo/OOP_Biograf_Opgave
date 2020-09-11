using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Biograf_Opgave
{//Opmærksom på at klasser skal være ental. Fokusere på at kode funktionalitet, hvis der er tid tilovers retter jeg Kunder klassen.
    class Program
    {
        static void Main(string[] args)
        {
            Indtast Skriv = new Indtast();
            SQL DataCmd = new SQL();
            List<Kunder> KundeList = new List<Kunder>();
            ConsoleKey Valg;

            do
            {
                DataCmd.CheckConnection();
                Menu HovMen = new Menu();
                HovMen.HovedmenuTekst();
                Valg = HovMen.Hovedmenuvalg();
            } while (Valg != ConsoleKey.Escape);
            
        }
    }
}
