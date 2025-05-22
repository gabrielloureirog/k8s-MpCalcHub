using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MPCalcHub.Domain.Entities;
using MPCalcHub.Domain.Enums;

namespace MPCalcHub.Infrastructure.Data.Configurations;

public class ContactConfiguration : BaseEntityConfiguration<Contact>
{
    public override void Configure(EntityTypeBuilder<Contact> builder)
    {
        base.Configure(builder);

        builder.ToTable("Contact");

        builder.Property(u => u.Name).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(150);
        builder.Property(u => u.DDD).IsRequired(true);
        builder.Property(u => u.PhoneNumber).IsRequired(false).HasMaxLength(9);
    }
}