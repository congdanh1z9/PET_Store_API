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
    public class BussinessPlanConfiguration : IEntityTypeConfiguration<BussinessPlan>
    {
        public void Configure(EntityTypeBuilder<BussinessPlan> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasMany(x => x.Shops)
                .WithOne(x => x.BussinessPlan);
        }
    }
}
