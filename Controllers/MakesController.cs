using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using vega.Persistence;
using vega.Controllers.Resources;
using vega.Core.Models;


namespace Vega.Controllers
{
    [Produces("application/json")]
    [Route("api/makes")]
    public class MakesController : Controller
    {
        readonly VegaDbContext _context;
        readonly IMapper _mapper;

        public MakesController(VegaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/makes
        [HttpGet]
        public IEnumerable<MakeResource> GetMakes()
        {
            var makes = _context.Makes.Include(m => m.Models).ToList();
            return _mapper.Map<List<Make>, List<MakeResource>>(makes);
        }
    }
}