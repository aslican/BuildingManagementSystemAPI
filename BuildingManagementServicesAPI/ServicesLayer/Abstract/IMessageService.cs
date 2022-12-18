using DomainLayer.Entities;
using ServicesLayer.Model.DTOs.MessageDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Abstract
{
    public interface IMessageService
    {
        public IEnumerable<MessageGetDto> GetAll();
        public MessageGetDto GetById(int id);
        public void SendMessage(MessageSendDto request);
        public void Delete(Message message);

    }
}
