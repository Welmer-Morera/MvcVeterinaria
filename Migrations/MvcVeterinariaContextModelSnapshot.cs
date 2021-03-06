// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcVeterinaria.Data;

namespace MvcVeterinaria.Migrations
{
    [DbContext(typeof(MvcVeterinariaContext))]
    partial class MvcVeterinariaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("MvcVeterinaria.Models.Cita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("MascotaID")
                        .HasColumnType("TEXT");

                    b.Property<int>("MedicamentoID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VeterinarioID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MedicamentoID");

                    b.HasIndex("VeterinarioID");

                    b.ToTable("Cita");
                });

            modelBuilder.Entity("MvcVeterinaria.Models.Medicamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Administracion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Dosis")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Medicamento");
                });

            modelBuilder.Entity("MvcVeterinaria.Models.Veterinario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Especialidad")
                        .HasColumnType("TEXT");

                    b.Property<int>("Experiencia")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GradoAcademico")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Veterinario");
                });

            modelBuilder.Entity("MvcVeterinaria.Models.Cita", b =>
                {
                    b.HasOne("MvcVeterinaria.Models.Medicamento", "Medicamento")
                        .WithMany()
                        .HasForeignKey("MedicamentoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcVeterinaria.Models.Veterinario", "Veterinario")
                        .WithMany()
                        .HasForeignKey("VeterinarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicamento");

                    b.Navigation("Veterinario");
                });
#pragma warning restore 612, 618
        }
    }
}
