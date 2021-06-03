using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EO.Infra.Migrations
{
    public partial class AdicionaSolicitacaoEmprestimo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "RendaMensal",
                table: "Tomadores",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Capital",
                table: "Fornecedores",
                type: "numeric(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldMaxLength: 11);

            migrationBuilder.CreateTable(
                name: "SolicitacaoEmprestimo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Valor = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Parcelas = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    TomadorId = table.Column<int>(type: "integer", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitacaoEmprestimo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitacaoEmprestimo_Tomadores_TomadorId",
                        column: x => x.TomadorId,
                        principalTable: "Tomadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoEmprestimo_TomadorId",
                table: "SolicitacaoEmprestimo",
                column: "TomadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolicitacaoEmprestimo");

            migrationBuilder.AlterColumn<decimal>(
                name: "RendaMensal",
                table: "Tomadores",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Capital",
                table: "Fornecedores",
                type: "numeric",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)");
        }
    }
}
