using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Models
{
    public class MedicDbContext : DbContext
    {

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        
        public DbSet<PrescriptionMedicament> Prescription_Medicaments { get; set; }

        public MedicDbContext()
        {

        }
        public MedicDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PrescriptionMedicament>()
           .HasKey(e => new { e.IdMedicament, e.IdPrescription });

            seed(modelBuilder);
        }

        public void seed(ModelBuilder model)
        {
            var doctors = new List<Doctor>();

            doctors.Add(new Doctor{
                IdDoctor = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                Email = "jan.kowal@poczta.pl"
            });


            doctors.Add(new Doctor
            {
                IdDoctor = 2,
                FirstName = "Mateusz",
                LastName = "Nowak",
                Email = "mat.nowak@poczta.pl"
            });

            doctors.Add(new Doctor
            {
                IdDoctor = 3,
                FirstName = "Piotr",
                LastName = "Kwiatek",
                Email = "piotr.kwiatek@poczta.pl"
            });

            doctors.Add(new Doctor
            {
                IdDoctor = 4,
                FirstName = "Doktor",
                LastName = "Dolittle",
                Email = "doktor.dolittle@poczta.pl"
            });

            var patients = new List<Patient>();

            patients.Add(new Patient
            {
                IdPatient = 1,
                FirstName = "Chory",
                LastName = "Nowacki",
                Birthdate = DateTime.Parse("1970-02-01")
            });

            patients.Add(new Patient
            {
                IdPatient = 2,
                FirstName = "Janina",
                LastName = "Malarska",
                Birthdate = DateTime.Parse("1983-01-21")
            });

            patients.Add(new Patient
            {
                IdPatient = 3,
                FirstName = "Maria",
                LastName = "NapewnonieCurieXD",
                Birthdate = DateTime.Parse("1925-09-04")
            });

            patients.Add(new Patient
            {
                IdPatient = 4,
                FirstName = "Stanisław",
                LastName = "Czapka",
                Birthdate = DateTime.Parse("1930-03-01")
            });

            var medicaments = new List<Medicament>();

            medicaments.Add(new Medicament
            {
                IdMedicament = 1,
                Name = "Etopiryna",
                Description = "Lek na wszystko, media nie kłamią",
                Type = "Tabletka",
            });

            medicaments.Add(new Medicament
            {
                IdMedicament = 2,
                Name = "Roznosol",
                Description = "Na katar",
                Type = "Dożylnie",
            });

            medicaments.Add(new Medicament
            {
                IdMedicament = 3,
                Name = "WigorPlus",
                Description = "Na skórę i paznokcie",
                Type = "Proszki",
            });

            medicaments.Add(new Medicament
            {
                IdMedicament = 4,
                Name = "Wkurzosol",
                Description = "Na problemy z oddychaniem",
                Type = "Dożylnie",
            });

            var prescriptions = new List<Prescription>();

            prescriptions.Add(new Prescription
            {
                IdPrescription = 1,
                Date = DateTime.Now,
                DueDate = DateTime.Now.AddMonths(1),
                IdPatient = 1,
                IdDoctor = 1
            });

            prescriptions.Add(new Prescription
            {
                IdPrescription = 2,
                Date = DateTime.Now,
                DueDate = DateTime.Now.AddMonths(5),
                IdPatient = 2,
                IdDoctor = 1
            });

            prescriptions.Add(new Prescription
            {
                IdPrescription = 3,
                Date = DateTime.Now,
                DueDate = DateTime.Now.AddMonths(2),
                IdPatient = 2,
                IdDoctor = 3
            });

            var prescriptionMedicaments = new List<PrescriptionMedicament>();

            prescriptionMedicaments.Add(new PrescriptionMedicament
            {
                IdPrescription = 1,
                IdMedicament = 1,
                Dose = 2,
                Details = "Dwa razy dziennie po posiłku"
            });

            prescriptionMedicaments.Add(new PrescriptionMedicament
            {
                IdPrescription = 2,
                IdMedicament = 2,
                Dose = 1,
                Details = "Raz dziennie rano"
            });

            prescriptionMedicaments.Add(new PrescriptionMedicament
            {
                IdPrescription = 3,
                IdMedicament = 3,
                Dose = 3,
                Details = "Trzy razy dziennie przed posiłkiem"
            });

            model.Entity<Doctor>().HasData(doctors);
            model.Entity<Patient>().HasData(patients);
            model.Entity<Medicament>().HasData(medicaments);
            model.Entity<Prescription>().HasData(prescriptions);
            model.Entity<PrescriptionMedicament>().HasData(prescriptionMedicaments);
        }

    }
}
