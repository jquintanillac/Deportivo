using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deportivo.Web.Migrations
{
    /// <inheritdoc />
    public partial class EgresoCaja : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingresos");

            migrationBuilder.DropColumn(
                name: "pagcab_est",
                table: "Pago_Cabecera");

            migrationBuilder.DropColumn(
                name: "pagcab_tipo",
                table: "Pago_Cabecera");

            migrationBuilder.AlterColumn<int>(
                name: "pagdet_unidad",
                table: "Pago_Detalle",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "pagdet_total",
                table: "Pago_Detalle",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "pagdet_monto",
                table: "Pago_Detalle",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "pagdet_unidad",
                table: "Pago_Detalle",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "pagdet_total",
                table: "Pago_Detalle",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "pagdet_monto",
                table: "Pago_Detalle",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pagcab_est",
                table: "Pago_Cabecera",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pagcab_tipo",
                table: "Pago_Cabecera",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ingresos",
                columns: table => new
                {
                    idingre = table.Column<int>(name: "id_ingre", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ingredesc = table.Column<string>(name: "ingre_desc", type: "nvarchar(max)", nullable: false),
                    ingrefecha = table.Column<DateTime>(name: "ingre_fecha", type: "datetime2", nullable: false),
                    ingremonto = table.Column<decimal>(name: "ingre_monto", type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingresos", x => x.idingre);
                });
        }
    }
}
