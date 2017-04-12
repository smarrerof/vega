using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationBasic.Data;
using WebApplicationBasic.Data.Dtos;
using WebApplicationBasic.Data.Models;

namespace Vega.Controllers
{
    [Produces("application/json")]
    [Route("api/vehicles")]
    public class VehiclesController : Controller
    {
        readonly VegaDbContext _context;
        readonly IMapper _mapper;

        public VehiclesController(VegaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/vehicle/1
        [HttpGet("{id}")]
        public IActionResult GetVehicle([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = _context.Vehicles.SingleOrDefault(m => m.Id == id);

            if (vehicle == null)
                return NotFound();

            return Ok(_mapper.Map<Vehicle, VehicleDto>(vehicle));
        }

        // GET: api/vehicle
        public IActionResult GetVehicles()
        {
            return Ok(_mapper.Map<List<Vehicle>, List<VehicleDto>>(_context.Vehicles.ToList()));
        }

        // POST: api/vehicle
        [HttpPost]
        public IActionResult Post([FromBody] VehicleDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            Vehicle vehicle = new Vehicle();
            _mapper.Map(dto, vehicle);
            vehicle.LastUpdate = DateTime.Now.ToUniversalTime();

            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();

            return Ok(_mapper.Map<Vehicle, VehicleDto>(vehicle));
        }

        // PUT: api/vehicle
        [HttpPut]
        public IActionResult Put([FromBody] VehicleDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Vehicle vehicle =_context.Vehicles.SingleOrDefault(m => m.Id == dto.Id);

            if (vehicle == null)
                return NotFound();

            _mapper.Map(dto, vehicle);
            vehicle.LastUpdate = DateTime.Now.ToUniversalTime();

            _context.SaveChanges();

            return Ok(_mapper.Map<Vehicle, VehicleDto>(vehicle));
        }
    }
}