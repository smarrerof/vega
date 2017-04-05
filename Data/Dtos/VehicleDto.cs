using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WebApplicationBasic.Data.Dtos
{
    public class VehicleDto
    {
        public int Id { get; set; }

        public int MakeId { get; set; }

        public int ModelId { get; set; }

        public bool IsRegistered { get; set; }

        public ICollection<int> Features { get; set; }

        public string ContactName { get; set; }

        public string ContactPhone { get; set; }

        public string ContactEmail { get; set; }

        // Navigation properties
        

        public VehicleDto()
        {
            Features = new Collection<int>();
        }
    }
}
