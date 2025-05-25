using Microsoft.EntityFrameworkCore;

namespace Tutorial5.Data;

public class DatabaseContext : DbContext
{
    
    public DbSet<Prescription> Prescriptions { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Medicament>().HasData(
            new Medicament { Description = "Effective in headache", idMedicament = 1, Name = "Paracetamol", Type = "Pill"},
            new Medicament { Description = "Effective in headache", idMedicament = 2, Name = "Citramon", Type = "Pill"}
        );
        
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor { IdDoctor = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@hospital.com" },
            new Doctor { IdDoctor = 2, FirstName = "Anna", LastName = "Smith", Email = "anna.smith@hospital.com" }
        ); 
        
        modelBuilder.Entity<Patient>().HasData(
            new Patient { IdPatient = 1, FirstName = "Michael", LastName = "Brown", BirthDate = new DateTime(1980, 5, 20) },
            new Patient { IdPatient = 2, FirstName = "Emily", LastName = "Clark", BirthDate = new DateTime(1995, 8, 12) }
        );
        
        modelBuilder.Entity<Prescription>().HasData(
            new Prescription { IdPrescription = 1, Date = new DateTime(2024, 5, 1), DueDate = new DateTime(2024, 5, 15), IdPatient = 1, IdDoctor = 1 },
            new Prescription { IdPrescription = 2, Date = new DateTime(2024, 5, 3), DueDate = new DateTime(2024, 5, 10), IdPatient = 2, IdDoctor = 2 }
        );


        modelBuilder.Entity<Prescription_Medicament>().HasData(
            new Prescription_Medicament { IdPrescription = 1, IdMedicament = 1, Dose = 2, Details = "Take after meals" },
            new Prescription_Medicament { IdPrescription = 2, IdMedicament = 2, Dose = 1, Details = "Twice a day" }
        );
        
        modelBuilder.Entity<Prescription_Medicament>().HasKey(pk => new { pk.IdPrescription, pk.IdMedicament });
        base.OnModelCreating(modelBuilder);
    }
}