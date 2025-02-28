namespace GestionNotes.Blazor.Models.Dynamic
{

    public class Departement
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string FaculteId { get; set; }
        public List<Filiere> Filieres { get; set; } = new();



        public Departement(string id, string nom, string faculteId)
        {
            Id = id;
            Nom = nom;
            FaculteId = faculteId;
        }

        public List<Filiere> GetFilieres()
        {
            return Filieres ?? new List<Filiere>();
        }

        public Filiere? GetFilierById(string filiereId)
        {
            return Filieres?.FirstOrDefault(d => d.Id == filiereId);
        }


        public void AjouterFiliere(Filiere filiere)
        {
            Filieres ??= new List<Filiere>();
            Filieres.Add(filiere);
        }

        public void SupprimerFiliere(string filiereId)
        {
            var filiere = Filieres?.FirstOrDefault(f => f.Id == filiereId);
            if (filiere != null)
                Filieres?.Remove(filiere);
        }
    }
}