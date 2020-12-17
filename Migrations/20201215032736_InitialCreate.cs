using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VacantesApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carreras",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCarrera = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Actualizado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carreras", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreHabilidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    CarreraID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Habilidades_Carreras_CarreraID",
                        column: x => x.CarreraID,
                        principalTable: "Carreras",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vacantes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCarrera = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Salario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Habilidades = table.Column<string>(type: "text", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experiencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Actualizado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarreraID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacantes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vacantes_Carreras_CarreraID",
                        column: x => x.CarreraID,
                        principalTable: "Carreras",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VacanteID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Candidatos_Vacantes_VacanteID",
                        column: x => x.VacanteID,
                        principalTable: "Vacantes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_VacanteID",
                table: "Candidatos",
                column: "VacanteID");

            migrationBuilder.CreateIndex(
                name: "IX_Habilidades_CarreraID",
                table: "Habilidades",
                column: "CarreraID");

            migrationBuilder.CreateIndex(
                name: "IX_Vacantes_CarreraID",
                table: "Vacantes",
                column: "CarreraID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidatos");

            migrationBuilder.DropTable(
                name: "Habilidades");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Vacantes");

            migrationBuilder.DropTable(
                name: "Carreras");
        }
    }
}
