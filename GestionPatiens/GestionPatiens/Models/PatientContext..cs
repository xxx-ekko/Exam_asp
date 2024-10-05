using GestionPatients.Models;
using System.Data.Entity;

public class PatientContext : DbContext
{
    public PatientContext() : base("name=PatientContext")
    {
    }

    public DbSet<Patient> Patients { get; set; }
}