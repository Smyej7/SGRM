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

        // One to One (IdentityUser - PersonnelDepartement)
        modelBuilder.Entity<IdentityUser>()
            .HasOne<PersonnelDepartement>()
            .WithOne()
            .HasForeignKey<PersonnelDepartement>(e => e.IdentityUserId);

        // One to One (IdentityUser - Maintenance)
        modelBuilder.Entity<IdentityUser>()
            .HasOne<Maintenance>()
            .WithOne()
            .HasForeignKey<Maintenance>(e => e.IdentityUserId);

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

        // One to Many (Departement - PersonnelDepartement)
        modelBuilder.Entity<Departement>()
            .HasMany(dept => dept.PersonnelDepartements)
            .WithOne(persoDept => persoDept.Departement)
            .HasForeignKey(persoDept => persoDept.DepartementId);

        // One to Many (Departement - Maintenance)
        modelBuilder.Entity<Departement>()
            .HasMany(dept => dept.Maintenances)
            .WithOne(m => m.Departement)
            .HasForeignKey(m => m.DepartementId);

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
        
        // One to Many (Fournisseur - Livraison)
        modelBuilder.Entity<Fournisseur>()
            .HasMany(f => f.Livraisons)
            .WithOne(l => l.Fournisseur)
            .HasForeignKey(l => l.FournisseurId);

        // One to Many (Livraison - Ressource)
        modelBuilder.Entity<Livraison>()
            .HasMany(l => l.Ressources)
            .WithOne(r => r.Livraison)
            .HasForeignKey(r => r.LivraisonId);

        // One to One (IdentityUser - Ressource)
        modelBuilder.Entity<IdentityUser>()
            .HasOne<Ressource>()
            .WithOne()
            .HasForeignKey<Ressource>(r => r.IdentityUserId);

        // One to One (Ressource - Imprimante)
        modelBuilder.Entity<Ressource>()
            .HasOne<Imprimante>()
            .WithOne()
            .HasForeignKey<Imprimante>(i => i.RessourceId);

        // One to One (Ressource - Ordinateur)
        modelBuilder.Entity<Ressource>()
            .HasOne<Ordinateur>()
            .WithOne()
            .HasForeignKey<Ordinateur>(o => o.RessourceId);

        // One to Many (TypeRessource - Ressource)
        modelBuilder.Entity<TypeRessource>()
            .HasMany(tr => tr.Ressources)
            .WithOne(r => r.TypeRessource)
            .HasForeignKey(r => r.TypeRessourceId);

        // One to Many (Ressource - Panne)
        modelBuilder.Entity<Ressource>()
            .HasMany(r => r.Pannes)
            .WithOne(p => p.Ressource)
            .HasForeignKey(p => p.RessourceId);

        // One to One (TypeRessource - Ordinateur)
        modelBuilder.Entity<TypeRessource>()
            .HasOne<Ordinateur>()
            .WithOne()
            .HasForeignKey<Ordinateur>(o => o.TypeRessourceId);

        // One to One (TypeRessource - Imprimante)
        modelBuilder.Entity<TypeRessource>()
            .HasOne<Imprimante>()
            .WithOne()
            .HasForeignKey<Imprimante>(i => i.TypeRessourceId);

        // Many to Many (TypeRessource - TypePanne)
        modelBuilder.Entity<TypeRessource>()
            .HasMany(tr => tr.TypePannes)
            .WithMany(tp => tp.TypeRessources)
            .UsingEntity(j => j.ToTable("AssociationTypeRessourcesTypePannes"));
        
        /*
        // Many to Many (Enseignant - Laboratoire) method 1
        modelBuilder.Entity<AssociationEnseignantsLaboratoires>()
            .HasKey(pk => new { pk.EnseignantId, pk.LaboratoireId });

        modelBuilder.Entity<AssociationEnseignantsLaboratoires>()
            .HasOne(el => el.Enseignant)
            .WithMany(e => e.AssociationEnseignantsLaboratoires)
            .HasForeignKey(el => el.EnseignantId);

        modelBuilder.Entity<AssociationEnseignantsLaboratoires>()
            .HasOne(el => el.Laboratoire)
            .WithMany(l => l.AssociationEnseignantsLaboratoires)
            .HasForeignKey(el => el.LaboratoireId);
        */

        modelBuilder.Entity<Departement>().HasIndex(c => c.Name).IsUnique();
        modelBuilder.Entity<Directeur>().HasIndex(c => c.Name).IsUnique();
        modelBuilder.Entity<Enseignant>().HasIndex(c => c.Name).IsUnique();
        modelBuilder.Entity<Laboratoire>().HasIndex(c => c.Name).IsUnique();
        
        modelBuilder.Entity<Ressource>().HasIndex(c => c.Name).IsUnique();
        modelBuilder.Entity<Imprimante>().HasIndex(c => c.Name).IsUnique();
        modelBuilder.Entity<Ordinateur>().HasIndex(c => c.Name).IsUnique();
        modelBuilder.Entity<Panne>().HasIndex(c => c.Name).IsUnique();
        modelBuilder.Entity<TypePanne>().HasIndex(c => c.Name).IsUnique();
        modelBuilder.Entity<TypeRessource>().HasIndex(c => c.Name).IsUnique();
        modelBuilder.Entity<Livraison>().HasIndex(c => c.Name).IsUnique();
        modelBuilder.Entity<Fournisseur>().HasIndex(c => c.Name).IsUnique();
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Departement> Departements { get; set; }
    public DbSet<Directeur> Directeurs { get; set; }
    public DbSet<Enseignant> Enseignants { get; set; }
    public DbSet<Laboratoire> Laboratoires { get; set; }
    
    public DbSet<Ressource> Ressources { get; set; }
    public DbSet<Imprimante> Imprimantes { get; set; }
    public DbSet<Ordinateur> Ordinateurs { get; set; }
    public DbSet<Panne> Pannes { get; set; }
    public DbSet<TypePanne> TypePannes { get; set; }
    public DbSet<TypeRessource> TypeRessources { get; set; }
    public DbSet<Livraison> Livraisons { get; set; }
    public DbSet<Fournisseur> Fournisseurs { get; set; }
}
