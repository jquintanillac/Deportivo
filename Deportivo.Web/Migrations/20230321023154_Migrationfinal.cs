using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deportivo.Web.Migrations
{
    /// <inheritdoc />
    public partial class Migrationfinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "hordep_tipo",
                table: "Horario",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hordep_tipo",
                table: "Horario");
        }
    }
}
