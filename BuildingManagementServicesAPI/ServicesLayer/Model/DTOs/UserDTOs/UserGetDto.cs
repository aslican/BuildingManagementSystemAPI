using DomainLayer.Entities;
using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Model.DTOs.UserDTOs
{
    public class UserGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public VehicleEnum VehicleInfo { get; set; }
        public int ApartmentNo { get; set; }
        public Apartment Apartment { get; set; }
    }
}
