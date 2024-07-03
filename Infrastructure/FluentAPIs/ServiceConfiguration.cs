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
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.ServiceProvider)
                .WithMany(x => x.Services)
                .HasForeignKey(x => x.serviceProviderId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.BookingDetail)
                .WithOne(x => x.Service).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
