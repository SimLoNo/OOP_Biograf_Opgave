﻿using System;
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
        public void OpretKunde(Kunder Kunde) 
        {
            try
            {
                using (SqlConnection Con = new SqlConnection(ConString))
                {
                    Con.Open();
                    SqlCommand Cmd = new SqlCommand("INSERT INTO Kunder VALUES ('" + Kunde.Fornavn + "','" + Kunde.Efternavn + "','" + Kunde.Email + "','" + Kunde.Tlf + "','" + Kunde.Kundetype + "')", Con);
                    Cmd.ExecuteNonQuery();
                }
            }
            catch (Exception Ex) { Console.WriteLine(Ex.Message.ToString()); }
        }
        public void RedigerKunde(Kunder Kunde) 
        {
            try
            {
                using (SqlConnection Con = new SqlConnection(ConString))
                {
                    Con.Open();
                    SqlCommand CmdSelect = new SqlCommand("SELECT Id from Kunder", Con);
                    SqlCommand CmdInsert = new SqlCommand("UPDATE Kunder SET Fornavn ='" + Kunde.Fornavn + "', Efternavn = '" + Kunde.Efternavn + "', Email = '" + Kunde.Email + "', Tlf = " + Kunde.Tlf + ",Kundetype = '" + Kunde.Kundetype + "' WHERE Id ="+Kunde.Id, Con);
                    SqlDataReader Reader = CmdSelect.ExecuteReader();
                    bool IdFundet = false;
                    while (Reader.Read()) 
                    {
                        if (Reader.GetInt32(0) == Kunde.Id) IdFundet = true;
                    }
                    Reader.Close();
                    if (IdFundet == true) CmdInsert.ExecuteNonQuery();




                }
            }
            catch (Exception Ex) { Console.WriteLine(Ex.Message.ToString()); }
            
        }
        public void SletKunde(int Id) 
        {
            using (SqlConnection Con = new SqlConnection(ConString))
            {
                Con.Open();
                SqlCommand CmdSelectKunder = new SqlCommand("SELECT Id from Kunder WHERE Id = "+Id, Con);
                SqlCommand CmdSelectBestilling = new SqlCommand("SELECT KundeId from Bestilling WHERE KundeId = "+Id, Con);
                SqlCommand CmdDelete = new SqlCommand("DELETE FROM Kunder WHERE Id = "+Id, Con);
                SqlDataReader ReaderKunder = CmdSelectKunder.ExecuteReader();
                bool KundeIdFundet = false;
                bool BestillingIdFundet = false;
                while (ReaderKunder.Read())
                {
                    if (ReaderKunder.GetInt32(0) == Id) KundeIdFundet = true;
                }
                ReaderKunder.Close();
                SqlDataReader ReaderBestilling = CmdSelectBestilling.ExecuteReader();
                while (ReaderBestilling.Read())
                {
                    if (ReaderBestilling.GetInt32(0) == Id) BestillingIdFundet = true;
                }
                ReaderBestilling.Close();
                if (KundeIdFundet == true && BestillingIdFundet == false) CmdDelete.ExecuteNonQuery();
                else Console.WriteLine("Kunde findes ikke, eller har en bestilling");




            }
        }

        public List<Bestilling> VisBestilling(int id) 
        {
            using (SqlConnection Con = new SqlConnection(ConString)) 
            {
                Con.Open();
                SqlCommand Sql = new SqlCommand("SELECT Fornavn, Efternavn, KundeId, Bestillingstid, Film, Betaling FROM Kunder,Bestilling WHERE Bestilling.KundeId = Kunder.Id and Kunder.Id = " + id, Con);
                List<Bestilling> OrdreList = new List<Bestilling>();
                SqlDataReader Reader = Sql.ExecuteReader();
                while (Reader.Read()) 
                {
                    string Fornavn = Reader.GetString(0);
                    string Efternavn = Reader.GetString(1);
                    int KundeId = Reader.GetInt32(2);
                    DateTime Tid = Reader.GetDateTime(3);
                    string Film = Reader.GetString(4);
                    string Betalling = Reader.GetString(5);
                    Bestilling Ordre = new Bestilling(Fornavn, Efternavn, KundeId, Tid, Film, Betalling);
                    OrdreList.Add(Ordre);
                }
                return OrdreList;

            
            }
        }
        public void OpretBestilling(Bestilling Ordre) 
        {
            using (SqlConnection Con = new SqlConnection(ConString)) 
            {
                Con.Open();
                SqlCommand Cmd = new SqlCommand("INSERT INTO Bestilling VALUES (" + Ordre.KundeId + ",'" + Ordre.Bestillingstid + "','" + Ordre.Film + "','" + Ordre.Betalling+"')", Con);
                try
                {
                    Cmd.ExecuteNonQuery();
                }
                catch (Exception) { Console.WriteLine("Der kunne ikke bestilles."); }
            }
        }
    }
}
