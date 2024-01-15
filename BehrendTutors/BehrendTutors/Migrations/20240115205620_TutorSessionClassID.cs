using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BehrendTutors.Migrations
{
    /// <inheritdoc />
    public partial class TutorSessionClassID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TutorClass_TutorSession_TutorSessionid",
                table: "TutorClass");

            migrationBuilder.DropForeignKey(
                name: "FK_TutorSession_TutorClass_TutorClassTutorId_TutorClassClassId",
                table: "TutorSession");

            migrationBuilder.DropIndex(
                name: "IX_TutorSession_TutorClassTutorId_TutorClassClassId",
                table: "TutorSession");

            migrationBuilder.DropIndex(
                name: "IX_TutorClass_TutorSessionid",
                table: "TutorClass");

            migrationBuilder.DropColumn(
                name: "TutorSessionid",
                table: "TutorClass");

            migrationBuilder.RenameColumn(
                name: "TutorClassTutorId",
                table: "TutorSession",
                newName: "TutorId");

            migrationBuilder.RenameColumn(
                name: "TutorClassClassId",
                table: "TutorSession",
                newName: "Classid");

            migrationBuilder.CreateIndex(
                name: "IX_TutorSession_Classid",
                table: "TutorSession",
                column: "Classid");

            migrationBuilder.CreateIndex(
                name: "IX_TutorSession_TutorId",
                table: "TutorSession",
                column: "TutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TutorSession_Class_Classid",
                table: "TutorSession",
                column: "Classid",
                principalTable: "Class",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_TutorSession_Tutor_TutorId",
                table: "TutorSession",
                column: "TutorId",
                principalTable: "Tutor",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TutorSession_Class_Classid",
                table: "TutorSession");

            migrationBuilder.DropForeignKey(
                name: "FK_TutorSession_Tutor_TutorId",
                table: "TutorSession");

            migrationBuilder.DropIndex(
                name: "IX_TutorSession_Classid",
                table: "TutorSession");

            migrationBuilder.DropIndex(
                name: "IX_TutorSession_TutorId",
                table: "TutorSession");

            migrationBuilder.RenameColumn(
                name: "TutorId",
                table: "TutorSession",
                newName: "TutorClassTutorId");

            migrationBuilder.RenameColumn(
                name: "Classid",
                table: "TutorSession",
                newName: "TutorClassClassId");

            migrationBuilder.AddColumn<int>(
                name: "TutorSessionid",
                table: "TutorClass",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TutorSession_TutorClassTutorId_TutorClassClassId",
                table: "TutorSession",
                columns: new[] { "TutorClassTutorId", "TutorClassClassId" });

            migrationBuilder.CreateIndex(
                name: "IX_TutorClass_TutorSessionid",
                table: "TutorClass",
                column: "TutorSessionid");

            migrationBuilder.AddForeignKey(
                name: "FK_TutorClass_TutorSession_TutorSessionid",
                table: "TutorClass",
                column: "TutorSessionid",
                principalTable: "TutorSession",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_TutorSession_TutorClass_TutorClassTutorId_TutorClassClassId",
                table: "TutorSession",
                columns: new[] { "TutorClassTutorId", "TutorClassClassId" },
                principalTable: "TutorClass",
                principalColumns: new[] { "TutorId", "ClassId" });
        }
    }
}
