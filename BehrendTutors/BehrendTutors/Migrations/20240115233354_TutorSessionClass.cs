using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BehrendTutors.Migrations
{
    /// <inheritdoc />
    public partial class TutorSessionClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TutorSession_Tutor_TutorId",
                table: "TutorSession");

            migrationBuilder.RenameColumn(
                name: "TutorId",
                table: "TutorSession",
                newName: "TutorId1");

            migrationBuilder.RenameIndex(
                name: "IX_TutorSession_TutorId",
                table: "TutorSession",
                newName: "IX_TutorSession_TutorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TutorSession_Tutor_TutorId1",
                table: "TutorSession",
                column: "TutorId1",
                principalTable: "Tutor",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TutorSession_Tutor_TutorId1",
                table: "TutorSession");

            migrationBuilder.RenameColumn(
                name: "TutorId1",
                table: "TutorSession",
                newName: "TutorId");

            migrationBuilder.RenameIndex(
                name: "IX_TutorSession_TutorId1",
                table: "TutorSession",
                newName: "IX_TutorSession_TutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TutorSession_Tutor_TutorId",
                table: "TutorSession",
                column: "TutorId",
                principalTable: "Tutor",
                principalColumn: "Id");
        }
    }
}
