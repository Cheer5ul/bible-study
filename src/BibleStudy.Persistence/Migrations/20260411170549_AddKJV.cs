using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibleStudy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddKJV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Translations_TranslationAbbrev",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_TranslationAbbrev",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Translations",
                table: "Translations");

            migrationBuilder.RenameTable(
                name: "Translations",
                newName: "Translation");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Translation",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Translation",
                table: "Translation",
                column: "TranslationAbbrev");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Translation",
                table: "Translation");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Translation");

            migrationBuilder.RenameTable(
                name: "Translation",
                newName: "Translations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Translations",
                table: "Translations",
                column: "TranslationAbbrev");

            migrationBuilder.CreateIndex(
                name: "IX_Books_TranslationAbbrev",
                table: "Books",
                column: "TranslationAbbrev");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Translations_TranslationAbbrev",
                table: "Books",
                column: "TranslationAbbrev",
                principalTable: "Translations",
                principalColumn: "TranslationAbbrev",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
