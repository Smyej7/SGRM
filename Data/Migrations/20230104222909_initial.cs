using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGRM.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departements",
                columns: table => new
                {
                    DepartementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departements", x => x.DepartementId);
                });

            migrationBuilder.CreateTable(
                name: "Directeurs",
                columns: table => new
                {
                    DirecteurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratoires", x => x.LaboratoireId);
                    table.ForeignKey(
                        name: "FK_Laboratoires_Departements_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departements",
                        principalColumn: "DepartementId");
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

            migrationBuilder.CreateIndex(
                name: "IX_AssociationEnseignantsLaboratoires_LaboratoiresLaboratoireId",
                table: "AssociationEnseignantsLaboratoires",
                column: "LaboratoiresLaboratoireId");

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
                name: "IX_Laboratoires_DepartementId",
                table: "Laboratoires",
                column: "DepartementId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssociationEnseignantsLaboratoires");

            migrationBuilder.DropTable(
                name: "Directeurs");

            migrationBuilder.DropTable(
                name: "Enseignants");

            migrationBuilder.DropTable(
                name: "Laboratoires");

            migrationBuilder.DropTable(
                name: "Departements");
        }
    }
}
