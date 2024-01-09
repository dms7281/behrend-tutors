﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BehrendTutors.Migrations
{
    /// <inheritdoc />
    public partial class TutorClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_Tutor_TutorId",
                table: "Class");

            migrationBuilder.DropIndex(
                name: "IX_Class_TutorId",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "TutorId",
                table: "Class");

            migrationBuilder.CreateTable(
                name: "TutorClasses",
                columns: table => new
                {
                    TutorId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorClasses", x => new { x.TutorId, x.ClassId });
                    table.ForeignKey(
                        name: "FK_TutorClasses_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TutorClasses_Tutor_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TutorClasses_ClassId",
                table: "TutorClasses",
                column: "ClassId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TutorClasses");

            migrationBuilder.AddColumn<int>(
                name: "TutorId",
                table: "Class",
                type: "int",
                nullable: true);

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
    }
}