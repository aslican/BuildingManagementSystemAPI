

using DataLayer.Abstract;
using DataLayer.ContextDb;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataLayer.Concrete
{
    public class ApartmentRepository : GenericRepository<Apartment, BMSContextDb>, IApartmentRepository
    {
        public ApartmentRepository(BMSContextDb context) : base(context)
        {
        }

        public Apartment GetApartmentWithBills(int id)
        {
            return _context.Apartments.Include(x => x.Bills).FirstOrDefault();
        }
    }
}
