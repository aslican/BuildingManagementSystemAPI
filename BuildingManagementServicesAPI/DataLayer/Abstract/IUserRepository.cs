
using DomainLayer.Entities;

namespace DataLayer.Abstract
{
    public interface IUserRepository :IGenericRepository<User>
    {
        User GetUserWithPassword(string email);
    }
}
