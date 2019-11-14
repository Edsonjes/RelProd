using Microsoft.EntityFrameworkCore.Migrations;

namespace RelProd.Migrations
{
    public partial class Relprod02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Usuarios_UsuarioIdId",
                table: "Chamados");

            migrationBuilder.RenameColumn(
                name: "UsuarioIdId",
                table: "Chamados",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Chamados_UsuarioIdId",
                table: "Chamados",
                newName: "IX_Chamados_UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Usuarios_UsuarioId",
                table: "Chamados",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Usuarios_UsuarioId",
                table: "Chamados");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Chamados",
                newName: "UsuarioIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Chamados_UsuarioId",
                table: "Chamados",
                newName: "IX_Chamados_UsuarioIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Usuarios_UsuarioIdId",
                table: "Chamados",
                column: "UsuarioIdId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
