using AutoMapper;
using DataLayer.Abstract;
using DomainLayer.Entities;
using ServicesLayer.Abstract;
using ServicesLayer.Model.DTOs.MessageDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Concrete
{
    public class MessageService :IMessageService
    {
        private readonly IMessageRepository _repository;
        private readonly IMapper _mapper;
        public MessageService(IMessageRepository messageRepositor, IMapper mapper)
        {
            _repository = messageRepositor;
            _mapper = mapper;
         }

        public void Delete(Message message)
        {
            _repository.Delete(message);
            _repository.SaveChanges();
        }

        public IEnumerable<MessageGetDto> GetAll()
        {
            var messages = _repository.GetAll();
            var mapMessages = messages.Select(x => _mapper.Map<MessageGetDto>(x)).ToList();
            return mapMessages;
        }

        public MessageGetDto GetById(int id)
        {
            var message = _repository.Get(x => x.Id == id);
            var mappedMessage = _mapper.Map<MessageGetDto>(message);
            return mappedMessage;
        }

        public void SendMessage(MessageSendDto request)
        {
            var message = _mapper.Map<Message>(request);

            _repository.Add(message);
            _repository.SaveChanges();
        }
    }
}
