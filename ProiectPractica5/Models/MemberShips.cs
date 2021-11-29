using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPractica5.Models
{
    public class MemberShips
    {
        [Key]
        public Guid IdMembership { get; set; }
        public Guid IdMember { get; set; }
        public Guid IdMembershipType { get; set; }
        public DateTime StartData { get; set; }
        public DateTime EndData { get; set; }
        public int Lvl { get; set; }
    }
}
