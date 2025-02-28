namespace GestionNotes.Blazor.Models.Dynamic
{

    public class Faculte
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public List<Departement> Departements { get; set; } = new();



        // Constructeur avec paramètres
        public Faculte(string id, string nom)
        {
            Id = id;
            Nom = nom;
        }

        public List<Departement> GetDepartements()
        {
            return Departements ?? new List<Departement>();
        }

        public Departement? GetDepartementById(string departementId)
        {
            return Departements?.FirstOrDefault(d => d.Id == departementId);
        }


        // Méthodes pour ajouter et supprimer des départements
        public void AjouterDepartement(Departement departement)
        {
            Departements ??= new List<Departement>();
            Departements.Add(departement);
        }

        public void SupprimerDepartement(string departementId)
        {
            var departement = Departements?.FirstOrDefault(d => d.Id == departementId);
            if (departement != null)
                Departements?.Remove(departement);
        }

        public List<Departement> GetDepartement(string idfaculte)
        {

            return Departements.Where(d => d.FaculteId == idfaculte).ToList();

        }
    }
}