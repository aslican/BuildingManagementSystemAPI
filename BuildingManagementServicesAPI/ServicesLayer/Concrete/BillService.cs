using AutoMapper;
using DataLayer.Abstract;
using DomainLayer.Entities;
using ServicesLayer.Abstract;
using ServicesLayer.Model.DTOs.BillDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Concrete
{
    public class BillService:IBillService
    {
        private readonly IBillRepository _repository;
        private readonly IMapper _mapper;
        private readonly IApartmentService _apartmentService;
        private readonly IApartmentRepository _apartmentRepository;
        public BillService(IBillRepository billRepository,IMapper mapper,IApartmentService apartmentService,IApartmentRepository apartmentRepository)
        {
            _repository = billRepository;   
            _mapper = mapper;
            _apartmentService = apartmentService;
            _apartmentRepository=apartmentRepository;
        }

        public void Add(BillAddDto billAddDto)
        {
            var bill = _mapper.Map<Bill>(billAddDto);
            _repository.Add(bill);
            _repository.SaveChanges();
        }

        public void Delete(Bill bill)
        {
            _repository.Delete(bill);
            _repository.SaveChanges();
        }

        public IEnumerable<BillGetDto> GetAll()
        {
            var bills = _repository.GetAll();
            var mappedBill = bills.Select(x => _mapper.Map<BillGetDto>(x)).ToList();
            return mappedBill;
        }


        public BillGetDto GetById(int id)
        {
            var bills = _repository.Get(x => x.Id == id);
            var mappedBill = _mapper.Map<BillGetDto>(bills);
            return mappedBill;
        }

        public void Update(BillUpdateDto billUpdateDto)
        {
            var cacheBill = _repository.Get(x => x.Id == billUpdateDto.Id);
            var mapBill = _mapper.Map(billUpdateDto, cacheBill);
            _repository.Update(mapBill);
            _repository.SaveChanges();
        }
    }
}
