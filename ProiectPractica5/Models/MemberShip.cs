using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPractica5.Models
{
    public class MemberShip
    {
        public int IdMembership { get; set; }
        public int IdMember { get; set; }
        public int MembershipType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int lvl { get; set; }
    }
}
