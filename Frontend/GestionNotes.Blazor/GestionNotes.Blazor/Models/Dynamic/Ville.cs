namespace GestionNotes.Blazor.Models.Dynamic
{
    public class Ville
    {
        public string Id { get; set; } = string.Empty;
        public string Nom { get; set; } = string.Empty;
        public string RegionId { get; set; } = string.Empty;

        // Constructeur par défaut
        public Ville() { }

        // Constructeur avec paramètres
        public Ville(string id, string nom, string regionId)
        {
            Id = id;
            Nom = nom;
            RegionId = regionId;
        }
    }
}


