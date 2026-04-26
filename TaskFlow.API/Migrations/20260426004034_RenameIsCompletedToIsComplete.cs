using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskFlow.API.Migrations
{
    /// <inheritdoc />
    public partial class RenameIsCompletedToIsComplete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCompleted",
                table: "TaskItems",
                newName: "IsComplete");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsComplete",
                table: "TaskItems",
                newName: "IsCompleted");
        }
    }
}
