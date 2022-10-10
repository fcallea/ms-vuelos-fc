﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vuelos.Infraestructure.EF.Contexts;

namespace Vuelos.Infraestructure.EF.Migrations
{
    [DbContext(typeof(ReadDbContext))]
    partial class ReadDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vuelos.Infraestructure.EF.ReadModel.AeropuertoReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Departamento")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("IATA")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Localidad")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("NombreAeropuerto")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("OACI")
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("Id");

                    b.ToTable("Aeropuerto");
                });

            modelBuilder.Entity("Vuelos.Infraestructure.EF.ReadModel.ItinerarioVueloReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EstadoItinerarioVuelo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("EstadoItinerarioVuelo");

                    b.Property<DateTime>("FechaHoraAbordaje")
                        .HasColumnType("DateTime")
                        .HasColumnName("FechaHoraAbordaje");

                    b.Property<DateTime>("FechaHoraCreacion")
                        .HasColumnType("DateTime")
                        .HasColumnName("FechaHoraCreacion");

                    b.Property<DateTime>("FechaHoraLLegada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaHoraPartida")
                        .HasColumnType("datetime")
                        .HasColumnName("FechaHoraPartida");

                    b.Property<Guid>("IdAeronave")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdAeronave");

                    b.Property<Guid>("IdTripulacion")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdTripulacion");

                    b.Property<Guid>("IdVuelo")
                        .HasMaxLength(40)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdVuelo");

                    b.Property<int>("NroAsientosHabilitados")
                        .HasColumnType("int")
                        .HasColumnName("NroAsientosHabilitados");

                    b.Property<string>("NroPuertaAbordaje")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("NroPuertaAbordaje");

                    b.Property<string>("TipoVuelo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("TipoVuelo");

                    b.Property<Guid?>("VueloId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ZonaAbordaje")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("ZonaAbordaje");

                    b.HasKey("Id");

                    b.HasIndex("VueloId");

                    b.ToTable("ItinerarioVuelo");
                });

            modelBuilder.Entity("Vuelos.Infraestructure.EF.ReadModel.VueloReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EstadoVuelo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("EstadoVuelo");

                    b.Property<Guid>("IdAeropuertoDestino")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdAeropuertoDestino");

                    b.Property<Guid>("IdAeropuertoOrigen")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdAeropuertoOrigen");

                    b.Property<decimal>("MillasVuelo")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("MillasVuelo");

                    b.Property<int>("NroVuelo")
                        .HasColumnType("int")
                        .HasColumnName("NroVuelo");

                    b.HasKey("Id");

                    b.ToTable("Vuelo");
                });

            modelBuilder.Entity("Vuelos.Infraestructure.EF.ReadModel.ItinerarioVueloReadModel", b =>
                {
                    b.HasOne("Vuelos.Infraestructure.EF.ReadModel.VueloReadModel", "Vuelo")
                        .WithMany("ItinerarioVuelo")
                        .HasForeignKey("VueloId");

                    b.Navigation("Vuelo");
                });

            modelBuilder.Entity("Vuelos.Infraestructure.EF.ReadModel.VueloReadModel", b =>
                {
                    b.Navigation("ItinerarioVuelo");
                });
#pragma warning restore 612, 618
        }
    }
}
