using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunShield.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Schedule",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Sessions",
                newName: "Language");

            migrationBuilder.RenameColumn(
                name: "Attendance",
                table: "Sessions",
                newName: "DayOfWeek");

            migrationBuilder.AlterColumn<int>(
                name: "Grade",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "SessionID",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "SessionID",
                table: "Sessions",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "SessionType",
                table: "Sessions",
                type: "TEXT",
                maxLength: 1,
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Students_StudentID",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_StudentID",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "SessionID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SessionType",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Sessions");

            migrationBuilder.RenameColumn(
                name: "Language",
                table: "Sessions",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "DayOfWeek",
                table: "Sessions",
                newName: "Attendance");

            migrationBuilder.AlterColumn<string>(
                name: "Grade",
                table: "Students",
                type: "TEXT",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "SessionID",
                table: "Sessions",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Schedule",
                table: "Courses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
