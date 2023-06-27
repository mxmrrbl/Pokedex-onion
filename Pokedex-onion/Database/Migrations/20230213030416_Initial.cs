using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokedex.Infrastructure.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PokemonTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type1 = table.Column<int>(type: "int", nullable: false),
                    type2 = table.Column<int>(type: "int", nullable: true),
                    region = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pokemons_PokemonTypes_type1",
                        column: x => x.type1,
                        principalTable: "PokemonTypes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Pokemons_PokemonTypes_type2",
                        column: x => x.type2,
                        principalTable: "PokemonTypes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Pokemons_Regions_region",
                        column: x => x.region,
                        principalTable: "Regions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_region",
                table: "Pokemons",
                column: "region");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_type1",
                table: "Pokemons",
                column: "type1");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_type2",
                table: "Pokemons",
                column: "type2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemons");

            migrationBuilder.DropTable(
                name: "PokemonTypes");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
