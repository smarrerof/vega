using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // POST: api/makes
        [HttpPost]
        public VehicleDto Post([FromBody] VehicleDto dto)
        {
            Vehicle vehicle = new Vehicle();
            _mapper.Map(dto, vehicle);

            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();

            return _mapper.Map<Vehicle, VehicleDto>(vehicle);
        }
    }
}