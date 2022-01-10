using AutoMapper;
using Integration_Class_Library.Models;
using Integration_Class_Library.Tendering.Models;

namespace Integration_API.DTO.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NewPharmacyDTO, Pharmacy>();

            CreateMap<TenderOffer, TenderOfferDTO>()
                .ForMember(dest => dest.TenderingOfferItems, opt => opt.MapFrom(src => src.TenderOfferItems))
                .ForMember(dest => dest.PriceForAllAvailable, opt => opt.MapFrom(src => src.PriceForAllAvailable.ToString()))
                .ForMember(dest => dest.PriceForAllRequired, opt => opt.MapFrom(src => src.PriceForAllRequired.ToString()))
                .ForMember(dest => dest.TotalNumberMissingMedicine, opt => opt.MapFrom(src => src.TotalNumberMissingMedicine.ToString()));

        }
    }
}
