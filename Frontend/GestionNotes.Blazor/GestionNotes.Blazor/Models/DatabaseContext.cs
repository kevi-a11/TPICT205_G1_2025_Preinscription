using GestionNotes.Blazor.Models.Dynamic;
using GestionNotes.Blazor.Models.Enums;

namespace GestionNotes.Blazor.Models
{
    public class DatabaseContext
    {
        public List<Pays> Pays { get; set; } = new();
        public List<Region> Regions { get; set; } = new();
        public List<Ville> Villes { get; set; } = new();
        public List<Faculte> Facultes { get; set; } = new();
        public List<Departement> Departements { get; set; } = new();
        public List<Filiere> Filieres { get; set; } = new();
        public List<Specialite> Specialites { get; set; } = new();
        public List<Annee> Annees { get; set; } = new();
        public List<AgencePaiement> AgencePaiements { get; set; } = new();
        public List<NumeroCompteAgence> NumeroCompteAgences { get; set; } = new();

        public DatabaseContext()
        {
            InitialiserDonnees();
        }

        public void InitialiserDonnees()
        {


            var pays = new List<Pays>
            {
            new("1","Cameroun"),
            new("2","Mali"),
            new("3","Sénégal"),
            new("4","Côte d'Ivoire"),
            new("5","Nigeria")
             };
            Pays.AddRange(pays);

            // 🔵 1. Ajouter les régions et villes des pays
            var regions = new List<Region>
            {
                // Cameroun
            new("1", "Adamaoua","1"),
            new("2", "Centre","1"),
            new("3", "Est","1"),
            new("4", "Extrême-Nord","1"),
            new("5", "Littoral","1"),
            new("6", "Nord","1"),
            new("7", "Nord-Ouest","1"),
            new("8", "Ouest","1"),
            new("9", "Sud","1"),
            new("10", "Sud-Ouest","1"),
        
            // Mali
            new("11", "Bamako","2"),
            new("12", "Sikasso","2"),
            new("13", "Kayes","2"),
            new("14", "Mopti","2"),
        
            // Sénégal
            new("15", "Dakar","3"),
            new("16", "Thiès","3"),
            new("17", "Saint-Louis","3"),
        
            // Côte d'Ivoire
            new("18", "Abidjan","4"),
            new("19", "Bouaké","4"),
            new("20", "Yamoussoukro","4"),
        
            // Nigeria
            new("21", "Lagos","5"),
            new("22", "Abuja","5"),
            new("23", "Kano","5")
        };
            Regions.AddRange(regions);

            var villes = new List<Ville>
        {
            // Cameroun
            new("1", "Ngaoundéré", "1"),
            new("2", "Yaoundé", "2"),
            new("3", "Bertoua", "3"),
            new("4", "Maroua", "4"),
            new("5", "Douala", "5"),
            new("6", "Garoua", "6"),
            new("7", "Bamenda", "7"),
            new("8", "Bafoussam", "8"),
            new("9", "Ebolowa", "9"),
            new("10", "Buea", "10"),
        
            // Mali
            new("11", "Bamako", "11"),
            new("12", "Sikasso", "12"),
            new("13", "Kayes", "13"),
        
            // Sénégal
            new("14", "Dakar", "15"),
            new("15", "Thiès", "16"),
        
            // Côte d'Ivoire
            new("16", "Abidjan", "18"),
            new("17", "Bouaké", "19"),
        
            // Nigeria
            new("18", "Lagos", "21"),
            new("19", "Abuja", "22")
        };
            Villes.AddRange(villes);

            // 🏦 2. Ajouter plusieurs banques et numéros de compte
            var banques = new List<AgencePaiement>
        {
            new("1", "UBA"),
            new("2", "Ecobank"),
            new("3", "Afriland First Bank"),
            new("4", "MTN Mobile Money"),
            new("5", "Orange Money"),
            new("6", "BICEC"),
            new("7", "Société Générale"),
            new("8", "Standard Chartered Bank")
        };
            AgencePaiements.AddRange(banques);

            var comptes = new List<NumeroCompteAgence>
        {
            new("1", "123456789", "1"),
            new("2", "987654321", "2"),
            new("3", "456789123", "3"),
            new("4", "112233445", "4"),
            new("5", "998877665", "5"),
            new("6", "000000001", "6"),
            new("7", "111222333", "7"),
            new("8", "444555666", "8"),
            new("9", "999888777", "1"),
            new("10", "555444333", "2")
        };
            NumeroCompteAgences.AddRange(comptes);


            var facs = new List<Faculte>
        {
            new("1", "Faculté des Sciences"), new("2", "Faculté des Lettres et Sciences de l'Éducation"),
            new("3", "Faculté de Médecine"), new("4", "Faculté de Droit"),
            new("5", "Faculté d'Économie et Gestion"), new("6", "Faculté des Sciences de l'Ingénieur")
        };
            Facultes.AddRange(facs);

            var filieres = new List<Filiere>
        {
            new("1", "Informatique", false, "1"), new("2", "Mathématiques", false, "1"),
            new("3", "Physique", false, "1"), new("4", "Chimie", false, "1"),
            new("5", "Biologie", false, "1"), new("6", "Géologie", false, "1"),
            new("7", "Lettres Modernes", false, "2"), new("8", "Philosophie", false, "2"),
            new("9", "Psychologie", false, "2"), new("10", "Sociologie", false, "2"),
            new("11", "Droit Privé", false, "4"), new("12", "Droit Public", false, "4"),
            new("13", "Économie Appliquée", false, "5"), new("14", "Gestion d'Entreprise", false, "5"),
            new("15", "Finance et Comptabilité", false, "5"), new("16", "Génie Civil", false, "6"),
            new("17", "Génie Électrique", false, "6"), new("18", "Génie Mécanique", false, "6")
        };
            Filieres.AddRange(filieres);

            var departements = new List<Departement>
        {
            new("1", "Informatique", "1"),
            new("2", "Mathématiques", "1"),
            new("3", "Physique", "1"),
            new("4", "Chimie", "1"),
            new("5", "Biologie", "1"),
            new("6", "Lettres Modernes", "2"),
            new("7", "Philosophie", "2"),
            new("8", "Sociologie", "2"),
            new("9", "Psychologie", "2"),
            new("10", "Sciences de l'Éducation", "2")
        };
            Departements.AddRange(departements);


            // 🎯 4. Ajouter spécialités
            var specialites = new List<Specialite>
        {
            new("1", "Génie Logiciel", "1", Niveau.L1), new("2", "Mathématiques Appliquées", "2", Niveau.L1),
            new("3", "Physique Quantique", "3", Niveau.L1), new("4", "Linguistique", "4", Niveau.L1),
            new("5", "Psychologie Cognitive", "5", Niveau.M2), new("6", "Génie Électrique Avancé", "18", Niveau.M1)
        };
            Specialites.AddRange(specialites);

            // 📅 5. Ajouter années académiques
            // Années académiques
            Annees.AddRange(new List<Annee>
        {
            new("1", "2022-2023"),
            new("2", "2023-2024")
        });
        }
    }
}
