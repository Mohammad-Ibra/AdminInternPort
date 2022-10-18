using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminInternPort.Migrations
{
    public partial class changingInDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProgramId",
                table: "Instructors");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Instructors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Instructors");

            migrationBuilder.AddColumn<int>(
                name: "ProgramId",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
