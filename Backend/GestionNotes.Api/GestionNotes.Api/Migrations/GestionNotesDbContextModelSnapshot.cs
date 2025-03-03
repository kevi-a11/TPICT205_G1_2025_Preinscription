﻿// <auto-generated />
using System;
using GestionNotes.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionNotes.Api.Migrations
{
    [DbContext(typeof(GestionNotesDbContext))]
    partial class GestionNotesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("GestionNotes.Api.Models.PreinscriptionEtudiant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AdresseEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AdresseLocalisation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AdresseTelephonique")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AdresseTelephoniqueMere")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AdresseTelephoniquePere")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AgencePaiement")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("AnneeObtention")
                        .HasColumnType("int");

                    b.Property<bool>("AntecedentsMedicaux")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ChoixFiliere1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ChoixFiliere2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ChoixFiliere3")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateDeNaissance")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateDelivrance")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateImpressionRecu")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("EstHandicap")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Faculte")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Handicap")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("ImageEtudiant")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("LangueDominante")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LieuDeNaissance")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("MaladieChronique")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("MontantPaye")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Moyenne")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Nationalite")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Niveau")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomMaladie")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomMaladieChronique")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomMere")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NomPere")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NumeroCNI")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NumeroComptePaiement")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NumeroRecu")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OrganismeDelivrance")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("PratiqueSport")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProfessionMere")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProfessionPere")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RegionOrigine")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Serie")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sexe")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SituationProfessionnelle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("SousTraitement")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Sport")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StatutMatrimonial")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TypeDiplome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("PreinscriptionsEtudiants");
                });
#pragma warning restore 612, 618
        }
    }
}
