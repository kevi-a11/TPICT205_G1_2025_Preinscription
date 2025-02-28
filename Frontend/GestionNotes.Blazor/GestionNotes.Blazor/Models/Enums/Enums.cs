using System.Text.Json.Serialization;

namespace GestionNotes.Blazor.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TypeDiplome
    {
        BAC,
        Licence,
        Master,
        Doctorat
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatutPreinscription
    {
        Cours,
        Valide,
        Refuse
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatutMatrimonial
    {
        Celibataire,
        Marie,
        Divorce,
        Veuf
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SituationPro
    {
        Etudiant,
        Salarie,
        Independant,
        Retraite,
        SansEmploi
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Sexe
    {
        Homme,
        Femme,
        Autre
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Serie
    {
        C,
        D,
        A,
        GCE,
        TI
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrganismeDelivrance
    {
        OBC,
        Autre

    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Niveau
    {
        L1,
        L2,
        L3,
        M1,
        M2
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Langue
    {
        Francais,
        Anglais,
        Autre
    }
}
