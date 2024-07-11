using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.FluentAPIs
{
    public class PostPetConfiguration : IEntityTypeConfiguration<PostPet>
    {
        public void Configure(EntityTypeBuilder<PostPet> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Shop)
                .WithMany(x => x.PostPets)
                .HasForeignKey(x => x.ShopID);

            builder.HasMany(x => x.Images)
                .WithOne(x => x.PostPet);

            builder.HasOne(x => x.Type)
                .WithMany(x => x.PostPets)
                .HasForeignKey(x => x.TypeId);
        }
    }
}
