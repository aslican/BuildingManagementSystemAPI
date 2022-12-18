using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Apartment
    {
        [Key]
        public int Id { get; set; }
        public BlockEnum Block { get; set; }
        public bool IsRented { get; set; }
        public int Floor { get; set; }
        public int ApartmentNo { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Bill> Bills { get; set; }

    }
}
