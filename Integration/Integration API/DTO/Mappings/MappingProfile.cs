using AutoMapper;
using Integration_Class_Library.Models;
using Integration_Class_Library.TenderingEntity.Models;

namespace Integration_API.DTO.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NewMedicineDTO, Medicine>();
            CreateMap<NewPharmacyDTO, Pharmacy>();

        }
    }
}
