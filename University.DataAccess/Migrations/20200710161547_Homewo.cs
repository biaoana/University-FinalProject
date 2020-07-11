using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace University.DataAccess.Migrations
{
    public partial class Homewo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Homeworks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AssignmentID = table.Column<Guid>(nullable: true),
                    StudentIdUserID = table.Column<Guid>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homeworks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Homeworks_Assignments_AssignmentID",
                        column: x => x.AssignmentID,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Homeworks_Users_StudentIdUserID",
                        column: x => x.StudentIdUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    HomeworkId = table.Column<Guid>(nullable: true),
                    StudentIdUserID = table.Column<Guid>(nullable: true),
                    Mark = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Homeworks_HomeworkId",
                        column: x => x.HomeworkId,
                        principalTable: "Homeworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Users_StudentIdUserID",
                        column: x => x.StudentIdUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_HomeworkId",
                table: "Grades",
                column: "HomeworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentIdUserID",
                table: "Grades",
                column: "StudentIdUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_AssignmentID",
                table: "Homeworks",
                column: "AssignmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_StudentIdUserID",
                table: "Homeworks",
                column: "StudentIdUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Homeworks");
        }
    }
}
