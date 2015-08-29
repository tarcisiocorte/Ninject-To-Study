using System.Linq;
using TC.Ioc.Core;

namespace TC.Ioc.Data
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
    }
}
