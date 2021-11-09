using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace ATM
{
     public class ClassDBAccess : IClientDataAccess
    {

       public void GetAll()
        {
             string cs = @"URI=file:C:\Users\mende\source\repos\ATM\ATM\database\data.db";

             using var con = new SQLiteConnection(cs);
             con.Open();
            string stm = "SELECT * FROM client;";
            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine("Liste des clients:");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetString(0)} {rdr.GetInt32(1)} {rdr.GetString(2)} {rdr.GetString(3)} {rdr.GetFloat(4)} {rdr.GetString(5)} ");
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
            string st = "SELECT * FROM currency;";
            Console.WriteLine("Liste des currencies des clients:");
            using var cm = new SQLiteCommand(st, con);
            using SQLiteDataReader rd = cm.ExecuteReader();
            while (rd.Read())
            {
                Console.WriteLine($"{rd.GetString(0)} {rd.GetFloat(1)} {rd.GetString(2)}  ");
            }
            con.Close();
        }



        public void UpdateClientInt(Guid guid, string nom_attribut, int i)
        {
            string cs = @"URI=file:C:\Users\mende\source\repos\ATM\ATM\database\data.db";

            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);
            string id = guid.ToString();

            cmd.CommandText = "UPDATE client set "+ nom_attribut+" = "+i+" where id='"+id + "';";
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Le client a été mise à jour dans la base de données");
        }

        public void UpdateClientString(Guid guid, string nom_attribut, string i)
        {
            string cs = @"URI=file:C:\Users\mende\source\repos\ATM\ATM\database\data.db";

            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);
            string id = guid.ToString();

            cmd.CommandText = "UPDATE client set " + nom_attribut + " = '" + i + "' where id='" + id + "';";
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Le client a été mise à jour dans la base de données");
        }
        public void UpdateClientFloat(Guid g, string nom_attribut, float i)
        {
            string cs = @"URI=file:C:\Users\mende\source\repos\ATM\ATM\database\data.db";

            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);
            string id = g.ToString();

            //cmd.CommandText = "UPDATE client set " + nom_attribut + " = " + i + " where id='" + id + "';";
            //cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Le client a été mise à jour dans la base de données");
        }

        public void UpdateCurrencyString(Guid c, string nom_attribut_id, string nom_attribut, string i)
        {
            string cs = @"URI=file:C:\Users\mende\source\repos\ATM\ATM\database\data.db";

            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);
            string id = c.ToString();

            cmd.CommandText = "UPDATE currency set " + nom_attribut_id + " = '" + i + "' where idClient='" + id + "' AND name='" + nom_attribut + "';";
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Le client a été mise à jour dans la base de données");
        }
        public void UpdateCurrencyFloat(Guid c, string nom_attribut_id,string nom_attribut, float i)
        {
            string cs = @"URI=file:C:\Users\mende\source\repos\ATM\ATM\database\data.db";

            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);
            string id = c.ToString();

           // cmd.CommandText = "UPDATE currency set " + nom_attribut_id + " = " + i + " where idClient='" + id+"' AND name='"+ nom_attribut+"';";
           // cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Le client a été mise à jour dans la base de données");
        }

        public void CreateClient(Guid _id, int _pin,string _FirstName, string _LastName, float _ammount, List<string> currency, List<float> currency_ammount, string maincurrency)
        {
            string cs = @"URI=file:C:\Users\mende\source\repos\ATM\ATM\database\data.db";

            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);
            string id = _id.ToString();

            cmd.CommandText = "INSERT INTO client(id, pin, firstName, lastName, myAmmountCurrency, myMainCurrency) VALUES ('" + id + "', " + _pin + ", '" + _FirstName + "', '" + _LastName + "', " + _ammount + ", '" + maincurrency + "')";
            cmd.ExecuteNonQuery();

            using var cm = new SQLiteCommand(con);
            for (int i = 0; i < currency.Count; i++)
            {
                //cm.CommandText = "INSERT INTO currency(idClient, name, ammount) VALUES ('" + id + "', '" + currency[i] +"', "+ currency_ammount[i]+")";
                //cm.ExecuteNonQuery();
            }
            con.Close();
            Console.WriteLine("Le client avec ses currencies a été crée dans la base de données");
        }

        public void GetClient(Guid guid)
        {
            
            string cs = @"URI=file:C:\Users\mende\source\repos\ATM\ATM\database\data.db";

            using var con = new SQLiteConnection(cs);
            con.Open();

            string id = guid.ToString();
            string stm = "SELECT * FROM client WHERE id ='"+ id+"';";
            string st = "SELECT * FROM currency WHERE idClient='" + id+"';";
            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetString(0)} {rdr.GetInt32(1)} {rdr.GetString(2)} {rdr.GetString(3)} {rdr.GetFloat(4)} {rdr.GetString(5)} ");
            }
            using var cm = new SQLiteCommand(st, con);
            con.Close();
        }
        public void DeleteClient(Guid guid)
        {
            string cs = @"URI=file:C:\Users\mende\source\repos\ATM\ATM\database\data.db";

            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);
            string id = guid.ToString();
            cmd.CommandText = "DELETE FROM client WHERE id = '" + id+"';";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "DELETE FROM currency WHERE idClient = '" + id+"';";
            cmd.ExecuteNonQuery();

            con.Close();
            Console.WriteLine("Le client a été éffacé de la base de données");
        }

    }
        
}

