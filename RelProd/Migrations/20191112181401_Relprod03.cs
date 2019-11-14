using Microsoft.EntityFrameworkCore.Migrations;

namespace RelProd.Migrations
{
    public partial class Relprod03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Usuarios_UsuarioId",
                table: "Chamados");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Chamados_ChamadosId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_ChamadosId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ChamadosId",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Chamados",
                newName: "ResponsavelId");

            migrationBuilder.RenameIndex(
                name: "IX_Chamados_UsuarioId",
                table: "Chamados",
                newName: "IX_Chamados_ResponsavelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Usuarios_ResponsavelId",
                table: "Chamados",
                column: "ResponsavelId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Usuarios_ResponsavelId",
                table: "Chamados");

            migrationBuilder.RenameColumn(
                name: "ResponsavelId",
                table: "Chamados",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Chamados_ResponsavelId",
                table: "Chamados",
                newName: "IX_Chamados_UsuarioId");

            migrationBuilder.AddColumn<int>(
                name: "ChamadosId",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ChamadosId",
                table: "Usuarios",
                column: "ChamadosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Usuarios_UsuarioId",
                table: "Chamados",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Chamados_ChamadosId",
                table: "Usuarios",
                column: "ChamadosId",
                principalTable: "Chamados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
