using PISSolution.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Numerics;


namespace PISSolution.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Ownership> Ownerships { get; set; }
        public DbSet<PriceHistory> PriceHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seeding model
            DataSeeder.SeedContacts(modelBuilder);
            DataSeeder.SeedProperties(modelBuilder);
            DataSeeder.SeedPriceHistories(modelBuilder);
            DataSeeder.SeedOwnerships(modelBuilder);
            //relationships
            modelBuilder.Entity<Property>()
               .HasMany(p => p.Ownerships)               
               .WithOne(o => o.Property)
               .HasForeignKey(o => o.PropertyID);

            modelBuilder.Entity<Property>()
                .HasMany(p => p.PriceHistories)
                .WithOne(ph => ph.Property)
                .HasForeignKey(ph => ph.PropertyID);

            modelBuilder.Entity<Contact>()
                .HasMany(c => c.Ownerships)
                .WithOne(o => o.Contact)
                .HasForeignKey(o => o.ContactID);
            
            base.OnModelCreating(modelBuilder);           
           
            
        }
    }
}
