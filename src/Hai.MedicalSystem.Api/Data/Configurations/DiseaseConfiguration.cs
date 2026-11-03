using Hai.MedicalSystem.Api.Entities.Diseases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hai.MedicalSystem.Api.Data.Configurations
{
    public sealed class DiseaseConfiguration : IEntityTypeConfiguration<Disease>
    {
        public void Configure(EntityTypeBuilder<Disease> builder)
        {
            builder.ToTable("diseases");

            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id)
                .HasColumnName("id");

            builder.Property(d => d.Name)
                .HasColumnName("name")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(d => d.Code)
                .HasColumnName("code")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(d => d.Description)
                .HasColumnName("description")
                .HasMaxLength(5000);

            builder.HasIndex(d => d.Code).IsUnique();
        }
    }
}
