using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using GestionNotes.Blazor.Models;
using Microsoft.Extensions.Logging;

namespace GestionNotes.Blazor.Services
{
    public class PreinscriptionService(HttpClient httpClient, ILogger<PreinscriptionService> logger, DatabaseContext dbContext)
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly ILogger<PreinscriptionService> _logger = logger;
        private readonly DatabaseContext _dbContext = dbContext;

        public async Task<Guid?> EnregistrerPreinscriptionAsync(PreinscriptionEtudiantDTO preinscriptionDto)
        {
            try
            {
                // Convertir les identifiants en noms
                preinscriptionDto.Nationalite = _dbContext.Pays.FirstOrDefault(p => p.Id == preinscriptionDto.Nationalite)?.Nom ?? preinscriptionDto.Nationalite;
                preinscriptionDto.Ville = _dbContext.Villes.FirstOrDefault(v => v.Id == preinscriptionDto.Ville)?.Nom ?? preinscriptionDto.Ville;
                preinscriptionDto.RegionOrigine = _dbContext.Regions.FirstOrDefault(r => r.Id == preinscriptionDto.RegionOrigine)?.Nom ?? preinscriptionDto.RegionOrigine;
                preinscriptionDto.NumeroComptePaiement = _dbContext.NumeroCompteAgences.FirstOrDefault(n => n.Id == preinscriptionDto.NumeroComptePaiement)?.Numero ?? preinscriptionDto.NumeroComptePaiement;
                preinscriptionDto.AgencePaiement = _dbContext.AgencePaiements.FirstOrDefault(a => a.Id == preinscriptionDto.AgencePaiement)?.Nom ?? preinscriptionDto.AgencePaiement;
                preinscriptionDto.Faculte = _dbContext.Facultes.FirstOrDefault(f => f.Id == preinscriptionDto.Faculte)?.Nom ?? preinscriptionDto.Faculte;
                preinscriptionDto.ChoixFiliere1 = _dbContext.Filieres.FirstOrDefault(f => f.Id == preinscriptionDto.ChoixFiliere1)?.Nom ?? preinscriptionDto.ChoixFiliere1;
                preinscriptionDto.ChoixFiliere2 = _dbContext.Filieres.FirstOrDefault(f => f.Id == preinscriptionDto.ChoixFiliere2)?.Nom ?? preinscriptionDto.ChoixFiliere2;
                preinscriptionDto.ChoixFiliere3 = _dbContext.Filieres.FirstOrDefault(f => f.Id == preinscriptionDto.ChoixFiliere3)?.Nom ?? preinscriptionDto.ChoixFiliere3;

                var response = await _httpClient.PostAsJsonAsync("api/CreatePreinscription", preinscriptionDto);
                if (response.IsSuccessStatusCode)
                {
                    var createdPreinscription = await response.Content.ReadFromJsonAsync<PreinscriptionEtudiantDTO>();
                    _logger.LogInformation("Préinscription réussie.");
                    return createdPreinscription?.Id;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    _logger.LogError("Échec de la préinscription : {ErrorContent}", errorContent);
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Erreur lors de l'envoi de la requête HTTP.");
                return null;
            }
        }


    }
}
