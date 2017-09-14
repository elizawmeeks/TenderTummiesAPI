using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TenderTummiesAPI.Data;

namespace TenderTummiesAPI.Migrations
{
    [DbContext(typeof(TenderTummiesAPIContext))]
    partial class TenderTummiesAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("TenderTummiesAPI.Models.Child", b =>
                {
                    b.Property<int>("ChildID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("Gender");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("UserID")
                        .IsRequired();

                    b.Property<int>("WtNumber");

                    b.Property<string>("WtUnit")
                        .IsRequired();

                    b.HasKey("ChildID");

                    b.ToTable("Child");
                });

            modelBuilder.Entity("TenderTummiesAPI.Models.Food", b =>
                {
                    b.Property<int>("FoodID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("FoodID");

                    b.ToTable("Food");
                });

            modelBuilder.Entity("TenderTummiesAPI.Models.Ingestion", b =>
                {
                    b.Property<int>("IngestionID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("IngestionID");

                    b.ToTable("Ingestion");
                });

            modelBuilder.Entity("TenderTummiesAPI.Models.Reaction", b =>
                {
                    b.Property<int>("ReactionID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChildID");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("strftime('%Y-%m-%d')");

                    b.Property<string>("FoodType")
                        .IsRequired();

                    b.Property<int>("IngestionID");

                    b.Property<DateTime>("StartDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("strftime('%Y-%m-%d')");

                    b.HasKey("ReactionID");

                    b.HasIndex("ChildID");

                    b.HasIndex("IngestionID");

                    b.ToTable("Reaction");
                });

            modelBuilder.Entity("TenderTummiesAPI.Models.ReactionEvent", b =>
                {
                    b.Property<int>("ReactionEventID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Acute");

                    b.Property<bool>("Chronic");

                    b.Property<DateTime>("DateTime")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

                    b.Property<string>("Description");

                    b.Property<int>("ReactionID");

                    b.Property<int?>("TrialID");

                    b.HasKey("ReactionEventID");

                    b.HasIndex("ReactionID");

                    b.HasIndex("TrialID");

                    b.ToTable("ReactionEvent");
                });

            modelBuilder.Entity("TenderTummiesAPI.Models.ReactionEventSymptom", b =>
                {
                    b.Property<int>("ReactionEventSymptomID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ReactionEventID");

                    b.Property<int>("SymptomID");

                    b.HasKey("ReactionEventSymptomID");

                    b.HasIndex("ReactionEventID");

                    b.HasIndex("SymptomID");

                    b.ToTable("ReactionEventSymptom");
                });

            modelBuilder.Entity("TenderTummiesAPI.Models.ReactionTrigger", b =>
                {
                    b.Property<int>("ReactionTriggerID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ReactionID");

                    b.Property<int>("TriggerID");

                    b.HasKey("ReactionTriggerID");

                    b.HasIndex("ReactionID");

                    b.HasIndex("TriggerID");

                    b.ToTable("ReactionTrigger");
                });

            modelBuilder.Entity("TenderTummiesAPI.Models.Safe", b =>
                {
                    b.Property<int>("SafeID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChildID");

                    b.Property<int>("FoodID");

                    b.HasKey("SafeID");

                    b.HasIndex("ChildID");

                    b.HasIndex("FoodID");

                    b.ToTable("Safe");
                });

            modelBuilder.Entity("TenderTummiesAPI.Models.Symptom", b =>
                {
                    b.Property<int>("SymptomID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("SymptomID");

                    b.ToTable("Symptom");
                });

            modelBuilder.Entity("TenderTummiesAPI.Models.Trial", b =>
                {
                    b.Property<int>("TrialID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChildID");

                    b.Property<DateTime>("EndDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("strftime('%Y-%m-%d')");

                    b.Property<int>("FoodID");

                    b.Property<bool>("Pass");

                    b.Property<DateTime>("StartDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("strftime('%Y-%m-%d')");

                    b.Property<int?>("TriggerID");

                    b.HasKey("TrialID");

                    b.HasIndex("ChildID");

                    b.HasIndex("FoodID");

                    b.HasIndex("TriggerID");

                    b.ToTable("Trial");
                });

            modelBuilder.Entity("TenderTummiesAPI.Models.TrialEvent", b =>
                {
                    b.Property<int>("TrialEventID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

                    b.Property<string>("FoodType")
                        .IsRequired();

                    b.Property<string>("Quantity")
                        .IsRequired();

                    b.Property<int>("TrialID");

                    b.HasKey("TrialEventID");

                    b.HasIndex("TrialID");

                    b.ToTable("TrialEvent");
                });

            modelBuilder.Entity("TenderTummiesAPI.Models.Trigger", b =>
                {
                    b.Property<int>("TriggerID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChildID");

                    b.Property<int>("FoodID");

                    b.Property<string>("Severity")
                        .IsRequired();

                    b.HasKey("TriggerID");

                    b.HasIndex("ChildID");

                    b.HasIndex("FoodID");

                    b.ToTable("Trigger");
                });

            modelBuilder.Entity("TenderTummiesAPI.Models.TriggerSymptom", b =>
                {
                    b.Property<int>("TriggerSymptomID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Acute");

                    b.Property<bool>("Chronic");

                    b.Property<int>("SymptomID");

                    b.Property<int>("TriggerID");

                    b.HasKey("TriggerSymptomID");

                    b.HasIndex("SymptomID");

                    b.HasIndex("TriggerID");

                    b.ToTable("TriggerSymptom");
                });

            modelBuilder.Entity("TenderTummiesAPI.Models.Reaction", b =>
                {
                    b.HasOne("TenderTummiesAPI.Models.Child", "Child")
                        .WithMany("Reactions")
                        .HasForeignKey("ChildID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TenderTummiesAPI.Models.Ingestion", "Ingestion")
                        .WithMany("Reactions")
                        .HasForeignKey("IngestionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TenderTummiesAPI.Models.ReactionEvent", b =>
                {
                    b.HasOne("TenderTummiesAPI.Models.Reaction", "Reaction")
                        .WithMany("ReactionEvents")
                        .HasForeignKey("ReactionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TenderTummiesAPI.Models.Trial", "Trial")
                        .WithMany("ReactionEvents")
                        .HasForeignKey("TrialID");
                });

            modelBuilder.Entity("TenderTummiesAPI.Models.ReactionEventSymptom", b =>
                {
                    b.HasOne("TenderTummiesAPI.Models.ReactionEvent", "ReactionEvent")
                        .WithMany("ReactionEventSymptoms")
                        .HasForeignKey("ReactionEventID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TenderTummiesAPI.Models.Symptom", "Symptom")
                        .WithMany("ReactionEventSymptoms")
                        .HasForeignKey("SymptomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TenderTummiesAPI.Models.ReactionTrigger", b =>
                {
                    b.HasOne("TenderTummiesAPI.Models.Reaction", "Reaction")
                        .WithMany("ReactionTriggers")
                        .HasForeignKey("ReactionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TenderTummiesAPI.Models.Trigger", "Trigger")
                        .WithMany("ReactionTrigger")
                        .HasForeignKey("TriggerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TenderTummiesAPI.Models.Safe", b =>
                {
                    b.HasOne("TenderTummiesAPI.Models.Child", "Child")
                        .WithMany("Safes")
                        .HasForeignKey("ChildID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TenderTummiesAPI.Models.Food", "Food")
                        .WithMany("Safes")
                        .HasForeignKey("FoodID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TenderTummiesAPI.Models.Trial", b =>
                {
                    b.HasOne("TenderTummiesAPI.Models.Child", "Child")
                        .WithMany("Trials")
                        .HasForeignKey("ChildID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TenderTummiesAPI.Models.Food", "Food")
                        .WithMany("Trials")
                        .HasForeignKey("FoodID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TenderTummiesAPI.Models.Trigger", "Trigger")
                        .WithMany("Trials")
                        .HasForeignKey("TriggerID");
                });

            modelBuilder.Entity("TenderTummiesAPI.Models.TrialEvent", b =>
                {
                    b.HasOne("TenderTummiesAPI.Models.Trial", "Trial")
                        .WithMany("TrialEvents")
                        .HasForeignKey("TrialID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TenderTummiesAPI.Models.Trigger", b =>
                {
                    b.HasOne("TenderTummiesAPI.Models.Child", "Child")
                        .WithMany("Triggers")
                        .HasForeignKey("ChildID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TenderTummiesAPI.Models.Food", "Food")
                        .WithMany("Triggers")
                        .HasForeignKey("FoodID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TenderTummiesAPI.Models.TriggerSymptom", b =>
                {
                    b.HasOne("TenderTummiesAPI.Models.Symptom", "Symptom")
                        .WithMany("TriggerSymptoms")
                        .HasForeignKey("SymptomID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TenderTummiesAPI.Models.Trigger", "Trigger")
                        .WithMany("TriggerSymptoms")
                        .HasForeignKey("TriggerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
