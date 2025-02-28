using Microsoft.EntityFrameworkCore;
using GestionNotes.Api.Models;
using GestionNotes.Api.Models.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestionNotes.Api.Data
{
    public class GestionNotesDbContext(DbContextOptions<GestionNotesDbContext> options) : DbContext(options)
    {

        // Définir les DbSet pour les entités à utiliser avec la base de données
        public DbSet<PreinscriptionEtudiant> PreinscriptionsEtudiants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration des énumérations pour être stockées en tant que chaînes de caractères
            modelBuilder.Entity<PreinscriptionEtudiant>()
                .Property(e => e.Sexe)
                .HasConversion(new EnumToStringConverter<Sexe>());

            modelBuilder.Entity<PreinscriptionEtudiant>()
                .Property(e => e.LangueDominante)
                .HasConversion(new EnumToStringConverter<Langue>());

            modelBuilder.Entity<PreinscriptionEtudiant>()
                .Property(e => e.StatutMatrimonial)
                .HasConversion(new EnumToStringConverter<StatutMatrimonial>());

            modelBuilder.Entity<PreinscriptionEtudiant>()
                .Property(e => e.SituationProfessionnelle)
                .HasConversion(new EnumToStringConverter<SituationPro>());

            modelBuilder.Entity<PreinscriptionEtudiant>()
                .Property(e => e.TypeDiplome)
                .HasConversion(new EnumToStringConverter<TypeDiplome>());

            modelBuilder.Entity<PreinscriptionEtudiant>()
                .Property(e => e.OrganismeDelivrance)
                .HasConversion(new EnumToStringConverter<OrganismeDelivrance>());

            modelBuilder.Entity<PreinscriptionEtudiant>()
                .Property(e => e.Serie)
                .HasConversion(new EnumToStringConverter<Serie>());

            modelBuilder.Entity<PreinscriptionEtudiant>()
                .Property(e => e.Niveau)
                .HasConversion(new EnumToStringConverter<Niveau>());
        }
    }
}
