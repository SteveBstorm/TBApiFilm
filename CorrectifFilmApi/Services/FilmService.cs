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
    public class FilmService
    {
        private FilmRepository _repo;

        public FilmService()
        {
            _repo = new FilmRepository();
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<Acteur> GetActorsByFilmId(int id)
        {
            return _repo.GetActorsByFilmId(id).Select(x => x.toApi());
        }

        public IEnumerable<Film> GetAll()
        {
            return _repo.GetAll().Select(x => x.toApi());
        }

        public Film GetById(int id)
        {
            return _repo.GetById(id).toApi();
        }

        public void Save(Film entity)
        {
            _repo.Save(entity.toDb());
        }

        public void Update(Film entity)
        {
            _repo.Update(entity.toDb());
        }
    }
}