﻿// <auto-generated />
using System;
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(StockLabContext))]
    partial class StockLabContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.Asignaturas", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("Codigo");

                    b.ToTable("Asignaturas");
                });

            modelBuilder.Entity("Entity.Chat", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Admi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdPersona")
                        .HasColumnType("varchar(13)");

                    b.Property<string>("Mensaje")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.HasIndex("IdPersona");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Entity.DetalleInsumo", b =>
                {
                    b.Property<string>("NumeroDetalle")
                        .HasColumnType("varchar(4)")
                        .HasMaxLength(4);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("CodigoInsumo")
                        .IsRequired()
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("Fecha")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("SolicitudNumero")
                        .HasColumnType("varchar(5)");

                    b.HasKey("NumeroDetalle");

                    b.HasIndex("CodigoInsumo");

                    b.HasIndex("SolicitudNumero");

                    b.ToTable("DetalleInsumo");
                });

            modelBuilder.Entity("Entity.Insumo", b =>
                {
                    b.Property<string>("Item")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(4);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("StockMinimo")
                        .HasColumnType("int");

                    b.HasKey("Item");

                    b.ToTable("Insumos");
                });

            modelBuilder.Entity("Entity.ModuloMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Modulos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Periodo Academico"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Insumos"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Usuarios"
                        },
                        new
                        {
                            Id = 4,
                            Nombre = "Asignaturas"
                        },
                        new
                        {
                            Id = 5,
                            Nombre = "Solicitudes"
                        },
                        new
                        {
                            Id = 6,
                            Nombre = "Reportes"
                        });
                });

            modelBuilder.Entity("Entity.PeriodoAcademico", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("varchar(5)");

                    b.Property<int>("Corte")
                        .HasColumnType("int")
                        .HasMaxLength(1);

                    b.Property<string>("Periodo")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Codigo");

                    b.ToTable("PeriodosAcademicos");

                    b.HasData(
                        new
                        {
                            Codigo = "1",
                            Corte = 1,
                            Periodo = "2021-1"
                        });
                });

            modelBuilder.Entity("Entity.Persona", b =>
                {
                    b.Property<string>("Identificacion")
                        .HasColumnType("varchar(13)")
                        .HasMaxLength(13);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Correo")
                        .HasColumnType("varchar(30)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Sexo")
                        .HasColumnType("varchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("UsuarioUser")
                        .HasColumnType("varchar(30)");

                    b.HasKey("Identificacion");

                    b.HasIndex("UsuarioUser");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Entity.ProgramasModulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdModulo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ruta")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdModulo");

                    b.ToTable("Programas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdModulo = 1,
                            Nombre = "Registro Periodo",
                            Ruta = "/periodoRegistro"
                        },
                        new
                        {
                            Id = 2,
                            IdModulo = 2,
                            Nombre = "Registro Insumos",
                            Ruta = "/RegistroInsumos"
                        },
                        new
                        {
                            Id = 3,
                            IdModulo = 2,
                            Nombre = "Consultar Insumos",
                            Ruta = "/ConsultaInsumos"
                        },
                        new
                        {
                            Id = 4,
                            IdModulo = 3,
                            Nombre = "Registrar Usuario",
                            Ruta = "/RegistroDocentes"
                        },
                        new
                        {
                            Id = 5,
                            IdModulo = 4,
                            Nombre = "Registro Asignaturas",
                            Ruta = "/RegistroAsignaturas"
                        },
                        new
                        {
                            Id = 6,
                            IdModulo = 4,
                            Nombre = "Consultar Asignaturas",
                            Ruta = "/ConsultaAsignaturas"
                        },
                        new
                        {
                            Id = 7,
                            IdModulo = 5,
                            Nombre = "Solicitar Pedido",
                            Ruta = "/GestionSolicitudes"
                        },
                        new
                        {
                            Id = 8,
                            IdModulo = 5,
                            Nombre = "Consultar Solicitudes",
                            Ruta = "/ConsultaSolicitudes"
                        },
                        new
                        {
                            Id = 9,
                            IdModulo = 6,
                            Nombre = "Reporte Insumos Usados",
                            Ruta = "/ReportesInsumos"
                        },
                        new
                        {
                            Id = 10,
                            IdModulo = 6,
                            Nombre = "Reporte Usuario Pedidos",
                            Ruta = "/ReportesUsuario"
                        },
                        new
                        {
                            Id = 11,
                            IdModulo = 6,
                            Nombre = "Reporte Asignaturas Solicitadas",
                            Ruta = "/ReporteAsignturas"
                        },
                        new
                        {
                            Id = 12,
                            IdModulo = 6,
                            Nombre = "Reporte Stock Insumos",
                            Ruta = "/ReportesStock"
                        },
                        new
                        {
                            Id = 13,
                            IdModulo = 6,
                            Nombre = "Reporte Stock Minimo",
                            Ruta = "/ReportesSolicitud"
                        });
                });

            modelBuilder.Entity("Entity.RolPrograma", b =>
                {
                    b.Property<int>("IdRolePrograma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdPrograma")
                        .HasColumnType("int");

                    b.Property<int>("IdRole")
                        .HasColumnType("int");

                    b.HasKey("IdRolePrograma");

                    b.HasIndex("IdPrograma");

                    b.ToTable("RolProgramas");

                    b.HasData(
                        new
                        {
                            IdRolePrograma = 1,
                            IdPrograma = 1,
                            IdRole = 4
                        },
                        new
                        {
                            IdRolePrograma = 2,
                            IdPrograma = 4,
                            IdRole = 4
                        },
                        new
                        {
                            IdRolePrograma = 3,
                            IdPrograma = 5,
                            IdRole = 4
                        },
                        new
                        {
                            IdRolePrograma = 4,
                            IdPrograma = 6,
                            IdRole = 4
                        },
                        new
                        {
                            IdRolePrograma = 5,
                            IdPrograma = 7,
                            IdRole = 4
                        },
                        new
                        {
                            IdRolePrograma = 6,
                            IdPrograma = 8,
                            IdRole = 4
                        },
                        new
                        {
                            IdRolePrograma = 7,
                            IdPrograma = 9,
                            IdRole = 4
                        },
                        new
                        {
                            IdRolePrograma = 16,
                            IdPrograma = 10,
                            IdRole = 4
                        },
                        new
                        {
                            IdRolePrograma = 17,
                            IdPrograma = 11,
                            IdRole = 4
                        },
                        new
                        {
                            IdRolePrograma = 18,
                            IdPrograma = 12,
                            IdRole = 4
                        },
                        new
                        {
                            IdRolePrograma = 19,
                            IdPrograma = 13,
                            IdRole = 4
                        },
                        new
                        {
                            IdRolePrograma = 8,
                            IdPrograma = 2,
                            IdRole = 2
                        },
                        new
                        {
                            IdRolePrograma = 9,
                            IdPrograma = 3,
                            IdRole = 2
                        },
                        new
                        {
                            IdRolePrograma = 10,
                            IdPrograma = 8,
                            IdRole = 2
                        },
                        new
                        {
                            IdRolePrograma = 11,
                            IdPrograma = 2,
                            IdRole = 3
                        },
                        new
                        {
                            IdRolePrograma = 12,
                            IdPrograma = 3,
                            IdRole = 3
                        },
                        new
                        {
                            IdRolePrograma = 13,
                            IdPrograma = 8,
                            IdRole = 3
                        },
                        new
                        {
                            IdRolePrograma = 14,
                            IdPrograma = 7,
                            IdRole = 1
                        },
                        new
                        {
                            IdRolePrograma = 15,
                            IdPrograma = 8,
                            IdRole = 1
                        });
                });

            modelBuilder.Entity("Entity.Role", b =>
                {
                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Codigo");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Codigo = 1,
                            Nombre = "Docente"
                        },
                        new
                        {
                            Codigo = 2,
                            Nombre = "Monitor"
                        },
                        new
                        {
                            Codigo = 3,
                            Nombre = "Coordinador"
                        },
                        new
                        {
                            Codigo = 4,
                            Nombre = "Administrador"
                        });
                });

            modelBuilder.Entity("Entity.Solicitud", b =>
                {
                    b.Property<string>("Numero")
                        .HasColumnType("varchar(5)");

                    b.Property<int>("CantidadInsumos")
                        .HasColumnType("int");

                    b.Property<string>("CodigoAsignatura")
                        .IsRequired()
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("Estado")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<string>("FechaEntrega")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("IdPeriodo")
                        .HasColumnType("varchar(5)");

                    b.Property<string>("IdPersona")
                        .IsRequired()
                        .HasColumnType("varchar(13)")
                        .HasMaxLength(13);

                    b.Property<string>("Monitor")
                        .IsRequired()
                        .HasColumnType("varchar(13)")
                        .HasMaxLength(15);

                    b.Property<DateTime>("SolicitudFecha")
                        .HasColumnType("datetime");

                    b.HasKey("Numero");

                    b.HasIndex("CodigoAsignatura");

                    b.HasIndex("IdPeriodo");

                    b.HasIndex("IdPersona");

                    b.ToTable("Solicitudes");
                });

            modelBuilder.Entity("Entity.Usuario", b =>
                {
                    b.Property<string>("User")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Apellidos")
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Estado")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("IdPersona")
                        .HasColumnType("varchar(13)");

                    b.Property<int>("IdRole")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(25)");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Tipo")
                        .HasColumnType("varchar(15)");

                    b.HasKey("User");

                    b.HasIndex("IdRole");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Entity.Chat", b =>
                {
                    b.HasOne("Entity.Persona", null)
                        .WithMany()
                        .HasForeignKey("IdPersona");
                });

            modelBuilder.Entity("Entity.DetalleInsumo", b =>
                {
                    b.HasOne("Entity.Insumo", null)
                        .WithMany()
                        .HasForeignKey("CodigoInsumo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Solicitud", null)
                        .WithMany("Detalles")
                        .HasForeignKey("SolicitudNumero");
                });

            modelBuilder.Entity("Entity.Persona", b =>
                {
                    b.HasOne("Entity.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioUser");
                });

            modelBuilder.Entity("Entity.ProgramasModulo", b =>
                {
                    b.HasOne("Entity.ModuloMenu", null)
                        .WithMany()
                        .HasForeignKey("IdModulo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entity.RolPrograma", b =>
                {
                    b.HasOne("Entity.ProgramasModulo", null)
                        .WithMany()
                        .HasForeignKey("IdPrograma")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entity.Role", b =>
                {
                    b.HasOne("Entity.Role", null)
                        .WithMany()
                        .HasForeignKey("Codigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entity.Solicitud", b =>
                {
                    b.HasOne("Entity.Asignaturas", null)
                        .WithMany()
                        .HasForeignKey("CodigoAsignatura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.PeriodoAcademico", null)
                        .WithMany()
                        .HasForeignKey("IdPeriodo");

                    b.HasOne("Entity.Persona", null)
                        .WithMany()
                        .HasForeignKey("IdPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entity.Usuario", b =>
                {
                    b.HasOne("Entity.Role", null)
                        .WithMany()
                        .HasForeignKey("IdRole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}