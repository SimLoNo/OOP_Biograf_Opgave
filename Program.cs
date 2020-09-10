using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Biograf_Opgave
{
    class Program
    {
        static void Main(string[] args)
        {
            SQL DataCmd = new SQL();
            List<Kunder> KundeList = new List<Kunder>();

            DataCmd.CheckConnection();
            KundeList = DataCmd.VisKunder(true);
            foreach (var item in KundeList)
            {
                Console.WriteLine(item.ToString()); ;
            }
            Console.WriteLine();
            Kunder Kunde =  new Kunder(2, "Adam", "Kryler", "AdKry@hotmail.com", 66677788, "Fattigkunde");
            DataCmd.RedigerKunde(Kunde);
            KundeList = DataCmd.VisKunder(false);
            foreach (var item in KundeList)
            {
                Console.WriteLine(item.ToString()); ;
            }
            Kunde = new Kunder(1, "Adam", "Kryler", "AdKry@hotmail.com", 66677788, "Fattigkunde");
                //Kunder Kunde = new Kunder(2, "Adam", "Kryler", "AdKry@hotmail.com", 66677788, "Fattigkunde");
            DataCmd.SletBruger(Kunde);
            KundeList = DataCmd.VisKunder(false);
            foreach (var item in KundeList)
            {
                Console.WriteLine(item.ToString()); ;
            }
            Console.ReadKey();
        }
    }
}
