using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationBasic.Data.Models
{
    [Table("VehicleFeature")]
    public class VehicleFeature
    {
        public int Id { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public int FeatureId { get; set; }
        public Feature Feature { get; set; }        
    }
}
