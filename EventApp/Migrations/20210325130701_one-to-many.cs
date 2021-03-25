using Microsoft.EntityFrameworkCore.Migrations;

namespace EventApp.Migrations
{
    public partial class onetomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organizers_OrganizerID",
                table: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizerID",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organizers_OrganizerID",
                table: "Events",
                column: "OrganizerID",
                principalTable: "Organizers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organizers_OrganizerID",
                table: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizerID",
                table: "Events",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organizers_OrganizerID",
                table: "Events",
                column: "OrganizerID",
                principalTable: "Organizers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
