using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminInternPort.Migrations
{
    public partial class changeForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProgramId",
                table: "Interns");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Interns",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Interns");

            migrationBuilder.AddColumn<int>(
                name: "ProgramId",
                table: "Interns",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
