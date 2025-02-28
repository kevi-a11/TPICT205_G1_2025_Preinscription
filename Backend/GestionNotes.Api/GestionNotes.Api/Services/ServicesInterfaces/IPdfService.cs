using GestionNotes.Api.DTOs;

namespace GestionNotes.Api.Services.ServicesInterfaces
{
    public interface IPdfService
    {
        byte[] GeneratePreinscriptionPdf(PreinscriptionEtudiantDTO etudiant);
    }
}
