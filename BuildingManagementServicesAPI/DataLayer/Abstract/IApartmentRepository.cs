

using DomainLayer.Entities;

namespace DataLayer.Abstract
{
    public interface IApartmentRepository :IGenericRepository<Apartment>
    {
        Apartment GetApartmentWithBills (int id);
    }
}
