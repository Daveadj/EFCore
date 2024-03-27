using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreWebApp.DAL.Tests
{
    [TestFixture]
    public class AggregationTests
    {
        private AppDbContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>().UseSqlServer("Server=.;Database=EFCoreWebApp;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false").Options);
        }

        [Test]
        public void CountPersons()
        {
            int personCount = _context.Persons.Count();
            Assert.That(personCount, Is.EqualTo(2));
        }

        [Test]
        public void AveragePersonAge()
        {
            var average = _context.Persons.Average(x => x.Age);
            Assert.That(average, Is.EqualTo(25));
        }

        [Test]
        public void SumPersonAge()
        {
            var sumAge = _context.Persons.Sum(x => x.Age);
            Assert.That(sumAge, Is.EqualTo(50));
        }

        [Test]
        public void GroupAddressesByState()
        {
            var expectedILAddressesCount = _context.Addresses.Where(x => x.State == "IL").Count();
            var expectedCAAddressesCount = _context.Addresses.Where(x => x.State == "CA").Count();
            var groupedAddresses = (from a in _context.Addresses.ToList()
                                    group a by a.State into g
                                    select new
                                    {
                                        State = g.Key,
                                        Addresses =
                                    g.Select(x => x)
                                    }).ToList();
            Assert.That(groupedAddresses.Single(x => x.State == "IL").Addresses.Count(), Is.EqualTo(expectedILAddressesCount));
            Assert.That(groupedAddresses.Single(x => x.State == "CA").Addresses.Count(), Is.EqualTo(expectedCAAddressesCount));
        }
    }
}