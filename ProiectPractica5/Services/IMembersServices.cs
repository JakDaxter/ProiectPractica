using Microsoft.EntityFrameworkCore;
using ProiectPractica5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPractica5.Services
{
    public interface IMembersServices
    {
        public DbSet<Members> Get();
        public void Put(Members members);
        public void Post(Members members);
        public void Delete(Members members);
    }
}
