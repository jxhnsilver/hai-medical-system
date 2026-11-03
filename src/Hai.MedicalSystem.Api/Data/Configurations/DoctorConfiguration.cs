using Hai.MedicalSystem.Api.Entities.Doctors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hai.MedicalSystem.Api.Data.Configurations
{
    public sealed class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("doctors");

            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id)
                .HasColumnName("id");

            builder.Property(d => d.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(d => d.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(d => d.Patronymic)
                .HasColumnName("patronymic")
                .HasMaxLength(100);

            builder.Property(d => d.Specialization)
                .HasColumnName("specialization")
                .HasConversion<string>()
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(d => d.CabinetNumber)
                .HasColumnName("cabinet_number")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(d => d.Status)
                .HasColumnName("status")
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(d => d.Phone)
                .HasColumnName("phone")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(d => d.Email)
                .HasColumnName("email")
                .HasMaxLength(256);

            builder.HasIndex(d => d.Specialization);

            builder.HasMany(d => d.Patients)
                .WithOne(p => p.CurrentDoctor)
                .HasForeignKey(p => p.CurrentDoctorId);
        }
    }
}
