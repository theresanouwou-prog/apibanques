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
    public class CompteRepository : ICompteRepository
    {
        private string connectionString =
            "Server=localhost;Database=BankDB;Trusted_Connection=True;";

        public void Add(Compte compte)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Comptes (ClientId, Solde, TypeCompte) VALUES (@ClientId, @Solde, @TypeCompte)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClientId", compte.ClientId);
                cmd.Parameters.AddWithValue("@Solde", compte.Solde);
                cmd.Parameters.AddWithValue("@TypeCompte", compte.TypeCompte);
                cmd.ExecuteNonQuery();
            }
        }

        public Compte GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Comptes WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Compte
                    {
                        Id = (int)reader["Id"],
                        ClientId = (int)reader["ClientId"],
                        Solde = (decimal)reader["Solde"],
                        TypeCompte = reader["TypeCompte"].ToString()
                    };
                }
            }
            return null;
        }

        public void Update(Compte compte)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Comptes SET Solde=@Solde WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Solde", compte.Solde);
                cmd.Parameters.AddWithValue("@Id", compte.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Compte> GetAll()
        {
            List<Compte> comptes = new List<Compte>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Comptes";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comptes.Add(new Compte
                    {
                        Id = (int)reader["Id"],
                        ClientId = (int)reader["ClientId"],
                        Solde = (decimal)reader["Solde"],
                        TypeCompte = reader["TypeCompte"].ToString()
                    });
                }
            }
            return comptes;
        }
    }
}
