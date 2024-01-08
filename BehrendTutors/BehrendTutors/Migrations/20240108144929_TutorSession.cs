using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BehrendTutors.Migrations
{
    /// <inheritdoc />
    public partial class TutorSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TutorSession",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Classid = table.Column<int>(type: "int", nullable: true),
                    TutorId = table.Column<int>(type: "int", nullable: true),
                    StudentEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorSession", x => x.id);
                    table.ForeignKey(
                        name: "FK_TutorSession_Class_Classid",
                        column: x => x.Classid,
                        principalTable: "Class",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TutorSession_Tutor_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TutorSession_Classid",
                table: "TutorSession",
                column: "Classid");

            migrationBuilder.CreateIndex(
                name: "IX_TutorSession_TutorId",
                table: "TutorSession",
                column: "TutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TutorSession");
        }
    }
}
