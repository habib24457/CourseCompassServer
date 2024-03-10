using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseCompassServer.Migrations
{
    /// <inheritdoc />
    public partial class updatedDelMethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insights_Courses_CourseId",
                table: "Insights");

            migrationBuilder.DropForeignKey(
                name: "FK_Insights_Student_StudentUserId",
                table: "Insights");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Courses_CourseId",
                table: "Student");

            migrationBuilder.AddForeignKey(
                name: "FK_Insights_Courses_CourseId",
                table: "Insights",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Insights_Student_StudentUserId",
                table: "Insights",
                column: "StudentUserId",
                principalTable: "Student",
                principalColumn: "StudentUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Courses_CourseId",
                table: "Student",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insights_Courses_CourseId",
                table: "Insights");

            migrationBuilder.DropForeignKey(
                name: "FK_Insights_Student_StudentUserId",
                table: "Insights");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Courses_CourseId",
                table: "Student");

            migrationBuilder.AddForeignKey(
                name: "FK_Insights_Courses_CourseId",
                table: "Insights",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Insights_Student_StudentUserId",
                table: "Insights",
                column: "StudentUserId",
                principalTable: "Student",
                principalColumn: "StudentUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Courses_CourseId",
                table: "Student",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
