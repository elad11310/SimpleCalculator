﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpleCalculator.Migrations
{
    /// <inheritdoc />
    public partial class AddActionsTableAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Operation = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "Id", "Description", "Operation" },
                values: new object[,]
                {
                    { 1, "Perform addition", "Addition" },
                    { 2, "Perform subtraction", "Subtraction" },
                    { 3, "Perform division", "Division" },
                    { 4, "Perform multiplication", "Multiplication" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actions_Operation",
                table: "Actions",
                column: "Operation",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actions");
        }
    }
}
