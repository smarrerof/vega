using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationBasic.Data.Models
{
    public class Make
    {
        [Key]
        public int IdMake { get; set; }
        public string Name { get; set; }
        public List<Model> Models { get; set; }
    }
}
