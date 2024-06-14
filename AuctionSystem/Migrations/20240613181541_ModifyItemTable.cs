using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionSystem.Migrations
{
    /// <inheritdoc />
    public partial class ModifyItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Items",
                newName: "StartedPrice");

            migrationBuilder.AddColumn<string>(
                name: "HighestBidder",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "HighestPrice",
                table: "Items",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighestBidder",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "HighestPrice",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "StartedPrice",
                table: "Items",
                newName: "Price");
        }
    }
}
