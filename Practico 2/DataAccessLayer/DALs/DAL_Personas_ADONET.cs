using DataAccessLayer.IDALs;
using Microsoft.Data.SqlClient;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.DALs
{
    public class DAL_Personas_ADONET : IDAL_Personas
    {

        private string _connectionString = "Server=localhost,1433;Database=Practico2;User Id=sa;Password=Abc*123!;Encrypt=False;";

        private Dictionary<string, Persona> personas = new Dictionary<string, Persona>();

        public List<Persona> Get()
        {
            List<Persona> personas = new List<Persona>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Personas", connection))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Persona persona = new Persona();

                            persona.Documento = reader["Documento"].ToString();
                            persona.Nombre = reader["Nombre"].ToString();
                            personas.Add(persona);
                        }
                    }
                }
            }
            return personas;
        }
        public Persona Get(string documento)
        {
            Persona persona = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                // Usar parámetros para evitar la inyección SQL.
                using (SqlCommand command = new SqlCommand("SELECT * FROM Personas WHERE Documento = @documento", connection))
                {
                    command.Parameters.AddWithValue("@documento", documento);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Si hay resultados
                        {
                            persona = new Persona(); // Instanciar el objeto Persona aquí
                            persona.Documento = reader["Documento"].ToString();
                            persona.Nombre = reader["Nombre"].ToString();
                        }
                    }
                }
            }

            return persona; // Devolver la persona encontrada o null si no se encuentra.
        }



        public void Insert(Persona persona)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO Personas(Nombre, Documento) VALUES (@Nombre, @Documento);", connection))
                {
                    command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                    command.Parameters.AddWithValue("@Documento", persona.Documento);

                    command.ExecuteNonQuery(); 
                }
            }
        }

        public int Update(Persona persona)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UPDATE Personas SET Nombre = @Nombre WHERE Documento = @Documento;", connection))
                {
                    command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                    command.Parameters.AddWithValue("@Documento", persona.Documento);

                    return command.ExecuteNonQuery();  // Devuelve el número de filas afectadas.
                }
            }
        }


        public void Delete(string documento)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DELETE FROM Personas WHERE Documento = @Documento", connection))
                {
                    command.Parameters.AddWithValue("@Documento", documento);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
