using EFCoreWebApp.core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreWebApp.DAL.Tests
{
    [TestFixture]
    public class StoredProceduresTests
    {
        private AppDbContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>().UseSqlServer("Server=.;Database=EFCoreWebApp;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=false").Options);
        }

        [Test]
        public void GetPersonsByStateRaw()
        {
            string state = "IL";
            var persons = _context.Persons.FromSqlRaw($"GetPersonsByState @p0", new { state }).ToList();
            Assert.That(persons.Count, Is.EqualTo(2));
        }

        [Test]
        public void AddLookUpItemInterpolated()
        {
            string code = "CAN";
            string description = "Canada";
            LookUpType lookUpType = LookUpType.Country;
            _context.Database.ExecuteSqlInterpolated($"AddLookUpItem {code},{description}, {lookUpType} ");
            var addedItem = _context.LookUps.Single(x => x.Code == "CAN");
            Assert.IsNotNull(addedItem);
            _context.LookUps.Remove(addedItem);
            _context.SaveChanges();
        }

        [Test]
        public void AddLookUpItemRaw()
        {
            string code = "MEX";
            string description = "Mexico";
            LookUpType lookUpType = LookUpType.Country;
            _context.Database.ExecuteSqlRaw("AddLookUpItem @p0,@p1,@p2", new { code, description, lookUpType });
            var addedItem = _context.LookUps.Single(x => x.Code == "MEX");
            Assert.IsNotNull(addedItem);
            _context.LookUps.Remove(addedItem);
            _context.SaveChanges();
        }
    }
}