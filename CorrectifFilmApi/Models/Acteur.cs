using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorrectifFilmApi.Models
{
    public class Acteur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public IEnumerable<Film> FilmList { get; set; }
    }
}