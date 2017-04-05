using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationBasic.Data.Models
{
    [Table("Makes")]
    public class Make
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        // Navigation properties
        public ICollection<Model> Models { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }

        public Make()
        {
            Models = new Collection<Model>();
            Vehicles = new Collection<Vehicle>();
        }
    }
}
