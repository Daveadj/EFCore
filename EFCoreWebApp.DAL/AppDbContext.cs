using EFCoreWebApp.core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWebApp.DAL
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<LookUp> LookUps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LookUp>().HasData(new List<LookUp>()
            {
                new LookUp() { Code = "AL", Description = "Alabama",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "AK", Description = "Alaska",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "AZ", Description = "Arizona",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "AR", Description = "Arkansas",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "CA", Description = "California",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "CO", Description = "Colorado",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "CT", Description = "Connecticut",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "DE", Description = "Delaware",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "DC", Description = "District of Columbia", LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "FL", Description = "Florida",LookUpType = (int)LookUpType.State},
                new LookUp() {Code = "GA",Description = "Georgia",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "ID", Description = "Hawaii",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "IL", Description = "Idaho",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "IN", Description = "Illinois",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "IA", Description = "Indiana",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "KS", Description = "Iowa",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "KY", Description = "Kansas",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "LA", Description = "Kentucky",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "ME", Description = "Louisiana", LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "MD", Description = "Maine",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "MA", Description = "Maryland",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "MI", Description = "Massachusetts",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "MN", Description = "Michigan",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "MS", Description = "Minnesota",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "MO", Description = "Mississippi",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "MT", Description = "Missouri",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "NE", Description = "Montana",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "NV", Description = "Nevada",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "NH", Description = "New Hampshire",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "NJ", Description = "New Jersey",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "NM", Description = "New Mexico",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "NY", Description = "New York", LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "NC", Description = "New Carolina",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "ND", Description = "North Dakota",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "OH", Description = "Ohio",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "OK", Description = "Oklahoma", LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "OR", Description = "Oregon",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "PA", Description = "Pennsylvania",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "RI", Description = "Rhode Island",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "SC", Description = "South Carolina", LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "SD", Description = "South Dakota",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "TN", Description = "Tennessee",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "TX", Description = "Texas", LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "UT", Description = "Utah",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "VT", Description = "Vermont",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "VA", Description = "Virginia",LookUpType = (int) LookUpType.State},
                new LookUp() { Code = "WA", Description= "Washington",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "WV", Description = "West Virginia",LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "WI", Description = "Wisconsis", LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "WY", Description = "Wyoming", LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "PR", Description = "Puerto Rico", LookUpType = (int)LookUpType.State},
                new LookUp() { Code = "USA", Description = "United States of America", LookUpType = (int)LookUpType.Country}
            });

            modelBuilder.Entity<Person>().HasData(new List<Person>()
            {
                new Person(){ Id = 1, FirstName = "John", LastName = "Smith",
                EmailAddress = "john@smith.com", Age = 20},
                new Person(){ Id = 2, FirstName = "Susan", LastName = "Jones",
                EmailAddress = "john@smith.com", Age = 30 }
            });

            modelBuilder.Entity<Address>().HasData(new List<Address>()
            {
                new Address() { Id = 1, AddressLine1 = "123 Test St", AddressLine2 = "",
                City = "Beverly Hills", State = "CA", ZipCode = "90210", PersonId = 1,
                Country = "USA"},
                new Address() { Id = 2, AddressLine1 = "123 Michigan Ave",
                AddressLine2 = "", City = "Chicago", State = "IL", ZipCode = "60612",
                PersonId = 2, Country = "USA"},
                new Address() { Id = 3, AddressLine1 = "100 1St St", AddressLine2 = "",
                City = "Chicago", State = "IL", ZipCode = "60612", PersonId = 2,
                Country = "USA"}
            });
        }
    }
}