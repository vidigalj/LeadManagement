using LeadManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeadManagement.Infra.Mappings;

public class LeadMap : IEntityTypeConfiguration<Lead>
{
    public void Configure(EntityTypeBuilder<Lead> builder)
    {
        builder.ToTable("Leads");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.FullName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.PhoneNumber)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(30);
        builder.Property(x => x.Suburb)
            .IsRequired()
            .HasMaxLength(500);
        builder.Property(x => x.Category)
            .IsRequired()
            .HasMaxLength(500);
        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(500);
        builder.Property(x => x.Price)
            .HasColumnType("decimal")
            .HasPrecision(18, 2)
            .IsRequired();
        builder.Property(x => x.CreateDate)
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Property(x => x.Status)
            .IsRequired();

        builder.Property(x => x.UpdateDate);

        builder.HasIndex(x => x.Email);
    }
}
