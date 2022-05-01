﻿using Laboratory_WebApi.Domain.Entities.Laboratory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laboratory_WebApi.Application.Interfaces
{
    public interface IDatabaseContext
    {
        public DbSet<TestsGroup> testsGroups { get; set; }
        public DbSet<SubTest> subTests { get; set; }
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
