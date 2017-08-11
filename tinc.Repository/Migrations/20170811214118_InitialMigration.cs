using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tinc.Repository.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sport",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Responsible = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sport", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EventDate = table.Column<DateTime>(nullable: false),
                    FilePath = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Local = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Responsible = table.Column<string>(nullable: true),
                    SportID = table.Column<Guid>(nullable: true),
                    Website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Event_Sport_SportID",
                        column: x => x.SportID,
                        principalTable: "Sport",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    Nacionality = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TeamID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Person_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Competition",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Distance = table.Column<float>(nullable: false),
                    EventID = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    Responsible = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competition", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Competition_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Extra",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EventID = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    Responsible = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extra", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Extra_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AthleteType = table.Column<string>(nullable: true),
                    CompetitionID = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    MaxAge = table.Column<int>(nullable: false),
                    MinAge = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NumberOfWinners = table.Column<int>(nullable: false),
                    Responsible = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Category_Competition_CompetitionID",
                        column: x => x.CompetitionID,
                        principalTable: "Competition",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CategoryID = table.Column<Guid>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    PersonID = table.Column<Guid>(nullable: true),
                    RegistrationBy = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Enrollment_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollment_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CategoryID = table.Column<Guid>(nullable: true),
                    CompetitionID = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Responsible = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Result_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Result_Competition_CompetitionID",
                        column: x => x.CompetitionID,
                        principalTable: "Competition",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_CompetitionID",
                table: "Category",
                column: "CompetitionID");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_EventID",
                table: "Competition",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_CategoryID",
                table: "Enrollment",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_PersonID",
                table: "Enrollment",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Event_SportID",
                table: "Event",
                column: "SportID");

            migrationBuilder.CreateIndex(
                name: "IX_Extra_EventID",
                table: "Extra",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Person_TeamID",
                table: "Person",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Result_CategoryID",
                table: "Result",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Result_CompetitionID",
                table: "Result",
                column: "CompetitionID");

            migrationBuilder.CreateIndex(
                name: "IX_Sport_Name",
                table: "Sport",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Extra");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Competition");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Sport");
        }
    }
}
