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
    public class MeetConfiguration : IEntityTypeConfiguration<Meet>
    {
        public void Configure(EntityTypeBuilder<Meet> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Buyer)
                .WithMany(x => x.Meets)
                .HasForeignKey(x => x.BuyerID);

            builder.HasOne(x => x.PostPet)
                .WithMany(x => x.Meets)
                .HasForeignKey(x => x.PostPetID);

        }
    }
}
