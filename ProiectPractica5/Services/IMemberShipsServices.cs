using Microsoft.EntityFrameworkCore;
using ProiectPractica5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPractica5.Services
{
    public interface IMemberShipsServices
    {
        public DbSet<MemberShips> Get();
        public void Put(MemberShips memberShips);
        public void Post(MemberShips memberShips);
        public void Delete(MemberShips memberShips);
    }
}
