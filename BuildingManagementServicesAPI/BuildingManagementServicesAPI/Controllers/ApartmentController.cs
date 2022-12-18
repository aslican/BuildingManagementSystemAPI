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
    
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;
        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var apartments = _apartmentService.GetAll();
            return Ok(apartments);

        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        [Route("getapartmentwithbill/{id}")]
        
        public IActionResult GetApartmentsWithBills(int id)
        {
            var apartment=_apartmentService.GetByIdWithBills(id);
            return Ok(apartment);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var apartment = _apartmentService.GetByIdWithUser(id);
            return Ok(apartment);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IActionResult Delete(Apartment apartment)
        {
            _apartmentService.Delete(apartment);
            return Ok("Success");
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(AddApartmentDto addDto)
        {
            _apartmentService.Add(addDto);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Update(ApartmentUpdateDto updateDto)
        {
            _apartmentService.Update(updateDto);
            return Ok("Success");
        }
    }
}
