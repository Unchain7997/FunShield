using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunShield.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentCourseRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Students_StudentID",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_StudentID",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Sessions");

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.StudentID, x.CourseID });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseID",
                table: "StudentCourses",
                column: "CourseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "Sessions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_StudentID",
                table: "Sessions",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Students_StudentID",
                table: "Sessions",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "StudentID");
        }
    }
}
