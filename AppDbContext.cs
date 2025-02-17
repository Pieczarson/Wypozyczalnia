using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Review> Reviews { get; set; }  // ✅ Dodaj brakującą tabelę Review

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityUserRole<string>>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

        modelBuilder.Entity<IdentityUserLogin<string>>()
            .HasKey(ul => new { ul.LoginProvider, ul.ProviderKey });

        modelBuilder.Entity<IdentityUserToken<string>>()
            .HasKey(ut => new { ut.UserId, ut.LoginProvider, ut.Name });

        modelBuilder.Entity<Car>()
            .Property(c => c.DailyRate)
            .HasColumnType("REAL");
    }
}
