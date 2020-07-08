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
    public class FilmRepository : IFilmRepository
    {
        private SqlConnection _connection;

        public FilmRepository()
        {
            _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbFilm"].ConnectionString);
        }

        public void Delete(int id)
        {
            using (SqlConnection c = _connection)
            {
                c.Open();
                using(SqlCommand cmd = _connection.CreateCommand())
                {
                    string command = "DELETE FROM Film WHERE Id = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.CommandText = command;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Film> GetAll()
        {
            using (SqlConnection c = _connection)
            {
                c.Open();
                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    
                    
                    cmd.CommandText = "SELECT * FROM Film";
                    
                    using(SqlDataReader reader = cmd.ExecuteReader())
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

        public Film GetById(int id)
        {
            Film f = new Film();
            using (SqlConnection c = _connection)
            {
                c.Open();
                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    string command = "SELECT * FROM Film WHERE Id = @id";
                    cmd.Parameters.AddWithValue("id", id);

                    cmd.CommandText = command;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            f.Id = (int)reader["Id"];
                            f.AnneeSortie = (int)reader["Annee"];
                            f.Titre = reader["Titre"].ToString();
                            f.Synopsis = reader["Synopsis"].ToString();
                            f.Realisateur = reader["Realisateur"].ToString();
                            f.Genre = reader["Genre"].ToString();
                          
                        }
                    }
                }
            }
            return f;
        }

        public void Save(Film entity)
        {
            using (SqlConnection c = _connection)
            {
                c.Open();
                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    string command = "INSERT INTO Film VALUES(@Titre, @annee, @genre, @real, @synopsis)";
                    cmd.CommandText = command;
                    cmd.Parameters.AddWithValue("Titre", entity.Titre);
                    cmd.Parameters.AddWithValue("annee", entity.AnneeSortie);
                    cmd.Parameters.AddWithValue("genre", entity.Genre);
                    cmd.Parameters.AddWithValue("real", entity.Realisateur);
                    cmd.Parameters.AddWithValue("synopsis", entity.Synopsis);

                    cmd.ExecuteNonQuery();
                }

            }
        }
        public void Update(Film entity)
        {
            using (SqlConnection c = _connection)
            {
                c.Open();
                using (SqlCommand cmd = _connection.CreateCommand())
                {
                    string command = "UPDATE Film SET Titre = @Titre, Annee = @annee, Genre = @genre, Realisateur = @real, Synopsis = @synopsis WHERE Id = @id";
                    cmd.CommandText = command;
                    cmd.Parameters.AddWithValue("Titre", entity.Titre);
                    cmd.Parameters.AddWithValue("annee", entity.AnneeSortie);
                    cmd.Parameters.AddWithValue("genre", entity.Genre);
                    cmd.Parameters.AddWithValue("real", entity.Realisateur);
                    cmd.Parameters.AddWithValue("synopsis", entity.Synopsis);
                    cmd.Parameters.AddWithValue("id", entity.Id);
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public IEnumerable<Acteur> GetActorsByFilmId(int id)
        {
            using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["DbFilm"].ConnectionString))
            {
                c.Open();
                using (SqlCommand cmd = c.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Acteur a JOIN FilmActeur fa ON fa.ActeurId = a.Id WHERE fa.FilmId = @id";
                    cmd.Parameters.AddWithValue("id", id);
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
    }
}
