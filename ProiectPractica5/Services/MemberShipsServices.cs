using Microsoft.EntityFrameworkCore;
using ProiectPractica5.App_Data;
using ProiectPractica5.Models;
using System;

namespace ProiectPractica5.Services
{
    public class MemberShipsServices : IMemberShipsServices
    {
        private readonly ClubMembershipDbContext _context;

        public MemberShipsServices(ClubMembershipDbContext context)
        {
            _context = context;
        }
        public void Delete(MemberShips memberShips)
        {
            _context.Remove(memberShips);
            _context.SaveChanges();
        }

        public DbSet<MemberShips> Get()
        {
            return _context.MemberShips;
        }

        public void Post(MemberShips memberShips)
        {
            var codeS = new MemberShips()
            {
                IdMembership = Guid.NewGuid(),//nu il trimitem in swagger
                IdMember = memberShips.IdMember,
                IdMembershipType = memberShips.IdMembershipType,
                StartData = memberShips.StartData,
                EndData = memberShips.EndData,
                Lvl = memberShips.Lvl
            };
            _context.Entry(codeS).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Put(MemberShips memberShips)
        {
            _context.Update(memberShips);
            _context.SaveChanges();
        }
    }
}
