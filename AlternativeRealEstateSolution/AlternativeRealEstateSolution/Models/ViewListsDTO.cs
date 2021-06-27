using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlternativeRealEstateSolution.Models
{
    public class ViewListsDTO
    {
        public List<User> Users { get; set; }
        public List<Property> Properties { get; set; }
        public List<Event> Events { get; set; }
    }
}
