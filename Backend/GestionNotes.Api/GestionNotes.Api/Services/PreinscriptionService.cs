using AutoMapper;
using GestionNotes.Api.Data;
using GestionNotes.Api.DTOs;
using GestionNotes.Api.Models;
using GestionNotes.Api.Models.Enums;
using GestionNotes.Api.Services.ServicesInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GestionNotes.Api.Services
{
    public class PreinscriptionService(GestionNotesDbContext context, IMapper mapper) : IPreinscriptionService
    {
        private readonly GestionNotesDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<bool> EnregistrerPreinscriptionAsync(PreinscriptionEtudiantDTO preinscriptionDto)
        {
            var entity = await _context.PreinscriptionsEtudiants.FindAsync(preinscriptionDto.Id);
            if (entity == null)
            {
                // Ajouter un nouvel enregistrement
                var preinscription = new PreinscriptionEtudiant
                {
                    Nom = preinscriptionDto.Nom,
                    Prenom = preinscriptionDto.Prenom,
                    Sexe = Enum.Parse<Sexe>(preinscriptionDto.Sexe),
                    AdresseEmail = preinscriptionDto.AdresseEmail,
                    AdresseTelephonique = preinscriptionDto.AdresseTelephonique,
                    AdresseLocalisation = preinscriptionDto.AdresseLocalisation,
                    LangueDominante = Enum.Parse<Langue>(preinscriptionDto.LangueDominante),
                    LieuDeNaissance = preinscriptionDto.LieuDeNaissance,
                    DateDeNaissance = preinscriptionDto.DateDeNaissance,
                    Nationalite = preinscriptionDto.Nationalite,
                    NumeroCNI = preinscriptionDto.NumeroCNI,
                    Ville = preinscriptionDto.Ville,
                    StatutMatrimonial = Enum.Parse<StatutMatrimonial>(preinscriptionDto.StatutMatrimonial),
                    SituationProfessionnelle = Enum.Parse<SituationPro>(preinscriptionDto.SituationProfessionnelle),
                    RegionOrigine = preinscriptionDto.RegionOrigine,
                    NomPere = preinscriptionDto.NomPere,
                    NomMere = preinscriptionDto.NomMere,
                    AdresseTelephoniquePere = preinscriptionDto.AdresseTelephoniquePere,
                    AdresseTelephoniqueMere = preinscriptionDto.AdresseTelephoniqueMere,
                    ProfessionPere = preinscriptionDto.ProfessionPere,
                    ProfessionMere = preinscriptionDto.ProfessionMere,
                    PratiqueSport = preinscriptionDto.PratiqueSport,
                    Sport = preinscriptionDto.Sport,
                    AntecedentsMedicaux = preinscriptionDto.AntecedentsMedicaux,
                    EstHandicap = preinscriptionDto.EstHandicap,
                    SousTraitement = preinscriptionDto.SousTraitement,
                    MaladieChronique = preinscriptionDto.MaladieChronique,
                    NomMaladieChronique = preinscriptionDto.NomMaladieChronique,
                    Handicap = preinscriptionDto.Handicap,
                    NomMaladie = preinscriptionDto.NomMaladie,
                    TypeDiplome = Enum.Parse<TypeDiplome>(preinscriptionDto.TypeDiplome),
                    OrganismeDelivrance = Enum.Parse<OrganismeDelivrance>(preinscriptionDto.OrganismeDelivrance),
                    Serie = Enum.Parse<Serie>(preinscriptionDto.Serie),
                    DateDelivrance = preinscriptionDto.DateDelivrance,
                    NumeroRecu = preinscriptionDto.NumeroRecu,
                    AnneeObtention = preinscriptionDto.AnneeObtention,
                    Moyenne = preinscriptionDto.Moyenne,
                    MontantPaye = preinscriptionDto.MontantPaye,
                    NumeroComptePaiement = preinscriptionDto.NumeroComptePaiement,
                    AgencePaiement = preinscriptionDto.AgencePaiement,
                    DateImpressionRecu = preinscriptionDto.DateImpressionRecu,
                    Faculte = preinscriptionDto.Faculte,
                    ChoixFiliere1 = preinscriptionDto.ChoixFiliere1,
                    ChoixFiliere2 = preinscriptionDto.ChoixFiliere2,
                    ChoixFiliere3 = preinscriptionDto.ChoixFiliere3,
                    Niveau = Enum.Parse<Niveau>(preinscriptionDto.Niveau),
                    ImageEtudiant = preinscriptionDto.ImageEtudiant
                };

                _context.PreinscriptionsEtudiants.Add(preinscription);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    preinscriptionDto.Id = preinscription.Id;
                    return true;
                }
                return result > 0;
            }
            else
            {
                // Mettre à jour l'enregistrement existant
                _mapper.Map(preinscriptionDto, entity);
                _context.PreinscriptionsEtudiants.Update(entity);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<PreinscriptionEtudiantDTO> GetByIdAsync(Guid id)
        {
            var entity = await _context.PreinscriptionsEtudiants.FindAsync(id);
            return entity == null
                ? throw new KeyNotFoundException($"PreinscriptionEtudiant with ID {id} not found.")
                : _mapper.Map<PreinscriptionEtudiantDTO>(entity);
        }

        public async Task<Guid> GetIdByBarcodeAsync(string barcode)
        {
            var etudiants = await _context.PreinscriptionsEtudiants.ToListAsync();
            var etudiant = etudiants.FirstOrDefault(e => Generate12DigitBarcode(e.Id) == barcode);
            return etudiant?.Id ?? Guid.Empty;
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
