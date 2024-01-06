using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MapperApp.Models;
using MapperApp.Models.DTOs.Incoming;
using MapperApp.Models.DTOs.Outgoing;
using Microsoft.AspNetCore.Mvc;

namespace MapperApp.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DriversController : ControllerBase
	{
		private readonly ILogger<DriversController> _logger;
		private static List<Driver> drivers = new List<Driver>();
		private readonly IMapper _mapper;

		public DriversController(ILogger<DriversController> logger, IMapper mapper)
		{
			_logger = logger;
			_mapper = mapper;
		}

		// Get all drivers
		[HttpGet]
		public IActionResult GetDrivers()
		{
			var allDrivers = drivers.Where(X => X.Status == 1).ToList();

			var _drivers = _mapper.Map<IEnumerable<DriverForResponseDtos>>(allDrivers);
			return Ok(_drivers);
		}
		[HttpPost]
		public IActionResult CreateDriver(DriverForCreationDto data)
		{
			if (ModelState.IsValid)
			{
				var _driver = _mapper.Map<Driver>(data);
				
				drivers.Add(_driver);

				var newDriver = _mapper.Map<DriverForResponseDtos>(_driver);
				return CreatedAtAction("GetDriver", new { _driver.Id }, newDriver);				
			}

			return new JsonResult("Error Creating Driver") { StatusCode = 500 };
			
		}
		 [HttpGet("{id}") ]
		 public IActionResult GetDriver(Guid id)
		 {
			var item = drivers.FirstOrDefault(x => x.Id == id);
			if (item == null)
			{
				return NotFound();
			}
			return Ok(item);
		 }
		 
		 [HttpPut("{id}")]		 
		 public IActionResult UpdateDriver(Guid id, Driver data)
		 {
			if (id != data.Id)
				return BadRequest();

			var existingDriver = drivers.FirstOrDefault(x => x.Id == data.Id);

			if (existingDriver == null)
				return NotFound();
				
			var updatedDriver = new Driver()
			{
				DriverNumber = data.DriverNumber,
				FirstName = data.FirstName,
				LastName = data.LastName,
				WorldChampionships = data.WorldChampionships				
			};

			existingDriver = updatedDriver;

			return NoContent();			
		 }
		 [HttpDelete("{id}") ]
		 public IActionResult DeleteDriver(Guid id)
		 {
			var existingDriver = drivers.FirstOrDefault(x => x.Id == id);
			if (existingDriver == null)
			{
				return NotFound();
			}
			existingDriver.Status = 0;
			
			return NoContent();
		 }
	}
}