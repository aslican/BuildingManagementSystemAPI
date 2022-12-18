using AutoMapper;
using DomainLayer.Entities;
using ServicesLayer.Model.DTOs.ApartmentDTOs;
using ServicesLayer.Model.DTOs.BillDTOs;
using ServicesLayer.Model.DTOs.MessageDTOs;
using ServicesLayer.Model.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Mapper
{
    public class MapperProfile :Profile
    {
        public MapperProfile()
        {
            //For users
            CreateMap<UserRegisterDto,User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap< User, UserGetDto>();
            //For Apartment
            CreateMap<AddApartmentDto, Apartment>();
            CreateMap<ApartmentUpdateDto, Apartment>();
            CreateMap<Apartment, ApartmentGetDto>();
            //For Bill
            CreateMap<BillAddDto, Bill>();
            CreateMap<BillUpdateDto, Bill>();
            CreateMap<Bill, BillGetDto>();
            //For Message
            CreateMap< Message,MessageGetDto > ();
            CreateMap<MessageSendDto, Message>();
            


        }
    }
}

