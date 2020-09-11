using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Biograf_Opgave
{
    class Indtast
    {
        public Kunder IndtastAlt()
        {
            int Id = IndtastId();
            string Fornavn = IndtastFornavn();
            string Efternavn = IndtastEfternavn();
            string Email = IndtastEmail();
            int Tlf = IndtastTlf();
            string Kundetype = IndtastKundetype();
            Kunder Kunde = new Kunder(Id, Fornavn, Efternavn, Email, Tlf, Kundetype);
            return Kunde;
        }
        public int IndtastId()
        {
            int KundeId = 0;
            do
            {
                try
                {
                    Console.Clear();
                    Console.Write("Indtast Kunde Id, og tryk enter: ");
                    KundeId = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Input ikke gyldig. Tryk Escape for at afslutte. Tast vilkårlig anden tast for at prøve igen.");
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape) return 0;
                }
            } while (KundeId <= 0);
            if (KundeId > 0) return KundeId;
            else return 0;
        }
        public string IndtastFornavn()
        {
            bool Godkendt = false;
            string Fornavn;
            do
            {
                Console.WriteLine("Indtast venligst kundens fornavn, og tryk enter.");
                Fornavn = Console.ReadLine();
                if (Fornavn.Length >= 2 && Fornavn.Length <= 35) Godkendt = true;
                else
                {
                    Console.Clear();
                    Console.WriteLine("Input ikke gyldig. Tryk Escape for at afslutte. Tast vilkårlig anden tast for at prøve igen.");
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape) return "N/A";
                }
            } while (Godkendt == false);
            return Fornavn;

        }

        public string IndtastEfternavn()
        {
            bool Godkendt = false;
            string Efternavn;
            do
            {
                Console.WriteLine("Indtast venligst kundens Efternavn, og tryk enter.");
                Efternavn = Console.ReadLine();
                if (Efternavn.Length >= 2 && Efternavn.Length <= 45) Godkendt = true;
                else
                {
                    Console.Clear();
                    Console.WriteLine("Input ikke gyldig. Tryk Escape for at afslutte. Tast vilkårlig anden tast for at prøve igen.");
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape) return "N/A";
                }
            } while (Godkendt == false);
            return Efternavn;

        }

        public string IndtastEmail()
        {
            bool Godkendt = false;
            string Email;
            do
            {
                Console.WriteLine("Indtast venligst kundens Email, og tryk enter.");
                Email = Console.ReadLine();
                if (Email.Length >= 6 && Email.Length <= 45 && Email.Contains("@") && Email.Contains(".")) Godkendt = true;
                else
                {
                    Console.Clear();
                    Console.WriteLine("Input ikke gyldig. Tryk Escape for at afslutte. Tast vilkårlig anden tast for at prøve igen.");
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape) return "N/A";
                }
            } while (Godkendt == false);
            return Email;

        }

        public int IndtastTlf()
        {
            int Tlf = 0;
            do
            {
                try
                {
                    Console.Clear();
                    Console.Write("Indtast Kunde telefonnummr, og tryk enter: ");
                    Tlf = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Input ikke gyldig. Tryk Escape for at afslutte. Tast vilkårlig anden tast for at prøve igen.");
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape) return 0;
                }
            } while (Tlf < 10000000 || Tlf > 99999999);
            if (Tlf >= 10000000 && Tlf <= 99999999) return Tlf;
            else return 00000000;
        }

        public string IndtastKundetype()
        {
            bool Godkendt = false;
            string KundeType;
            do
            {
                Console.WriteLine("Indtast venligst kundens kundetype, og tryk enter.");
                KundeType = Console.ReadLine();

                if (KundeType.Length >= 4 && KundeType.Length <= 20) Godkendt = true;
                else
                {
                    Console.Clear();
                    Console.WriteLine("Input ikke gyldig. Tryk Escape for at afslutte. Tast vilkårlig anden tast for at prøve igen.");
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape) return "N/A";
                }
            } while (Godkendt == false);
            return KundeType;

        }
        //public DateTime IndtastDato()
        //{
        //    DateTime BestilFør = DateTime.Now.AddYears(1);
        //    DateTime Forestilling = DateTime.MinValue;
        //    do
        //    {
        //        Console.WriteLine("Indtast);

        //    } while (Forestilling.Year > BestilFør.Year || Forestilling.Year < DateTime.Now.Year);
        //}
    }
}
