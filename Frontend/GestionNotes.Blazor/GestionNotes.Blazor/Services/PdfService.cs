namespace GestionNotes.Blazor.Services
{
    public class PdfService(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<byte[]> GetPreinscriptionPdfAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"api/CreatePreinscription/{id}/pdf");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsByteArrayAsync();
        }
    }
}
