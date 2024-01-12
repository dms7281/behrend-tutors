using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BehrendTutors.Migrations
{
    /// <inheritdoc />
    public partial class ClassT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_Tutor_TutorId",
                table: "Class");

            migrationBuilder.AlterColumn<int>(
                name: "TutorId",
                table: "Class",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Class_Tutor_TutorId",
                table: "Class",
                column: "TutorId",
                principalTable: "Tutor",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_Tutor_TutorId",
                table: "Class");

            migrationBuilder.AlterColumn<int>(
                name: "TutorId",
                table: "Class",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Class_Tutor_TutorId",
                table: "Class",
                column: "TutorId",
                principalTable: "Tutor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
