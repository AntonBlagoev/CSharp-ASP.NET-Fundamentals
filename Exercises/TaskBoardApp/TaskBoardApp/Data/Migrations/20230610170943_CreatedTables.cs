using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class CreatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8f948fc0-6be1-496c-8b5a-5a6f0bcd1923", 0, "40e05252-215d-4f71-8fc9-739d10e59e31", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAELIeLJgxLDwH0HPzk31aJ3Y7ks82mRvlnVRHcyPhlRvhrYcRHELaZGlkphpYO/JvDg==", null, false, "f2f31d89-5791-4eb0-9f87-e729de78920c", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 11, 22, 20, 9, 42, 437, DateTimeKind.Local).AddTicks(5856), "Implement better styling for all public pages", "8f948fc0-6be1-496c-8b5a-5a6f0bcd1923", "Improve CSS styles", null },
                    { 2, 3, new DateTime(2023, 1, 10, 20, 9, 42, 437, DateTimeKind.Local).AddTicks(6346), "Create Android client app for the TaskBoard RESTful API", "8f948fc0-6be1-496c-8b5a-5a6f0bcd1923", "Android Client App", null },
                    { 3, 2, new DateTime(2023, 6, 9, 20, 9, 42, 437, DateTimeKind.Local).AddTicks(6380), "Ceate Windows Forms desktop app client for the TaskBoard RESTful API", "8f948fc0-6be1-496c-8b5a-5a6f0bcd1923", "Desktop Client App", null },
                    { 4, 3, new DateTime(2022, 6, 10, 20, 9, 42, 437, DateTimeKind.Local).AddTicks(6401), "Implemet [Create Task] page for adding new tasks", "8f948fc0-6be1-496c-8b5a-5a6f0bcd1923", "Create Tasks", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f948fc0-6be1-496c-8b5a-5a6f0bcd1923");
        }
    }
}
