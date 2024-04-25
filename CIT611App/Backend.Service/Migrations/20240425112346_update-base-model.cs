using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Service.Migrations
{
    /// <inheritdoc />
    public partial class updatebasemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyID",
                schema: "User",
                table: "UserAction");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "User",
                table: "UserAction");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                schema: "User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                schema: "User",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "User",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                schema: "Profile",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Profile",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                schema: "Order",
                table: "OrderLog");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Order",
                table: "OrderLog");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                schema: "Order",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Order",
                table: "Order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                schema: "User",
                table: "UserAction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "User",
                table: "UserAction",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                schema: "User",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "User",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                schema: "User",
                table: "Token",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "User",
                table: "Token",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                schema: "Profile",
                table: "Profile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Profile",
                table: "Profile",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                schema: "Order",
                table: "OrderLog",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Order",
                table: "OrderLog",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                schema: "Order",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Order",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
