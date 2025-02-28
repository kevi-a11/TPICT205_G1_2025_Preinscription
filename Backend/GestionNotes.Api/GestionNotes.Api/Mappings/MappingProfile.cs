using AutoMapper;
using GestionNotes.Api.DTOs;
using GestionNotes.Api.Models;
using GestionNotes.Api.Models.Enums;

namespace GestionNotes.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Configuration de mappage pour PreinscriptionEtudiantDTO et PreinscriptionEtudiant
            CreateMap<PreinscriptionEtudiantDTO, PreinscriptionEtudiant>()
                .ForMember(dest => dest.Sexe, opt => opt.MapFrom(src => Enum.Parse<Sexe>(src.Sexe)))
                .ForMember(dest => dest.LangueDominante, opt => opt.MapFrom(src => Enum.Parse<Langue>(src.LangueDominante)))
                .ForMember(dest => dest.StatutMatrimonial, opt => opt.MapFrom(src => Enum.Parse<StatutMatrimonial>(src.StatutMatrimonial)))
                .ForMember(dest => dest.SituationProfessionnelle, opt => opt.MapFrom(src => Enum.Parse<SituationPro>(src.SituationProfessionnelle)))
                .ForMember(dest => dest.TypeDiplome, opt => opt.MapFrom(src => Enum.Parse<TypeDiplome>(src.TypeDiplome)))
                .ForMember(dest => dest.OrganismeDelivrance, opt => opt.MapFrom(src => Enum.Parse<OrganismeDelivrance>(src.OrganismeDelivrance)))
                .ForMember(dest => dest.Serie, opt => opt.MapFrom(src => Enum.Parse<Serie>(src.Serie)))
                .ForMember(dest => dest.Niveau, opt => opt.MapFrom(src => Enum.Parse<Niveau>(src.Niveau)));

            // Configuration de mappage pour PreinscriptionEtudiant vers PreinscriptionEtudiantDTO
            CreateMap<PreinscriptionEtudiant, PreinscriptionEtudiantDTO>()
                .ForMember(dest => dest.Sexe, opt => opt.MapFrom(src => src.Sexe.ToString()))
                .ForMember(dest => dest.LangueDominante, opt => opt.MapFrom(src => src.LangueDominante.ToString()))
                .ForMember(dest => dest.StatutMatrimonial, opt => opt.MapFrom(src => src.StatutMatrimonial.ToString()))
                .ForMember(dest => dest.SituationProfessionnelle, opt => opt.MapFrom(src => src.SituationProfessionnelle.ToString()))
                .ForMember(dest => dest.TypeDiplome, opt => opt.MapFrom(src => src.TypeDiplome.ToString()))
                .ForMember(dest => dest.OrganismeDelivrance, opt => opt.MapFrom(src => src.OrganismeDelivrance.ToString()))
                .ForMember(dest => dest.Serie, opt => opt.MapFrom(src => src.Serie.ToString()))
                .ForMember(dest => dest.Niveau, opt => opt.MapFrom(src => src.Niveau.ToString()));
        }
    }
}


