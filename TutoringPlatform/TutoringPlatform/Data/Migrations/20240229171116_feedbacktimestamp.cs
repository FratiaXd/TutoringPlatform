using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutoringPlatform.Migrations
{
    /// <inheritdoc />
    public partial class feedbacktimestamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FeedbackTimeStamp",
                table: "LessonProgresses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeedbackTimeStamp",
                table: "LessonProgresses");
        }
    }
}
