using Hai.MedicalSystem.Api.Entities.Diseases;
using Hai.MedicalSystem.Api.Entities.Patients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hai.MedicalSystem.Api.Data.Configurations
{
    public sealed class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("patients");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("patient_id");

            builder.Property(p => p.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Patronymic)
                .HasColumnName("patronymic")
                .HasMaxLength(100);

            builder.Property(p => p.BirthDate)
                .HasColumnName("birth_date")
                .IsRequired();

            builder.Property(p => p.Gender)
                .HasColumnName("gender")
                .HasConversion<string>()
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(p => p.Phone)
                .HasColumnName("phone")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnName("email")
                .HasMaxLength(256);

            builder.Property(p => p.PolicyNumber)
                .HasColumnName("policy_number")
                .HasMaxLength(16)
                .IsRequired();

            builder.HasIndex(p => p.PolicyNumber).IsUnique();

            builder.Property(p => p.CurrentDoctorId)
                .HasColumnName("current_doctor_id");
            builder.HasOne(p => p.CurrentDoctor)
                .WithMany(d => d.Patients)
                .HasForeignKey(p => p.CurrentDoctorId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(p => p.Diseases)
                .WithMany(d => d.Patients)
                .UsingEntity<Dictionary<string, object>>(
                    "patient_diseases",
                    right => right
                        .HasOne<Disease>()
                        .WithMany()
                        .HasForeignKey("disease_id"),
                    left => left
                        .HasOne<Patient>()
                        .WithMany()
                        .HasForeignKey("patient_id"),
                    join =>
                    {
                        join.ToTable("patient_diseases");
                        join.HasKey("patient_id", "disease_id");
                    });
        }
    }
}
