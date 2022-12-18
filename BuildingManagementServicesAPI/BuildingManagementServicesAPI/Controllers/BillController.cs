using DomainLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Abstract;
using ServicesLayer.Model.DTOs.BillDTOs;

namespace BuildingManagementServicesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Consumes("application/json")]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;
        public BillController (IBillService billService)
        {
            _billService = billService;
        }
        
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var bills = _billService.GetAll();
            return Ok(bills);

        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var bill= _billService.GetById(id);
            return Ok(bill);
        }
        
        [HttpDelete]
        public IActionResult Delete(Bill bill)
        {
            _billService.Delete(bill);
            return Ok("Success");
        }
        
        [HttpPost]
        public IActionResult Add(BillAddDto billAddDto)
        {
            _billService.Add(billAddDto);
            return Ok();
        }
        
        [HttpPut]
        public IActionResult Update(BillUpdateDto billUpdateDto)
        {
            _billService.Update(billUpdateDto);
            return Ok("Success");
        }

    }
}
