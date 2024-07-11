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
    public class NotificationConfiguration : IEntityTypeConfiguration<Notifition>
    {
        public void Configure(EntityTypeBuilder<Notifition> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Buyer)
                .WithOne(x => x.Notifition)
                .HasForeignKey<Notifition>(x => x.BuyerId);
        }
    }
}
