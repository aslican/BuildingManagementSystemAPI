using DomainLayer.Entities;
using ServicesLayer.Model.DTOs.BillDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Abstract
{
    public interface IBillService
    {
        public IEnumerable<BillGetDto> GetAll();
        public BillGetDto GetById(int id);
        public void Add(BillAddDto billAddDto);
        public void Update(BillUpdateDto billUpdateDto);
        public void Delete(Bill bill);


    }
}
