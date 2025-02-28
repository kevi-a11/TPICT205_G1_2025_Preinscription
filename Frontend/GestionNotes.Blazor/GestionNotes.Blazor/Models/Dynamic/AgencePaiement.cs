namespace GestionNotes.Blazor.Models.Dynamic
{
    public class AgencePaiement
    {
        public string? Id { get; set; }
        public string? Nom { get; set; }
        public List<NumeroCompteAgence> NumeroComptes { get; set; } = new();


        public AgencePaiement() { }

        public AgencePaiement(string id, string nom)
        {
            Id = id;
            Nom = nom;
        }

        public List<NumeroCompteAgence> GetNumro()
        {
            return NumeroComptes ?? new List<NumeroCompteAgence>();
        }


        public NumeroCompteAgence? GetNumeroById(string numeroId)
        {
            return NumeroComptes.FirstOrDefault(n => n.Id == numeroId);

        }


        public void AjouterNumeroCompte(NumeroCompteAgence numeroCompte)
        {
            NumeroComptes.Add(numeroCompte);
        }
    }
}
