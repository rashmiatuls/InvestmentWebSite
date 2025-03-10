// <auto-generated />
using System;
using InvestmentManagement.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InvestmentManagement.DataLayer.Migrations
{
    [DbContext(typeof(InvestmentDbContext))]
    [Migration("20231231150002_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InvestmentManagement.Entities.Investment", b =>
                {
                    b.Property<long>("InvestmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CurrentValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("InitialInvestmentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("InvestmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InvestmentStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InvestorId")
                        .HasColumnType("int");

                    b.HasKey("InvestmentId");

                    b.ToTable("Investments");
                });
#pragma warning restore 612, 618
        }
    }
}
