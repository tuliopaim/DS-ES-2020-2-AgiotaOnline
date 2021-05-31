using Microsoft.EntityFrameworkCore.Migrations;

namespace EO.Infra.Migrations
{
    public partial class AlteraColunaUsuarioId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Users_UserId",
                table: "Fornecedores");

            migrationBuilder.DropForeignKey(
                name: "FK_Tomadores_Users_UserId",
                table: "Tomadores");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tomadores",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Tomadores_UserId",
                table: "Tomadores",
                newName: "IX_Tomadores_UsuarioId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Fornecedores",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Fornecedores_UserId",
                table: "Fornecedores",
                newName: "IX_Fornecedores_UsuarioId");

            migrationBuilder.AlterColumn<string>(
                name: "ChavePix",
                table: "Users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Enderecos",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Users_UsuarioId",
                table: "Fornecedores",
                column: "UsuarioId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tomadores_Users_UsuarioId",
                table: "Tomadores",
                column: "UsuarioId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedores_Users_UsuarioId",
                table: "Fornecedores");

            migrationBuilder.DropForeignKey(
                name: "FK_Tomadores_Users_UsuarioId",
                table: "Tomadores");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Tomadores",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tomadores_UsuarioId",
                table: "Tomadores",
                newName: "IX_Tomadores_UserId");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Fornecedores",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Fornecedores_UsuarioId",
                table: "Fornecedores",
                newName: "IX_Fornecedores_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "ChavePix",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Enderecos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedores_Users_UserId",
                table: "Fornecedores",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tomadores_Users_UserId",
                table: "Tomadores",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
