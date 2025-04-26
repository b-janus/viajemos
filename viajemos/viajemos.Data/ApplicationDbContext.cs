using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using viajemos.Data.Models.TripProposition;

namespace viajemos.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<TripPropositionPlace>(tpp =>
        {
            tpp.HasKey(t => t.Id);
            tpp.Property(t => t.Name).HasMaxLength(100).IsRequired();
            tpp.HasIndex(t => t.Name);
        });

        builder.Entity<TripProposition>(tp =>
        {
            tp.HasKey(t => t.Id);
            tp.Property(t => t.Name).HasMaxLength(100).IsRequired();
            tp.Property(t => t.Description).HasMaxLength(500).IsRequired();
            tp.Property(t => t.ImageUrl).HasMaxLength(200);
            tp.HasOne(t => t.Owner).WithMany().HasForeignKey(t => t.OwnerId).IsRequired();
            tp.HasMany(t => t.Places).WithOne();
            tp.HasIndex(t => new { t.StartDate, t.EndDate });
        });
    }
}