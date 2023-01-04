using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SGRM.Models;

namespace SGRM.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // One to One (IdentityUser - Directeur)
        modelBuilder.Entity<IdentityUser>()
            .HasOne<Directeur>()
            .WithOne()
            .HasForeignKey<Directeur>(dir => dir.IdentityUserId);

        // One to One (IdentityUser - Enseignant)
        modelBuilder.Entity<IdentityUser>()
            .HasOne<Enseignant>()
            .WithOne()
            .HasForeignKey<Enseignant>(e => e.IdentityUserId);

        // One to One (Directeur - Departement)
        modelBuilder.Entity<Departement>()
            .HasOne<Directeur>(dept => dept.Directeur)
            .WithOne(dir => dir.Departement)
            .HasForeignKey<Directeur>(dir => dir.DepartementId);

        // One to Many (Departement - Enseignants)
        modelBuilder.Entity<Departement>()
            .HasMany(dept => dept.Enseignants)
            .WithOne(e => e.Departement)
            .HasForeignKey(e => e.DepartementId);

        // One to Many (Departement - Laboratoire)
        modelBuilder.Entity<Departement>()
            .HasMany(dept => dept.Laboratoires)
            .WithOne(lab => lab.Departement)
            .HasForeignKey(lab => lab.DepartementId);

        // Many to Many (Enseignant - Laboratoire)
        modelBuilder.Entity<Enseignant>()
            .HasMany(e => e.Laboratoires)
            .WithMany(lab => lab.Enseignants)
            .UsingEntity(j => j.ToTable("AssociationEnseignantsLaboratoires"));

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Departement> Departements { get; set; }
    public DbSet<Directeur> Directeurs { get; set; }
    public DbSet<Enseignant> Enseignants { get; set; }
    public DbSet<Laboratoire> Laboratoires { get; set; }
}
