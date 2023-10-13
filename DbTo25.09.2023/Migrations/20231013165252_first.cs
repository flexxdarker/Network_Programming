using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DbTo25._09._2023.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Farewells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Farewells = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farewells", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FellAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answers = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FellAnswers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Greets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Greets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherAnswers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Farewells",
                columns: new[] { "Id", "Farewells" },
                values: new object[,]
                {
                    { 1, "See u later" },
                    { 2, "Bye" },
                    { 3, "Auf Wiedersehen!" }
                });

            migrationBuilder.InsertData(
                table: "FellAnswers",
                columns: new[] { "Id", "Answers" },
                values: new object[,]
                {
                    { 1, "I'm fine" },
                    { 2, "As usual" },
                    { 3, "Bad" },
                    { 4, "Wie zu Hitlers Lebzeiten!" }
                });

            migrationBuilder.InsertData(
                table: "Greets",
                columns: new[] { "Id", "Answer" },
                values: new object[,]
                {
                    { 1, "Hello" },
                    { 2, "Hi Gitler" },
                    { 3, "Good afternoon" }
                });

            migrationBuilder.InsertData(
                table: "WeatherAnswers",
                columns: new[] { "Id", "Answer" },
                values: new object[,]
                {
                    { 1, "Warm" },
                    { 2, "Not too warm" },
                    { 3, "Cold" },
                    { 4, "Wie im 2. Weltkrieg!" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Farewells");

            migrationBuilder.DropTable(
                name: "FellAnswers");

            migrationBuilder.DropTable(
                name: "Greets");

            migrationBuilder.DropTable(
                name: "WeatherAnswers");
        }
    }
}
