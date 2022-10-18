using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vuelos.Infraestructure.EF.Migrations
{
    public partial class InitialStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aeronave",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NroAsientos = table.Column<int>(type: "int", nullable: false),
                    EstadoAeronave = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeronave", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aeropuerto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreAeropuerto = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Localidad = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Departamento = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    OACI = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    IATA = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeropuerto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tripulacion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstadoTripulacion = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tripulacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vuelo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdAeropuertoOrigen = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdAeropuertoDestino = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NroVuelo = table.Column<int>(type: "int", nullable: false),
                    EstadoVuelo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MillasVuelo = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItinerarioVuelo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTripulacion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdAeronave = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaHoraCreacion = table.Column<DateTime>(type: "DateTime", nullable: false),
                    ZonaAbordaje = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NroPuertaAbordaje = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FechaHoraAbordaje = table.Column<DateTime>(type: "DateTime", nullable: false),
                    FechaHoraPartida = table.Column<DateTime>(type: "DateTime", nullable: false),
                    FechaHoraLLegada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NroAsientosHabilitados = table.Column<int>(type: "int", nullable: false),
                    TipoVuelo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EstadoItinerarioVuelo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    VueloId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItinerarioVuelo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItinerarioVuelo_Vuelo_VueloId",
                        column: x => x.VueloId,
                        principalTable: "Vuelo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItinerarioVuelo_VueloId",
                table: "ItinerarioVuelo",
                column: "VueloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aeronave");

            migrationBuilder.DropTable(
                name: "Aeropuerto");

            migrationBuilder.DropTable(
                name: "ItinerarioVuelo");

            migrationBuilder.DropTable(
                name: "Tripulacion");

            migrationBuilder.DropTable(
                name: "Vuelo");
        }
    }
}
