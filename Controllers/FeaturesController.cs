using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using vega.Persistence;
using vega.Controllers.Resources;
using vega.Core.Models;


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
        public IEnumerable<KeyValuePairResource> GetMakes()
        {
            var features = _context.Features.ToList();
            return _mapper.Map<List<Feature>, List<KeyValuePairResource>>(features);
        }
    }
}