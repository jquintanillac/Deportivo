using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deportivo.Web.Migrations
{
    /// <inheritdoc />
    public partial class Pagos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "pagdet_total",
                table: "Pago_Detalle",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "id_client",
                table: "Pago_Cabecera",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "pagcab_tipo",
                table: "Pago_Cabecera",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Egresos",
                columns: table => new
                {
                    idegre = table.Column<int>(name: "id_egre", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    egredescr = table.Column<string>(name: "egre_descr", type: "nvarchar(max)", nullable: false),
                    egrecosto = table.Column<decimal>(name: "egre_costo", type: "decimal(18,2)", nullable: false),
                    egrefecha = table.Column<DateTime>(name: "egre_fecha", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egresos", x => x.idegre);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idhorario = table.Column<int>(name: "id_horario", type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Ingresos",
                columns: table => new
                {
                    idingre = table.Column<int>(name: "id_ingre", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ingredesc = table.Column<string>(name: "ingre_desc", type: "nvarchar(max)", nullable: false),
                    ingremonto = table.Column<decimal>(name: "ingre_monto", type: "decimal(18,2)", nullable: false),
                    ingrefecha = table.Column<DateTime>(name: "ingre_fecha", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingresos", x => x.idingre);
                });

            migrationBuilder.CreateTable(
                name: "Inicial",
                columns: table => new
                {
                    idini = table.Column<int>(name: "id_ini", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    inidesc = table.Column<string>(name: "ini_desc", type: "nvarchar(max)", nullable: false),
                    inimonto = table.Column<decimal>(name: "ini_monto", type: "decimal(18,2)", nullable: false),
                    inifecha = table.Column<DateTime>(name: "ini_fecha", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inicial", x => x.idini);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Egresos");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Ingresos");

            migrationBuilder.DropTable(
                name: "Inicial");

            migrationBuilder.DropColumn(
                name: "pagdet_total",
                table: "Pago_Detalle");

            migrationBuilder.DropColumn(
                name: "id_client",
                table: "Pago_Cabecera");

            migrationBuilder.DropColumn(
                name: "pagcab_tipo",
                table: "Pago_Cabecera");
        }
    }
}
