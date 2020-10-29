using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DogTraining.Migrations
{
    public partial class DogTrainingDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dog",
                columns: table => new
                {
                    DogID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Breed = table.Column<string>(maxLength: 20, nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Neutered = table.Column<bool>(nullable: false),
                    Microchip = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dog", x => x.DogID);
                });

            migrationBuilder.CreateTable(
                name: "Trainer",
                columns: table => new
                {
                    TrainerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer", x => x.TrainerID);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    SchedID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogID = table.Column<int>(nullable: false),
                    TrainerID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.SchedID);
                    table.ForeignKey(
                        name: "FK_Schedule_Dog_DogID",
                        column: x => x.DogID,
                        principalTable: "Dog",
                        principalColumn: "DogID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedule_Trainer_TrainerID",
                        column: x => x.TrainerID,
                        principalTable: "Trainer",
                        principalColumn: "TrainerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_DogID",
                table: "Schedule",
                column: "DogID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_TrainerID",
                table: "Schedule",
                column: "TrainerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Dog");

            migrationBuilder.DropTable(
                name: "Trainer");
        }
    }
}
