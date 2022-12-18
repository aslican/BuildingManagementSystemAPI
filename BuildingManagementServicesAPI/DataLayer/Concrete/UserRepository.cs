using DataLayer.Abstract;
using DataLayer.ContextDb;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Concrete
{
    public class UserRepository : GenericRepository<User,BMSContextDb>, IUserRepository
    {
        public UserRepository(BMSContextDb context) : base(context)
        {
        }
        public User GetUserWithPassword(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }
    }
}
