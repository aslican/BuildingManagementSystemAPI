using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Model.DTOs.BillDTOs
{
    public class BillAddDto
    {
        public BillTypeEnum BillType { get; set; }
        public int TotalAmount { get; set; }
        public MonthEnum Month { get; set; }
        public int ApartmentId { get; set; }
        public bool IsPaid { get; set; }
    }
}
