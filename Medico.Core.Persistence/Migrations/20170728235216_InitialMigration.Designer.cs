using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Medico.Core.Persistence;

namespace Medico.Core.Persistence.Migrations
{
    [DbContext(typeof(MedicoContext))]
    [Migration("20170728235216_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Medico.Core.Entities.Medication", b =>
                {
                    b.Property<int>("MedicationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HumanReadableName");

                    b.Property<DateTime?>("InitialDoseTime");

                    b.Property<int>("MaximumNumberOfDoses");

                    b.Property<string>("MedicalName");

                    b.Property<bool>("MedicationActive");

                    b.Property<DateTime?>("MedicationNoLongerActiveDate");

                    b.Property<string>("Notes");

                    b.Property<int>("PerscribedDosage");

                    b.Property<int>("TimeBetweenDoses");

                    b.HasKey("MedicationId");

                    b.ToTable("Medications");
                });

            modelBuilder.Entity("Medico.Core.Entities.MedicationActionTime", b =>
                {
                    b.Property<int>("MedicationActionTimeId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Actioned");

                    b.Property<int>("MedicationId");

                    b.Property<string>("Notes");

                    b.Property<DateTime?>("TimeActioned");

                    b.HasKey("MedicationActionTimeId");

                    b.HasIndex("MedicationId");

                    b.ToTable("MedicationActionTimes");
                });

            modelBuilder.Entity("Medico.Core.Entities.MedicationActionTime", b =>
                {
                    b.HasOne("Medico.Core.Entities.Medication", "Medication")
                        .WithMany()
                        .HasForeignKey("MedicationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
