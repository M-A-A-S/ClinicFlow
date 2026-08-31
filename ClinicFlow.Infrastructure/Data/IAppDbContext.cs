using ClinicFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicFlow.Infrastructure.Data
{
    public interface IAppDbContext
    {
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<PatientAllergy> PatientAllergies { get; set; }
        public DbSet<ChronicCondition> ChronicConditions { get; set; }
        public DbSet<PatientChronicCondition> PatientChronicConditions { get; set; }
        public DbSet<Patient> Patients { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int SaveChanges();
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);


    }
}
