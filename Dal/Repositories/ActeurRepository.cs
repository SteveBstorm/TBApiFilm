using Dal.Entities;
using Dal.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repositories
{
    public class ActeurRepository : IActeurRepository
    {
        private SqlConnection _connection;

        public ActeurRepository()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbFilm"].ConnectionString);
        }
        
        public void Delete(int id)
        {
            using (SqlConnection c = _connection)
            {
                c.Open();
                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    string command = "DELETE FROM Acteur WHERE Id = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.CommandText = command;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Acteur> GetAll()
        {
            using (SqlConnection c = _connection)
            {
                c.Open();
                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    string command = "SELECT * FROM Acteur";

                    cmd.CommandText = command;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Acteur
                            {
                                Id = (int)reader["Id"],
                                Nom = reader["Nom"].ToString(),
                                Prenom = reader["Prenom"].ToString()
                            };
                        }
                    }
                }
            }
        }

        public Acteur GetById(int id)
        {
            Acteur a = new Acteur();
            using (SqlConnection c = _connection) 
            { 
                c.Open();
                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    
                    string command = "SELECT * FROM Acteur";

                    cmd.CommandText = command;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            a.Id = (int)reader["Id"];
                            a.Nom = reader["Nom"].ToString();
                            a.Prenom = reader["Prenom"].ToString();  
                        }
                    }
                }
            }
            return a;
        }

        public void Save(Acteur entity)
        {
            using (SqlConnection c = _connection)
            {
                c.Open();
                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    string command = "INSERT INTO Acteur VALUES(@Nom, @Prenom)";
                    cmd.CommandText = command;
                    cmd.Parameters.AddWithValue("Nom", entity.Nom);
                    cmd.Parameters.AddWithValue("Prenom", entity.Prenom);

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void Update(Acteur entity)
        {
            using (SqlConnection c = _connection)
            {
                c.Open();
                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    string command = "UPDATE Acteur SET Nom = @Nom, Prenom = @Prenom WHERE Id = @id";
                    cmd.CommandText = command;
                    cmd.Parameters.AddWithValue("Nom", entity.Nom);
                    cmd.Parameters.AddWithValue("Prenom", entity.Prenom);
                    cmd.Parameters.AddWithValue("id", entity.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Film> GetFilmByActorId(int id)
        {
            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["DbFilm"].ConnectionString))
            {
                c.Open();
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Film f JOIN FilmActeur fa ON fa.FilmId = f.Id WHERE fa.ActeurId = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Film
                            {
                                Id = (int)reader["Id"],
                                AnneeSortie = (int)reader["Annee"],
                                Titre = reader["Titre"].ToString(),
                                Synopsis = reader["Synopsis"].ToString(),
                                Realisateur = reader["Realisateur"].ToString(),
                                Genre = reader["Genre"].ToString()
                            };
                        }
                    }
                }
            }
        }

        public void SetActorToFilm(int idActeur, int idFilm)
        {
            using (SqlConnection c = _connection)
            {
                c.Open();
                using(SqlCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO FilmActeur VALUES (@idF, @idA)";
                    cmd.Parameters.AddWithValue("idF", idFilm);
                    cmd.Parameters.AddWithValue("idA", idActeur);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
