using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationBasic.Data.Dtos
{
    public class MakeDto
    {
        public int IdMake { get; set; }
        public string Name { get; set; }
        public List<ModelDto> Models { get; set; }
    }
}
