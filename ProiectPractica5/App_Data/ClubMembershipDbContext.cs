using Microsoft.EntityFrameworkCore;
using ProiectPractica5.Models;

namespace ProiectPractica5.App_Data
{
    public class ClubMembershipDbContext:DbContext
    {
        public ClubMembershipDbContext(DbContextOptions<ClubMembershipDbContext> options): base(options) { }

        public DbSet<Annoncements> Announcements { get; set; }
        public DbSet<CodeShippets> CodeShippets { get; set; }
    }
}
