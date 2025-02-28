namespace GestionNotes.Api.DTOs
{
    public class PreinscriptionEtudiantDTO
    {
        public Guid Id { get; set; }
        public required string Nom { get; set; }
        public required string Prenom { get; set; }
        public required string Sexe { get; set; }
        public required string AdresseEmail { get; set; }
        public required string AdresseTelephonique { get; set; }
        public required string AdresseLocalisation { get; set; }
        public required string LangueDominante { get; set; }
        public required string LieuDeNaissance { get; set; }
        public required DateTime DateDeNaissance { get; set; }
        public required string Nationalite { get; set; }
        public required string NumeroCNI { get; set; }
        public required string Ville { get; set; }
        public required string StatutMatrimonial { get; set; }
        public required string SituationProfessionnelle { get; set; }
        public required string RegionOrigine { get; set; }
        public required string NomPere { get; set; }
        public required string NomMere { get; set; }
        public required string AdresseTelephoniquePere { get; set; }
        public required string AdresseTelephoniqueMere { get; set; }
        public required string ProfessionPere { get; set; }
        public required string ProfessionMere { get; set; }
        public required bool PratiqueSport { get; set; }
        public required string Sport { get; set; }
        public required bool AntecedentsMedicaux { get; set; }
        public required bool EstHandicap { get; set; }
        public required bool SousTraitement { get; set; }
        public required bool MaladieChronique { get; set; }
        public string? NomMaladieChronique { get; set; }
        public string? Handicap { get; set; }
        public string? NomMaladie { get; set; }
        public required string TypeDiplome { get; set; }
        public required string OrganismeDelivrance { get; set; }
        public required string Serie { get; set; }
        public required DateTime DateDelivrance { get; set; }
        public required string NumeroRecu { get; set; }
        public required int AnneeObtention { get; set; }
        public required decimal Moyenne { get; set; }
        public required decimal MontantPaye { get; set; }
        public required string NumeroComptePaiement { get; set; }
        public required string AgencePaiement { get; set; }
        public required DateTime DateImpressionRecu { get; set; }
        public required string Faculte { get; set; }
        public required string ChoixFiliere1 { get; set; }
        public required string ChoixFiliere2 { get; set; }
        public required string ChoixFiliere3 { get; set; }
        public required string Niveau { get; set; }
        public required byte[] ImageEtudiant { get; set; }
    }
}
