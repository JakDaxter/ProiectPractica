using Microsoft.EntityFrameworkCore;
using ProiectPractica5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPractica5.Services
{
    public interface IMemberShipTypesServices
    {
        public DbSet<MemberShipTypes> Get();
        public void Put(MemberShipTypes memberShipTypes);
        public void Post(MemberShipTypes memberShipTypes);
        public void Delete(MemberShipTypes memberShipTypes);
    }
}
