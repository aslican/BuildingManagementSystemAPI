using DomainLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Abstract;
using ServicesLayer.Model.DTOs.MessageDTOs;

namespace BuildingManagementServicesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessageController (IMessageService messageService)
        {
            _messageService = messageService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var messages = _messageService.GetAll();
            return Ok(messages);

        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var message = _messageService.GetById(id);
            return Ok(message);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IActionResult Delete(Message message)
        {
            _messageService.Delete(message);
            return Ok("Success");
        }
        [Authorize(Roles = "Admin,User")]
        [HttpPost]
        public IActionResult SendMessage(MessageSendDto request)
        {
            _messageService.SendMessage(request);
            return Ok("Success");

        }
    }
}
