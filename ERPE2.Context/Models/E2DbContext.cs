using Microsoft.EntityFrameworkCore;

namespace ERPE2.Context.Models;

public class E2DbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Rol> Rols { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<CaseType> CaseTypes { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Case> Cases { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=ERPE2;Username=postgres;Password=admin2");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            entity.Property(e => e.Email)
                .IsRequired();
            entity.HasIndex(e => e.Email)
                .IsUnique();
            entity.Property(e => e.Password);
            entity.HasOne<Rol>(u => u.RolNavigation)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RolId);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            entity.Property(e => e.Name);
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            entity.Property(e => e.Name);
        });
        
        modelBuilder.Entity<CaseType>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            entity.Property(e => e.Name);
        });
        
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            entity.Property(e => e.Name);
        });
        
        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            entity.Property(e => e.Name);
            entity.HasOne<Brand>(m => m.BrandNavigation)
                .WithOne()
                .HasForeignKey<Model>(m => m.BrandId);
        });

        modelBuilder.Entity<Case>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            entity.Property(e => e.Stock);
            entity.HasOne<Model>(c => c.ModelNavigation)
                .WithOne()
                .HasForeignKey<Case>(c => c.ModelId);
            entity.HasOne<Color>(c => c.ColorNavigation)
                .WithOne()
                .HasForeignKey<Case>(c => c.ColorId);
            entity.HasOne<CaseType>(c => c.CaseTyepeNavigation)
                .WithOne()
                .HasForeignKey<Case>(c => c.CaseTypeId);
        });

    }
}