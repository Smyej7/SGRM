// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGRM.Data;

#nullable disable

namespace SGRM.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230201025737_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EnseignantLaboratoire", b =>
                {
                    b.Property<int>("EnseignantsEnseignantId")
                        .HasColumnType("int");

                    b.Property<int>("LaboratoiresLaboratoireId")
                        .HasColumnType("int");

                    b.HasKey("EnseignantsEnseignantId", "LaboratoiresLaboratoireId");

                    b.HasIndex("LaboratoiresLaboratoireId");

                    b.ToTable("AssociationEnseignantsLaboratoires", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SGRM.Models.Departement", b =>
                {
                    b.Property<int>("DepartementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartementId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DepartementId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Departements");
                });

            modelBuilder.Entity("SGRM.Models.Directeur", b =>
                {
                    b.Property<int>("DirecteurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DirecteurId"), 1L, 1);

                    b.Property<int?>("DepartementId")
                        .HasColumnType("int");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DirecteurId");

                    b.HasIndex("DepartementId")
                        .IsUnique()
                        .HasFilter("[DepartementId] IS NOT NULL");

                    b.HasIndex("IdentityUserId")
                        .IsUnique()
                        .HasFilter("[IdentityUserId] IS NOT NULL");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Directeurs");
                });

            modelBuilder.Entity("SGRM.Models.Enseignant", b =>
                {
                    b.Property<int>("EnseignantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnseignantId"), 1L, 1);

                    b.Property<int?>("DepartementId")
                        .HasColumnType("int");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EnseignantId");

                    b.HasIndex("DepartementId");

                    b.HasIndex("IdentityUserId")
                        .IsUnique()
                        .HasFilter("[IdentityUserId] IS NOT NULL");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Enseignants");
                });

            modelBuilder.Entity("SGRM.Models.Fournisseur", b =>
                {
                    b.Property<int>("FournisseurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FournisseurId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FournisseurId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Fournisseurs");
                });

            modelBuilder.Entity("SGRM.Models.Imprimante", b =>
                {
                    b.Property<int>("ImprimanteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImprimanteId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RessourceId")
                        .HasColumnType("int");

                    b.Property<int?>("RessourceId1")
                        .HasColumnType("int");

                    b.Property<int>("TypeRessourceId")
                        .HasColumnType("int");

                    b.HasKey("ImprimanteId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("RessourceId")
                        .IsUnique();

                    b.HasIndex("RessourceId1");

                    b.HasIndex("TypeRessourceId")
                        .IsUnique();

                    b.ToTable("Imprimantes");
                });

            modelBuilder.Entity("SGRM.Models.Laboratoire", b =>
                {
                    b.Property<int>("LaboratoireId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LaboratoireId"), 1L, 1);

                    b.Property<int>("DepartementId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LaboratoireId");

                    b.HasIndex("DepartementId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Laboratoires");
                });

            modelBuilder.Entity("SGRM.Models.Livraison", b =>
                {
                    b.Property<int>("LivraisonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LivraisonId"), 1L, 1);

                    b.Property<int>("FournisseurId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LivraisonId");

                    b.HasIndex("FournisseurId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Livraisons");
                });

            modelBuilder.Entity("SGRM.Models.Maintenance", b =>
                {
                    b.Property<int>("MaintenanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaintenanceId"), 1L, 1);

                    b.Property<int?>("DepartementId")
                        .HasColumnType("int");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaintenanceId");

                    b.HasIndex("DepartementId");

                    b.HasIndex("IdentityUserId")
                        .IsUnique()
                        .HasFilter("[IdentityUserId] IS NOT NULL");

                    b.ToTable("Maintenance");
                });

            modelBuilder.Entity("SGRM.Models.Ordinateur", b =>
                {
                    b.Property<int>("OrdinateurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrdinateurId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RessourceId")
                        .HasColumnType("int");

                    b.Property<int?>("RessourceId1")
                        .HasColumnType("int");

                    b.Property<int>("TypeRessourceId")
                        .HasColumnType("int");

                    b.HasKey("OrdinateurId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("RessourceId")
                        .IsUnique();

                    b.HasIndex("RessourceId1");

                    b.HasIndex("TypeRessourceId")
                        .IsUnique();

                    b.ToTable("Ordinateurs");
                });

            modelBuilder.Entity("SGRM.Models.Panne", b =>
                {
                    b.Property<int>("PanneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PanneId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RessourceId")
                        .HasColumnType("int");

                    b.Property<int>("TypePanneId")
                        .HasColumnType("int");

                    b.HasKey("PanneId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("RessourceId");

                    b.HasIndex("TypePanneId");

                    b.ToTable("Pannes");
                });

            modelBuilder.Entity("SGRM.Models.PersonnelDepartement", b =>
                {
                    b.Property<int>("PersonnelDepartementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonnelDepartementId"), 1L, 1);

                    b.Property<int?>("DepartementId")
                        .HasColumnType("int");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonnelDepartementId");

                    b.HasIndex("DepartementId");

                    b.HasIndex("IdentityUserId")
                        .IsUnique()
                        .HasFilter("[IdentityUserId] IS NOT NULL");

                    b.ToTable("PersonnelDepartement");
                });

            modelBuilder.Entity("SGRM.Models.Ressource", b =>
                {
                    b.Property<int>("RessourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RessourceId"), 1L, 1);

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("LivraisonId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TypeRessourceId")
                        .HasColumnType("int");

                    b.HasKey("RessourceId");

                    b.HasIndex("IdentityUserId")
                        .IsUnique()
                        .HasFilter("[IdentityUserId] IS NOT NULL");

                    b.HasIndex("LivraisonId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("TypeRessourceId");

                    b.ToTable("Ressources");
                });

            modelBuilder.Entity("SGRM.Models.TypePanne", b =>
                {
                    b.Property<int>("TypePanneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypePanneId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TypePanneId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("TypePannes");
                });

            modelBuilder.Entity("SGRM.Models.TypeRessource", b =>
                {
                    b.Property<int>("TypeRessourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeRessourceId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TypeRessourceId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("TypeRessources");
                });

            modelBuilder.Entity("TypePanneTypeRessource", b =>
                {
                    b.Property<int>("TypePannesTypePanneId")
                        .HasColumnType("int");

                    b.Property<int>("TypeRessourcesTypeRessourceId")
                        .HasColumnType("int");

                    b.HasKey("TypePannesTypePanneId", "TypeRessourcesTypeRessourceId");

                    b.HasIndex("TypeRessourcesTypeRessourceId");

                    b.ToTable("AssociationTypeRessourcesTypePannes", (string)null);
                });

            modelBuilder.Entity("EnseignantLaboratoire", b =>
                {
                    b.HasOne("SGRM.Models.Enseignant", null)
                        .WithMany()
                        .HasForeignKey("EnseignantsEnseignantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGRM.Models.Laboratoire", null)
                        .WithMany()
                        .HasForeignKey("LaboratoiresLaboratoireId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SGRM.Models.Directeur", b =>
                {
                    b.HasOne("SGRM.Models.Departement", "Departement")
                        .WithOne("Directeur")
                        .HasForeignKey("SGRM.Models.Directeur", "DepartementId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithOne()
                        .HasForeignKey("SGRM.Models.Directeur", "IdentityUserId");

                    b.Navigation("Departement");
                });

            modelBuilder.Entity("SGRM.Models.Enseignant", b =>
                {
                    b.HasOne("SGRM.Models.Departement", "Departement")
                        .WithMany("Enseignants")
                        .HasForeignKey("DepartementId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithOne()
                        .HasForeignKey("SGRM.Models.Enseignant", "IdentityUserId");

                    b.Navigation("Departement");
                });

            modelBuilder.Entity("SGRM.Models.Imprimante", b =>
                {
                    b.HasOne("SGRM.Models.Ressource", null)
                        .WithOne()
                        .HasForeignKey("SGRM.Models.Imprimante", "RessourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGRM.Models.Ressource", "Ressource")
                        .WithMany()
                        .HasForeignKey("RessourceId1");

                    b.HasOne("SGRM.Models.TypeRessource", null)
                        .WithOne()
                        .HasForeignKey("SGRM.Models.Imprimante", "TypeRessourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ressource");
                });

            modelBuilder.Entity("SGRM.Models.Laboratoire", b =>
                {
                    b.HasOne("SGRM.Models.Departement", "Departement")
                        .WithMany("Laboratoires")
                        .HasForeignKey("DepartementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departement");
                });

            modelBuilder.Entity("SGRM.Models.Livraison", b =>
                {
                    b.HasOne("SGRM.Models.Fournisseur", "Fournisseur")
                        .WithMany("Livraisons")
                        .HasForeignKey("FournisseurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fournisseur");
                });

            modelBuilder.Entity("SGRM.Models.Maintenance", b =>
                {
                    b.HasOne("SGRM.Models.Departement", "Departement")
                        .WithMany("Maintenances")
                        .HasForeignKey("DepartementId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithOne()
                        .HasForeignKey("SGRM.Models.Maintenance", "IdentityUserId");

                    b.Navigation("Departement");
                });

            modelBuilder.Entity("SGRM.Models.Ordinateur", b =>
                {
                    b.HasOne("SGRM.Models.Ressource", null)
                        .WithOne()
                        .HasForeignKey("SGRM.Models.Ordinateur", "RessourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGRM.Models.Ressource", "Ressource")
                        .WithMany()
                        .HasForeignKey("RessourceId1");

                    b.HasOne("SGRM.Models.TypeRessource", null)
                        .WithOne()
                        .HasForeignKey("SGRM.Models.Ordinateur", "TypeRessourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ressource");
                });

            modelBuilder.Entity("SGRM.Models.Panne", b =>
                {
                    b.HasOne("SGRM.Models.Ressource", "Ressource")
                        .WithMany("Pannes")
                        .HasForeignKey("RessourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGRM.Models.TypePanne", null)
                        .WithMany("Pannes")
                        .HasForeignKey("TypePanneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ressource");
                });

            modelBuilder.Entity("SGRM.Models.PersonnelDepartement", b =>
                {
                    b.HasOne("SGRM.Models.Departement", "Departement")
                        .WithMany("PersonnelDepartements")
                        .HasForeignKey("DepartementId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithOne()
                        .HasForeignKey("SGRM.Models.PersonnelDepartement", "IdentityUserId");

                    b.Navigation("Departement");
                });

            modelBuilder.Entity("SGRM.Models.Ressource", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithOne()
                        .HasForeignKey("SGRM.Models.Ressource", "IdentityUserId");

                    b.HasOne("SGRM.Models.Livraison", "Livraison")
                        .WithMany("Ressources")
                        .HasForeignKey("LivraisonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGRM.Models.TypeRessource", "TypeRessource")
                        .WithMany("Ressources")
                        .HasForeignKey("TypeRessourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livraison");

                    b.Navigation("TypeRessource");
                });

            modelBuilder.Entity("TypePanneTypeRessource", b =>
                {
                    b.HasOne("SGRM.Models.TypePanne", null)
                        .WithMany()
                        .HasForeignKey("TypePannesTypePanneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGRM.Models.TypeRessource", null)
                        .WithMany()
                        .HasForeignKey("TypeRessourcesTypeRessourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SGRM.Models.Departement", b =>
                {
                    b.Navigation("Directeur");

                    b.Navigation("Enseignants");

                    b.Navigation("Laboratoires");

                    b.Navigation("Maintenances");

                    b.Navigation("PersonnelDepartements");
                });

            modelBuilder.Entity("SGRM.Models.Fournisseur", b =>
                {
                    b.Navigation("Livraisons");
                });

            modelBuilder.Entity("SGRM.Models.Livraison", b =>
                {
                    b.Navigation("Ressources");
                });

            modelBuilder.Entity("SGRM.Models.Ressource", b =>
                {
                    b.Navigation("Pannes");
                });

            modelBuilder.Entity("SGRM.Models.TypePanne", b =>
                {
                    b.Navigation("Pannes");
                });

            modelBuilder.Entity("SGRM.Models.TypeRessource", b =>
                {
                    b.Navigation("Ressources");
                });
#pragma warning restore 612, 618
        }
    }
}
