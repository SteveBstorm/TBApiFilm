using Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Interface
{
    public interface IFilmRepository : IRepository<Film>
    {
        IEnumerable<Acteur> GetActorsByFilmId(int id);
    }
}
