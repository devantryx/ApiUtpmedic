using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiUtpmedic.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinica",
                columns: table => new
                {
                    idclinica = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clinica_nombre = table.Column<string>(nullable: true),
                    clinica_direccion = table.Column<string>(nullable: true),
                    clinica_telefono = table.Column<string>(nullable: true),
                    clinica_email = table.Column<string>(nullable: true),
                    clinica_ruc = table.Column<string>(nullable: true),
                    clinica_distrito = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinica", x => x.idclinica);
                });

            migrationBuilder.CreateTable(
                name: "Especialidad",
                columns: table => new
                {
                    idespecialidad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    especialidad_nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidad", x => x.idespecialidad);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    idpersona = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    persona_dni = table.Column<string>(nullable: true),
                    persona_nombres = table.Column<string>(nullable: true),
                    persona_apellidos = table.Column<string>(nullable: true),
                    fecNac = table.Column<string>(nullable: true),
                    persona_sexo = table.Column<string>(nullable: true),
                    persona_direccion = table.Column<string>(nullable: true),
                    persona_email = table.Column<string>(nullable: true),
                    persona_telefono = table.Column<string>(nullable: true),
                    persona_distrito = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.idpersona);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    idtipousuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipousuario_descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.idtipousuario);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    idmedico = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idespecialidad = table.Column<int>(nullable: true),
                    idclinica = table.Column<int>(nullable: true),
                    idpersona = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.idmedico);
                    table.ForeignKey(
                        name: "FK_Medico_Clinica_idclinica",
                        column: x => x.idclinica,
                        principalTable: "Clinica",
                        principalColumn: "idclinica",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medico_Especialidad_idespecialidad",
                        column: x => x.idespecialidad,
                        principalTable: "Especialidad",
                        principalColumn: "idespecialidad",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medico_Persona_idpersona",
                        column: x => x.idpersona,
                        principalTable: "Persona",
                        principalColumn: "idpersona",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idusuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario_user = table.Column<string>(nullable: true),
                    usuario_clave = table.Column<byte[]>(nullable: true),
                    usuario_clave2 = table.Column<byte[]>(nullable: true),
                    nombrefoto = table.Column<string>(nullable: true),
                    idtipousuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.idusuario);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoUsuario_idtipousuario",
                        column: x => x.idtipousuario,
                        principalTable: "TipoUsuario",
                        principalColumn: "idtipousuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    idhorario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    horario_hinicio = table.Column<string>(nullable: true),
                    horario_hfin = table.Column<string>(nullable: true),
                    horario_dia = table.Column<string>(nullable: true),
                    idmedico = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.idhorario);
                    table.ForeignKey(
                        name: "FK_Horario_Medico_idmedico",
                        column: x => x.idmedico,
                        principalTable: "Medico",
                        principalColumn: "idmedico",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    idpaciente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idpersona = table.Column<int>(nullable: false),
                    idusuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.idpaciente);
                    table.ForeignKey(
                        name: "FK_Paciente_Persona_idpersona",
                        column: x => x.idpersona,
                        principalTable: "Persona",
                        principalColumn: "idpersona",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paciente_Usuario_idusuario",
                        column: x => x.idusuario,
                        principalTable: "Usuario",
                        principalColumn: "idusuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publicacion",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mensaje = table.Column<string>(nullable: true),
                    megusta = table.Column<int>(nullable: false),
                    usuario_user = table.Column<string>(nullable: true),
                    nombrefoto = table.Column<string>(nullable: true),
                    fecha_publicacion = table.Column<string>(nullable: true),
                    idusuario = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicacion", x => x.id);
                    table.ForeignKey(
                        name: "FK_Publicacion_Usuario_idusuario",
                        column: x => x.idusuario,
                        principalTable: "Usuario",
                        principalColumn: "idusuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    idcita = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idpaciente = table.Column<int>(nullable: true),
                    idhorario = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.idcita);
                    table.ForeignKey(
                        name: "FK_Cita_Horario_idhorario",
                        column: x => x.idhorario,
                        principalTable: "Horario",
                        principalColumn: "idhorario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cita_Paciente_idpaciente",
                        column: x => x.idpaciente,
                        principalTable: "Paciente",
                        principalColumn: "idpaciente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cita_idhorario",
                table: "Cita",
                column: "idhorario");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_idpaciente",
                table: "Cita",
                column: "idpaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_idmedico",
                table: "Horario",
                column: "idmedico");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_idclinica",
                table: "Medico",
                column: "idclinica");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_idespecialidad",
                table: "Medico",
                column: "idespecialidad");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_idpersona",
                table: "Medico",
                column: "idpersona");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_idpersona",
                table: "Paciente",
                column: "idpersona");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_idusuario",
                table: "Paciente",
                column: "idusuario");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacion_idusuario",
                table: "Publicacion",
                column: "idusuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idtipousuario",
                table: "Usuario",
                column: "idtipousuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "Publicacion");

            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Clinica");

            migrationBuilder.DropTable(
                name: "Especialidad");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "TipoUsuario");
        }
    }
}
