using AutoMapper;
using Pokemon_Api.Dto;
using Pokemon_Api.Models;

namespace Pokemon_Api.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Pokemon Mappings
            _ = CreateMap<Pokemon, PokemonResponseDto>();
            CreateMap<PokemonCreateRequestDto, Pokemon>();
            CreateMap<PokemonUpdateRequestDto, Pokemon>();

            // Category Mappings
            CreateMap<Category, CategoryResponseDto>();
            CreateMap<CategoryCreateRequestDto, Category>();
            CreateMap<CategoryUpdateRequestDto, Category>();

            // Country Mappings
            CreateMap<Country, CountryResponseDto>();
            CreateMap<CountryCreateRequestDto, Country>();
            CreateMap<CountryUpdateRequestDto, Country>();

            // Owner Mappings
            CreateMap<Owner, OwnerResponseDto>()
                .ForMember(
                    dest => dest.Country,
                    opt => opt.MapFrom(src => src.Country == null ? string.Empty : src.Country.Name));
            CreateMap<OwnerCreateRequestDto, Owner>();
            CreateMap<OwnerUpdateRequestDto, Owner>();

            // Review Mappings
            CreateMap<Review, ReviewResponseDto>()
                .ForMember(
                    dest => dest.PokemonName,
                    opt => opt.MapFrom(src => src.Pokemon == null ? string.Empty : src.Pokemon.Name))
                .ForMember(
                    dest => dest.ReviewerName,
                    opt => opt.MapFrom(src => src.Reviewer == null ? string.Empty : $"{src.Reviewer.FirstName} {src.Reviewer.LastName}"));
            CreateMap<ReviewCreateRequestDto, Review>();
            CreateMap<ReviewUpdateRequestDto, Review>();

            // Reviewer Mappings
            CreateMap<Reviewer, ReviewerResponseDto>();
            CreateMap<ReviewerCreateRequestDto, Reviewer>();
            CreateMap<ReviewerUpdateRequestDto, Reviewer>();
        }
    }
}