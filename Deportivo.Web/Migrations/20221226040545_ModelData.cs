using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deportivo.Web.Migrations
{
    /// <inheritdoc />
    public partial class ModelData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Tipo_Documento_id_tipdoc",
                table: "Tipo_Documento",
                column: "id_tipdoc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tipo_Deportivo_id_tipdep",
                table: "Tipo_Deportivo",
                column: "id_tipdep",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pago_Detalle_id_pagdet",
                table: "Pago_Detalle",
                column: "id_pagdet",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pago_Cabecera_id_pagcab",
                table: "Pago_Cabecera",
                column: "id_pagcab",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Horario_id_hordep",
                table: "Horario",
                column: "id_hordep",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Espacio_Deportivo_id_espdep",
                table: "Espacio_Deportivo",
                column: "id_espdep",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deportivo_Accesorio_id_depacce",
                table: "Deportivo_Accesorio",
                column: "id_depacce",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_id_client",
                table: "Cliente",
                column: "id_client",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adicionales_id_adicio",
                table: "Adicionales",
                column: "id_adicio",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accesorios_id_acce",
                table: "Accesorios",
                column: "id_acce",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tipo_Documento_id_tipdoc",
                table: "Tipo_Documento");

            migrationBuilder.DropIndex(
                name: "IX_Tipo_Deportivo_id_tipdep",
                table: "Tipo_Deportivo");

            migrationBuilder.DropIndex(
                name: "IX_Pago_Detalle_id_pagdet",
                table: "Pago_Detalle");

            migrationBuilder.DropIndex(
                name: "IX_Pago_Cabecera_id_pagcab",
                table: "Pago_Cabecera");

            migrationBuilder.DropIndex(
                name: "IX_Horario_id_hordep",
                table: "Horario");

            migrationBuilder.DropIndex(
                name: "IX_Espacio_Deportivo_id_espdep",
                table: "Espacio_Deportivo");

            migrationBuilder.DropIndex(
                name: "IX_Deportivo_Accesorio_id_depacce",
                table: "Deportivo_Accesorio");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_id_client",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Adicionales_id_adicio",
                table: "Adicionales");

            migrationBuilder.DropIndex(
                name: "IX_Accesorios_id_acce",
                table: "Accesorios");
        }
    }
}
