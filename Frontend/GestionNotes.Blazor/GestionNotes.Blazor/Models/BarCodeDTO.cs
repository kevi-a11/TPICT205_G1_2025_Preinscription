using System.ComponentModel.DataAnnotations;

namespace GestionNotes.Blazor.Models
{
    public class BarcodeDTO
    {
        [Required(ErrorMessage = "Le code-barre est requis.")]
        public string? CodeBarre { get; set; }
    }

}
