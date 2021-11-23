using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPractica5.Models
{
    public class MemberShipType
    {
        public int IdMembershipType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SuscriptionLengthInMounths { get; set; }
    }
}
