using Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Interface
{
    public interface IActeurRepository : IRepository<Acteur>
    {
        void SetActorToFilm(int idActeur, int idFilm);
        IEnumerable<Film> GetFilmByActorId(int id);
    }
}
