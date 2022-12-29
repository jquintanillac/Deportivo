using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Deportivo.Web.Migrations
{
    /// <inheritdoc />
    public partial class InicioMigra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accesorios",
                columns: table => new
                {
                    idacce = table.Column<int>(name: "id_acce", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accedesc = table.Column<string>(name: "acce_desc", type: "nvarchar(max)", nullable: false),
                    acceobs = table.Column<string>(name: "acce_obs", type: "nvarchar(max)", nullable: false),
                    acceact = table.Column<bool>(name: "acce_act", type: "bit", nullable: false),
                    accefecing = table.Column<DateTime>(name: "acce_fecing", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesorios", x => x.idacce);
                });

            migrationBuilder.CreateTable(
                name: "Adicionales",
                columns: table => new
                {
                    idadicio = table.Column<int>(name: "id_adicio", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adiciodesc = table.Column<string>(name: "adicio_desc", type: "nvarchar(max)", nullable: false),
                    adicioest = table.Column<bool>(name: "adicio_est", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adicionales", x => x.idadicio);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    idclient = table.Column<int>(name: "id_client", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientdesc = table.Column<string>(name: "client_desc", type: "nvarchar(max)", nullable: false),
                    clientdociden = table.Column<string>(name: "client_dociden", type: "nvarchar(max)", nullable: false),
                    clienttipdoc = table.Column<string>(name: "client_tipdoc", type: "nvarchar(max)", nullable: false),
                    clientobser = table.Column<string>(name: "client_obser", type: "nvarchar(max)", nullable: false),
                    clienttelf = table.Column<string>(name: "client_telf", type: "nvarchar(max)", nullable: false),
                    clientemail = table.Column<string>(name: "client_email", type: "nvarchar(max)", nullable: false),
                    clientact = table.Column<bool>(name: "client_act", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.idclient);
                });

            migrationBuilder.CreateTable(
                name: "Deportivo_Accesorio",
                columns: table => new
                {
                    iddepacce = table.Column<int>(name: "id_depacce", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idespdep = table.Column<int>(name: "id_espdep", type: "int", nullable: false),
                    idacce = table.Column<int>(name: "id_acce", type: "int", nullable: false),
                    depaccefecingr = table.Column<DateTime>(name: "depacce_fecingr", type: "datetime2", nullable: false),
                    depacceact = table.Column<bool>(name: "depacce_act", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deportivo_Accesorio", x => x.iddepacce);
                });

            migrationBuilder.CreateTable(
                name: "Espacio_Deportivo",
                columns: table => new
                {
                    idespdep = table.Column<int>(name: "id_espdep", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    espdeptipo = table.Column<int>(name: "espdep_tipo", type: "int", nullable: false),
                    espdepcod = table.Column<string>(name: "espdep_cod", type: "nvarchar(max)", nullable: false),
                    espdepdesc = table.Column<string>(name: "espdep_desc", type: "nvarchar(max)", nullable: false),
                    espdepfecha = table.Column<DateTime>(name: "espdep_fecha", type: "datetime2", nullable: false),
                    espdepact = table.Column<bool>(name: "espdep_act", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Espacio_Deportivo", x => x.idespdep);
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    idhordep = table.Column<int>(name: "id_hordep", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idespdep = table.Column<int>(name: "id_espdep", type: "int", nullable: false),
                    idclien = table.Column<int>(name: "id_clien", type: "int", nullable: false),
                    hordepdesc = table.Column<string>(name: "hordep_desc", type: "nvarchar(max)", nullable: false),
                    hordepfecing = table.Column<DateTime>(name: "hordep_fecing", type: "datetime2", nullable: false),
                    hordepfecsal = table.Column<DateTime>(name: "hordep_fecsal", type: "datetime2", nullable: false),
                    hordepobse = table.Column<string>(name: "hordep_obse", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.idhordep);
                });

            migrationBuilder.CreateTable(
                name: "Pago_Cabecera",
                columns: table => new
                {
                    idpagcab = table.Column<int>(name: "id_pagcab", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idtipodoc = table.Column<int>(name: "id_tipodoc", type: "int", nullable: false),
                    pagcabdescr = table.Column<string>(name: "pagcab_descr", type: "nvarchar(max)", nullable: false),
                    pagcabfeccrea = table.Column<DateTime>(name: "pagcab_feccrea", type: "datetime2", nullable: false),
                    pagcabfecemis = table.Column<DateTime>(name: "pagcab_fecemis", type: "datetime2", nullable: false),
                    pagcabnro = table.Column<string>(name: "pagcab_nro", type: "nvarchar(max)", nullable: false),
                    pagcabobs = table.Column<string>(name: "pagcab_obs", type: "nvarchar(max)", nullable: false),
                    pagcabtotal = table.Column<decimal>(name: "pagcab_total", type: "decimal(18,2)", nullable: false),
                    pagcabest = table.Column<string>(name: "pagcab_est", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago_Cabecera", x => x.idpagcab);
                });

            migrationBuilder.CreateTable(
                name: "Pago_Detalle",
                columns: table => new
                {
                    idpagdet = table.Column<int>(name: "id_pagdet", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idpagcab = table.Column<int>(name: "id_pagcab", type: "int", nullable: false),
                    idhordep = table.Column<int>(name: "id_hordep", type: "int", nullable: false),
                    idadicio = table.Column<int>(name: "id_adicio", type: "int", nullable: false),
                    pagdetmonto = table.Column<decimal>(name: "pagdet_monto", type: "decimal(18,2)", nullable: false),
                    pagdetunidad = table.Column<int>(name: "pagdet_unidad", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago_Detalle", x => x.idpagdet);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Deportivo",
                columns: table => new
                {
                    idtipdep = table.Column<int>(name: "id_tipdep", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipdepdesc = table.Column<string>(name: "tipdep_desc", type: "nvarchar(max)", nullable: false),
                    tipdepact = table.Column<bool>(name: "tipdep_act", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Deportivo", x => x.idtipdep);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Documento",
                columns: table => new
                {
                    idtipdoc = table.Column<int>(name: "id_tipdoc", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipdocdesc = table.Column<string>(name: "tipdoc_desc", type: "nvarchar(max)", nullable: false),
                    tipdocact = table.Column<bool>(name: "tipdoc_act", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Documento", x => x.idtipdoc);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accesorios");

            migrationBuilder.DropTable(
                name: "Adicionales");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Deportivo_Accesorio");

            migrationBuilder.DropTable(
                name: "Espacio_Deportivo");

            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "Pago_Cabecera");

            migrationBuilder.DropTable(
                name: "Pago_Detalle");

            migrationBuilder.DropTable(
                name: "Tipo_Deportivo");

            migrationBuilder.DropTable(
                name: "Tipo_Documento");
        }
    }
}
