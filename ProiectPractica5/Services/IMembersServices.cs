using Microsoft.EntityFrameworkCore;
using ProiectPractica5.Models;

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
