using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaExpress.Web.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageUrl = table.Column<string>(nullable: false),
                    Título = table.Column<string>(nullable: false),
                    TítuloOriginal = table.Column<string>(nullable: false),
                    VideoUrl = table.Column<string>(nullable: false),
                    Año = table.Column<string>(nullable: false),
                    Reparto = table.Column<string>(nullable: false),
                    Géneros = table.Column<string>(nullable: false),
                    Idioma = table.Column<string>(nullable: false),
                    Calidad = table.Column<string>(nullable: false),
                    Sinópsis = table.Column<string>(nullable: false),
                    TrailerUrl = table.Column<string>(nullable: false),
                    LastSale = table.Column<DateTime>(nullable: true),
                    IsAvailabe = table.Column<bool>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
