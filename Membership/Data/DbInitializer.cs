using Membership.Models;
using Microsoft.EntityFrameworkCore;

namespace Membership.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _builder;

        public DbInitializer(ModelBuilder builder)
        {
            _builder = builder;
        }

        public void Seed()
        {
            _builder.Entity<Person>(a =>
            {
                a.HasData(new Person
                {
                    Id = new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"),
                    FirstName = "Ayokunle",
                    Surname = "Olowoniwa",
                    Email = "olowoniwa.ayokunle@gmail.com",
                    
                });
                a.HasData(new Person
                {
                    Id = new Guid("6ebc3dbe-2e7b-4132-8c33-e089d47694cd"),
                    FirstName = "Mile",
                    Surname = "Montego",
                    Email = "ayokunle@mailinator.com",
                });
            });

            _builder.Entity<Memberships>(b =>
            {
                b.HasData(new Memberships
                {
                    Id = new Guid("98474b8e-d713-401e-8aee-acb7353f97bb"),
                    MembershipNumber = 111,
                    AccountBalance = 5000,
                    Type = Models.Type.Primary.ToString(),
                    PersonId = new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59")
                });
                b.HasData(new Memberships
                {
                    Id = new Guid("bfe902af-3cf0-4a1c-8a83-66be60b028ba"),
                    MembershipNumber = 112,
                    AccountBalance = 64000,
                    Type = Models.Type.Secondary.ToString(),
                    PersonId = new Guid("6ebc3dbe-2e7b-4132-8c33-e089d47694cd")
                });
                b.HasData(new Memberships
                {
                    Id = new Guid("150c81c6-2458-466e-907a-2df11325e2b8"),
                    MembershipNumber = 113,
                    AccountBalance = 600,
                    Type = Models.Type.Secondary.ToString(),
                    PersonId = new Guid("6ebc3dbe-2e7b-4132-8c33-e089d47694cd")
                });
            });

        }
    }

}
