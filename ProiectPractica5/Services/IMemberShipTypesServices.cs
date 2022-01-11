using Microsoft.EntityFrameworkCore;
using ProiectPractica5.Models;

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
