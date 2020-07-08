using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorrectifFilmApi.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Genre { get; set; }
        public int AnneeSortie { get; set; }
        public string Realisateur { get; set; }
        public string Synopsis { get; set; }

        public IEnumerable<Acteur> Roles { get; set; }
    }
}