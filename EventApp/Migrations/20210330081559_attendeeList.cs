using Microsoft.EntityFrameworkCore.Migrations;

namespace EventApp.Migrations
{
    public partial class attendeeList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Attendees_AttendeeID",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_AttendeeID",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "AttendeeID",
                table: "Events");

            migrationBuilder.CreateTable(
                name: "AttendeeEvent",
                columns: table => new
                {
                    AttendeesID = table.Column<int>(type: "int", nullable: false),
                    EventsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendeeEvent", x => new { x.AttendeesID, x.EventsID });
                    table.ForeignKey(
                        name: "FK_AttendeeEvent_Attendees_AttendeesID",
                        column: x => x.AttendeesID,
                        principalTable: "Attendees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendeeEvent_Events_EventsID",
                        column: x => x.EventsID,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendeeEvent_EventsID",
                table: "AttendeeEvent",
                column: "EventsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendeeEvent");

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
        }
    }
}
