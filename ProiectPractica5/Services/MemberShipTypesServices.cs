using Microsoft.EntityFrameworkCore;
using ProiectPractica5.App_Data;
using ProiectPractica5.Models;
using System;

namespace ProiectPractica5.Services
{
    public class MemberShipTypesServices : IMemberShipTypesServices
    {
        private readonly ClubMembershipDbContext _context;

        public MemberShipTypesServices(ClubMembershipDbContext context)
        {
            _context = context;
        }
        public void Delete(MemberShipTypes memberShipTypes)
        {
            _context.Remove(memberShipTypes);
            _context.SaveChanges();
        }

        public DbSet<MemberShipTypes> Get()
        {
            return _context.MemberShipTypes;
        }

        public void Post(MemberShipTypes memberShipTypes)
        {
            var codeS = new MemberShipTypes()
            {
                IdMembershipType = Guid.NewGuid(),//nu il trimitem in swagger
                Name = memberShipTypes.Name,
                Description = memberShipTypes.Description,
                SuscriptionLengthInMounths = memberShipTypes.SuscriptionLengthInMounths
            };
            _context.Entry(codeS).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Put(MemberShipTypes memberShipTypes)
        {
            _context.Update(memberShipTypes);
            _context.SaveChanges();
        }
    }
}
