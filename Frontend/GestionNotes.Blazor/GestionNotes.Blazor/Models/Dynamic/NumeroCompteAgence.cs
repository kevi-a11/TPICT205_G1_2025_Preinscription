namespace GestionNotes.Blazor.Models.Dynamic
{
    public class NumeroCompteAgence
    {
        public string Id { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string AgencePaiementId { get; set; } = string.Empty;

        // Constructeur par défaut
        public NumeroCompteAgence() { }

        // Constructeur avec paramètres
        public NumeroCompteAgence(string id, string numero, string agencePaiementId)
        {
            Id = id;
            Numero = numero;
            AgencePaiementId = agencePaiementId;
        }
    }
}
