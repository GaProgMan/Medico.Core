using System;
using Medico.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medico.Core.Persistence
{
    public class MedicoContext : DbContext
    {
        public MedicoContext(DbContextOptions<MedicoContext> options) : base(options) { }

        public MedicoContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public DbSet<Medication> Medications { get; set; }
        public DbSet<MedicationActionTime> MedicationActionTimes { get; set; }
    }
}
