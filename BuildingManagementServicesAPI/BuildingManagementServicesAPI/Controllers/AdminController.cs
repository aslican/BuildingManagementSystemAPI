using DomainLayer.Entities;
using DomainLayer.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Abstract;
using ServicesLayer.Model.DTOs.UserDTOs;
using System;

namespace BuildingManagementServicesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        public AdminController (IUserService userService) { 
            _userService = userService;
        }
        //[Authorize(Roles ="Admin")]
        [HttpGet("GetAll")]
        
        public IActionResult GetAll()
        {
            var users= _userService.GetAll();
            return Ok(users);
        }
        //[Authorize(Roles ="Admin")]
        [HttpGet("{id}")]
        
        public IActionResult GetById(int id)
        {
            var user= _userService.GetById(id);
            return Ok(user);
        }
        //[Authorize(Roles = "Admin")]
        [HttpDelete]
        public IActionResult Delete(User user)
        {
           _userService.Delete(user);
           return Ok("Success");
        }
        //[Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Update(UserUpdateDto updateUser)
        {

            _userService.Update(updateUser);
            return Ok();
        }
        [HttpPost]
        public IActionResult Register(UserRegisterDto userRegister)
        {
            _userService.Register(userRegister);
            return Ok();
        }

    }
}
