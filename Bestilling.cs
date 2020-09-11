using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Biograf_Opgave
{
    class Bestilling : IComparable<Bestilling>
	{
		public string Fornavn { get; set; }
		public string Efternavn { get; set; }
		public int KundeId { get; set; }
		public DateTime Bestillingstid { get; set; }
		public string Film { get; set; }
		public string Betalling { get; set; }

		public Bestilling(int id, DateTime bestTid, string film, string betalling) : this("N/A", "N/A", id, bestTid, film, betalling) { }
		public Bestilling(string fornavn, string efternavn, int id, DateTime bestTid, string film, string betalling) 
		{
			Fornavn = fornavn;
			Efternavn = efternavn;
			KundeId = id;
			Bestillingstid = bestTid;
			Film = film;
			Betalling = betalling;
		}
		public int CompareTo(Bestilling other) 
		{
			//DateTime Tid = DateTime.Now;
			if (this.Bestillingstid.Year > other.Bestillingstid.Year) return 1;
			else if (this.Bestillingstid.Year == other.Bestillingstid.Year)
			{
				if (this.Bestillingstid.Month > other.Bestillingstid.Month) return 1;
				else if (this.Bestillingstid.Month == other.Bestillingstid.Month)
				{
					if (this.Bestillingstid.Day > other.Bestillingstid.Day) return 1;
					else if (this.Bestillingstid.Day == other.Bestillingstid.Day) return 0;
					else return -1;
				}
				else return -1;
			}
			else return -1;
		}



	}
}
