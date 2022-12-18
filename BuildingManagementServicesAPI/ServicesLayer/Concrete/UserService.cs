using AutoMapper;
using DataLayer.Abstract;
using DomainLayer.Entities;
using ServicesLayer.Abstract;
using ServicesLayer.Model.DTOs.UserDTOs;
using ServicesLayer.Password;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Concrete
{
    public class UserService :IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService (IUserRepository userRepository, IMapper mapper)
        {
            _repository = userRepository;
            _mapper = mapper;
        }
        //Kullanıcıları listelemek için:
        public IEnumerable<UserGetDto> GetAll()
        {
            var users = _repository.GetAll();
            var mappedUser = users.Select(x=> _mapper.Map<UserGetDto>(x)).ToList();
            return mappedUser;
        }

        public UserGetDto GetById(int id)
        {
            var user = _repository.Get(x=>x.Id==id);
            var mappedUser= _mapper.Map<UserGetDto>(user);
            return mappedUser;
        }

        public void Register(UserRegisterDto register)
        {
            string password = GeneratePassword.CreatePassword(6);
            var user =_mapper.Map<User>(register);  
            user.Password = password;
            _repository.Add(user);
            _repository.SaveChanges();

        }

        public void Update(UserUpdateDto updateUser)
        {
            var user= _mapper.Map<User>(updateUser);
            //var userCache=_repository.Get
            //user.Password=userCache.Password;
            //user.TC=userCache.TC;   
            _repository.Update(user);   
        }

        public void Delete(User user)
        {
            _repository.Delete(user);
            _repository.SaveChanges();
        }
    }
}
