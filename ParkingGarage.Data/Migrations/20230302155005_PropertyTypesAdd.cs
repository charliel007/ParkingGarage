using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingGarage.Data.Migrations
{
    /// <inheritdoc />
    public partial class PropertyTypesAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_AspNetUsers_UserEntityId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_UserEntityId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "UserEntityId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserEntityId1",
                table: "Vehicles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserEntityId1",
                table: "Vehicles",
                column: "UserEntityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_AspNetUsers_UserEntityId1",
                table: "Vehicles",
                column: "UserEntityId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_AspNetUsers_UserEntityId1",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_UserEntityId1",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "UserEntityId1",
                table: "Vehicles");

            migrationBuilder.AlterColumn<string>(
                name: "UserEntityId",
                table: "Vehicles",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserEntityId",
                table: "Vehicles",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_AspNetUsers_UserEntityId",
                table: "Vehicles",
                column: "UserEntityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
