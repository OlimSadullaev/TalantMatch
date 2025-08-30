using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalentMatch.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    KeyResponsibilities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qualifications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About_Us = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Benefits = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FitScore = table.Column<double>(type: "float(5)", precision: 5, scale: 2, nullable: false),
                    PostedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecruiterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LinkedIn = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CV = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplications_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobId",
                table: "JobApplications",
                column: "JobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
