using Microsoft.EntityFrameworkCore;
using ProiectPractica5.Models;

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
