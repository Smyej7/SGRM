using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGRM.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departements",
                columns: table => new
                {
                    DepartementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departements", x => x.DepartementId);
                });

            migrationBuilder.CreateTable(
                name: "Fournisseurs",
                columns: table => new
                {
                    FournisseurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseurs", x => x.FournisseurId);
                });

            migrationBuilder.CreateTable(
                name: "TypePannes",
                columns: table => new
                {
                    TypePanneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePannes", x => x.TypePanneId);
                });

            migrationBuilder.CreateTable(
                name: "TypeRessources",
                columns: table => new
                {
                    TypeRessourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeRessources", x => x.TypeRessourceId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Directeurs",
                columns: table => new
                {
                    DirecteurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartementId = table.Column<int>(type: "int", nullable: true),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directeurs", x => x.DirecteurId);
                    table.ForeignKey(
                        name: "FK_Directeurs_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Directeurs_Departements_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departements",
                        principalColumn: "DepartementId");
                });

            migrationBuilder.CreateTable(
                name: "Enseignants",
                columns: table => new
                {
                    EnseignantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartementId = table.Column<int>(type: "int", nullable: true),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignants", x => x.EnseignantId);
                    table.ForeignKey(
                        name: "FK_Enseignants_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enseignants_Departements_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departements",
                        principalColumn: "DepartementId");
                });

            migrationBuilder.CreateTable(
                name: "Laboratoires",
                columns: table => new
                {
                    LaboratoireId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratoires", x => x.LaboratoireId);
                    table.ForeignKey(
                        name: "FK_Laboratoires_Departements_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departements",
                        principalColumn: "DepartementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maintenance",
                columns: table => new
                {
                    MaintenanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartementId = table.Column<int>(type: "int", nullable: true),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenance", x => x.MaintenanceId);
                    table.ForeignKey(
                        name: "FK_Maintenance_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Maintenance_Departements_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departements",
                        principalColumn: "DepartementId");
                });

            migrationBuilder.CreateTable(
                name: "PersonnelDepartement",
                columns: table => new
                {
                    PersonnelDepartementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartementId = table.Column<int>(type: "int", nullable: true),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnelDepartement", x => x.PersonnelDepartementId);
                    table.ForeignKey(
                        name: "FK_PersonnelDepartement_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonnelDepartement_Departements_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departements",
                        principalColumn: "DepartementId");
                });

            migrationBuilder.CreateTable(
                name: "Livraisons",
                columns: table => new
                {
                    LivraisonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FournisseurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livraisons", x => x.LivraisonId);
                    table.ForeignKey(
                        name: "FK_Livraisons_Fournisseurs_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "Fournisseurs",
                        principalColumn: "FournisseurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssociationTypeRessourcesTypePannes",
                columns: table => new
                {
                    TypePannesTypePanneId = table.Column<int>(type: "int", nullable: false),
                    TypeRessourcesTypeRessourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociationTypeRessourcesTypePannes", x => new { x.TypePannesTypePanneId, x.TypeRessourcesTypeRessourceId });
                    table.ForeignKey(
                        name: "FK_AssociationTypeRessourcesTypePannes_TypePannes_TypePannesTypePanneId",
                        column: x => x.TypePannesTypePanneId,
                        principalTable: "TypePannes",
                        principalColumn: "TypePanneId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssociationTypeRessourcesTypePannes_TypeRessources_TypeRessourcesTypeRessourceId",
                        column: x => x.TypeRessourcesTypeRessourceId,
                        principalTable: "TypeRessources",
                        principalColumn: "TypeRessourceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssociationEnseignantsLaboratoires",
                columns: table => new
                {
                    EnseignantsEnseignantId = table.Column<int>(type: "int", nullable: false),
                    LaboratoiresLaboratoireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociationEnseignantsLaboratoires", x => new { x.EnseignantsEnseignantId, x.LaboratoiresLaboratoireId });
                    table.ForeignKey(
                        name: "FK_AssociationEnseignantsLaboratoires_Enseignants_EnseignantsEnseignantId",
                        column: x => x.EnseignantsEnseignantId,
                        principalTable: "Enseignants",
                        principalColumn: "EnseignantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssociationEnseignantsLaboratoires_Laboratoires_LaboratoiresLaboratoireId",
                        column: x => x.LaboratoiresLaboratoireId,
                        principalTable: "Laboratoires",
                        principalColumn: "LaboratoireId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ressources",
                columns: table => new
                {
                    RessourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LivraisonId = table.Column<int>(type: "int", nullable: false),
                    TypeRessourceId = table.Column<int>(type: "int", nullable: false),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ressources", x => x.RessourceId);
                    table.ForeignKey(
                        name: "FK_Ressources_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ressources_Livraisons_LivraisonId",
                        column: x => x.LivraisonId,
                        principalTable: "Livraisons",
                        principalColumn: "LivraisonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ressources_TypeRessources_TypeRessourceId",
                        column: x => x.TypeRessourceId,
                        principalTable: "TypeRessources",
                        principalColumn: "TypeRessourceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imprimantes",
                columns: table => new
                {
                    ImprimanteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RessourceId = table.Column<int>(type: "int", nullable: false),
                    RessourceId1 = table.Column<int>(type: "int", nullable: true),
                    TypeRessourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imprimantes", x => x.ImprimanteId);
                    table.ForeignKey(
                        name: "FK_Imprimantes_Ressources_RessourceId",
                        column: x => x.RessourceId,
                        principalTable: "Ressources",
                        principalColumn: "RessourceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Imprimantes_Ressources_RessourceId1",
                        column: x => x.RessourceId1,
                        principalTable: "Ressources",
                        principalColumn: "RessourceId");
                    table.ForeignKey(
                        name: "FK_Imprimantes_TypeRessources_TypeRessourceId",
                        column: x => x.TypeRessourceId,
                        principalTable: "TypeRessources",
                        principalColumn: "TypeRessourceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ordinateurs",
                columns: table => new
                {
                    OrdinateurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RessourceId = table.Column<int>(type: "int", nullable: false),
                    RessourceId1 = table.Column<int>(type: "int", nullable: true),
                    TypeRessourceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordinateurs", x => x.OrdinateurId);
                    table.ForeignKey(
                        name: "FK_Ordinateurs_Ressources_RessourceId",
                        column: x => x.RessourceId,
                        principalTable: "Ressources",
                        principalColumn: "RessourceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ordinateurs_Ressources_RessourceId1",
                        column: x => x.RessourceId1,
                        principalTable: "Ressources",
                        principalColumn: "RessourceId");
                    table.ForeignKey(
                        name: "FK_Ordinateurs_TypeRessources_TypeRessourceId",
                        column: x => x.TypeRessourceId,
                        principalTable: "TypeRessources",
                        principalColumn: "TypeRessourceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pannes",
                columns: table => new
                {
                    PanneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RessourceId = table.Column<int>(type: "int", nullable: false),
                    TypePanneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pannes", x => x.PanneId);
                    table.ForeignKey(
                        name: "FK_Pannes_Ressources_RessourceId",
                        column: x => x.RessourceId,
                        principalTable: "Ressources",
                        principalColumn: "RessourceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pannes_TypePannes_TypePanneId",
                        column: x => x.TypePanneId,
                        principalTable: "TypePannes",
                        principalColumn: "TypePanneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AssociationEnseignantsLaboratoires_LaboratoiresLaboratoireId",
                table: "AssociationEnseignantsLaboratoires",
                column: "LaboratoiresLaboratoireId");

            migrationBuilder.CreateIndex(
                name: "IX_AssociationTypeRessourcesTypePannes_TypeRessourcesTypeRessourceId",
                table: "AssociationTypeRessourcesTypePannes",
                column: "TypeRessourcesTypeRessourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Departements_Name",
                table: "Departements",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Directeurs_DepartementId",
                table: "Directeurs",
                column: "DepartementId",
                unique: true,
                filter: "[DepartementId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Directeurs_IdentityUserId",
                table: "Directeurs",
                column: "IdentityUserId",
                unique: true,
                filter: "[IdentityUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Directeurs_Name",
                table: "Directeurs",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enseignants_DepartementId",
                table: "Enseignants",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_Enseignants_IdentityUserId",
                table: "Enseignants",
                column: "IdentityUserId",
                unique: true,
                filter: "[IdentityUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Enseignants_Name",
                table: "Enseignants",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fournisseurs_Name",
                table: "Fournisseurs",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Imprimantes_Name",
                table: "Imprimantes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Imprimantes_RessourceId",
                table: "Imprimantes",
                column: "RessourceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Imprimantes_RessourceId1",
                table: "Imprimantes",
                column: "RessourceId1");

            migrationBuilder.CreateIndex(
                name: "IX_Imprimantes_TypeRessourceId",
                table: "Imprimantes",
                column: "TypeRessourceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Laboratoires_DepartementId",
                table: "Laboratoires",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_Laboratoires_Name",
                table: "Laboratoires",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Livraisons_FournisseurId",
                table: "Livraisons",
                column: "FournisseurId");

            migrationBuilder.CreateIndex(
                name: "IX_Livraisons_Name",
                table: "Livraisons",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_DepartementId",
                table: "Maintenance",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_IdentityUserId",
                table: "Maintenance",
                column: "IdentityUserId",
                unique: true,
                filter: "[IdentityUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ordinateurs_Name",
                table: "Ordinateurs",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ordinateurs_RessourceId",
                table: "Ordinateurs",
                column: "RessourceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ordinateurs_RessourceId1",
                table: "Ordinateurs",
                column: "RessourceId1");

            migrationBuilder.CreateIndex(
                name: "IX_Ordinateurs_TypeRessourceId",
                table: "Ordinateurs",
                column: "TypeRessourceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pannes_Name",
                table: "Pannes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pannes_RessourceId",
                table: "Pannes",
                column: "RessourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Pannes_TypePanneId",
                table: "Pannes",
                column: "TypePanneId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelDepartement_DepartementId",
                table: "PersonnelDepartement",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelDepartement_IdentityUserId",
                table: "PersonnelDepartement",
                column: "IdentityUserId",
                unique: true,
                filter: "[IdentityUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ressources_IdentityUserId",
                table: "Ressources",
                column: "IdentityUserId",
                unique: true,
                filter: "[IdentityUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ressources_LivraisonId",
                table: "Ressources",
                column: "LivraisonId");

            migrationBuilder.CreateIndex(
                name: "IX_Ressources_Name",
                table: "Ressources",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ressources_TypeRessourceId",
                table: "Ressources",
                column: "TypeRessourceId");

            migrationBuilder.CreateIndex(
                name: "IX_TypePannes_Name",
                table: "TypePannes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TypeRessources_Name",
                table: "TypeRessources",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AssociationEnseignantsLaboratoires");

            migrationBuilder.DropTable(
                name: "AssociationTypeRessourcesTypePannes");

            migrationBuilder.DropTable(
                name: "Directeurs");

            migrationBuilder.DropTable(
                name: "Imprimantes");

            migrationBuilder.DropTable(
                name: "Maintenance");

            migrationBuilder.DropTable(
                name: "Ordinateurs");

            migrationBuilder.DropTable(
                name: "Pannes");

            migrationBuilder.DropTable(
                name: "PersonnelDepartement");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Enseignants");

            migrationBuilder.DropTable(
                name: "Laboratoires");

            migrationBuilder.DropTable(
                name: "Ressources");

            migrationBuilder.DropTable(
                name: "TypePannes");

            migrationBuilder.DropTable(
                name: "Departements");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Livraisons");

            migrationBuilder.DropTable(
                name: "TypeRessources");

            migrationBuilder.DropTable(
                name: "Fournisseurs");
        }
    }
}
