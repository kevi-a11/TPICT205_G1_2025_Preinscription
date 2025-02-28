namespace GestionNotes.Blazor.Models.Dynamic
{
    public class Filiere
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public bool Professionnelle { get; set; } // "Académique" ou "Professionnelle"
        public string DepartementId { get; set; }
        public List<Specialite> Specialites { get; set; } = new();




        public Filiere(string Id, string nom, bool professionnelle, string departementId)
        {
            this.Id = Id;
            Nom = nom;
            Professionnelle = professionnelle;
            DepartementId = departementId;
        }

        public List<Specialite> GetSpecialites()
        {
            return Specialites ?? new List<Specialite>();
        }


        public Specialite? GetSpecialiteById(string specialiteId)
        {
            return Specialites.FirstOrDefault(s => s.Id == specialiteId);

        }


        public void AjouterSpecialite(Specialite specialite)
        {
            Specialites ??= new List<Specialite>();
            Specialites.Add(specialite);
        }

        public void SupprimerSpecialite(string specialiteId)
        {
            var specialite = Specialites?.FirstOrDefault(s => s.Id == specialiteId);
            if (specialite != null)
                Specialites?.Remove(specialite);
        }
    }
}