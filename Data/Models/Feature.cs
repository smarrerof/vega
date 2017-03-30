using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationBasic.Data.Models
{
    public class Feature
    {
        [Key]
        public int IdFeature { get; set; }
        public string Name { get; set; }
    }
}
