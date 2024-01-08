using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BehrendTutors.Migrations
{
    /// <inheritdoc />
    public partial class Tutors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TutorId",
                table: "Class",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tutor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Class_TutorId",
                table: "Class",
                column: "TutorId");

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

            migrationBuilder.DropTable(
                name: "Tutor");

            migrationBuilder.DropIndex(
                name: "IX_Class_TutorId",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "TutorId",
                table: "Class");
        }
    }
}
