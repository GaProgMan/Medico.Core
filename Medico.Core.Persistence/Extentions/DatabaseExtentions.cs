using System.Collections.Generic;
using System.Linq;
using Medico.Core.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Medico.Core.Persistence.Extentions
{
    public static class DatabaseExtentions
    {
        public static bool AllMigrationsApplied(this MedicoContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }
        
        public static void EnsureSeedData(this MedicoContext context)
        {
            if (context.AllMigrationsApplied())
            {
                if(!context.Medications.Any())
                {
                    // Add some records
                    context.Medications.AddRange(GenerateAMedication());
                    context.SaveChanges();
                }
            }
        }

        private static ICollection<Medication> GenerateAMedication()
        {
            return new List<Medication>()
            {
                new Medication()
                {
                    HumanReadableName = "Paracetamol",
                    MedicalName = "Paracetamol",
                    PerscribedDosage = 150,
                    TimeBetweenDoses = 240,
                    MaximumNumberOfDoses = 4,
                    MedicationActive = true
                },
                new Medication()
                {
                    HumanReadableName = "Ibuprofen",
                    MedicalName = "Ibuprofen",
                    PerscribedDosage = 150,
                    TimeBetweenDoses = 240,
                    MaximumNumberOfDoses = 4,
                    MedicationActive = false
                }
            };
        }
    }
}