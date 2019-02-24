using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QueryMutator.Tests.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SmallDogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmallDogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    EntityProperty = table.Column<int>(nullable: false),
                    Ignored = table.Column<string>(nullable: true),
                    SmallDogId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dogs_SmallDogs_SmallDogId",
                        column: x => x.SmallDogId,
                        principalTable: "SmallDogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "SmallDogs",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Small Bodri" });

            migrationBuilder.InsertData(
                table: "SmallDogs",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Small Pimpedli" });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "EntityProperty", "Ignored", "Name", "SmallDogId" },
                values: new object[] { 1, 5, "IGNORE!", "Bodri", 1 });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "EntityProperty", "Ignored", "Name", "SmallDogId" },
                values: new object[] { 2, 10, null, "Pimpedli", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_SmallDogId",
                table: "Dogs",
                column: "SmallDogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "SmallDogs");
        }
    }
}
