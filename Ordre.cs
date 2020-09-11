using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Biograf_Opgave
{
    class Ordre
    {public void OpretBestilling() 
        {
            Indtast Skriv = new Indtast();
            SQL DataCmd = new SQL();
            int KundeId = Skriv.IndtastId();
            DateTime Forestilling = Skriv.IndtastDato();
            string Film = Skriv.IndtastFilm();
            string Betalling = Skriv.IndtastBetalling();
            Bestilling Ordre = new Bestilling(KundeId, Forestilling,Film,Betalling);
            DataCmd.OpretBestilling(Ordre);

        }
    }
}
