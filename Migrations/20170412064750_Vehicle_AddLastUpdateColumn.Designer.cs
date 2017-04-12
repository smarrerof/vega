using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApplicationBasic.Data;

namespace Vega.Migrations
{
    [DbContext(typeof(VegaDbContext))]
    [Migration("20170412064750_Vehicle_AddLastUpdateColumn")]
    partial class Vehicle_AddLastUpdateColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplicationBasic.Data.Models.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("WebApplicationBasic.Data.Models.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("WebApplicationBasic.Data.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MakeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("WebApplicationBasic.Data.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactEmail")
                        .HasMaxLength(255);

                    b.Property<string>("ContactName")
                        .HasMaxLength(255);

                    b.Property<string>("ContactPhone")
                        .HasMaxLength(255);

                    b.Property<bool>("IsRegistered");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<int>("MakeId");

                    b.Property<int>("ModelId");

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.HasIndex("ModelId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("WebApplicationBasic.Data.Models.VehicleFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FeatureId");

                    b.Property<int>("VehicleId");

                    b.HasKey("Id");

                    b.HasIndex("FeatureId");

                    b.HasIndex("VehicleId");

                    b.ToTable("VehicleFeature");
                });

            modelBuilder.Entity("WebApplicationBasic.Data.Models.Model", b =>
                {
                    b.HasOne("WebApplicationBasic.Data.Models.Make", "Make")
                        .WithMany("Models")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplicationBasic.Data.Models.Vehicle", b =>
                {
                    b.HasOne("WebApplicationBasic.Data.Models.Make", "Make")
                        .WithMany("Vehicles")
                        .HasForeignKey("MakeId");

                    b.HasOne("WebApplicationBasic.Data.Models.Model", "Model")
                        .WithMany("Vehicles")
                        .HasForeignKey("ModelId");
                });

            modelBuilder.Entity("WebApplicationBasic.Data.Models.VehicleFeature", b =>
                {
                    b.HasOne("WebApplicationBasic.Data.Models.Feature", "Feature")
                        .WithMany("FeatureVehicles")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplicationBasic.Data.Models.Vehicle", "Vehicle")
                        .WithMany("VehicleFeatures")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
