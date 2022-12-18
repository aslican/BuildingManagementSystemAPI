using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Model.DTOs.ApartmentDTOs
{
    public class AddApartmentDto
    {
        public BlockEnum Block { get; set; }
        public bool IsRented { get; set; }
        public int Floor { get; set; }
        public int ApartmentNo { get; set; }
        public int UserId { get; set; }
    }
}
