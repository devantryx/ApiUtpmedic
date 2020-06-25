using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiUtpmedic.Migrations
{
    public partial class MigracionMedicamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicamento",
                columns: table => new
                {
                    idmedicamento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    medicamento_nombre = table.Column<string>(nullable: true),
                    medicamento_presenta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamento", x => x.idmedicamento);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicamento");
        }
    }
}
