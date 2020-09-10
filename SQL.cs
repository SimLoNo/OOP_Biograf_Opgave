using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace OOP_Biograf_Opgave
{
    class SQL
    {
        private static string ConString = "Server=localhost;Database=Biograf;Trusted_Connection=True;";

        public bool CheckConnection()
        {
            using (SqlConnection Con = new SqlConnection(ConString))
                try
                {
                    Con.Open();
                    return true;
                }
                catch (Exception) { return false; }
        }

        public List<Kunder> VisKunder(bool SorterEftn) 
        {
            using (SqlConnection Con = new SqlConnection(ConString)) 
            {
                List<Kunder> Kunde = new List<Kunder>();
                Con.Open();
                string Sql;
                if (SorterEftn) Sql = "SELECT * FROM Kunder ORDER BY Efternavn";
                else Sql = "SELECT * FROM Kunder";
                SqlCommand Cmd = new SqlCommand(Sql, Con);
                SqlDataReader Reader = Cmd.ExecuteReader();

                while (Reader.Read()) 
                {
                    int Id = Reader.GetInt32(0);
                    string Fornavn = Reader.GetString(1);
                    string Efternavn = Reader.GetString(2);
                    string Email = Reader.GetString(3);
                    int Tlf = Reader.GetInt32(4);
                    string Kundetype = Reader.GetString(5);
                    Kunder Knd = new Kunder(Id, Fornavn, Efternavn, Email, Tlf, Kundetype);
                    Kunde.Add(Knd);
                }
                return Kunde;

            
            }

        }
    }
}
