using Domain.Entitys;
using Infrastructures.FluentAPIs;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<BussinessPlan> BussinessPlans { get; set; }
        public DbSet<Domain.Entitys.Type> Types { get; set; }
        public DbSet<Kind> Kinds { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<PostPet> PostPets { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new PostPetConfiguration());
            modelBuilder.ApplyConfiguration(new BuyerConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
