using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Image;
using GestionNotes.Api.DTOs;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using GestionNotes.Api.Services.ServicesInterfaces;
using iTextImage = iText.Layout.Element.Image;
using System.Runtime.Versioning;

namespace GestionNotes.Api.Services
{
    public class PdfService : IPdfService
    {
        [SupportedOSPlatform("windows")]
        public byte[] GeneratePreinscriptionPdf(PreinscriptionEtudiantDTO etudiant)
        {
            using var stream = new MemoryStream();
            var writer = new PdfWriter(stream);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf);

            // Générer un code-barres unique de 12 chiffres
            var barcodeValue = Generate12DigitBarcode(etudiant.Id);

            var barcodeWriter = new BarcodeWriterPixelData
            {
                Format = BarcodeFormat.CODE_128,
                Options = new EncodingOptions
                {
                    Height = 50,
                    Width = 300
                }
            };
            var pixelData = barcodeWriter.Write(barcodeValue);
            using (var barcodeStream = new MemoryStream())
            {
                var barcodeBitmap = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb);
                var bitmapData = barcodeBitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
                try
                {
                    Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
                }
                finally
                {
                    barcodeBitmap.UnlockBits(bitmapData);
                }
                barcodeBitmap.Save(barcodeStream, ImageFormat.Png);
                var barcodeImageData = ImageDataFactory.Create(barcodeStream.ToArray());
                var barcodeImage = new iTextImage(barcodeImageData);
                document.Add(new Paragraph("Code-barres:"));
                document.Add(barcodeImage);
                document.Add(new Paragraph($"Code-barres (12 chiffres) : {barcodeValue}"));
            }

            // Ajouter le contenu du PDF ici
            document.Add(new Paragraph("Fiche de Préinscription"));
            document.Add(new Paragraph($"Nom: {etudiant.Nom}"));
            document.Add(new Paragraph($"Prénom: {etudiant.Prenom}"));
            document.Add(new Paragraph($"Sexe: {etudiant.Sexe}"));
            document.Add(new Paragraph($"Adresse Email: {etudiant.AdresseEmail}"));
            document.Add(new Paragraph($"Adresse Téléphonique: {etudiant.AdresseTelephonique}"));
            document.Add(new Paragraph($"Adresse Localisation: {etudiant.AdresseLocalisation}"));
            document.Add(new Paragraph($"Langue Dominante: {etudiant.LangueDominante}"));
            document.Add(new Paragraph($"Lieu de Naissance: {etudiant.LieuDeNaissance}"));
            document.Add(new Paragraph($"Date de Naissance: {etudiant.DateDeNaissance.ToShortDateString()}"));
            document.Add(new Paragraph($"Nationalité: {etudiant.Nationalite}"));
            document.Add(new Paragraph($"Numéro CNI: {etudiant.NumeroCNI}"));
            document.Add(new Paragraph($"Ville: {etudiant.Ville}"));
            document.Add(new Paragraph($"Statut Matrimonial: {etudiant.StatutMatrimonial}"));
            document.Add(new Paragraph($"Situation Professionnelle: {etudiant.SituationProfessionnelle}"));
            document.Add(new Paragraph($"Région d'Origine: {etudiant.RegionOrigine}"));
            document.Add(new Paragraph($"Nom du Père: {etudiant.NomPere}"));
            document.Add(new Paragraph($"Nom de la Mère: {etudiant.NomMere}"));
            document.Add(new Paragraph($"Adresse Téléphonique du Père: {etudiant.AdresseTelephoniquePere}"));
            document.Add(new Paragraph($"Adresse Téléphonique de la Mère: {etudiant.AdresseTelephoniqueMere}"));
            document.Add(new Paragraph($"Profession du Père: {etudiant.ProfessionPere}"));
            document.Add(new Paragraph($"Profession de la Mère: {etudiant.ProfessionMere}"));
            document.Add(new Paragraph($"Pratique Sport: {(etudiant.PratiqueSport ? "Oui" : "Non")}"));
            document.Add(new Paragraph($"Sport: {etudiant.Sport}"));
            document.Add(new Paragraph($"Antécédents Médicaux: {(etudiant.AntecedentsMedicaux ? "Oui" : "Non")}"));
            document.Add(new Paragraph($"Est Handicap: {(etudiant.EstHandicap ? "Oui" : "Non")}"));
            document.Add(new Paragraph($"Sous Traitement: {(etudiant.SousTraitement ? "Oui" : "Non")}"));
            document.Add(new Paragraph($"Maladie Chronique: {(etudiant.MaladieChronique ? "Oui" : "Non")}"));
            document.Add(new Paragraph($"Nom de la Maladie Chronique: {etudiant.NomMaladieChronique}"));
            document.Add(new Paragraph($"Handicap: {etudiant.Handicap}"));
            document.Add(new Paragraph($"Nom de la Maladie: {etudiant.NomMaladie}"));
            document.Add(new Paragraph($"Type de Diplôme: {etudiant.TypeDiplome}"));
            document.Add(new Paragraph($"Organisme de Délivrance: {etudiant.OrganismeDelivrance}"));
            document.Add(new Paragraph($"Série: {etudiant.Serie}"));
            document.Add(new Paragraph($"Date de Délivrance: {etudiant.DateDelivrance.ToShortDateString()}"));
            document.Add(new Paragraph($"Numéro de Reçu: {etudiant.NumeroRecu}"));
            document.Add(new Paragraph($"Année d'Obtention: {etudiant.AnneeObtention}"));
            document.Add(new Paragraph($"Moyenne: {etudiant.Moyenne}"));
            document.Add(new Paragraph($"Montant Payé: {etudiant.MontantPaye}"));
            document.Add(new Paragraph($"Numéro de Compte de Paiement: {etudiant.NumeroComptePaiement}"));
            document.Add(new Paragraph($"Agence de Paiement: {etudiant.AgencePaiement}"));
            document.Add(new Paragraph($"Date d'Impression du Reçu: {etudiant.DateImpressionRecu.ToShortDateString()}"));
            document.Add(new Paragraph($"Faculté: {etudiant.Faculte}"));
            document.Add(new Paragraph($"Choix Filière 1: {etudiant.ChoixFiliere1}"));
            document.Add(new Paragraph($"Choix Filière 2: {etudiant.ChoixFiliere2}"));
            document.Add(new Paragraph($"Choix Filière 3: {etudiant.ChoixFiliere3}"));
            document.Add(new Paragraph($"Niveau: {etudiant.Niveau}"));

            // Ajouter l'image de l'étudiant
            if (etudiant.ImageEtudiant != null && etudiant.ImageEtudiant.Length > 0)
            {
                try
                {
                    var imageData = ImageDataFactory.Create(Convert.FromBase64String(Convert.ToBase64String(etudiant.ImageEtudiant)));
                    var image = new iTextImage(imageData);
                    document.Add(new Paragraph("Image de l'étudiant:"));
                    document.Add(image);
                }
                catch (Exception ex)
                {
                    document.Add(new Paragraph("Erreur lors de l'ajout de l'image de l'étudiant: " + ex.Message));
                }
            }

            document.Close();
            return stream.ToArray();
        }

        private static string Generate12DigitBarcode(Guid id)
        {
            // Convertir l'ID en une chaîne de 12 chiffres
            var idString = id.ToString("N");
            var numericId = new string(idString.Where(char.IsDigit).ToArray());
            return numericId[..12].PadLeft(12, '0');
        }
    }
}

