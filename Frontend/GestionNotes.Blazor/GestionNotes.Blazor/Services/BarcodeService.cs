using GestionNotes.Blazor.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GestionNotes.Blazor.Services
{
    public class BarcodeService
    {
        private readonly HttpClient _httpClient;

        public BarcodeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Méthode pour récupérer les données de l'étudiant avec le code-barre
        public async Task<PreinscriptionEtudiantDTO> GetStudentByBarcodeAsync(string barcode)
        {
            var response = await _httpClient.PostAsJsonAsync("api/CreatePreinscription/modifier", barcode);

            if (response.IsSuccessStatusCode)
            {
                // Si la réponse est valide, on retourne les données de l'étudiant
                return await response.Content.ReadFromJsonAsync<PreinscriptionEtudiantDTO>();
            }

            return null;
        }

        // Méthode pour modifier les données de préinscription via PUT
        public async Task<bool> UpdatePreinscriptionAsync(PreinscriptionEtudiantDTO preinscriptionDto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/CreatePreinscription/modifier", preinscriptionDto);

            return response.IsSuccessStatusCode;
        }
    }
}
