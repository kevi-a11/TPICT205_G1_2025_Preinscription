namespace GestionNotes.Blazor.Models.Dynamic
{
    public class Region
    {
        public string Id { get; set; } = string.Empty;
        public string Nom { get; set; } = string.Empty;
        public string PaysId { get; set; } = string.Empty;
        public List<Ville> Villes { get; set; } = new List<Ville>();


        public Region()
        {

        }
        public Region(string id, string nom, string paysId)
        {
            Id = id;
            Nom = nom;
            PaysId = paysId;
        }

        public List<Ville> getVilles()
        {
            return Villes;
        }
    }
}