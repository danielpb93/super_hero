// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.DatabaseContext;

namespace backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221109022536_insertSuperpoderesInDatabase")]
    partial class insertSuperpoderesInDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HeroiSuperpoder", b =>
                {
                    b.Property<int>("HeroisId")
                        .HasColumnType("int");

                    b.Property<int>("SuperpoderesId")
                        .HasColumnType("int");

                    b.HasKey("HeroisId", "SuperpoderesId");

                    b.HasIndex("SuperpoderesId");

                    b.ToTable("HeroiSuperpoder");
                });

            modelBuilder.Entity("backend.Models.Heroi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Altura")
                        .HasColumnType("float");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeHeroi")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("NomeHeroi")
                        .IsUnique();

                    b.ToTable("Herois");
                });

            modelBuilder.Entity("backend.Models.Superpoder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Superpoder");

                    b.HasKey("Id");

                    b.ToTable("Superpoderes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Voa Alto",
                            Nome = "Voar"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Muito Forte",
                            Nome = "Super Força"
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "Muito Veloz",
                            Nome = "Super Velocidade"
                        },
                        new
                        {
                            Id = 4,
                            Descricao = "Muita Inteligencia",
                            Nome = "Super Inteligencia"
                        },
                        new
                        {
                            Id = 5,
                            Descricao = "Muito Resistente",
                            Nome = "Super Resistencia"
                        },
                        new
                        {
                            Id = 6,
                            Descricao = "XD",
                            Nome = "Conversar com Peixes"
                        },
                        new
                        {
                            Id = 7,
                            Descricao = "",
                            Nome = "Soltar Laser dos Olhos"
                        },
                        new
                        {
                            Id = 8,
                            Descricao = "Consegue controlar metal da forma que quiser",
                            Nome = "Controlar Metal"
                        },
                        new
                        {
                            Id = 9,
                            Descricao = "Telepatia",
                            Nome = "Telepatia"
                        });
                });

            modelBuilder.Entity("HeroiSuperpoder", b =>
                {
                    b.HasOne("backend.Models.Heroi", null)
                        .WithMany()
                        .HasForeignKey("HeroisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.Superpoder", null)
                        .WithMany()
                        .HasForeignKey("SuperpoderesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
