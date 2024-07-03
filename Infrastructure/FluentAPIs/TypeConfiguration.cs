using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entitys;

namespace Infrastructures.FluentAPIs
{
    public class TypeConfiguration : IEntityTypeConfiguration<Domain.Entitys.Type>
    {
        public void Configure(EntityTypeBuilder<Domain.Entitys.Type> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasMany(x => x.Pets)
                .WithOne(x => x.Type);
        }
    }
}
