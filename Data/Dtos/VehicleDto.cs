using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationBasic.Data.Dtos
{
    public class VehicleDto
    {
        public int Id { get; set; }

        public int MakeId { get; set; }

        [Required]
        public int ModelId { get; set; }

        public bool IsRegistered { get; set; }

        public ICollection<int> Features { get; set; }

        [StringLength(255)]
        public string ContactName { get; set; }

        [StringLength(255)]
        public string ContactPhone { get; set; }

        public string ContactEmail { get; set; }

        public DateTime LastUpdate { get; set; }

        public VehicleDto()
        {
            Features = new Collection<int>();
        }
    }
}
