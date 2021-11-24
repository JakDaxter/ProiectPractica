using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPractica5.Models
{
    public class MemberShip
    {
        [Key]
        public Guid IdMembership { get; set; }
        public Guid IdMember { get; set; }
        public Guid IdMembershipType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int lvl { get; set; }
    }
}
