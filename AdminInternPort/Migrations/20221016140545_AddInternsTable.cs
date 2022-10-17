using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminInternPort.Migrations
{
    public partial class AddInternsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Program",
                table: "Program");

            migrationBuilder.RenameTable(
                name: "Program",
                newName: "ProgramTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramTable",
                table: "ProgramTable",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Intern",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    University = table.Column<string>(nullable: true),
                    Major = table.Column<string>(nullable: true),
                    GraduationDate = table.Column<DateTime>(nullable: false),
                    ProgramId = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ValidEmail = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intern", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Intern");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramTable",
                table: "ProgramTable");

            migrationBuilder.RenameTable(
                name: "ProgramTable",
                newName: "Program");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Program",
                table: "Program",
                column: "Id");
        }
    }
}
