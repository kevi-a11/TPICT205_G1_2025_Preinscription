namespace GestionNotes.Blazor.Models.Dynamic
{
    public class Annee
    {
        public string? AnneeId { get; set; }
        public string? AnneeScolaire { get; set; }

        public Annee() { }

        public Annee(string idAnnee, string anneeScolaire)
        {
            AnneeId = idAnnee;
            AnneeScolaire = anneeScolaire;
        }


        public int? GetAnneeDebut(char separateur)
        {
            if (!string.IsNullOrEmpty(AnneeScolaire) && AnneeScolaire.Contains(separateur))
            {
                string[] parties = AnneeScolaire.Split(separateur);
                if (int.TryParse(parties[0], out int anneeDebut))
                {
                    return anneeDebut;
                }
            }
            return null;
        }


        public int? GetAnneeFin(char separateur)
        {
            if (!string.IsNullOrEmpty(AnneeScolaire) && AnneeScolaire.Contains(separateur))
            {
                string[] parties = AnneeScolaire.Split(separateur);
                if (int.TryParse(parties[1], out int anneeFin))
                {
                    return anneeFin;
                }
            }
            return null;
        }
    }
}