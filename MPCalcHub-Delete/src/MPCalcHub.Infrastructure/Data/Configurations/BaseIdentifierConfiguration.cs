using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MPCalcHub.Domain.Entities.Interfaces;

namespace MPCalcHub.Infrastructure.Data.Configurations;

public abstract class BaseIdentifierConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class, IIdentifier
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property<Guid>("Id")
                .ValueGeneratedNever()
                .IsRequired();
    }
}