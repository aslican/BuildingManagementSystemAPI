using AutoMapper;
using DataLayer.Abstract;
using DomainLayer.Entities;
using ServicesLayer.Abstract;
using ServicesLayer.Model.DTOs.ApartmentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Concrete
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;

        public ApartmentService(IApartmentRepository apartmentRepository, IMapper mapper, IUserRepository userRepository, IBillRepository billRepository)
        {
            _repository = apartmentRepository;
            _userRepository = userRepository;
            _billRepository = billRepository;
            _mapper = mapper;
        }
        public void Add(AddApartmentDto addDto)
        {
            var apartment = _mapper.Map<Apartment>(addDto);
            
            _repository.Add(apartment);
            _repository.SaveChanges();

        }

        public void Delete(Apartment apartment)
        {
            _repository.Delete(apartment);
            _repository.SaveChanges();
        }

        public IEnumerable<ApartmentGetDto> GetAll()
        {
            var apartment= _repository.GetAll();
            var mapApartment = apartment.Select(x=> _mapper.Map<ApartmentGetDto>(x)).ToList();
            return mapApartment;    
        }

        public ApartmentGetDto GetByIdWithUser(int id)
        {
            var apartment = _repository.Get(x => x.Id == id);
            var user = _userRepository.Get(x => x.Id == apartment.UserId);
       
            var mapApartment = _mapper.Map<ApartmentGetDto>(apartment);
           mapApartment.User= user;
            return mapApartment;
        }
        public ApartmentGetDto GetByIdWithBills(int id)
        {
            var apartment = _repository.Get(x => x.Id == id);
            var bills = _billRepository.GetAll(x => x.ApartmentId == id).ToList();            
            var mapApartment =_mapper.Map<ApartmentGetDto>(apartment);
            if (mapApartment == null)
            {
                throw new Exception();
            }
            if (bills == null)
            {
                return mapApartment;
            }
            else
            {
                mapApartment.Bills = bills;
            }
            
            return mapApartment;
        }

        public void Update(ApartmentUpdateDto updateDto)
        {
            var cacheApartmet=_repository.Get(x=>x.Id == updateDto.Id);
            var mapApartment = _mapper.Map(updateDto, cacheApartmet);
            _repository.Update(mapApartment);
            _repository.SaveChanges();
        }
    }
}
