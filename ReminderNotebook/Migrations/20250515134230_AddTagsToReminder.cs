using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReminderNotebook.Migrations
{
    /// <inheritdoc />
    public partial class AddTagsToReminder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Reminders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Reminders");
        }
    }
}
