using Microsoft.EntityFrameworkCore;
using ProiectPractica5.Models;
namespace ProiectPractica5.Services
{
    public interface IAnnouncementsServices
    {
        public DbSet<Announcements> Get();
        public void Put(Announcements announcements);
        public void Post(Announcements announcements);
        public void Delete(Announcements announcements);
    }
}
