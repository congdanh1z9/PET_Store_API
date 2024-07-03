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
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Pets)
                .HasForeignKey(x => x.userId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Bookings)
                .WithOne(x => x.Pet).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Type)
                .WithMany(x => x.Pets)
                .HasForeignKey(x => x.typeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
