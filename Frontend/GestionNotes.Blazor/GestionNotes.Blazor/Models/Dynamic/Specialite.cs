using GestionNotes.Blazor.Models.Enums;

namespace GestionNotes.Blazor.Models.Dynamic
{
    public class Specialite
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string FiliereId { get; set; }
        public Niveau Niveau { get; set; }

        public Specialite(string id, string nom, string filiereId, Niveau niveau)
        {
            Id = id;
            Nom = nom;
            FiliereId = filiereId;
            Niveau = niveau;
        }

        public bool EstDisponiblePourNiveau(Niveau niveau)
        {
            return Niveau == niveau;
        }
    }

}