using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationBasic.Data.Models
{
    [Table("Vehicles")]
    public class Vehicle
    {
        public int Id { get; set; }

        public int MakeId { get; set; }

        public int ModelId { get; set; }

        public bool IsRegistered { get; set; }

        public ICollection<VehicleFeature> VehicleFeatures { get; set; }

        [StringLength(255)]
        public string ContactName { get; set; }

        [StringLength(255)]
        public string ContactPhone { get; set; }

        [StringLength(255)]
        public string ContactEmail { get; set; }
        
        // Navigation properties
        public Make Make { get; set; }

        public Model Model { get; set; }

        public Vehicle()
        {
            VehicleFeatures = new Collection<VehicleFeature>();
        }
    }
}
