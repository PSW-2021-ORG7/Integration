using AutoMapper;
using Integration_Class_Library.Models;

namespace Integration_API.DTO.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NewPharmacyDTO, Pharmacy>();

        }
    }
}
