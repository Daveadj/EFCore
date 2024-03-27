using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFCoreWebApp.core.Entities;

namespace EFCoreWebApp.Data
{
    public class EFCoreWebAppContext : DbContext
    {
        public EFCoreWebAppContext (DbContextOptions<EFCoreWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<EFCoreWebApp.core.Entities.Person> Person { get; set; } = default!;
    }
}
