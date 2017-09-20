using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TenderTummiesAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Child",
                columns: table => new
                {
                    ChildID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Age = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: false),
                    UserID = table.Column<string>(nullable: false),
                    WtNumber = table.Column<int>(nullable: false),
                    WtUnit = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Child", x => x.ChildID);
                });

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    FoodID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.FoodID);
                });

            migrationBuilder.CreateTable(
                name: "Ingestion",
                columns: table => new
                {
                    IngestionID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingestion", x => x.IngestionID);
                });

            migrationBuilder.CreateTable(
                name: "Symptom",
                columns: table => new
                {
                    SymptomID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptom", x => x.SymptomID);
                });

            migrationBuilder.CreateTable(
                name: "Safe",
                columns: table => new
                {
                    SafeID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChildID = table.Column<int>(nullable: false),
                    FoodID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Safe", x => x.SafeID);
                    table.ForeignKey(
                        name: "FK_Safe_Child_ChildID",
                        column: x => x.ChildID,
                        principalTable: "Child",
                        principalColumn: "ChildID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Safe_Food_FoodID",
                        column: x => x.FoodID,
                        principalTable: "Food",
                        principalColumn: "FoodID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trigger",
                columns: table => new
                {
                    TriggerID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChildID = table.Column<int>(nullable: false),
                    FoodID = table.Column<int>(nullable: false),
                    Severity = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trigger", x => x.TriggerID);
                    table.ForeignKey(
                        name: "FK_Trigger_Child_ChildID",
                        column: x => x.ChildID,
                        principalTable: "Child",
                        principalColumn: "ChildID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trigger_Food_FoodID",
                        column: x => x.FoodID,
                        principalTable: "Food",
                        principalColumn: "FoodID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reaction",
                columns: table => new
                {
                    ReactionID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChildID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true, defaultValueSql: "null"),
                    FoodType = table.Column<string>(nullable: false),
                    IngestionID = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false, defaultValueSql: "strftime('%Y-%m-%d')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reaction", x => x.ReactionID);
                    table.ForeignKey(
                        name: "FK_Reaction_Child_ChildID",
                        column: x => x.ChildID,
                        principalTable: "Child",
                        principalColumn: "ChildID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reaction_Ingestion_IngestionID",
                        column: x => x.IngestionID,
                        principalTable: "Ingestion",
                        principalColumn: "IngestionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trial",
                columns: table => new
                {
                    TrialID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChildID = table.Column<int>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false, defaultValueSql: "strftime('%Y-%m-%d')"),
                    FoodID = table.Column<int>(nullable: false),
                    Pass = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false, defaultValueSql: "strftime('%Y-%m-%d')"),
                    TriggerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trial", x => x.TrialID);
                    table.ForeignKey(
                        name: "FK_Trial_Child_ChildID",
                        column: x => x.ChildID,
                        principalTable: "Child",
                        principalColumn: "ChildID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trial_Food_FoodID",
                        column: x => x.FoodID,
                        principalTable: "Food",
                        principalColumn: "FoodID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trial_Trigger_TriggerID",
                        column: x => x.TriggerID,
                        principalTable: "Trigger",
                        principalColumn: "TriggerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TriggerSymptom",
                columns: table => new
                {
                    TriggerSymptomID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Acute = table.Column<bool>(nullable: false),
                    Chronic = table.Column<bool>(nullable: false),
                    SymptomID = table.Column<int>(nullable: false),
                    TriggerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TriggerSymptom", x => x.TriggerSymptomID);
                    table.ForeignKey(
                        name: "FK_TriggerSymptom_Symptom_SymptomID",
                        column: x => x.SymptomID,
                        principalTable: "Symptom",
                        principalColumn: "SymptomID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TriggerSymptom_Trigger_TriggerID",
                        column: x => x.TriggerID,
                        principalTable: "Trigger",
                        principalColumn: "TriggerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReactionTrigger",
                columns: table => new
                {
                    ReactionTriggerID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReactionID = table.Column<int>(nullable: false),
                    TriggerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReactionTrigger", x => x.ReactionTriggerID);
                    table.ForeignKey(
                        name: "FK_ReactionTrigger_Reaction_ReactionID",
                        column: x => x.ReactionID,
                        principalTable: "Reaction",
                        principalColumn: "ReactionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReactionTrigger_Trigger_TriggerID",
                        column: x => x.TriggerID,
                        principalTable: "Trigger",
                        principalColumn: "TriggerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReactionEvent",
                columns: table => new
                {
                    ReactionEventID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Acute = table.Column<bool>(nullable: false),
                    Chronic = table.Column<bool>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "strftime('%Y-%m-%d %H:%M:%S')"),
                    Description = table.Column<string>(nullable: true),
                    ReactionID = table.Column<int>(nullable: false),
                    TrialID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReactionEvent", x => x.ReactionEventID);
                    table.ForeignKey(
                        name: "FK_ReactionEvent_Reaction_ReactionID",
                        column: x => x.ReactionID,
                        principalTable: "Reaction",
                        principalColumn: "ReactionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReactionEvent_Trial_TrialID",
                        column: x => x.TrialID,
                        principalTable: "Trial",
                        principalColumn: "TrialID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrialEvent",
                columns: table => new
                {
                    TrialEventID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "strftime('%Y-%m-%d %H:%M:%S')"),
                    FoodType = table.Column<string>(nullable: false),
                    Quantity = table.Column<string>(nullable: false),
                    TrialID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrialEvent", x => x.TrialEventID);
                    table.ForeignKey(
                        name: "FK_TrialEvent_Trial_TrialID",
                        column: x => x.TrialID,
                        principalTable: "Trial",
                        principalColumn: "TrialID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReactionEventSymptom",
                columns: table => new
                {
                    ReactionEventSymptomID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReactionEventID = table.Column<int>(nullable: false),
                    SymptomID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReactionEventSymptom", x => x.ReactionEventSymptomID);
                    table.ForeignKey(
                        name: "FK_ReactionEventSymptom_ReactionEvent_ReactionEventID",
                        column: x => x.ReactionEventID,
                        principalTable: "ReactionEvent",
                        principalColumn: "ReactionEventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReactionEventSymptom_Symptom_SymptomID",
                        column: x => x.SymptomID,
                        principalTable: "Symptom",
                        principalColumn: "SymptomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reaction_ChildID",
                table: "Reaction",
                column: "ChildID");

            migrationBuilder.CreateIndex(
                name: "IX_Reaction_IngestionID",
                table: "Reaction",
                column: "IngestionID");

            migrationBuilder.CreateIndex(
                name: "IX_ReactionEvent_ReactionID",
                table: "ReactionEvent",
                column: "ReactionID");

            migrationBuilder.CreateIndex(
                name: "IX_ReactionEvent_TrialID",
                table: "ReactionEvent",
                column: "TrialID");

            migrationBuilder.CreateIndex(
                name: "IX_ReactionEventSymptom_ReactionEventID",
                table: "ReactionEventSymptom",
                column: "ReactionEventID");

            migrationBuilder.CreateIndex(
                name: "IX_ReactionEventSymptom_SymptomID",
                table: "ReactionEventSymptom",
                column: "SymptomID");

            migrationBuilder.CreateIndex(
                name: "IX_ReactionTrigger_ReactionID",
                table: "ReactionTrigger",
                column: "ReactionID");

            migrationBuilder.CreateIndex(
                name: "IX_ReactionTrigger_TriggerID",
                table: "ReactionTrigger",
                column: "TriggerID");

            migrationBuilder.CreateIndex(
                name: "IX_Safe_ChildID",
                table: "Safe",
                column: "ChildID");

            migrationBuilder.CreateIndex(
                name: "IX_Safe_FoodID",
                table: "Safe",
                column: "FoodID");

            migrationBuilder.CreateIndex(
                name: "IX_Trial_ChildID",
                table: "Trial",
                column: "ChildID");

            migrationBuilder.CreateIndex(
                name: "IX_Trial_FoodID",
                table: "Trial",
                column: "FoodID");

            migrationBuilder.CreateIndex(
                name: "IX_Trial_TriggerID",
                table: "Trial",
                column: "TriggerID");

            migrationBuilder.CreateIndex(
                name: "IX_TrialEvent_TrialID",
                table: "TrialEvent",
                column: "TrialID");

            migrationBuilder.CreateIndex(
                name: "IX_Trigger_ChildID",
                table: "Trigger",
                column: "ChildID");

            migrationBuilder.CreateIndex(
                name: "IX_Trigger_FoodID",
                table: "Trigger",
                column: "FoodID");

            migrationBuilder.CreateIndex(
                name: "IX_TriggerSymptom_SymptomID",
                table: "TriggerSymptom",
                column: "SymptomID");

            migrationBuilder.CreateIndex(
                name: "IX_TriggerSymptom_TriggerID",
                table: "TriggerSymptom",
                column: "TriggerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReactionEventSymptom");

            migrationBuilder.DropTable(
                name: "ReactionTrigger");

            migrationBuilder.DropTable(
                name: "Safe");

            migrationBuilder.DropTable(
                name: "TrialEvent");

            migrationBuilder.DropTable(
                name: "TriggerSymptom");

            migrationBuilder.DropTable(
                name: "ReactionEvent");

            migrationBuilder.DropTable(
                name: "Symptom");

            migrationBuilder.DropTable(
                name: "Reaction");

            migrationBuilder.DropTable(
                name: "Trial");

            migrationBuilder.DropTable(
                name: "Ingestion");

            migrationBuilder.DropTable(
                name: "Trigger");

            migrationBuilder.DropTable(
                name: "Child");

            migrationBuilder.DropTable(
                name: "Food");
        }
    }
}
