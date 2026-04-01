using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InfraStructure.Migrations
{
    /// <inheritdoc />
    public partial class HorarioDisponibilidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartaoValidade",
                table: "Tecnicos");

            migrationBuilder.DropColumn(
                name: "CartaoValidade",
                table: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "AnoExpiracao",
                table: "Tecnicos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FormaPagamento_Cartao_CardId",
                table: "Tecnicos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FormaPagamento_Cartao_CustomerId",
                table: "Tecnicos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MesExpiracao",
                table: "Tecnicos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnoExpiracao",
                table: "Clientes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FormaPagamento_Cartao_CardId",
                table: "Clientes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FormaPagamento_Cartao_CustomerId",
                table: "Clientes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MesExpiracao",
                table: "Clientes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TecnicoHorariosDisponibilidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Dia = table.Column<int>(type: "integer", nullable: false),
                    Inicio = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    Fim = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    TecnicoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TecnicoHorariosDisponibilidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TecnicoHorariosDisponibilidade_Tecnicos_TecnicoId",
                        column: x => x.TecnicoId,
                        principalTable: "Tecnicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TecnicoHorariosDisponibilidade_TecnicoId",
                table: "TecnicoHorariosDisponibilidade",
                column: "TecnicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TecnicoHorariosDisponibilidade");

            migrationBuilder.DropColumn(
                name: "AnoExpiracao",
                table: "Tecnicos");

            migrationBuilder.DropColumn(
                name: "FormaPagamento_Cartao_CardId",
                table: "Tecnicos");

            migrationBuilder.DropColumn(
                name: "FormaPagamento_Cartao_CustomerId",
                table: "Tecnicos");

            migrationBuilder.DropColumn(
                name: "MesExpiracao",
                table: "Tecnicos");

            migrationBuilder.DropColumn(
                name: "AnoExpiracao",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "FormaPagamento_Cartao_CardId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "FormaPagamento_Cartao_CustomerId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "MesExpiracao",
                table: "Clientes");

            migrationBuilder.AddColumn<DateTime>(
                name: "CartaoValidade",
                table: "Tecnicos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CartaoValidade",
                table: "Clientes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
