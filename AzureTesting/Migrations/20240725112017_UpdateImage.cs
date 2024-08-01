using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzureTesting.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileBlob",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "year",
                table: "Leagues",
                newName: "Year");

            migrationBuilder.AddColumn<string>(
                name: "BlobUrl",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlobUrl",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Leagues",
                newName: "year");

            migrationBuilder.AddColumn<byte[]>(
                name: "FileBlob",
                table: "Images",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
