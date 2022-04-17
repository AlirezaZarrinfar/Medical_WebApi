using Hospital_WebApi.Application.Interfaces.Context;
using Hospital_WebApi.Models.Hospital;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_WebApi.Persistance.Context
{
    public class DatabaseContext : DbContext,IDatabaseContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Reception> Receptions { get; set; }

    }
}
