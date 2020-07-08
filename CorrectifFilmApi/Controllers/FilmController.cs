using CorrectifFilmApi.Models;
using CorrectifFilmApi.Services;
using CorrectifFilmApi.Utils;
using Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CorrectifFilmApi.Controllers
{
    public class FilmController : ApiController
    {
        FilmRepository _repo;
        public FilmController()
        {
            _repo = new FilmRepository();
        }

        [HttpGet]
        public IEnumerable<Film> Get()
        {
            return _repo.GetAll().Select(x => x.toApi());
        }

        [HttpGet]
        public Film Get(int id)
        {

            Film f = _repo.GetById(id).toApi();
            f.Roles = _repo.GetActorsByFilmId(id).Select(x => x.toApi());

            return f;
        }

        [HttpPost]
        public void Post(Film f)
        {
            _repo.Save(f.toDb());
        }

        [HttpPut]
        public void Put(Film f)
        {
            _repo.Update(f.toDb());
        }

        [HttpDelete] 
        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
