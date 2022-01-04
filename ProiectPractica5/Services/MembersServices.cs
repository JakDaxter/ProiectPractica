using Microsoft.EntityFrameworkCore;
using ProiectPractica5.App_Data;
using ProiectPractica5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPractica5.Services
{
    public class MembersServices : IMembersServices
    {
        private readonly ClubMembershipDbContext _context;

        public MembersServices(ClubMembershipDbContext context)
        {
            _context = context;
        }
        public void Delete(Members members)
        {
            _context.Remove(members);
            _context.SaveChanges();
        }

        public DbSet<Members> Get()
        {
            return _context.Members;
        }

        public void Post(Members members)
        {
            var codeS = new Members()
            {
                IdMembers = Guid.NewGuid(),//nu il trimitem in swagger
                Name = members.Name,
                Title = members.Title,
                Position = members.Position,
                Description = members.Description,
                Resume = members.Resume
            };
            _context.Entry(codeS).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Put(Members members)
        {
            _context.Update(members);
            _context.SaveChanges();
        }
    }
}
