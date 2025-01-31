﻿// <auto-generated />
using DiogoTurismo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DiogoTurismo.Migrations
{
    [DbContext(typeof(BancoDados))]
    [Migration("20211219072709_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DiogoTurismo.Models.Cadastro", b =>
                {
                    b.Property<int>("Id_cadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_cadastro");

                    b.ToTable("Cadastro");
                });

            modelBuilder.Entity("DiogoTurismo.Models.Destino", b =>
                {
                    b.Property<int>("Id_destino")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cidade_destino")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade_origem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_destino");

                    b.ToTable("Destino");
                });

            modelBuilder.Entity("DiogoTurismo.Models.Passagem", b =>
                {
                    b.Property<int>("Id_passagem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CadastroId_cadastro")
                        .HasColumnType("int");

                    b.Property<string>("Data_chegada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Data_saida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DestinoId_destino")
                        .HasColumnType("int");

                    b.Property<string>("Horario_chegada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Horario_saida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero_passaporte")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_passagem");

                    b.HasIndex("CadastroId_cadastro");

                    b.HasIndex("DestinoId_destino");

                    b.ToTable("Passagens");
                });

            modelBuilder.Entity("DiogoTurismo.Models.Passagem", b =>
                {
                    b.HasOne("DiogoTurismo.Models.Cadastro", "Cadastro")
                        .WithMany()
                        .HasForeignKey("CadastroId_cadastro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DiogoTurismo.Models.Destino", "Destino")
                        .WithMany()
                        .HasForeignKey("DestinoId_destino")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cadastro");

                    b.Navigation("Destino");
                });
#pragma warning restore 612, 618
        }
    }
}
