using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Model.DTOs.MessageDTOs
{
    public class MessageGetDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Sender { get; set; }
        public MessageContextEnum Context { get; set; }
        public string Contents { get; set; }
        public DateTime Created { get; set; }
        public bool IsRead { get; set; }
    }
}
