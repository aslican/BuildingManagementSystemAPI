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
    public class BillRepository : GenericRepository<Bill, BMSContextDb>, IBillRepository
    {
        public BillRepository(BMSContextDb context) : base(context)
        {
        }

    }
}
