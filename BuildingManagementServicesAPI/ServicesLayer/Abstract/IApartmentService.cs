using DomainLayer.Entities;
using ServicesLayer.Model.DTOs.ApartmentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Abstract
{
    public interface IApartmentService
    {
        public IEnumerable<ApartmentGetDto> GetAll();
        public ApartmentGetDto GetByIdWithUser(int id);
        public ApartmentGetDto GetByIdWithBills(int id);
        public void Add(AddApartmentDto addDto);
        public void Update(ApartmentUpdateDto updateDto);
        public void Delete(Apartment apartment);

    }
}
