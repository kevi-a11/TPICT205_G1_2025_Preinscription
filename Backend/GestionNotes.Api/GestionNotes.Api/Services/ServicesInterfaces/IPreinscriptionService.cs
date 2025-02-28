using GestionNotes.Api.DTOs;

namespace GestionNotes.Api.Services.ServicesInterfaces
{
    public interface IPreinscriptionService
    {
        Task<bool> EnregistrerPreinscriptionAsync(PreinscriptionEtudiantDTO preinscriptionDto);
        Task<PreinscriptionEtudiantDTO> GetByIdAsync(Guid id);
        Task<Guid> GetIdByBarcodeAsync(string barcode);
    }
}
