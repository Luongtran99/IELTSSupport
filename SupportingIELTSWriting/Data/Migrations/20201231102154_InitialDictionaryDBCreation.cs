using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportingIELTSWriting.Data.Migrations
{
    public partial class InitialDictionaryDBCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    wordId = table.Column<string>(nullable: false),
                    word = table.Column<string>(maxLength: 50, nullable: false),
                    popularCount = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY_KEY_WORD", x => x.wordId);
                });

            migrationBuilder.CreateTable(
                name: "Meanings",
                columns: table => new
                {
                    meaningId = table.Column<string>(nullable: false),
                    partOfSpeech = table.Column<string>(nullable: true),
                    wordId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY_KEY_MEANING", x => x.meaningId);
                    table.ForeignKey(
                        name: "FK_Meanings_Words_wordId",
                        column: x => x.wordId,
                        principalTable: "Words",
                        principalColumn: "wordId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phonetics",
                columns: table => new
                {
                    phoneticId = table.Column<string>(nullable: false),
                    text = table.Column<string>(nullable: true),
                    audio = table.Column<string>(nullable: true),
                    wordId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY_KEY_PHONETIC", x => x.phoneticId);
                    table.ForeignKey(
                        name: "FK_Phonetics_Words_wordId",
                        column: x => x.wordId,
                        principalTable: "Words",
                        principalColumn: "wordId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Definitions",
                columns: table => new
                {
                    definitionId = table.Column<string>(nullable: false),
                    definition = table.Column<string>(nullable: true),
                    example = table.Column<string>(nullable: true),
                    meaningId = table.Column<string>(nullable: true),
                    synonyms = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY_KEY_DEFINITION", x => x.definitionId);
                    table.ForeignKey(
                        name: "FK_Definitions_Meanings_meaningId",
                        column: x => x.meaningId,
                        principalTable: "Meanings",
                        principalColumn: "meaningId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Definitions_meaningId",
                table: "Definitions",
                column: "meaningId");

            migrationBuilder.CreateIndex(
                name: "IX_Meanings_wordId",
                table: "Meanings",
                column: "wordId");

            migrationBuilder.CreateIndex(
                name: "IX_Phonetics_wordId",
                table: "Phonetics",
                column: "wordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Definitions");

            migrationBuilder.DropTable(
                name: "Phonetics");

            migrationBuilder.DropTable(
                name: "Meanings");

            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
