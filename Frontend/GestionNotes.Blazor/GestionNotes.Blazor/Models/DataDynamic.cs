using GestionNotes.Blazor.Models.Dynamic;

namespace GestionNotes.Blazor.Models
{



    public class DataDynamic
    {

        public List<Pays> pays = new();
        public List<Region> regions = new();
        public List<Ville> villes = new();
        public List<Faculte> facultes = new();
        public List<Departement> departements = new();
        public List<Filiere> filieres = new();
        public List<Specialite> specialites = new();
        public List<AgencePaiement> agences = new();
        public List<NumeroCompteAgence> numeroComptes = new();
        public List<Annee> annneAcademique = new();

        public void DonneTest()
        {

            DatabaseContext db = new DatabaseContext(); // Charge les données

            pays = db.Pays;
            regions = db.Regions;
            villes = db.Villes;
            facultes = db.Facultes;
            departements = db.Departements;
            filieres = db.Filieres;
            specialites = db.Specialites;
            agences = db.AgencePaiements;
            numeroComptes = db.NumeroCompteAgences;
            annneAcademique = db.Annees;

        }

    }

}