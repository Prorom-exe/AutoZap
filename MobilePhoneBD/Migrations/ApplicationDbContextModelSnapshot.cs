﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MobilePhoneBD.Data;

namespace AutoZap.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MobilePhoneBD.Models.Auto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Auto");
                });

            modelBuilder.Entity("MobilePhoneBD.Models.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quality")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("MobilePhoneBD.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutoId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quality")
                        .HasColumnType("int");

                    b.Property<int>("ZapId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AutoId");

                    b.HasIndex("ZapId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MobilePhoneBD.Models.Zap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutoId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AutoId");

                    b.ToTable("Zap");
                });

            modelBuilder.Entity("MobilePhoneBD.Models.Basket", b =>
                {
                    b.HasOne("MobilePhoneBD.Models.Products", "Products")
                        .WithMany("Baskets")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");
                });

            modelBuilder.Entity("MobilePhoneBD.Models.Products", b =>
                {
                    b.HasOne("MobilePhoneBD.Models.Auto", "Category")
                        .WithMany("Products")
                        .HasForeignKey("AutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MobilePhoneBD.Models.Zap", "Zap")
                        .WithMany("Products")
                        .HasForeignKey("ZapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Zap");
                });

            modelBuilder.Entity("MobilePhoneBD.Models.Zap", b =>
                {
                    b.HasOne("MobilePhoneBD.Models.Auto", null)
                        .WithMany("Zap")
                        .HasForeignKey("AutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MobilePhoneBD.Models.Auto", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Zap");
                });

            modelBuilder.Entity("MobilePhoneBD.Models.Products", b =>
                {
                    b.Navigation("Baskets");
                });

            modelBuilder.Entity("MobilePhoneBD.Models.Zap", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
