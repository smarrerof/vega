using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using vega.Data.Dtos;
using vega.Data.Models;
using vega.Data.Interfaces;

namespace Vega.Controllers
{
    [Produces("application/json")]
    [Route("api/vehicles")]
    public class VehiclesController : Controller
    {
        //readonly VegaDbContext _context;
        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;

        public VehiclesController(/*VegaDbContext context, */IUnitOfWork unitOfWork, IMapper mapper)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/vehicles/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle([FromRoute] int id)
        {
            //var vehicle = await _context.Vehicles.Include(m => m.Make).Include(m => m.Model).Include(m => m.Features).SingleOrDefaultAsync(m => m.Id == id);
            var vehicle = await _unitOfWork.Vehicles.GetExtendedVehicle(id);

            if (vehicle == null)
                return NotFound();

            var result = _mapper.Map<Vehicle, VehicleDto>(vehicle);
            return Ok(result);
        }

        // GET: api/vehicles
        [HttpGet]
        public async Task<IActionResult> GetVehicles()
        {
            //var vehicles = await _context.Vehicles.Include(m => m.Make).Include(m => m.Model).Include(m => m.Features).ToListAsync();
            var vehicles = await _unitOfWork.Vehicles.GetExtendedVehicles();
            var result = _mapper.Map<List<Vehicle>, List<VehicleDto>>(vehicles);
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

            //_context.Vehicles.Add(vehicle);
            //await _context.SaveChangesAsync();
            _unitOfWork.Vehicles.Add(vehicle);
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<Vehicle, VehicleDto>(vehicle);
            return Ok(result);
        }

        // PUT: api/vehicles/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] VehicleDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var vehicle = await _context.Vehicles.Include(m => m.Features).SingleOrDefaultAsync(m => m.Id == id);
            var vehicle = await _unitOfWork.Vehicles.GetExtendedVehicle(id);

            if (vehicle == null)
                return NotFound();

            _mapper.Map(dto, vehicle);
            vehicle.LastUpdate = DateTime.Now.ToUniversalTime();

            //await _context.SaveChangesAsync();
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<Vehicle, VehicleDto>(vehicle);
            return Ok(result);
        }

        // DELETE: api/vehicles/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            //var vehicle = await _context.Vehicles.FindAsync(id);
            var vehicle = await _unitOfWork.Vehicles.GetAsync(id);

            if (vehicle == null)
                return NotFound();

            //_context.Remove(vehicle);
            //await _context.SaveChangesAsync();
            _unitOfWork.Vehicles.Remove(vehicle);
            await _unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}