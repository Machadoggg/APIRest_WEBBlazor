using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIRest_WEBBlazor.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_Name",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "Document",
                table: "Customers",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Document",
                table: "Customers",
                column: "Document",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_Document",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Document",
                table: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Name",
                table: "Customers",
                column: "Name",
                unique: true);
        }
    }
}
