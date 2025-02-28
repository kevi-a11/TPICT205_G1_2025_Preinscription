using System.ComponentModel.DataAnnotations;

namespace GestionNotes.Blazor.Models
{
    public class PreinscriptionEtudiantDTO
    {
        public Guid Id { get; set; }

        // Informations personnelles
        [Required] public string Nom { get; set; } = "";
        [Required] public string Prenom { get; set; } = "";
        [Required] public string Sexe { get; set; } = "";
        [Required] public string AdresseEmail { get; set; } = "";
        [Required] public string AdresseTelephonique { get; set; } = "";
        [Required] public string AdresseLocalisation { get; set; } = "";
        [Required] public string LangueDominante { get; set; } = "";
        [Required] public string LieuDeNaissance { get; set; } = "";
        [Required] public DateTime DateDeNaissance { get; set; } = DateTime.MinValue;
        [Required] public string Nationalite { get; set; } = "";
        [Required] public string NumeroCNI { get; set; } = "";
        [Required] public string Ville { get; set; } = "";
        [Required] public string StatutMatrimonial { get; set; } = "";
        [Required] public string SituationProfessionnelle { get; set; } = "";
        [Required] public string RegionOrigine { get; set; } = "";

        // Parents
        [Required] public string NomPere { get; set; } = "";
        [Required] public string NomMere { get; set; } = "";
        [Required] public string AdresseTelephoniquePere { get; set; } = "";
        [Required] public string AdresseTelephoniqueMere { get; set; } = "";
        [Required] public string ProfessionPere { get; set; } = "";
        [Required] public string ProfessionMere { get; set; } = "";

        // Informations médicales
        [Required] public bool PratiqueSport { get; set; } = false;
        [Required] public string Sport { get; set; } = "";
        [Required] public bool AntecedentsMedicaux { get; set; } = false;
        [Required] public bool EstHandicap { get; set; } = false;
        [Required] public bool SousTraitement { get; set; } = false;
        [Required] public bool MaladieChronique { get; set; } = false;
        public string NomMaladieChronique { get; set; } = "";
        public string Handicap { get; set; } = "";
        public string NomMaladie { get; set; } = "";

        // Diplôme
        [Required] public string TypeDiplome { get; set; } = "";
        [Required] public string OrganismeDelivrance { get; set; } = "";
        [Required] public string Serie { get; set; } = "";
        [Required] public DateTime DateDelivrance { get; set; } = DateTime.MinValue;
        [Required] public string NumeroRecu { get; set; } = "";
        [Required] public int AnneeObtention { get; set; } = 0;
        [Required] public decimal Moyenne { get; set; } = 0.0m;

        // Paiement
        [Required] public decimal MontantPaye { get; set; } = 0.0m;
        [Required] public string NumeroComptePaiement { get; set; } = "";
        [Required] public string AgencePaiement { get; set; } = "";
        [Required] public DateTime DateImpressionRecu { get; set; } = DateTime.MinValue;

        // Choix filières et spécialité
        [Required] public string Faculte { get; set; } = "";
        [Required] public string ChoixFiliere1 { get; set; } = "";
        [Required] public string ChoixFiliere2 { get; set; } = "";
        [Required] public string ChoixFiliere3 { get; set; } = "";
        [Required] public string Niveau { get; set; } = "";

        // Image étudiant
        [Required] public byte[] ImageEtudiant { get; set; } = [];
    }
}
