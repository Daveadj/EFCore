using EFCoreWebApp.core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWebApp.DAL.Tests
{
    [TestFixture]
    public class SelectTests
    {
        private AppDbContext _context;

        [SetUp]
        public void Setup()
        {
            _context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>().UseSqlServer("Server=.;Database=EFCoreWebApp;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false").Options);
        }

        [Test]
        public void Test1()
        {
            IEnumerable<Person> persons = _context.Persons.ToList();
            Assert.That(persons.Count(), Is.EqualTo(2));
        }

        [Test]
        public void PersonsHaveAddresses()
        {
            List<Person> persons = _context.Persons.Include("Addresses").ToList();
            Assert.That(persons[0].Addresses.Count, Is.EqualTo(1));
            Assert.That(persons[1].Addresses.Count, Is.EqualTo(2));
        }

        [Test]
        public void HaveLookUpRecords()
        {
            var lookUps = _context.LookUps.ToList();
            var countries = lookUps.Where(x => x.LookUpType == (int)LookUpType.Country).
            ToList();
            var states = lookUps.Where(x => x.LookUpType == (int)LookUpType.State).ToList();
            Assert.That(countries.Count, Is.EqualTo(1));
            Assert.That(states.Count, Is.EqualTo(51));
        }

        [Test]
        public void InsertPersonWithAddresses()
        {
            var record = new Person()
            {
                FirstName = "Clarke",
                LastName = "Kent",
                EmailAddress = "clark@dailybugel.com",
                Addresses = new List<Address>
                {
                    new Address
                    {
                        AddressLine1 = "1234 Fake Street",
                        AddressLine2 = "Suite 1",
                        City = "Chicago",
                        State = "IL",
                        ZipCode = "60652",
                        Country = "United States"
                    },
                     new Address
                    {
                        AddressLine1 = "555 Waverly Street",
                        AddressLine2 = "APT B2",
                        City = "Mt. Plesant",
                        State = "MI",
                        ZipCode = "48858",
                        Country = "USA"
                    }
                }
            };
            _context.Persons.Add(record);
            _context.SaveChanges();
            var addedPerson = _context.Persons.Single(x => x.FirstName == "Clarke" && x.LastName == "Kent");
            Assert.Greater(addedPerson.Id, 0);
            Assert.That(addedPerson.Addresses.Count, Is.EqualTo(2));
            Assert.That(addedPerson.FirstName, Is.EqualTo(record.FirstName));
            Assert.That(addedPerson.LastName, Is.EqualTo(record.LastName));
            Assert.That(addedPerson.EmailAddress, Is.EqualTo(record.EmailAddress));
            for (int i = 0; i < record.Addresses.Count; i++)
            {
                Assert.That(addedPerson.Addresses[i].AddressLine1, Is.EqualTo(record.Addresses[i].AddressLine1));
                Assert.That(addedPerson.Addresses[i].AddressLine2, Is.EqualTo(record.Addresses[i].AddressLine2));
                Assert.That(addedPerson.Addresses[i].City, Is.EqualTo(record.Addresses[i].City));
                Assert.That(addedPerson.Addresses[i].State, Is.EqualTo(record.Addresses[i].State));
                Assert.That(addedPerson.Addresses[i].ZipCode, Is.EqualTo(record.Addresses[i].ZipCode));
                Assert.That(addedPerson.Addresses[i].Country, Is.EqualTo(record.Addresses[i].Country));
            }
        }

        [TearDown]
        public void TearDown()
        {
            var person = _context.Persons.Single(X => X.FirstName == "Clarke" && X.LastName == "Kent");
            _context.Persons.Remove(person);
            _context.SaveChanges();
        }
    }
}