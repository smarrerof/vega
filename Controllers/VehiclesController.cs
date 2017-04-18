using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationBasic.Data;
using WebApplicationBasic.Data.Dtos;
using WebApplicationBasic.Data.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        // GET: api/vehicles/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle([FromRoute] int id)
        {
            var vehicle = await _context.Vehicles.Include(m => m.Features).SingleOrDefaultAsync(m => m.Id == id);

            if (vehicle == null)
                return NotFound();

            var result = _mapper.Map<Vehicle, VehicleDto>(vehicle);
            return Ok(result);
        }

        // GET: api/vehicles
        [HttpGet]
        public IActionResult GetVehicles()
        {
            var result = _mapper.Map<List<Vehicle>, List<VehicleDto>>(_context.Vehicles.ToList());
            return Ok(result);
        }

        // POST: api/vehicles
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                        
            var vehicle =_mapper.Map<VehicleDto, Vehicle>(dto);
            vehicle.LastUpdate = DateTime.Now.ToUniversalTime();

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<Vehicle, VehicleDto>(vehicle);
            return Ok(result);
        }

        // PUT: api/vehicles/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] VehicleDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Vehicle vehicle = await _context.Vehicles.Include(m => m.Features).SingleOrDefaultAsync(m => m.Id == id);

            if (vehicle == null)
                return NotFound();

            _mapper.Map(dto, vehicle);
            vehicle.LastUpdate = DateTime.Now.ToUniversalTime();

            await _context.SaveChangesAsync();

            var result = _mapper.Map<Vehicle, VehicleDto>(vehicle);
            return Ok(result);
        }

        // DELETE: api/vehicles/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            Vehicle vehicle = await _context.Vehicles.FindAsync(id);

            if (vehicle == null)
                return NotFound();

            _context.Remove(vehicle);
            await _context.SaveChangesAsync();

            return Ok(id);
        }
    }
}