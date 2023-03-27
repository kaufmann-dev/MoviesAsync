using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Model.Configurations;

public class ImdbContext : DbContext
{
    public DbSet<Movie>? Movie { get; set; }
        
    public ImdbContext(DbContextOptions<ImdbContext> options) : base(options) {
            
    }

    protected override void OnModelCreating(ModelBuilder builder) {
        builder.Entity<Movie>()
            .HasIndex(m => m.Name)
            .IsUnique();
    }
}