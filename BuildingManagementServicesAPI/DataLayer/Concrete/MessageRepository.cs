using DataLayer.Abstract;
using DataLayer.ContextDb;
using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Concrete
{
    public class MessageRepository : GenericRepository<Message, BMSContextDb>, IMessageRepository
    {
        public MessageRepository(BMSContextDb context) : base(context)
        {
        }
    }
}
