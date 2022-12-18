using DomainLayer.Entities;
using ServicesLayer.Model.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Abstract
{
    public interface IUserService
    {
        IEnumerable<UserGetDto> GetAll();
        UserGetDto GetById(int id);
        void  Register(UserRegisterDto register);
        void Update(UserUpdateDto updateUser);
        void Delete(User user);
    }
}
