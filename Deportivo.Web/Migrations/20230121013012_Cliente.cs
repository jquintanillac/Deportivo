using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deportivo.Web.Migrations
{
    /// <inheritdoc />
    public partial class Cliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accesorios_Deportivo_Accesorio_DeportivoAccesorioid_depacce",
                table: "Accesorios");

            migrationBuilder.DropForeignKey(
                name: "FK_Adicionales_Pago_Detalle_PagoDetalleid_pagdet",
                table: "Adicionales");

            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Horario_Horarioid_hordep",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Espacio_Deportivo_Deportivo_Accesorio_DeportivoAccesorioid_depacce",
                table: "Espacio_Deportivo");

            migrationBuilder.DropForeignKey(
                name: "FK_Espacio_Deportivo_Horario_Horarioid_hordep",
                table: "Espacio_Deportivo");

            migrationBuilder.DropForeignKey(
                name: "FK_Horario_Pago_Detalle_PagoDetalleid_pagdet",
                table: "Horario");

            migrationBuilder.DropForeignKey(
                name: "FK_Pago_Detalle_Pago_Cabecera_PagoCabeceraid_pagcab",
                table: "Pago_Detalle");

            migrationBuilder.DropForeignKey(
                name: "FK_Tipo_Deportivo_Espacio_Deportivo_EspacioDeportivoid_espdep",
                table: "Tipo_Deportivo");

            migrationBuilder.DropForeignKey(
                name: "FK_Tipo_Documento_Pago_Cabecera_PagoCabeceraid_pagcab",
                table: "Tipo_Documento");

            migrationBuilder.DropIndex(
                name: "IX_Tipo_Documento_PagoCabeceraid_pagcab",
                table: "Tipo_Documento");

            migrationBuilder.DropIndex(
                name: "IX_Tipo_Deportivo_EspacioDeportivoid_espdep",
                table: "Tipo_Deportivo");

            migrationBuilder.DropIndex(
                name: "IX_Pago_Detalle_PagoCabeceraid_pagcab",
                table: "Pago_Detalle");

            migrationBuilder.DropIndex(
                name: "IX_Horario_PagoDetalleid_pagdet",
                table: "Horario");

            migrationBuilder.DropIndex(
                name: "IX_Espacio_Deportivo_DeportivoAccesorioid_depacce",
                table: "Espacio_Deportivo");

            migrationBuilder.DropIndex(
                name: "IX_Espacio_Deportivo_Horarioid_hordep",
                table: "Espacio_Deportivo");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_Horarioid_hordep",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Adicionales_PagoDetalleid_pagdet",
                table: "Adicionales");

            migrationBuilder.DropIndex(
                name: "IX_Accesorios_DeportivoAccesorioid_depacce",
                table: "Accesorios");

            migrationBuilder.DropColumn(
                name: "PagoCabeceraid_pagcab",
                table: "Tipo_Documento");

            migrationBuilder.DropColumn(
                name: "EspacioDeportivoid_espdep",
                table: "Tipo_Deportivo");

            migrationBuilder.DropColumn(
                name: "PagoCabeceraid_pagcab",
                table: "Pago_Detalle");

            migrationBuilder.DropColumn(
                name: "PagoDetalleid_pagdet",
                table: "Horario");

            migrationBuilder.DropColumn(
                name: "DeportivoAccesorioid_depacce",
                table: "Espacio_Deportivo");

            migrationBuilder.DropColumn(
                name: "Horarioid_hordep",
                table: "Espacio_Deportivo");

            migrationBuilder.DropColumn(
                name: "Horarioid_hordep",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "PagoDetalleid_pagdet",
                table: "Adicionales");

            migrationBuilder.DropColumn(
                name: "DeportivoAccesorioid_depacce",
                table: "Accesorios");

            migrationBuilder.AddColumn<int>(
                name: "id_adicio",
                table: "Pago_Detalle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_hordep",
                table: "Pago_Detalle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_pagcab",
                table: "Pago_Detalle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_tipodoc",
                table: "Pago_Cabecera",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_clien",
                table: "Horario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_espdep",
                table: "Horario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "id_tipdep",
                table: "Espacio_Deportivo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_acce",
                table: "Deportivo_Accesorio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_espdep",
                table: "Deportivo_Accesorio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "client_act",
                table: "Cliente",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_tipdoc",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_adicio",
                table: "Pago_Detalle");

            migrationBuilder.DropColumn(
                name: "id_hordep",
                table: "Pago_Detalle");

            migrationBuilder.DropColumn(
                name: "id_pagcab",
                table: "Pago_Detalle");

            migrationBuilder.DropColumn(
                name: "id_tipodoc",
                table: "Pago_Cabecera");

            migrationBuilder.DropColumn(
                name: "id_clien",
                table: "Horario");

            migrationBuilder.DropColumn(
                name: "id_espdep",
                table: "Horario");

            migrationBuilder.DropColumn(
                name: "id_acce",
                table: "Deportivo_Accesorio");

            migrationBuilder.DropColumn(
                name: "id_espdep",
                table: "Deportivo_Accesorio");

            migrationBuilder.DropColumn(
                name: "id_tipdoc",
                table: "Cliente");

            migrationBuilder.AddColumn<int>(
                name: "PagoCabeceraid_pagcab",
                table: "Tipo_Documento",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EspacioDeportivoid_espdep",
                table: "Tipo_Deportivo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PagoCabeceraid_pagcab",
                table: "Pago_Detalle",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PagoDetalleid_pagdet",
                table: "Horario",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "id_tipdep",
                table: "Espacio_Deportivo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeportivoAccesorioid_depacce",
                table: "Espacio_Deportivo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Horarioid_hordep",
                table: "Espacio_Deportivo",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "client_act",
                table: "Cliente",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "Horarioid_hordep",
                table: "Cliente",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PagoDetalleid_pagdet",
                table: "Adicionales",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeportivoAccesorioid_depacce",
                table: "Accesorios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tipo_Documento_PagoCabeceraid_pagcab",
                table: "Tipo_Documento",
                column: "PagoCabeceraid_pagcab");

            migrationBuilder.CreateIndex(
                name: "IX_Tipo_Deportivo_EspacioDeportivoid_espdep",
                table: "Tipo_Deportivo",
                column: "EspacioDeportivoid_espdep");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_Detalle_PagoCabeceraid_pagcab",
                table: "Pago_Detalle",
                column: "PagoCabeceraid_pagcab");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_PagoDetalleid_pagdet",
                table: "Horario",
                column: "PagoDetalleid_pagdet");

            migrationBuilder.CreateIndex(
                name: "IX_Espacio_Deportivo_DeportivoAccesorioid_depacce",
                table: "Espacio_Deportivo",
                column: "DeportivoAccesorioid_depacce");

            migrationBuilder.CreateIndex(
                name: "IX_Espacio_Deportivo_Horarioid_hordep",
                table: "Espacio_Deportivo",
                column: "Horarioid_hordep");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Horarioid_hordep",
                table: "Cliente",
                column: "Horarioid_hordep");

            migrationBuilder.CreateIndex(
                name: "IX_Adicionales_PagoDetalleid_pagdet",
                table: "Adicionales",
                column: "PagoDetalleid_pagdet");

            migrationBuilder.CreateIndex(
                name: "IX_Accesorios_DeportivoAccesorioid_depacce",
                table: "Accesorios",
                column: "DeportivoAccesorioid_depacce");

            migrationBuilder.AddForeignKey(
                name: "FK_Accesorios_Deportivo_Accesorio_DeportivoAccesorioid_depacce",
                table: "Accesorios",
                column: "DeportivoAccesorioid_depacce",
                principalTable: "Deportivo_Accesorio",
                principalColumn: "id_depacce");

            migrationBuilder.AddForeignKey(
                name: "FK_Adicionales_Pago_Detalle_PagoDetalleid_pagdet",
                table: "Adicionales",
                column: "PagoDetalleid_pagdet",
                principalTable: "Pago_Detalle",
                principalColumn: "id_pagdet");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Horario_Horarioid_hordep",
                table: "Cliente",
                column: "Horarioid_hordep",
                principalTable: "Horario",
                principalColumn: "id_hordep");

            migrationBuilder.AddForeignKey(
                name: "FK_Espacio_Deportivo_Deportivo_Accesorio_DeportivoAccesorioid_depacce",
                table: "Espacio_Deportivo",
                column: "DeportivoAccesorioid_depacce",
                principalTable: "Deportivo_Accesorio",
                principalColumn: "id_depacce");

            migrationBuilder.AddForeignKey(
                name: "FK_Espacio_Deportivo_Horario_Horarioid_hordep",
                table: "Espacio_Deportivo",
                column: "Horarioid_hordep",
                principalTable: "Horario",
                principalColumn: "id_hordep");

            migrationBuilder.AddForeignKey(
                name: "FK_Horario_Pago_Detalle_PagoDetalleid_pagdet",
                table: "Horario",
                column: "PagoDetalleid_pagdet",
                principalTable: "Pago_Detalle",
                principalColumn: "id_pagdet");

            migrationBuilder.AddForeignKey(
                name: "FK_Pago_Detalle_Pago_Cabecera_PagoCabeceraid_pagcab",
                table: "Pago_Detalle",
                column: "PagoCabeceraid_pagcab",
                principalTable: "Pago_Cabecera",
                principalColumn: "id_pagcab");

            migrationBuilder.AddForeignKey(
                name: "FK_Tipo_Deportivo_Espacio_Deportivo_EspacioDeportivoid_espdep",
                table: "Tipo_Deportivo",
                column: "EspacioDeportivoid_espdep",
                principalTable: "Espacio_Deportivo",
                principalColumn: "id_espdep");

            migrationBuilder.AddForeignKey(
                name: "FK_Tipo_Documento_Pago_Cabecera_PagoCabeceraid_pagcab",
                table: "Tipo_Documento",
                column: "PagoCabeceraid_pagcab",
                principalTable: "Pago_Cabecera",
                principalColumn: "id_pagcab");
        }
    }
}
