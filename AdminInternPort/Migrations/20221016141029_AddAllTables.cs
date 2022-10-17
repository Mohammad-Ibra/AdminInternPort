using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminInternPort.Migrations
{
    public partial class AddAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramTable",
                table: "ProgramTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Intern",
                table: "Intern");

            migrationBuilder.RenameTable(
                name: "ProgramTable",
                newName: "Program");

            migrationBuilder.RenameTable(
                name: "Intern",
                newName: "Interns");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Program",
                table: "Program",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interns",
                table: "Interns",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    AssessmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamUrl = table.Column<string>(nullable: true),
                    ProgramId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.AssessmentId);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    InstructorEmployer = table.Column<bool>(nullable: false),
                    Major = table.Column<string>(nullable: true),
                    ProgramId = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Program",
                table: "Program");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interns",
                table: "Interns");

            migrationBuilder.RenameTable(
                name: "Program",
                newName: "ProgramTable");

            migrationBuilder.RenameTable(
                name: "Interns",
                newName: "Intern");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramTable",
                table: "ProgramTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Intern",
                table: "Intern",
                column: "Id");
        }
    }
}
