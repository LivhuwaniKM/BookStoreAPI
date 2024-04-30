using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "ISBN", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "Robert C. Martin", "8797-ADGH-IWNJ", "Clean Code", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides", "978-0201633610", "Design Patterns: Elements of Reusable Object-Oriented Software", new DateTime(1994, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Andrew Hunt, David Thomas", "978-0201616224", "The Pragmatic Programmer", new DateTime(1999, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Guido van Rossum", "672-2638643868", "Python Programming", new DateTime(2001, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
