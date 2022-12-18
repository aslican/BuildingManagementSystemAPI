using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }    
        public bool IsPaid { get; set; }        
        public int TotalAmount { get; set; }
        public MonthEnum Month { get; set; }
        public BillTypeEnum BillType { get; set; }
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
    }
}
