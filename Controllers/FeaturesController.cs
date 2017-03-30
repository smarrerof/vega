using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplicationBasic.Data;
using WebApplicationBasic.Data.Dtos;
using WebApplicationBasic.Data.Models;

namespace Vega.Controllers
{
    [Produces("application/json")]
    [Route("api/features")]
    public class FeaturesController : Controller
    {
        readonly VegaDbContext _context;
        readonly IMapper _mapper;

        public FeaturesController(VegaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/features
        [HttpGet]
        public IEnumerable<FeatureDto> GetMakes()
        {
            var features = _context.Features.ToList();
            return Mapper.Map<List<Feature>, List<FeatureDto>>(features);
        }
    }
}