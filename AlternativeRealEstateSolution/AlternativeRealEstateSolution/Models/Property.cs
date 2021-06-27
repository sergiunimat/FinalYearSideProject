using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlternativeRealEstateSolution.Models
{
    public class Property
    {
        [Key]
        public string Id { get; set; }
        public string Ether { get; set; }
        public string OwnerPublicAddress { get; set; }
        public string Description { get; set; }
        public string GeographicalAddress { get; set; }
    }
}
