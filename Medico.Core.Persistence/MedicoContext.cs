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
            modelBuilder.Entity<MedicationActionTime>()
                .HasOne(mat => mat.Medication)
                .WithMany(m => m.MedicationActionTimes)
                .HasForeignKey(mat => mat.MedicationId);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public DbSet<Medication> Medications { get; set; }
        public DbSet<MedicationActionTime> MedicationActionTimes { get; set; }
    }
}
