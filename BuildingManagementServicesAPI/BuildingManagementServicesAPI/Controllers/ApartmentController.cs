using DomainLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Abstract;
using ServicesLayer.Model.DTOs.ApartmentDTOs;

namespace BuildingManagementServicesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;
        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var apartments = _apartmentService.GetAll();
            return Ok(apartments);

        }
        [HttpGet]
        [Route("getapartmentwithbill/{id}")]
        
        public IActionResult GetApartmentsWithBills(int id)
        {
            var apartment=_apartmentService.GetByIdWithBills(id);
            return Ok(apartment);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var apartment = _apartmentService.GetByIdWithUser(id);
            return Ok(apartment);
        }
        [HttpDelete]
        public IActionResult Delete(Apartment apartment)
        {
            _apartmentService.Delete(apartment);
            return Ok("Success");
        }
        [HttpPost]
        public IActionResult Add(AddApartmentDto addDto)
        {
            _apartmentService.Add(addDto);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(ApartmentUpdateDto updateDto)
        {
            _apartmentService.Update(updateDto);
            return Ok("Success");
        }
    }
}
