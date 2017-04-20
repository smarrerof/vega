using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vega.Data.Models
{
    [Table("Models")]
    public class Model
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        // Navigation properties
        public Make Make { get; set; }
        
        public int MakeId { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }

        public Model()
        {
            Vehicles = new Collection<Vehicle>();
        }
    }
}
