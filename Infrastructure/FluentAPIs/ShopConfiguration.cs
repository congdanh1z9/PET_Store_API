using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructures.FluentAPIs
{
    public class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Account)
                .WithOne(x => x.Shop)
                .HasForeignKey<Shop>(x => x.AccountId);

            builder.HasOne(x => x.BussinessPlan)
                .WithMany(x => x.Shops)
                .HasForeignKey(x => x.BusinessPlanId);

            builder.HasMany(x => x.PostPets)
                .WithOne(x => x.Shop);
        }
    }
}
