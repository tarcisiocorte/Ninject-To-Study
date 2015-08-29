using System.Linq;
using TC.Ioc.Core.Data;

namespace TC.Ioc.Service
{
   public interface IUserService
    {
       IQueryable<User> GetUsers();
       User GetUser(long id);
       void InsertUser(User user);
       void UpdateUser(User user);
       void DeleteUser(User user);
    }
}
