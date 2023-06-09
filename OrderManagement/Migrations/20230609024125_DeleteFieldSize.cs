using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class DeleteFieldSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "TypeProduct");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "TypeProduct",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
