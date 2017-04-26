using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vega.Core.Models
{
    [Table("Features")]
    public class Feature
    {        
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }    
    }
}
