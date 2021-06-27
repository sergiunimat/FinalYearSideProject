using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlternativeRealEstateSolution.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string PrivateAddress { get; set; }
        public string PublicAddress { get; set; }
        public string FullName { get; set; }
        public int Type { get; set; }
        public string Ether { get; set; }
        public string Email { get; set; }
    }
}
