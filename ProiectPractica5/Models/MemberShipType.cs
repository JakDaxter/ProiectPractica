using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPractica5.Models
{
    public class MemberShipType
    {
        [Key]
        public Guid IdMembershipType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SuscriptionLengthInMounths { get; set; }
    }
}
