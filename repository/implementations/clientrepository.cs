using apibanque.models;
using apibanque.repository.interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apibanque.repository.implementations
{
    public class clientrepository : iclientrepository
    {
        private string connectionString = "Server=localhost;Database=banque;Trusted_Connection=True;";
        public void Add(Client client)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Clients(nom,prenom,telephone) VALUES (@nom,@prenom,@telephone)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nom", client.nom);
                cmd.Parameters.AddWithValue("@prenom", client.prenom);
                cmd.Parameters.AddWithValue("@telephone", client.telephone);

                cmd.ExecuteNonQuery();
            }
        }
        public List<Client> GetAll()
        {
            List<Client> client = new List<Client>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Clients";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    client.Add(new Client
                    {
                        id = (int)reader["id"],
                        nom = reader["nom"].ToString(),
                        prenom = reader["prenom"].ToString(),
                        telephone = reader["telephone"].ToString()
                    });
                }
            }
            return client;
        }
    }
}
