using Microsoft.EntityFrameworkCore;
using ProiectPractica5.App_Data;
using ProiectPractica5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectPractica5.Services
{
    public class AnnouncementsServices : IAnnouncementsServices
    {
        private readonly ClubMembershipDbContext _context;

        public AnnouncementsServices(ClubMembershipDbContext context)
        {
            _context = context;
        }
        public void Delete(Announcements announcements)
        {
            _context.Remove(announcements);
            _context.SaveChanges();
        }

        public DbSet<Announcements> Get()
        {
            return _context.Announcements;
        }

        public void Post(Announcements announcements)
        {
            var codeS = new Announcements()
            {
                IdAnnouncement = Guid.NewGuid(),//nu il trimitem in swagger
                ValidFrom = announcements.ValidFrom,
                ValidTo = announcements.ValidTo,
                Title = announcements.Title,
                Text = announcements.Text,
                EventDateTime = announcements.EventDateTime,
                Tags = announcements.Tags
            };
            _context.Entry(codeS).State = EntityState.Added;
            _context.SaveChanges();
        }
        public void Put(Announcements announcements)
        {
            _context.Update(announcements);
            _context.SaveChanges();
        }
    }
}
