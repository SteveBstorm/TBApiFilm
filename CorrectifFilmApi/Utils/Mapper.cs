using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using dal = Dal.Entities;
using api = CorrectifFilmApi.Models;

namespace CorrectifFilmApi.Utils
{
    public static class MapperExtension
    {
        public static dal.Acteur toDb(this api.Acteur a)
        {
            return new dal.Acteur
            {
                Id = a.Id,
                Nom = a.Nom,
                Prenom = a.Prenom
            };
        }

        public static api.Acteur toApi(this dal.Acteur a)
        {
            return new api.Acteur
            {
                Id = a.Id,
                Nom = a.Nom,
                Prenom = a.Prenom
            };
        }


        public static dal.Film toDb(this api.Film f)
        {
            return new dal.Film
            {
                Id = f.Id,
                Titre = f.Titre,
                AnneeSortie = f.AnneeSortie,
                Genre = f.Genre,
                Realisateur = f.Realisateur,
                Synopsis = f.Synopsis
            };
        }

        public static api.Film toApi(this dal.Film f)
        {
            return new api.Film
            {
                Id = f.Id,
                Titre = f.Titre,
                AnneeSortie = f.AnneeSortie,
                Genre = f.Genre,
                Realisateur = f.Realisateur,
                Synopsis = f.Synopsis
            };
        }

        public static T MapTo<T>(this object from)
            where T : new()
        {
            T result = new T();
            var resultProperties = typeof(T).GetProperties();
            foreach (PropertyInfo resultProperty in resultProperties)
            {
                PropertyInfo fromProperty
                    = from.GetType().GetProperty(resultProperty.Name);
                if (fromProperty != null)
                {
                    object valueToSet = fromProperty.GetValue(from);
                    resultProperty.SetValue(result, valueToSet);
                }
            }
            return result;
        }
    }
}