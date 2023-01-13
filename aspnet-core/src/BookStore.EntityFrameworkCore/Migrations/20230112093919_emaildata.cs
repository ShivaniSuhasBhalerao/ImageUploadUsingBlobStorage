using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    public partial class emaildata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppEmailConfigration",
                table: "AppEmailConfigration");

            migrationBuilder.RenameTable(
                name: "AppEmailConfigration",
                newName: "EmailConfigration");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EmailConfigration",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailConfigration",
                table: "EmailConfigration",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailConfigration",
                table: "EmailConfigration");

            migrationBuilder.RenameTable(
                name: "EmailConfigration",
                newName: "AppEmailConfigration");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AppEmailConfigration",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppEmailConfigration",
                table: "AppEmailConfigration",
                column: "Id");
        }
    }
}
