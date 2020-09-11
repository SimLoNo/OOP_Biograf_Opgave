using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Biograf_Opgave
{
    class Menu
    { public void HovedmenuTekst()
        {
            Console.Clear();
            Console.WriteLine("Velkommen til Biografen, tast følgende for diverse menuer:");
            Console.WriteLine("1:      Opret bruger");
            Console.WriteLine("2:      Rediger bruger");
            Console.WriteLine("3:      Slet bruger");
            Console.WriteLine("4:      Vis brugere sorteret efter efternavn");
            Console.WriteLine("5:      Vis brugere usorteret");
            Console.WriteLine("6:      Vis Ordre");
            Console.WriteLine("7:      Opret Ordre");
            Console.WriteLine("Escape: for at afslutte programmet");


        }
        

        public void Fortsaet()
        {
            Console.WriteLine("Indtast vilkårlig tast for at fortsætte.");
            Console.ReadKey(true);
        }

        public void SkrivTabel(bool Valg)
        {
            Console.Clear();
            SQL DataCmd = new SQL();
            List<Kunder> Kunde = new List<Kunder>();
            Kunde = DataCmd.VisKunder(Valg);
            foreach (var item in Kunde)
            {
                Console.WriteLine(item.ToString());
            }

        }
        public void SkrivOrdre()
        {
            Console.Clear();
            Indtast Skriv = new Indtast();
            SQL DataCmd = new SQL();
            List<Bestilling> Ordre = new List<Bestilling>();
            Ordre = DataCmd.VisBestilling(Skriv.IndtastId());
            
            if (Ordre.Count >= 1) 
            {
                Ordre.Sort();
                Console.WriteLine("Ordre:");
                foreach (var item in Ordre)
                {
                    Console.WriteLine($"Navn: {item.Fornavn} {item.Efternavn} Film: {item.Film} {item.Bestillingstid} Betallingsstatus: {item.Betalling}");
                }
            }
            else Console.WriteLine("Der kunne ikke findes nogle ordre.");
        }
        public ConsoleKey Hovedmenuvalg() 
        {
            ConsoleKey Valg;
            bool Godkendt = false;
            SQL DataCmd = new SQL();
            Ordre Ordre = new Ordre();
            Indtast Skriv = new Indtast();
            do
            {
                Valg = Console.ReadKey(true).Key;
                switch (Valg)
                {
                    case ConsoleKey.D1:
                        DataCmd.OpretKunde(Skriv.IndtastAlt());
                        Godkendt = true;
                        Fortsaet();
                        break;
                    case ConsoleKey.D2:;
                        DataCmd.RedigerKunde(Skriv.IndtastAlt());
                        Godkendt = true;
                        Fortsaet();
                        break;
                    case ConsoleKey.D3:
                        DataCmd.SletKunde(Skriv.IndtastId());
                        Godkendt = true;
                        Fortsaet();
                        break;
                    case ConsoleKey.D4:
                        SkrivTabel(true);
                        Godkendt = true;
                        Fortsaet();
                        break;
                    case ConsoleKey.D5:
                        SkrivTabel(false);
                        Godkendt = true;
                        Fortsaet();
                        break;
                    case ConsoleKey.D6:
                        SkrivOrdre();
                        Godkendt = true;
                        Fortsaet();
                        break;
                    case ConsoleKey.D7:
                        Ordre.OpretBestilling();
                        Godkendt = true;
                        Fortsaet();
                        break;
                    case ConsoleKey.Escape:
                        Godkendt = true;
                        break;
                    default:
                        Console.WriteLine("Input ikke godkendt.");
                        Fortsaet();
                        continue;

                }

            } while (Godkendt == false);
            return Valg;
        }
    }
}
