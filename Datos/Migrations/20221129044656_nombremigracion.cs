using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class nombremigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asignaturas",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    Nombre = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Horario = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignaturas", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Insumos",
                columns: table => new
                {
                    Item = table.Column<string>(type: "varchar(5)", maxLength: 4, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Marca = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    StockMinimo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumos", x => x.Item);
                });

            migrationBuilder.CreateTable(
                name: "Modulos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeriodosAcademicos",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "varchar(5)", nullable: false),
                    Periodo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Corte = table.Column<int>(type: "int", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodosAcademicos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Programas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Ruta = table.Column<string>(nullable: true),
                    IdModulo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programas_Modulos_IdModulo",
                        column: x => x.IdModulo,
                        principalTable: "Modulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    User = table.Column<string>(type: "varchar(30)", nullable: false),
                    Password = table.Column<string>(type: "varchar(15)", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(25)", nullable: true),
                    Apellidos = table.Column<string>(type: "varchar(25)", nullable: true),
                    Tipo = table.Column<string>(type: "varchar(15)", nullable: true),
                    Estado = table.Column<string>(type: "varchar(8)", nullable: true),
                    IdPersona = table.Column<string>(type: "varchar(13)", nullable: true),
                    IdRole = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.User);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolProgramas",
                columns: table => new
                {
                    IdRolePrograma = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRole = table.Column<int>(nullable: false),
                    IdPrograma = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolProgramas", x => x.IdRolePrograma);
                    table.ForeignKey(
                        name: "FK_RolProgramas_Programas_IdPrograma",
                        column: x => x.IdPrograma,
                        principalTable: "Programas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Identificacion = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    Nombre = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Apellidos = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Correo = table.Column<string>(type: "varchar(30)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Sexo = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true),
                    UsuarioUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Identificacion);
                    table.ForeignKey(
                        name: "FK_Personas_Usuarios_UsuarioUser",
                        column: x => x.UsuarioUser,
                        principalTable: "Usuarios",
                        principalColumn: "User",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "varchar(5)", nullable: false),
                    Mensaje = table.Column<string>(nullable: true),
                    IdPersona = table.Column<string>(type: "varchar(13)", nullable: true),
                    Admi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Chats_Personas_IdPersona",
                        column: x => x.IdPersona,
                        principalTable: "Personas",
                        principalColumn: "Identificacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Solicitudes",
                columns: table => new
                {
                    Numero = table.Column<string>(type: "varchar(5)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaEntrega = table.Column<string>(type: "varchar(20)", nullable: true),
                    Estado = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Monitor = table.Column<string>(type: "varchar(13)", maxLength: 15, nullable: false),
                    CantidadInsumos = table.Column<int>(type: "int", nullable: false),
                    CodigoAsignatura = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    IdPersona = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    IdPeriodo = table.Column<string>(type: "varchar(5)", nullable: true),
                    SolicitudFecha = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => x.Numero);
                    table.ForeignKey(
                        name: "FK_Solicitudes_Asignaturas_CodigoAsignatura",
                        column: x => x.CodigoAsignatura,
                        principalTable: "Asignaturas",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitudes_PeriodosAcademicos_IdPeriodo",
                        column: x => x.IdPeriodo,
                        principalTable: "PeriodosAcademicos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Solicitudes_Personas_IdPersona",
                        column: x => x.IdPersona,
                        principalTable: "Personas",
                        principalColumn: "Identificacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleInsumo",
                columns: table => new
                {
                    NumeroDetalle = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false),
                    Fecha = table.Column<string>(type: "varchar(20)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    CodigoInsumo = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    SolicitudNumero = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleInsumo", x => x.NumeroDetalle);
                    table.ForeignKey(
                        name: "FK_DetalleInsumo_Insumos_CodigoInsumo",
                        column: x => x.CodigoInsumo,
                        principalTable: "Insumos",
                        principalColumn: "Item",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleInsumo_Solicitudes_SolicitudNumero",
                        column: x => x.SolicitudNumero,
                        principalTable: "Solicitudes",
                        principalColumn: "Numero",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Modulos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Periodo Academico" },
                    { 2, "Insumos" },
                    { 3, "Usuarios" },
                    { 4, "Asignaturas" },
                    { 5, "Solicitudes" },
                    { 6, "Reportes" }
                });

            migrationBuilder.InsertData(
                table: "PeriodosAcademicos",
                columns: new[] { "Codigo", "Corte", "Periodo" },
                values: new object[] { "1", 1, "2021-1" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Codigo", "Nombre" },
                values: new object[,]
                {
                    { 1, "Docente" },
                    { 2, "Monitor" },
                    { 3, "Coordinador" },
                    { 4, "Administrador" }
                });

            migrationBuilder.InsertData(
                table: "Programas",
                columns: new[] { "Id", "IdModulo", "Nombre", "Ruta" },
                values: new object[,]
                {
                    { 1, 1, "Registro Periodo", "/periodoRegistro" },
                    { 2, 2, "Registro Insumos", "/RegistroInsumos" },
                    { 3, 2, "Consultar Insumos", "/ConsultaInsumos" },
                    { 4, 3, "Registrar Usuario", "/RegistroDocentes" },
                    { 5, 4, "Registro Asignaturas", "/RegistroAsignaturas" },
                    { 6, 4, "Consultar Asignaturas", "/ConsultaAsignaturas" },
                    { 7, 5, "Solicitar Pedido", "/GestionSolicitudes" },
                    { 8, 5, "Consultar Solicitudes", "/ConsultaSolicitudes" },
                    { 9, 6, "Reporte Insumos Usados", "/ReportesInsumos" },
                    { 10, 6, "Reporte Usuario Pedidos", "/ReportesUsuario" },
                    { 11, 6, "Reporte Asignaturas Solicitadas", "/ReporteAsignturas" },
                    { 12, 6, "Reporte Stock Insumos", "/ReportesStock" },
                    { 13, 6, "Reporte Stock Minimo", "/ReportesSolicitud" }
                });

            migrationBuilder.InsertData(
                table: "RolProgramas",
                columns: new[] { "IdRolePrograma", "IdPrograma", "IdRole" },
                values: new object[,]
                {
                    { 1, 1, 4 },
                    { 17, 11, 4 },
                    { 16, 10, 4 },
                    { 7, 9, 4 },
                    { 15, 8, 1 },
                    { 13, 8, 3 },
                    { 10, 8, 2 },
                    { 6, 8, 4 },
                    { 18, 12, 4 },
                    { 14, 7, 1 },
                    { 4, 6, 4 },
                    { 3, 5, 4 },
                    { 2, 4, 4 },
                    { 12, 3, 3 },
                    { 9, 3, 2 },
                    { 11, 2, 3 },
                    { 8, 2, 2 },
                    { 5, 7, 4 },
                    { 19, 13, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chats_IdPersona",
                table: "Chats",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleInsumo_CodigoInsumo",
                table: "DetalleInsumo",
                column: "CodigoInsumo");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleInsumo_SolicitudNumero",
                table: "DetalleInsumo",
                column: "SolicitudNumero");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_UsuarioUser",
                table: "Personas",
                column: "UsuarioUser");

            migrationBuilder.CreateIndex(
                name: "IX_Programas_IdModulo",
                table: "Programas",
                column: "IdModulo");

            migrationBuilder.CreateIndex(
                name: "IX_RolProgramas_IdPrograma",
                table: "RolProgramas",
                column: "IdPrograma");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_CodigoAsignatura",
                table: "Solicitudes",
                column: "CodigoAsignatura");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_IdPeriodo",
                table: "Solicitudes",
                column: "IdPeriodo");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_IdPersona",
                table: "Solicitudes",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdRole",
                table: "Usuarios",
                column: "IdRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "DetalleInsumo");

            migrationBuilder.DropTable(
                name: "RolProgramas");

            migrationBuilder.DropTable(
                name: "Insumos");

            migrationBuilder.DropTable(
                name: "Solicitudes");

            migrationBuilder.DropTable(
                name: "Programas");

            migrationBuilder.DropTable(
                name: "Asignaturas");

            migrationBuilder.DropTable(
                name: "PeriodosAcademicos");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Modulos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
