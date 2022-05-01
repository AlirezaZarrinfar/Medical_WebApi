using Laboratory_WebApi.Application.Interfaces;
using Laboratory_WebApi.Domain.Entities.Laboratory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_WebApi.Persistance.Context
{
    public class DatabaseContext : DbContext , IDatabaseContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<TestsGroup> testsGroups { get; set; }
        public DbSet<SubTest> subTests { get; set; }
    }
}
