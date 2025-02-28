using GestionNotes.Api.DTOs;
using GestionNotes.Api.Services.ServicesInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionNotes.Api.Controllers
{
    [Route("api/CreatePreinscription")]
    [ApiController]
    public class PreinscriptionController(IPreinscriptionService preinscriptionService, IPdfService pdfService) : ControllerBase
    {
        private readonly IPreinscriptionService _preinscriptionService = preinscriptionService;
        private readonly IPdfService _pdfService = pdfService;

        [HttpPost]
        public async Task<IActionResult> EnregistrerPreinscription([FromBody] PreinscriptionEtudiantDTO preinscriptionDto)
        {
            var resultat = await _preinscriptionService.EnregistrerPreinscriptionAsync(preinscriptionDto);

            if (resultat)
            {
                // Lorsque vous renvoyez le DTO, l'ID sera désormais correct
                return CreatedAtAction(nameof(EnregistrerPreinscription), new { id = preinscriptionDto.Id }, preinscriptionDto);
            }

            return BadRequest("Échec de l'enregistrement de la préinscription.");
        }

        [HttpGet("{id}/pdf")]
        public async Task<IActionResult> GetPreinscriptionPdf(Guid id)
        {
            var etudiant = await _preinscriptionService.GetByIdAsync(id);
            if (etudiant == null)
            {
                return NotFound();
            }

            var pdfBytes = _pdfService.GeneratePreinscriptionPdf(etudiant);
            return File(pdfBytes, "application/pdf", "Preinscription.pdf");
        }

        [HttpPost("modifier")]
        public async Task<IActionResult> ModifierPreinscription([FromBody] string barcode)
        {
            if (string.IsNullOrEmpty(barcode))
            {
                return BadRequest("Le champ code-barres est requis.");
            }

            var id = await _preinscriptionService.GetIdByBarcodeAsync(barcode);
            if (id == Guid.Empty)
            {
                return NotFound("Code-barres invalide.");
            }

            var etudiant = await _preinscriptionService.GetByIdAsync(id);
            if (etudiant == null)
            {
                return NotFound("Étudiant non trouvé.");
            }

            return Ok(etudiant);
        }


        [HttpPut("modifier")]
        public async Task<IActionResult> ModifierPreinscription([FromBody] PreinscriptionEtudiantDTO preinscriptionDto)
        {
            var resultat = await _preinscriptionService.EnregistrerPreinscriptionAsync(preinscriptionDto);

            if (resultat)
            {
                return Ok(preinscriptionDto);
            }

            return BadRequest("Échec de la modification de la préinscription.");
        }
    }
}
