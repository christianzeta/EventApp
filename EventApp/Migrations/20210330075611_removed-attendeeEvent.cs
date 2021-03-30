using Microsoft.EntityFrameworkCore.Migrations;

namespace EventApp.Migrations
{
    public partial class removedattendeeEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organizers_OrganizerID",
                table: "Events");

            migrationBuilder.DropTable(
                name: "AttendeeEvent");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizerID",
                table: "Events",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AttendeeID",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_AttendeeID",
                table: "Events",
                column: "AttendeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Attendees_AttendeeID",
                table: "Events",
                column: "AttendeeID",
                principalTable: "Attendees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organizers_OrganizerID",
                table: "Events",
                column: "OrganizerID",
                principalTable: "Organizers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Attendees_AttendeeID",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Organizers_OrganizerID",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_AttendeeID",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "AttendeeID",
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

            migrationBuilder.CreateTable(
                name: "AttendeeEvent",
                columns: table => new
                {
                    AttendeeId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendeeEvent", x => new { x.AttendeeId, x.EventId });
                    table.ForeignKey(
                        name: "FK_AttendeeEvent_Attendees_AttendeeId",
                        column: x => x.AttendeeId,
                        principalTable: "Attendees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendeeEvent_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendeeEvent_EventId",
                table: "AttendeeEvent",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Organizers_OrganizerID",
                table: "Events",
                column: "OrganizerID",
                principalTable: "Organizers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
