using Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Core;

internal class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
        
    }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Database Source=localhost;Initial Catalog=Diagonstyka;Trusted_Connection=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemEntity>()
            .HasOne<ColorEntity>(s => s.Color)
            .WithMany(g => g.Items);

        modelBuilder.Entity<ItemEntity>()
            .Property(ie => ie.Code).HasMaxLength(12);
        
        modelBuilder.Entity<ItemEntity>()
            .Property(ie => ie.Name).HasMaxLength(200);
            
        modelBuilder.Entity<ItemEntity>()
            .Property(ie => ie.Notes).HasMaxLength(1000);
        
        modelBuilder.Entity<ColorEntity>()
            .Property(ie => ie.Color).HasMaxLength(25);
    }

    public DbSet<ColorEntity> Colors { get; set; }
    public DbSet<ItemEntity> Items { get; set; }
}