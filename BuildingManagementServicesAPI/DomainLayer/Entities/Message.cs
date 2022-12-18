using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Sender { get; set; }
        public MessageContextEnum Context { get; set; }
        public string Contents { get; set; }
        public DateTime Created { get; set; }
        public bool IsRead { get; set; }    

    }
}
