using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryApp.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "PickUpRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestId",
                table: "PickUpRequests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "PickUpRequests");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "PickUpRequests");
        }
    }
}
