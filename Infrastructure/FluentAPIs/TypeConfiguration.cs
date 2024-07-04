using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entitys;

namespace Infrastructures.FluentAPIs
{
    public class TypeConfiguration : IEntityTypeConfiguration<Domain.Entitys.Type>, IEntityTypeConfiguration<Kind>
    {
        public void Configure(EntityTypeBuilder<Domain.Entitys.Type> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasMany(x => x.PostPets)
                .WithOne(x => x.Type);

            builder.HasOne(x => x.Kind)
                .WithMany(x => x.Types)
                .HasForeignKey(x => x.KindId);
        }

        public void Configure(EntityTypeBuilder<Kind> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasMany(x => x.Types)
                .WithOne(x => x.Kind);
        }
    }
}
