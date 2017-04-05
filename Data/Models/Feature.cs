using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationBasic.Data.Models
{
    [Table("Features")]
    public class Feature
    {        
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        public ICollection<VehicleFeature> FeatureVehicles { get; set; }

        public Feature()
        {
            FeatureVehicles = new Collection<VehicleFeature>();
        }
    }
}
