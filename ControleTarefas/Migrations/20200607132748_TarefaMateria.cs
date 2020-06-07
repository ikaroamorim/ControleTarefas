using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleTarefas.Migrations
{
    public partial class TarefaMateria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Materia",
                table: "Tarefa",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Materia",
                table: "Tarefa");
        }
    }
}
