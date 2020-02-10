using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniverseKino.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CinemaHalls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaHalls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Genre = table.Column<string>(nullable: false),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCinemaHall = table.Column<int>(nullable: false),
                    CinemaHallId = table.Column<int>(nullable: true),
                    Cost = table.Column<decimal>(nullable: false),
                    Row = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_CinemaHalls_CinemaHallId",
                        column: x => x.CinemaHallId,
                        principalTable: "CinemaHalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    MovieId = table.Column<int>(nullable: false),
                    CinemaHallId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_CinemaHalls_CinemaHallId",
                        column: x => x.CinemaHallId,
                        principalTable: "CinemaHalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessions_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatId = table.Column<int>(nullable: false),
                    SessionId = table.Column<int>(nullable: false),
                    Paid = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    UserNameId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_ApplicationUsers_UserNameId",
                        column: x => x.UserNameId,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CinemaHalls",
                columns: new[] { "Id", "Number" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Duration", "Genre", "Name" },
                values: new object[,]
                {
                    { 1, 182, "Action, superhero, adventure, science fiction, fantasy", "Avengers" },
                    { 2, 131, "Crime, drama, mysticism", "Knives" },
                    { 3, 124, "Action, comedy, crime", "Bad boys" }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CinemaHallId", "Cost", "IdCinemaHall", "Number", "Row" },
                values: new object[,]
                {
                    { 18, null, 150m, 1, 1, 6 },
                    { 19, null, 150m, 1, 1, 7 },
                    { 20, null, 150m, 1, 1, 8 },
                    { 21, null, 150m, 1, 1, 9 },
                    { 22, null, 150m, 1, 1, 10 },
                    { 23, null, 200m, 1, 1, 1 },
                    { 26, null, 200m, 1, 1, 4 },
                    { 25, null, 200m, 1, 1, 3 },
                    { 17, null, 150m, 1, 1, 5 },
                    { 27, null, 200m, 1, 1, 5 },
                    { 28, null, 200m, 1, 1, 6 },
                    { 29, null, 200m, 1, 1, 7 },
                    { 24, null, 200m, 1, 1, 2 },
                    { 16, null, 150m, 1, 1, 4 },
                    { 12, null, 100m, 1, 1, 5 },
                    { 14, null, 150m, 1, 1, 2 },
                    { 13, null, 150m, 1, 1, 1 },
                    { 30, null, 200m, 1, 1, 8 },
                    { 11, null, 100m, 1, 1, 4 },
                    { 10, null, 100m, 1, 1, 3 },
                    { 9, null, 100m, 1, 1, 2 },
                    { 8, null, 100m, 1, 1, 1 },
                    { 7, null, 100m, 1, 1, 7 },
                    { 6, null, 100m, 1, 1, 6 },
                    { 5, null, 100m, 1, 1, 5 },
                    { 4, null, 100m, 1, 1, 4 },
                    { 3, null, 100m, 1, 1, 3 },
                    { 2, null, 100m, 1, 1, 2 },
                    { 1, null, 100m, 1, 1, 1 },
                    { 15, null, 150m, 1, 1, 3 },
                    { 31, null, 200m, 1, 1, 9 }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "CinemaHallId", "Date", "MovieId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 3, new DateTime(2020, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 3, new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, 1, new DateTime(2020, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SeatId",
                table: "Reservations",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SessionId",
                table: "Reservations",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserNameId",
                table: "Reservations",
                column: "UserNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_CinemaHallId",
                table: "Seats",
                column: "CinemaHallId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_CinemaHallId",
                table: "Sessions",
                column: "CinemaHallId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_MovieId",
                table: "Sessions",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "CinemaHalls");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
