using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestJob.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserStatistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CountSignIn = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStatistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Percent = table.Column<int>(type: "integer", nullable: false),
                    UserStatisticsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestStatuses_UserStatistics_UserStatisticsId",
                        column: x => x.UserStatisticsId,
                        principalTable: "UserStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UserStatistics",
                columns: new[] { "Id", "CountSignIn" },
                values: new object[,]
                {
                    { new Guid("0771e564-238c-4b6e-8b6e-096ddbbd2b91"), 5 },
                    { new Guid("7c68acd4-6461-4cca-a11b-bc58192b4c92"), 12 },
                    { new Guid("c6e77341-b5c6-4ec2-817f-73232a981124"), 7 },
                    { new Guid("e390e96f-d2f8-4148-8378-b76739f24082"), 103 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestStatuses_UserStatisticsId",
                table: "RequestStatuses",
                column: "UserStatisticsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestStatuses");

            migrationBuilder.DropTable(
                name: "UserStatistics");
        }
    }
}
