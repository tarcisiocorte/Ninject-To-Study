using System.Data.Entity;
using TC.Ioc.Core;
namespace TC.Ioc.Data
{
   public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : EntityBase;
        int SaveChanges();
    }
}
