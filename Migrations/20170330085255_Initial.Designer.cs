using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApplicationBasic.Data;

namespace Vega.Migrations
{
    [DbContext(typeof(VegaDbContext))]
    [Migration("20170330085255_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplicationBasic.Data.Models.Feature", b =>
                {
                    b.Property<int>("IdFeature")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("IdFeature");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("WebApplicationBasic.Data.Models.Make", b =>
                {
                    b.Property<int>("IdMake")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("IdMake");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("WebApplicationBasic.Data.Models.Model", b =>
                {
                    b.Property<int>("IdModel")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MakeIdMake");

                    b.Property<string>("Name");

                    b.HasKey("IdModel");

                    b.HasIndex("MakeIdMake");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("WebApplicationBasic.Data.Models.Model", b =>
                {
                    b.HasOne("WebApplicationBasic.Data.Models.Make")
                        .WithMany("Models")
                        .HasForeignKey("MakeIdMake");
                });
        }
    }
}
