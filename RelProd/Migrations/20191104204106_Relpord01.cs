using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RelProd.Migrations
{
    public partial class Relpord01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Senha = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    ChamadosId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chamados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<int>(nullable: false),
                    Setor = table.Column<string>(nullable: true),
                    UsuarioIdId = table.Column<int>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    Hora = table.Column<DateTime>(nullable: false),
                    Solicitante = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chamados_Usuarios_UsuarioIdId",
                        column: x => x.UsuarioIdId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_UsuarioIdId",
                table: "Chamados",
                column: "UsuarioIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ChamadosId",
                table: "Usuarios",
                column: "ChamadosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Chamados_ChamadosId",
                table: "Usuarios",
                column: "ChamadosId",
                principalTable: "Chamados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Usuarios_UsuarioIdId",
                table: "Chamados");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Chamados");
        }
    }
}
