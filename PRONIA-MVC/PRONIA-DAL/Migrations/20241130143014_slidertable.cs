using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRONIA_DAL.Migrations
{
    /// <inheritdoc />
    public partial class slidertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SliderItesms",
                table: "SliderItesms");

            migrationBuilder.RenameTable(
                name: "SliderItesms",
                newName: "SliderItem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SliderItem",
                table: "SliderItem",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SliderItem",
                table: "SliderItem");

            migrationBuilder.RenameTable(
                name: "SliderItem",
                newName: "SliderItesms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SliderItesms",
                table: "SliderItesms",
                column: "Id");
        }
    }
}
