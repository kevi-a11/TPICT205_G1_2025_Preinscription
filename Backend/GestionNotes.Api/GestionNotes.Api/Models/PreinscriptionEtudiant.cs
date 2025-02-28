using System;
using System.ComponentModel.DataAnnotations;
using GestionNotes.Api.Models.Enums;

namespace GestionNotes.Api.Models
{
   

    public class PreinscriptionEtudiant
    {
        // Identifiant unique généré automatiquement
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();  // Utilisation de GUID pour générer un ID unique

        // Informations personnelles
        public required string Nom { get; set; }
        public required string Prenom { get; set; }

        public Sexe Sexe { get; set; }
        public required string AdresseEmail { get; set; }
        public required string AdresseTelephonique { get; set; }
        public required string AdresseLocalisation { get; set; }
        public Langue LangueDominante { get; set; }
        public required string LieuDeNaissance { get; set; }
        public DateTime DateDeNaissance { get; set; }
        public required string Nationalite { get; set; }
        public required string NumeroCNI { get; set; }
        public required string Ville { get; set; }

        // Statut marital et situation professionnelle
        public StatutMatrimonial StatutMatrimonial { get; set; }
        public SituationPro SituationProfessionnelle { get; set; }
        public required string RegionOrigine { get; set; }

        // Parents
        public required string NomPere { get; set; }
        public required string NomMere { get; set; }
        public required string AdresseTelephoniquePere { get; set; }
        public required string AdresseTelephoniqueMere { get; set; }
        public required string ProfessionPere { get; set; }
        public required string ProfessionMere { get; set; }

        // Informations médicales
        public bool PratiqueSport { get; set; }
        public required string Sport { get; set; }
        public bool AntecedentsMedicaux { get; set; }
        public bool EstHandicap { get; set; }
        public bool SousTraitement { get; set; }
        public bool MaladieChronique { get; set; }
        public string? NomMaladieChronique { get; set; }
        public string? Handicap { get; set; }
        public string? NomMaladie { get; set; }

        // Diplôme
        public TypeDiplome TypeDiplome { get; set; }
        public required OrganismeDelivrance OrganismeDelivrance { get; set; }
        public required Serie Serie { get; set; }
        public DateTime DateDelivrance { get; set; }
        public required string NumeroRecu { get; set; }
        public int AnneeObtention { get; set; }
        public decimal Moyenne { get; set; }

        // Paiement
        public decimal MontantPaye { get; set; }
        public required string NumeroComptePaiement { get; set; }
        public required string AgencePaiement { get; set; }
        public DateTime DateImpressionRecu { get; set; }

        // Choix filières et spécialité
        public required string Faculte { get; set; }
        public required string ChoixFiliere1 { get; set; }
        public required string ChoixFiliere2 { get; set; }
        public required string ChoixFiliere3 { get; set; }
        public Niveau Niveau { get; set; }

        // Image étudiant
        public required byte[] ImageEtudiant { get; set; }
    }

}
