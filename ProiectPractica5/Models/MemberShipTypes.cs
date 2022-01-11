using System;
using System.ComponentModel.DataAnnotations;

namespace ProiectPractica5.Models
{
    public class MemberShipTypes
    {
        [Key]
        public Guid IdMembershipType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SuscriptionLengthInMounths { get; set; }
    }
}
