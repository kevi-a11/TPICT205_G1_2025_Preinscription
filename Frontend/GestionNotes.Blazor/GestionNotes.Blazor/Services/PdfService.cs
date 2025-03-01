using Microsoft.JSInterop;

namespace GestionNotes.Blazor.Services
{
    public class PdfService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsRuntime;

        public PdfService(HttpClient httpClient, IJSRuntime jsRuntime)
        {
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;
        }

        // Méthode pour récupérer le PDF en base64 pour l'affichage dans l'iframe
        public async Task<string> GetPreinscriptionPdfBase64Async(Guid id)
        {
            var response = await _httpClient.GetAsync($"api/CreatePreinscription/{id}/pdf");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erreur lors du chargement du PDF.");
            }

            var pdfBytes = await response.Content.ReadAsByteArrayAsync();
            return Convert.ToBase64String(pdfBytes);
        }

        // Méthode pour récupérer le PDF sous forme de byte[] pour le téléchargement
        public async Task<byte[]> GetPreinscriptionPdfAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"api/CreatePreinscription/{id}/pdf");

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsByteArrayAsync();
        }

        // Méthode pour télécharger le PDF (via JS)
        public async Task DownloadPreinscriptionPdfAsync(Guid id)
        {
            var pdfBytes = await GetPreinscriptionPdfAsync(id);
            var base64Pdf = Convert.ToBase64String(pdfBytes);
            var fileName = "Preinscription.pdf";

            await _jsRuntime.InvokeVoidAsync("downloadFile", fileName, base64Pdf);
        }
    }
}
