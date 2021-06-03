using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EO.Infra.Migrations
{
    public partial class TomadorId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoEmprestimo_Tomadores_TomadorId",
                table: "SolicitacaoEmprestimo");

            migrationBuilder.DropIndex(
                name: "IX_SolicitacaoEmprestimo_TomadorId",
                table: "SolicitacaoEmprestimo");

            migrationBuilder.AlterColumn<Guid>(
                name: "TomadorId",
                table: "SolicitacaoEmprestimo",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TomadorId1",
                table: "SolicitacaoEmprestimo",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoEmprestimo_TomadorId1",
                table: "SolicitacaoEmprestimo",
                column: "TomadorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoEmprestimo_Tomadores_TomadorId1",
                table: "SolicitacaoEmprestimo",
                column: "TomadorId1",
                principalTable: "Tomadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoEmprestimo_Tomadores_TomadorId1",
                table: "SolicitacaoEmprestimo");

            migrationBuilder.DropIndex(
                name: "IX_SolicitacaoEmprestimo_TomadorId1",
                table: "SolicitacaoEmprestimo");

            migrationBuilder.DropColumn(
                name: "TomadorId1",
                table: "SolicitacaoEmprestimo");

            migrationBuilder.AlterColumn<int>(
                name: "TomadorId",
                table: "SolicitacaoEmprestimo",
                type: "integer",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoEmprestimo_TomadorId",
                table: "SolicitacaoEmprestimo",
                column: "TomadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoEmprestimo_Tomadores_TomadorId",
                table: "SolicitacaoEmprestimo",
                column: "TomadorId",
                principalTable: "Tomadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
