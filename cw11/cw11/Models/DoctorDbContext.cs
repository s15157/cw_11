using cw11.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw11.Models;

namespace cw11.Models
{
    public class DoctorDbContext : DbContext
    {
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicament { get; set; }

        public DoctorDbContext() { }

        public DoctorDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DoctorEfConfiguration());
            modelBuilder.ApplyConfiguration(new PatientEfConfiguration());
            modelBuilder.ApplyConfiguration(new PrescriptionEfConfiguration());
            modelBuilder.ApplyConfiguration(new MedicamentEfConfiguration());
            modelBuilder.ApplyConfiguration(new Prescription_MedicamentEfConfiguration());

            Seed(modelBuilder);
        }

        protected void Seed(ModelBuilder modelBuilder)
        {
            var doctor = new List<Doctor>();
                doctor.Add(new Doctor { IdDoctor = 1, FirstName = "Jan", LastName = "Kowalski", Email = "test@test.pl" });
                doctor.Add(new Doctor { IdDoctor = 2, FirstName = "Damian", LastName = "Przyborowski", Email = "mail@mail.com" });
            modelBuilder.Entity<Doctor>()
                        .HasData(doctor);

            var patient = new List<Patient>();
                patient.Add(new Patient { IdPatient = 1, FirstName = "Andrzej", LastName = "Brzostek", BirthDate = DateTime.Parse("20/04/1979") });
                patient.Add(new Patient { IdPatient = 2, FirstName = "Klaudia", LastName = "Nowak", BirthDate = DateTime.Parse("16/06/1994") });
            modelBuilder.Entity<Patient>()
                        .HasData(patient);

            var prescription = new List<Prescription>();
                prescription.Add(new Prescription { IdPrescription = 1, Date = DateTime.Parse("20/07/2019"), DueDate = DateTime.Parse("20/08/2019"), IdPatient = 2, IdDoctor = 1 });
                prescription.Add(new Prescription { IdPrescription = 2, Date = DateTime.Parse("12/11/2018"), DueDate = DateTime.Parse("12/12/2018"), IdPatient = 1, IdDoctor = 2 });
                prescription.Add(new Prescription { IdPrescription = 3, Date = DateTime.Parse("02/01/2013"), DueDate = DateTime.Parse("02/02/2013"), IdPatient = 1, IdDoctor = 1 });
                prescription.Add(new Prescription { IdPrescription = 4, Date = DateTime.Parse("18/10/2012"), DueDate = DateTime.Parse("18/11/2012"), IdPatient = 2, IdDoctor = 2 });
            modelBuilder.Entity<Prescription>()
                        .HasData(prescription);

            var medicament = new List<Medicament>();
                medicament.Add(new Medicament { IdMedicament = 1, Name = "APAP", Description = "Przeciwbolowy", Type = "tabletki" });
                medicament.Add(new Medicament { IdMedicament = 2, Name = "Herbapect", Description = "Na kaszel", Type = "syrop" });
                medicament.Add(new Medicament { IdMedicament = 3, Name = "Paracetamol", Description = "Przeciwgoraczkowy", Type = "tabletki" });
                medicament.Add(new Medicament { IdMedicament = 4, Name = "Fervex", Description = "na przeziebienie", Type = "saszetki" });
            modelBuilder.Entity<Medicament>()
                        .HasData(medicament);

            var prescription_medicament = new List<Prescription_Medicament>();
                prescription_medicament.Add(new Prescription_Medicament { IdMedicament = 1, IdPrescription = 3, Dose = 1, Details = "w razie goraczki" });
                prescription_medicament.Add(new Prescription_Medicament { IdMedicament = 2, IdPrescription = 2, Dose = 50, Details = "rano i wiecorem" });
                prescription_medicament.Add(new Prescription_Medicament { IdMedicament = 3, IdPrescription = 4, Dose = 3, Details = "po sniadaniu, obiedzie, kolacji" });
                prescription_medicament.Add(new Prescription_Medicament { IdMedicament = 4, IdPrescription = 1, Dose = 1, Details = "w bolu" });
            modelBuilder.Entity<Prescription_Medicament>()
                        .HasData(prescription_medicament);
        }
    }
}
