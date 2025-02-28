namespace GestionNotes.Blazor.Models.Dynamic
{
    public class Pays
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public List<Region> Regions { get; set; } = new List<Region>();


        public Pays(string id, string nom)
        {
            Id = id;
            Nom = nom;
        }
    }
}