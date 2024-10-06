using KindergartenManager.Models.Kindergarten;
using Microsoft.EntityFrameworkCore;
using KindergartenManager.Models.Kindergarten; 


namespace KindergartenManager.Data
{
    public class KindergartenContext : DbContext
    {
        public KindergartenContext(DbContextOptions<KindergartenContext> options) : base(options) { }

        public DbSet<Child> Children { get; set; }
    }
}
