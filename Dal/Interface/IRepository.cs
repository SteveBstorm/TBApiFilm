using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Interface
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Save(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
