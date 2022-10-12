using Membership.Models;
using Microsoft.EntityFrameworkCore;

namespace Membership.Data
{
    public class MembershipDbContext : DbContext
    {
        public MembershipDbContext(DbContextOptions<MembershipDbContext> options) : base(options)
        {

        }
        public DbSet<Memberships> Membership { get; set; }
        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Defining relationship between Persons and Memberships
            builder.Entity<Memberships>()
                .HasOne(a => a.Person)
                .WithMany(b => b.Memberships);

            //Seed database with Persons and Memberships

            new DbInitializer(builder).Seed();
        }
    }
}
