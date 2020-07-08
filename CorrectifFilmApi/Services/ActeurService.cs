using CorrectifFilmApi.Models;
using Dal.Interface;
using Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CorrectifFilmApi.Utils;

namespace CorrectifFilmApi.Services
{
    public class ActeurService
    {
        private IActeurRepository _repo;

        public ActeurService()
        {
            _repo = new ActeurRepository();
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<Film> GetFilmByActorId(int id)
        {
            return _repo.GetFilmByActorId(id).Select(x => x.toApi());
        }

        public IEnumerable<Acteur> GetAll()
        {
            return _repo.GetAll().Select(x => x.toApi());
        }

        public Acteur GetById(int id)
        {
            return _repo.GetById(id).toApi();
        }

        public void Save(Acteur entity)
        {
            _repo.Save(entity.toDb());
        }

        public void Update(Acteur entity)
        {
            _repo.Update(entity.toDb());
        }

        public void SetActorToFilm(int idFilm, int idActeur)
        {
            _repo.SetActorToFilm(idActeur, idFilm);
        }
    }
}