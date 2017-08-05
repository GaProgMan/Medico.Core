using System;
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
            var paracetamol = new Medication()
            {
                HumanReadableName = "Paracetamol",
                MedicalName = "Paracetamol",
                PerscribedDosage = 150,
                TimeBetweenDoses = 240,
                MaximumNumberOfDoses = 4,
                InitialDoseTime = DateTime.Now.Date + new TimeSpan(9, 30, 0)
            };


            var ibuprofen = new Medication()
            {
                HumanReadableName = "Ibuprofen",
                MedicalName = "Ibuprofen",
                PerscribedDosage = 150,
                TimeBetweenDoses = 240,
                MaximumNumberOfDoses = 4,
                InitialDoseTime = DateTime.Now.Date + new TimeSpan(9, 30, 0)
            };

            return new List<Medication>()
            {
                paracetamol,
                ibuprofen
            };
        }
    }
}