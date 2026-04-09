using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibleStudy.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addtranslationlanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Licence",
                table: "Translations",
                newName: "License");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "License",
                table: "Translations",
                newName: "Licence");
        }
    }
}
