using AutoMapper;
using BigBazarData.Entity;
using BigBazarModels.Models;

namespace BigBazarAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, customer>().ReverseMap();
            // .ForMember(x => x.itemId, y => y.MapFrom(y=>y.itemId));
            CreateMap<Store, store>().ReverseMap();
            CreateMap<WareHouse, wareHouse>().ReverseMap();
            //CreateMap<List<WareHouse>, wareHouse>().ReverseMap();
        }
    }
}
