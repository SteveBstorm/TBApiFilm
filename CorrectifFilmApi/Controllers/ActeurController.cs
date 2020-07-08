using CorrectifFilmApi.Models;
using CorrectifFilmApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CorrectifFilmApi.Controllers
{
    public class ActeurController : ApiController
    {
        private ActeurService _service;

        public ActeurController()
        {
            _service = new ActeurService();
        }

        [HttpGet]
        public IEnumerable<Acteur> Get()
        {
            return _service.GetAll();
        }

        [HttpGet]

        public Acteur Get(int id)
        {
            Acteur a = _service.GetById(id);
            a.FilmList = _service.GetFilmByActorId(id);

            return a;
        }

        [HttpPost]
        public void Post(Acteur a)
        {
            _service.Save(a);
            
        }

        [HttpPut]
        public void Put(Acteur a)
        {
            _service.Update(a);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _service.Delete(id);
        }

        [HttpPost]
        [Route("api/acteur/{idFilm}/SetActor/{idActeur}")]
        public void SetActor(int idFilm, int idActeur)
        {
            _service.SetActorToFilm(idFilm, idActeur);
        }
    }
}
